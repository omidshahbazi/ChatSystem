using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public partial class TextEditorOld : UserControl
    {
        OpenFileDialog ofd;

        public bool Multiline
        {
            get { return tbText.Multiline; }
            set 
            { 
                tbText.Multiline = value; 
                //
                if (!value)
                    Height = 47;
            }
        }

        public string Text
        {
            get { return tbText.Text; }
            set { tbText.Text = value; }
        }

        public TextEditorOld()
        {
            InitializeComponent();
            //
            ofd = new OpenFileDialog();
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {

        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, 
                tbText.Multiline ? height : 47, 
                specified);
        }

        private void tbText_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsMenu.Show(this, e.Location);
            }
        }

        private void tsmiAddPath_Click(object sender, EventArgs e)
        {
            tsbAddPath_Click(null, null);
        }

        private void tsbAddPath_Click(object sender, EventArgs e)
        {
            ofd.Filter = "همه فرمتها|*.*";
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                string st = "";
                foreach (string s in ofd.FileNames)
                    st += s + Environment.NewLine;
                //
                tbText.Text = tbText.Text.Insert(tbText.SelectionStart + tbText.SelectionLength, st);
            }
        }

        private void tsbRTL_Click(object sender, EventArgs e)
        {
            tsbLTR.Checked = false;
            //
            tbText.RightToLeft = RightToLeft.Yes;
        }

        private void tsbLTR_Click(object sender, EventArgs e)
        {
            tsbRTL.Checked = false;
            //
            tbText.RightToLeft = RightToLeft.No;
        }
    }
}
