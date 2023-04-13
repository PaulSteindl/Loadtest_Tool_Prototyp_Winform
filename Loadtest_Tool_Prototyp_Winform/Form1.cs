using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loadtest_Tool_Prototyp_Winform
{
    public partial class Form1 : Form
    {
        private string _xsdFile;

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

        private void sendRequestsBtn_Click(object sender, EventArgs e)
        {

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
