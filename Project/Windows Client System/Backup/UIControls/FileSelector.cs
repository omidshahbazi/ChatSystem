using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BinarySoftCo.UIControls
{
    [DefaultEvent("NewFileSelected")]
    public partial class FileSelector : UserControl
    {
        public event EventHandler NewFileSelected;

        bool withDoubleClick = true;
        OpenFileDialog ofd;

        public string ButtonText
        {
            get { return bSelect.Text; }
            set
            {
                bSelect.Width = (int)bSelect.CreateGraphics().MeasureString(value, bSelect.Font).Width + 20;
                Width = bSelect.Width + tbPath.Width;
                //
                bSelect.Text = value;
            }
        }

        public bool WithDoubleClick
        {
            get { return withDoubleClick; }
            set { withDoubleClick = value; }
        }

        public string SelectedFilePath
        {
            get { return tbPath.Text; }
            set { tbPath.Text = value; }
        }

        public byte[] SelectedFileBytes
        {
            get
            {
                byte[] b = null;
                //
                if (tbPath.TextLength > 0)
                    b = File.ReadAllBytes(tbPath.Text);
                //
                return b;
            }
        }

        public string Filter
        {
            get { return ofd.Filter; }
            set { ofd.Filter = value; }
        }

        protected void OnNewFileSelected(EventArgs e)
        {
            if (NewFileSelected != null)
                NewFileSelected(this, e);
        }

        public FileSelector()
        {
            InitializeComponent();
            //
            ofd = new OpenFileDialog();
            //
            ofd.Filter = "All Files|*.*";
        }

        private void FileSelector_Load(object sender, EventArgs e)
        {

        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                tbPath.Text = ofd.FileName;
                //
                OnNewFileSelected(new EventArgs());
            }
        }

        private void tbPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (withDoubleClick)
                bSelect_Click(null, null);
        }
    }
}
