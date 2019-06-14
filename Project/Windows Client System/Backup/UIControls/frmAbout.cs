using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public partial class frmAbout : Form
    {
        new public static void Show(string ApplicationName, string ApplicationVersion, int ApplicationCopyRightYear)
        {
            frmAbout frmA = new frmAbout(ApplicationName, ApplicationVersion, ApplicationCopyRightYear);
            frmA.ShowDialog();
        }

        public frmAbout()
        {
            InitializeComponent();
        }

        public frmAbout(string ApplicationName, string ApplicationVersion, int ApplicationCopyRightYear)
            : this()
        {
            lApplicationName.Text = ApplicationName;
            lVersion.Text = string.Format(lVersion.Tag.ToString(), ApplicationVersion);
            lCopyright.Text = string.Format(lCopyright.Tag.ToString(), ApplicationCopyRightYear);
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void llEmail_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:info@aban-co.ir");
        }

        private void llWebSite_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://aban-co.ir");
        }

        private void bCopyPhone_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("0311-2358335");
        }

        private void bCopyEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("info@aban-co.ir");
        }

        private void bCopyWebSite_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("http://aban-co.ir");
        }
    }
}
