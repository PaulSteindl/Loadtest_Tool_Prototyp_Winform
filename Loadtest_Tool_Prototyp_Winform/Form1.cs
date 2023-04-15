using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Xml.Serialization;
using XmlSchemaClassGenerator;
using System.ComponentModel.Design;
using System.CodeDom;
using System.Reflection.Emit;

namespace Loadtest_Tool_Prototyp_Winform
{
    public partial class Form1 : Form
    {
        private string _xsdFile;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private Type _rootType;

        public Form1()
        {
            InitializeComponent();
        }

        private void selectXsdBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".xsd";
            dlg.Filter = "XSD Files (*.xsd)|*.xsd";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _xsdFile = dlg.FileName;
                selectXsdTxt.Text = dlg.SafeFileName;
            }
        }

        private void loadXsdBtn_Click(object sender, EventArgs e)
        {
            var generator = new Generator
            {
                OutputFolder = ".\\",
                Log = s => Console.Out.WriteLine(s),
                GenerateNullables = true,
                NamespaceProvider = new Dictionary<NamespaceKey, string>
                {
                    { new NamespaceKey(), "tmpXmlClass" }
                }
                .ToNamespaceProvider(new GeneratorConfiguration { NamespacePrefix = "PS" }.NamespaceProvider.GenerateNamespace)
            };

            generator.Generate(new[] { _xsdFile });

            // Lese den generierten Code aus den erstellten Dateien
            StringWriter generatedCode = new StringWriter();
            string file = Directory.GetFiles(".\\", "tmpXmlClass.cs", SearchOption.AllDirectories).First();
            using (StreamReader reader = new StreamReader(file))
            {
                generatedCode.WriteLine(reader.ReadToEnd());
            }

            using (CSharpCodeProvider codeProvider = new CSharpCodeProvider())
            {
                CompilerParameters compilerParameters = new CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true,
                    IncludeDebugInformation = false,
                    ReferencedAssemblies = { "System.Xml.dll", "System.Runtime.Serialization.dll", "System.dll", "System.ComponentModel.DataAnnotations.dll" }
                };

                var compileResults = codeProvider.CompileAssemblyFromSource(compilerParameters, generatedCode.ToString());

                if (compileResults.Errors.HasErrors)
                {
                    Console.WriteLine("Fehler beim Kompilieren des generierten Codes:");
                    foreach (CompilerError error in compileResults.Errors)
                    {
                        Console.WriteLine($"{error.FileName}({error.Line},{error.Column}): {error.ErrorText}");
                    }
                }
                else
                {
                    XmlSchema schema;
                    using (var stream = new StreamReader(_xsdFile))
                    {
                        schema = XmlSchema.Read(stream, null);
                    }

                    // Finde das Root-Element
                    string rootElement = String.Empty;
                    foreach (XmlSchemaObject item in schema.Items)
                    {
                        if (item is XmlSchemaElement element)
                        {
                            rootElement = char.ToUpper(element.Name[0]) + element.Name.Substring(1);
                            break;
                        }
                    }

                    // Hole die generierte Hauptklasse aus dem kompilierten Assembly
                    //_rootType = compileResults.CompiledAssembly.GetType(String.Format("tmpXmlClass.{0}", rootElement));
                    _rootType = compileResults.CompiledAssembly.GetType("tmpXmlClass.ShiporderShipto");
                    xmlPropertView.SelectedObject = Activator.CreateInstance(_rootType);
                }
            }
        }

        private async void sendRequestsBtn_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            List<Task> tasks = new List<Task>();
            Stopwatch stopwatch = new Stopwatch();

            CancellationToken token = _cts.Token;
            _cts.CancelAfter(new TimeSpan(0, 0, Convert.ToInt32(this.durationNr.Value)));
            string url = String.Format("{0}:{1}/{2}", this.urlTxt.Text, this.portTxt.Text, this.pathTxt.Text);
            int completedRequests = 0;
            double currentRequest = 0;
            int totalRequests = Convert.ToInt32(this.threadsNumberNr.Value * this.loopCountNr.Value);
            int rampupPeriode = Convert.ToInt32(this.rampupPeriodeNr.Value);

            Console.WriteLine("Starting load test...");

            stopwatch.Start();

            try
            {
                for (currentRequest = 0; currentRequest < totalRequests; currentRequest++)
                {
                    token.ThrowIfCancellationRequested();

                    double rampUpFactor = currentRequest / totalRequests;
                    int rampUpDelay = Convert.ToInt32(rampupPeriode * rampUpFactor * 1000);

                    tasks.Add(Task.Run(async () =>
                    {
                        await Task.Delay(rampUpDelay);
                        await ExecuteRequest(httpClient, url);
                        int currentCompleted = Interlocked.Increment(ref completedRequests);
                        Console.WriteLine($"{currentCompleted} requests completed.");
                    }));

                    if (tasks.Count >= this.threadsNumberNr.Value)
                    {
                        var completedTask = await Task.WhenAny(tasks);
                        tasks.Remove(completedTask);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Loop has been broken by the timer.");
            }

            await Task.WhenAll(tasks);

            stopwatch.Stop();

            Console.WriteLine($"Load test completed. {currentRequest} requests in {stopwatch.ElapsedMilliseconds} ms.");
        }

        private static async Task ExecuteRequest(HttpClient httpClient, string url)
        {
            try
            {
                // Replace this code with the actual code to send the SOAP request.
                // This is just a simple GET request for demonstration purposes.
                //var response = await httpClient.GetAsync(url);
                //response.EnsureSuccessStatusCode();

                await Task.Delay(1000);
                Console.WriteLine($"Request: {url}, {Task.CurrentId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            //Todo cleanup
        }
    }    
}
