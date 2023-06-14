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
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Reflection;

namespace noneSharp
{
    public partial class frmMain : Form
    {
        private int openDoceuments = 0;

        public frmMain()
        {
            InitializeComponent();
            
        }


        private void mnuNew_Click(object sender, EventArgs e)
        {
            blank frm = new blank();
            frm.docName = "Untitled" + ++openDoceuments;
            frm.Text = frm.docName;
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuArrangeIcons_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTitleHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTitleVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;
            frm.Delete();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;
            frm.SelectAll();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;
            frm.Paste();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;
            frm.Copy();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;
            frm.Cut();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var frm = new blank();
                frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this;
                frm.docName = openFileDialog1.FileName;
                frm.Text = frm.docName;
                frm.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SaveFile(frm.docName + ".rtf", RichTextBoxStreamType.RichText);
                frm.MdiParent = this;
                frm.docName = saveFileDialog1.FileName;
                frm.Text = frm.docName;
            }
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            fontDialog1.ShowColor = true;
            fontDialog1.Font = frm.richTextBox1.SelectionFont;
            fontDialog1.Color = frm.richTextBox1.SelectionColor;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionFont = fontDialog1.Font;
                frm.richTextBox1.SelectionColor = fontDialog1.Color;
            }
            frm.Show();
        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            colorDialog1.Color = frm.richTextBox1.SelectionColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionColor = colorDialog1.Color;
            }
            frm.Show();
        }

        private void mnuInsertImage_Click(object sender, EventArgs e)
        {
            var frm = (blank)this.ActiveMdiChild;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog2.FileName;

                if (File.Exists(imagePath))
                {
                    Image image = Image.FromFile(imagePath);
                    Clipboard.SetDataObject(image, true);
                    frm.richTextBox1.Paste();
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Additional menu item functionality
        }

        
    }
}
// Text Files (*.txt)| *.txt | All Files(*.*) | *.*