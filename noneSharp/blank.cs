using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace noneSharp
{
    public partial class blank : Form
    {
        public string docName = "";
        private string bufferText = "";
        public bool isSaved = false;
        public blank()
        {
            InitializeComponent();
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Now.ToLongTimeString());
        }
        public void Cut()
        {
            this.bufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }
        public void Copy()
        {
            this.bufferText = richTextBox1.SelectedText;
        }
        public void Paste()
        {
            richTextBox1.SelectedText = bufferText;
        }
        public void SelectAll()
        {
            richTextBox1.SelectAll();

        }
        public void Delete()
        {
            richTextBox1.SelectedText = "";
            this.bufferText="";
        }

        private void cmnuCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void cmnuCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void cmnuPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void cmnuDelete_Click(object sender, EventArgs e)
        {
            Delete();

        }

        private void cmnuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }


        public void Open(string openFileName)
        {
            if(openFileName=="")
            {
                return;
            }
            else
            {
                StreamReader sr = new StreamReader(openFileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                docName = openFileName;


            }
        }
        public void Save(string saveFileName)
        {
            
            if (saveFileName == "")
            {
                return;
            }
            else
            {
                
                StreamWriter sw = new StreamWriter(saveFileName);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                docName = saveFileName;
            }
        }
        private void blank_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isSaved == true)
                
                if (MessageBox.Show("Do you want save changes in " + this.docName + "?",
                "Message", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Save(this.docName);
                }
        }
        private void richTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            
            sbAmount.Text = "Аmount of symbols" + richTextBox1.Text.Length.ToString();
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
