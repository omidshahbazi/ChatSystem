using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    sealed partial class TransparentDialogBox : Form
    {
        public TransparentDialogBox(string Header, string Content)
        {
            InitializeComponent();
            //
            lHeader.Text = Header;
            lContent.Text = Content;
        }

        private void TransparentDialogBox_Load(object sender, EventArgs e)
        {

        }

        private void TransparetDialogBox_SizeChanged(object sender, EventArgs e)
        {
            pItems.Location = new Point(
                (Width / 2) - (pItems.Width / 2),
                (Height / 2) - (pItems.Height / 2));
        }

        private void bNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void bYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void TransparetDialogBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) bYes_Click(null, null);
            else if (e.KeyCode == Keys.Escape) bNo_Click(null, null);
        }
    }

    public static class TransparentMessage
    {
        public static DialogResult Show(string Header, string Content)
        {
            TransparentDialogBox tdb = new TransparentDialogBox(Header, Content);
            return tdb.ShowDialog();
        }
    }
}
