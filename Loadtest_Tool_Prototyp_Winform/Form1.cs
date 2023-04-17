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
using System.Reflection;
using System.Xml;
using Bogus;
using Bogus.Bson;
using System.Collections;

namespace Loadtest_Tool_Prototyp_Winform
{
    public partial class Form1 : Form
    {
        private string _xsdFilePath;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        #region Helper
        public static void FillWithDummyData<T>(T obj)
        {
            var faker = new Faker();
            Dictionary<Type, Action<PropertyInfo>> FillPropertyDic = new Dictionary<Type, Action<PropertyInfo>>
            {
                { typeof(string), (PropertyInfo property) => property.SetValue(obj, faker.Random.String2(10)) },
                { typeof(int), (PropertyInfo property) => property.SetValue(obj, faker.Random.Int()) },
                { typeof(DateTime), (PropertyInfo property) => property.SetValue(obj, DateTime.Now) }
            };

            var properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!property.CanWrite) continue;

                if (FillPropertyDic.ContainsKey(property.PropertyType))
                {
                    FillPropertyDic[property.PropertyType](property);
                    continue;
                }

                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    continue;
                }

                if (!property.PropertyType.IsValueType && property.PropertyType != typeof(string))
                {
                    object subclass = Activator.CreateInstance(property.PropertyType);
                    FillWithDummyData(subclass); // Rekursiver Aufruf, um die Subklasse zu befüllen
                    TypeDescriptor.AddProvider(new ExpandableTypeDescriptionProvider(), property.PropertyType);
                    property.SetValue(obj, subclass);
                }
            }
        }
        #endregion

        private void selectXsdBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".xsd";
            dlg.Filter = "XSD Files (*.xsd)|*.xsd";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _xsdFilePath = dlg.FileName;
                selectXsdTxt.Text = dlg.SafeFileName;
            }
        }

        private void loadXsdBtn_Click(object sender, EventArgs e)
        {
            //Liest das File aus
            XmlSchema schema;
            XmlSchemas schemas = new XmlSchemas();

            using (XmlReader reader = XmlReader.Create(_xsdFilePath))
            {
                schema = XmlSchema.Read(reader, null);
            }
            schemas.Add(schema);

            CodeNamespace codeNamespace = new CodeNamespace("GeneratedNamespace");
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
            codeCompileUnit.Namespaces.Add(codeNamespace);

            XmlSchemaImporter schemaImporter = new XmlSchemaImporter(schemas);
            XmlCodeExporter codeExporter = new XmlCodeExporter(codeNamespace);

            XmlSchemaElement schemaElement = schema.Elements.Values.Cast<XmlSchemaElement>().First();
            XmlTypeMapping typeMapping = schemaImporter.ImportTypeMapping(schemaElement.QualifiedName);
            codeExporter.ExportTypeMapping(typeMapping);

            // Kompiliert die temporäre C#-Klasse zur Laufzeit
            var compilerParameters = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                ReferencedAssemblies = { "System.dll", "System.Xml.dll" }
            };

            var codeProvider = new CSharpCodeProvider();
            CompilerResults compilerResults = codeProvider.CompileAssemblyFromDom(compilerParameters, codeCompileUnit);

            if (compilerResults.Errors.HasErrors)
            {
                Console.WriteLine("Fehler beim Kompilieren des generierten Codes:");
                foreach (CompilerError error in compilerResults.Errors)
                {
                    Console.WriteLine($"{error.FileName}({error.Line},{error.Column}): {error.ErrorText}");
                }
            }

            Assembly generatedAssembly = compilerResults.CompiledAssembly;
            Type _rootType = generatedAssembly.GetTypes()[0];

            // Erstellt eine Instanz der generierten Klasse und befüllt sie
            object createdObject = Activator.CreateInstance(_rootType);
            FillWithDummyData(createdObject);
            xmlPropertView.SelectedObject = createdObject;
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
