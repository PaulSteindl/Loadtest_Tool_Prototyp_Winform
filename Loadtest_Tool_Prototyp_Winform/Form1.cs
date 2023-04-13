using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loadtest_Tool_Prototyp_Winform
{
    public partial class Form1 : Form
    {
        private string _xsdFile;
        private CancellationTokenSource _cts = new CancellationTokenSource();

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

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void loadXsdBtn_Click(object sender, EventArgs e)
        {
            PropertyGridSimpleDemoClass test = new PropertyGridSimpleDemoClass();
            xmlPropertView.SelectedObject = test;
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

    class PropertyGridSimpleDemoClass
    {
        int m_DisplayInt;
        public int DisplayInt
        {
            get { return m_DisplayInt; }
            set { m_DisplayInt = value; }
        }

        string m_DisplayString;
        public string DisplayString
        {
            get { return m_DisplayString; }
            set { m_DisplayString = value; }
        }

        bool m_DisplayBool;
        public bool DisplayBool
        {
            get { return m_DisplayBool; }
            set { m_DisplayBool = value; }
        }

        Color m_DisplayColors;
        public Color DisplayColors
        {
            get { return m_DisplayColors; }
            set { m_DisplayColors = value; }
        }
    }
}
