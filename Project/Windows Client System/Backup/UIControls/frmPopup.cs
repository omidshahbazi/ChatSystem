using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    sealed partial class frmPopup : Form
    {
        public frmPopup(string Header, string Content)
        {
            InitializeComponent();
            //
            rtllHeader.Text = Header;
            rtllContent.Text = Content;
        }

        private void frmPopup_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, Screen.PrimaryScreen.Bounds.Height);
            //
            for (int i = Location.Y; i >= Screen.PrimaryScreen.Bounds.Height - Height; i -= 3)
                Location = new Point(Location.X, i);
        }

        new public DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }

        private void frmPopup_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DialogResult = DialogResult.Yes;
            else if (e.Button == MouseButtons.Right)
                DialogResult = DialogResult.No;
        }
    }

    public static class PopupMessage
    {
        public static DialogResult Show(string Header, string Content)
        {
            frmPopup frmP = new frmPopup(Header, Content);
            return frmP.ShowDialog();
        }
    }
}
