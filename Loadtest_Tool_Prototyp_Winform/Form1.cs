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
using AutoBogus;
using System.Net.Http.Headers;
using System.Net;

namespace Loadtest_Tool_Prototyp_Winform
{
    public partial class LoadTestTool : Form
    {
        private string _xsdFilePath;
        private string _xmlCreatePath;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private object _createdObject;
        private static List<string> _loadedXmls = new List<string>();
        private static List<CollectedData> _collectedDatas = new List<CollectedData>();

        public LoadTestTool()
        {
            InitializeComponent();
        }

        #region Helper
        private static void FillWithDummyData<T>(T obj)
        {
            var faker = new Faker();
            Dictionary<Type, Action<PropertyInfo>> FillPropertyDic = new Dictionary<Type, Action<PropertyInfo>>
            {
                { typeof(string), (PropertyInfo property) => property.SetValue(obj, faker.Random.String2(10)) },
                { typeof(char), (PropertyInfo property) => property.SetValue(obj, faker.Random.Char()) },
                { typeof(bool), (PropertyInfo property) => property.SetValue(obj, faker.Random.Bool()) },

                { typeof(int), (PropertyInfo property) => property.SetValue(obj, faker.Random.Int()) },
                { typeof(decimal), (PropertyInfo property) => property.SetValue(obj, faker.Random.Decimal()) },
                { typeof(float), (PropertyInfo property) => property.SetValue(obj, faker.Random.Float()) },
                { typeof(long), (PropertyInfo property) => property.SetValue(obj, faker.Random.Long()) },
                { typeof(short), (PropertyInfo property) => property.SetValue(obj, faker.Random.Short()) },
                { typeof(byte), (PropertyInfo property) => property.SetValue(obj, faker.Random.Byte()) },

                { typeof(Guid), (PropertyInfo property) => property.SetValue(obj, faker.Random.Guid()) },
                { typeof(DateTime), (PropertyInfo property) => property.SetValue(obj, DateTime.Now) },
                { typeof(Uri), (PropertyInfo property) => property.SetValue(obj, new Uri("https://github.com/PaulSteindl")) }
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
                    object subclassItem1 = Activator.CreateInstance(property.PropertyType.GetElementType());
                    object subclassItem2 = Activator.CreateInstance(property.PropertyType.GetElementType());

                    FillWithDummyData(subclassItem1); // Rekursiver Aufruf, um die Subklasse zu befüllen
                    FillWithDummyData(subclassItem2); // Rekursiver Aufruf, um die Subklasse zu befüllen

                    var subclassList = Array.CreateInstance(property.PropertyType.GetElementType(), 2);
                    subclassList.SetValue(subclassItem1, 0);
                    subclassList.SetValue(subclassItem2, 1);

                    property.SetValue(obj, subclassList);

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

        private void CreateXmlListForRequests(int totalRequestAmount)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(_createdObject.GetType());
            _loadedXmls.Clear();

            for (int i = 0; i < totalRequestAmount; i++)
            {
                FillWithDummyData(_createdObject);

                using (StringWriter stringWriter = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
                    {
                        xmlSerializer.Serialize(xmlWriter, _createdObject);
                        _loadedXmls.Add($@"<?xml version=""1.0"" encoding=""utf-8""?>
                            <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                                <soap12:Body>
                                    {stringWriter.ToString()}
                                </soap12:Body>
                            </soap12:Envelope>");
                    }
                }
            }
        }

        private void GenerateReport(double requestNr)
        {
            Results frm = new Results();

            frm.requestsTxt.Text = requestNr.ToString();

            long total = 0;
            long min = _collectedDatas.First().Time;
            long max = 0;
            int errorCount = 0;
            foreach (CollectedData data in _collectedDatas) 
            {
                total += data.Time;

                if (min > data.Time) min = data.Time;
                if (max < data.Time) max = data.Time;
                if (!data.Success) { errorCount++; }

                frm.resultListView.Items.Add(new ListViewItem(new string[] 
                { 
                    data.Time.ToString(),
                    data.Success.ToString(),
                    data.SendKb.ToString(),
                    data.ReceiveKb.ToString(),
                    data.Send.ToString(),
                    data.Response.ToString()
                }));

                Console.WriteLine(data.Response);
            };

            frm.averageTimeTxt.Text = (total / requestNr).ToString();
            frm.minTimeTxt.Text = (min).ToString();
            frm.maxTimeTxt.Text = (max).ToString();
            frm.errorMarginTxt.Text = ((errorCount / requestNr) * 100).ToString() + "%";

            frm.Show();
            _collectedDatas.Clear();

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
                this.loadXsdBtn.Enabled = true;
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
            _createdObject = Activator.CreateInstance(_rootType);
            FillWithDummyData(_createdObject);
            xmlPropertView.SelectedObject = _createdObject;
            this.sendRequestsBtn.Enabled = true;
            this.selectXmlsPathBtn.Enabled = true;
        }

        private async void sendRequestsBtn_Click(object sender, EventArgs e)
        {
            this.stopBtn.Enabled = true;

            HttpClient httpClient = new HttpClient();
            List<Task> tasks = new List<Task>();
            Stopwatch stopwatch = new Stopwatch();

            CancellationToken token = _cts.Token;
            string url = String.Format("{0}:{1}/{2}", this.urlTxt.Text, this.portTxt.Text, this.pathTxt.Text);
            string soapAction = this.soapActionTxt.Text;
            int completedRequests = 0;
            double currentRequest = 0;
            int totalRequests = Convert.ToInt32(this.threadsNumberNr.Value * this.loopCountNr.Value);
            int rampupPeriode = Convert.ToInt32(this.rampupPeriodeNr.Value);

            CreateXmlListForRequests(totalRequests);

            Console.WriteLine("Starting load test...");

            if(this.durationActiveChbx.Checked)
                _cts.CancelAfter(new TimeSpan(0, 0, Convert.ToInt32(this.durationNr.Value)));

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
                        await ExecuteRequest(httpClient, url, soapAction, (int)currentRequest);
                        int currentCompleted = Interlocked.Increment(ref completedRequests);
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

            GenerateReport(currentRequest);
        }

        private static async Task ExecuteRequest(HttpClient httpClient, string url, string soapAction, int currentRequest)
        {
            string soapRequestXml = _loadedXmls.ElementAt(currentRequest);

            CollectedData collectedData = new CollectedData();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.Headers.Add("SOAPAction", soapAction);
            collectedData.Send = soapRequestXml;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (Stream stream = await request.GetRequestStreamAsync())
            {
                using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
                {
                    await streamWriter.WriteAsync(soapRequestXml);
                    collectedData.SendKb = Encoding.UTF8.GetByteCount(soapRequestXml);
                }
            }

            try
            {
                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseContent = await reader.ReadToEndAsync();
                        collectedData.Response = responseContent;
                        collectedData.ReceiveKb = response.ContentLength;
                        collectedData.Success = true;
                    }
                }
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseContent = await reader.ReadToEndAsync();
                        collectedData.Response = responseContent;
                        collectedData.ReceiveKb = response.ContentLength;
                        collectedData.Success = false;
                    }
                }
            }
            finally
            {
                stopwatch.Stop();
                collectedData.Time = stopwatch.ElapsedMilliseconds;
                _collectedDatas.Add(collectedData);
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            //Todo cleanup
        }

        private void selectXmlsPathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.createPathTxt.Text = dlg.SelectedPath;
                this._xmlCreatePath = this.createPathTxt.Text;
                this.createXmlsBtn.Enabled = true;
            }
        }

        private void createXmlsBtn_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(_createdObject.GetType());

            for (int i = 0; i < this.xmlCreateCountNr.Value; i++)
            {
                FillWithDummyData(_createdObject);

                using (StreamWriter streamWriter = new StreamWriter(String.Format("{0}\\CreatedXml_{1}.xml", _xmlCreatePath, Guid.NewGuid())))
                {
                    xmlSerializer.Serialize(streamWriter, _createdObject);
                }
            }
        }
    }    
}
