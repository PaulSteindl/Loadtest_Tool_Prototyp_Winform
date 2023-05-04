using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Loadtest_Tool_Prototyp_Winform
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        private void resultListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.resultListView.SelectedItems.Count > 0)
            {
                Form3 frm = new Form3();

                ListViewItem selectedItem = resultListView.SelectedItems[0];
                frm.requestTxtBx.Text = PrettyPrintXml(selectedItem.SubItems[4].Text);
                frm.responseTxtBx.Text = PrettyPrintXml(selectedItem.SubItems[5].Text);

                frm.Show();
            }
        }

        private static string PrettyPrintXml(string inputXml)
        {
            XDocument xDocument = XDocument.Parse(inputXml);

            using (StringWriter writer = new StringWriter())
            {
                xDocument.Save(writer, SaveOptions.None);
                return writer.ToString();
            }
        }
    }
}
