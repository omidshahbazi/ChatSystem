using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BinarySoftCo.Tools.Mail;

namespace BinarySoftCo.UIControls
{
    partial class frmErrorViewer : Form
    {
        string
            displayName = "",
            mailServer = "",
            viaEmail = "",
            password = "",
            toEmail = "";
        int port = 25;

        public frmErrorViewer()
        {
            InitializeComponent();
        }

        public frmErrorViewer(string DisplayName, string MailServer, int Port, string ViaEmail, string Password, string ToEmail, string Subject, string Body)
            : this()
        {
            displayName = DisplayName;
            mailServer = MailServer;
            port = Port;
            viaEmail = ViaEmail;
            password = Password;
            toEmail = ToEmail;
            lSubject.Text = Subject;
            tbBody.Text = Body;
        }

        private void llShowDetails_MouseClick(object sender, MouseEventArgs e)
        {
            if (tbBody.Height < 20)
                tbBody.Height = 150;
            else
                tbBody.Height = 5;
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //
            panel1.Visible = true;
            //
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //
            Mailer mailer = new Mailer(mailServer, port, viaEmail, password);
            //
            if (mailer.Send(toEmail, displayName, displayName,
                ""))
            {
                PersianMessageBox.Show(".ارسال با موفقیت انجام شد", "ارسال فرم گزارش خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                PersianMessageBox.Show(".ارسال با شکست مواجه شد", "ارسال فرم گزارش خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bSend.Text = "تلاش مجدد";
                //
                panel1.Visible = false;
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            if (PersianMessageBox.Show("آیا مایل به ادامه میباشید ؟", "بستن فرم گزارش خطا", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                Close();
        }
    }

    public static class ErrorManager
    {
        public static void Show(string MailServer, int Port, string ViaEmail, string Password, string Subject, string Body)
        {
            Show("رخ دادن خطا در " + Application.ProductName, MailServer, Port, ViaEmail, Password, ViaEmail, Subject, Body);
        }

        public static void Show(string DisplayName, string MailServer, int Port, string ViaEmail, string Password, string ToEmail, string Subject, string Body)
        {
            frmErrorViewer frmEV = new frmErrorViewer(DisplayName, MailServer, Port, ViaEmail, Password, ToEmail, Subject, Body);
            frmEV.ShowDialog();
        }
    }
}
