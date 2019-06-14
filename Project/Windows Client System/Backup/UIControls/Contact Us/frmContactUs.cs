using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BinarySoftCo.Tools.Security;
using BinarySoftCo.Tools.Mail;

namespace BinarySoftCo.UIControls
{
    partial class frmContactUs : Form
    {
        string
            displayName = "",
            mailServer = "",
            viaEmail = "",
            password = "",
            toEmail = "",
            webPageURL = "",
            finalURL = "";
        int port = 25;
        bool useWebSender = false;

        WebBrowser browser;

        private string MailBody
        {
            get
            {
                return "نوع : " + cbType.Text + Environment.NewLine +
                    "ایمیل  : " + tbEmail.Text + Environment.NewLine +
                    "عنوان : " + tbSubject.Text + Environment.NewLine +
                    "پیغام : " + teMessage.Text;
            }
        }

        private frmContactUs()
        {
            InitializeComponent();
        }

        public frmContactUs(string WebPageURL)
            : this()
        {
            useWebSender = true;
            //
            webPageURL = WebPageURL;
            //
            browser = new WebBrowser();
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            panel1.Visible = false;
            //
            PersianMessageBox.Show(".ارسال با موفقیت انجام شد", "ارسال فرم تماس با ما", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        public frmContactUs(string DisplayName, string MailServer, int Port, string ViaEmail, string Password, string ToEmail)
            : this()
        {
            useWebSender = false;
            //
            displayName = DisplayName;
            mailServer = MailServer;
            port = Port;
            viaEmail = ViaEmail;
            password = Password;
            toEmail = ToEmail;
        }

        private void frmContactUs_Load(object sender, EventArgs e)
        {

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            if (cbType.Validate && tbFullName.Validate && tbEmail.Validate && tbSubject.Validate)
            {
                if (useWebSender)
                {
                    try
                    {
                        if (useWebSender)
                            finalURL = webPageURL + (!webPageURL.EndsWith("/") ? "/" : "") +
                                "?name=" + Codec.EncodeString(tbFullName.Text) +
                                "&email=" + Codec.EncodeString(tbEmail.Text) +
                                "&body=" + Codec.EncodeString(teMessage.Text) +
                                "&bcc=" + cbBCC.Checked;

                        MessageBox.Show(Codec.DecodeString(Codec.EncodeString(tbFullName.Text)) + " <> " + Codec.EncodeString(tbFullName.Text));
                        MessageBox.Show(Codec.DecodeString(Codec.EncodeString(tbEmail.Text)) + " <> " + Codec.EncodeString(tbEmail.Text));
                        MessageBox.Show(Codec.DecodeString(Codec.EncodeString(teMessage.Text)) + " <> " + Codec.EncodeString(teMessage.Text));
                        //
                        browser.Navigate(finalURL);
                    }
                    catch
                    {
                        PersianMessageBox.Show(".ارسال با شکست مواجه شد", "ارسال فرم تماس با ما", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bSend.Text = "تلاش مجدد";
                    }
                }
                else
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    //
                    panel1.Visible = true;
                    //
                    bw.RunWorkerAsync();
                }
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //
                Mailer mailer = new Mailer(mailServer, port, viaEmail, password);
                //
                if (cbBCC.Checked)
                    mailer.BccList.Add(tbEmail.Text);
                //
                if (mailer.Send(toEmail, tbFullName.Text, displayName, MailBody))
                {
                    PersianMessageBox.Show(".ارسال با موفقیت انجام شد", "ارسال فرم تماس با ما", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    PersianMessageBox.Show(".ارسال با شکست مواجه شد", "ارسال فرم تماس با ما", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bSend.Text = "تلاش مجدد";
                }
            //
            panel1.Visible = false;
        }
    }

    public static class ContactUs
    {
        /// <summary>
        /// Send Via SMTP
        /// </summary>
        public static void Show(string MailServer, int Port, string ViaEmail, string Password)
        {
            Show("تماس با ما " + Application.ProductName, MailServer, Port, ViaEmail, Password, ViaEmail);
        }

        /// <summary>
        /// Send Via SMTP
        /// </summary>
        public static void Show(string DisplayName, string MailServer, int Port, string ViaEmail, string Password, string ToEmail)
        {
            frmContactUs frmC = new frmContactUs(DisplayName, MailServer, Port, ViaEmail, Password, ToEmail);
            frmC.ShowDialog();
        }

        /// <summary>
        /// Send Via Web Page
        /// </summary>
        public static void Show(string WebPageURL)
        {
            frmContactUs frmC = new frmContactUs(WebPageURL);
            frmC.ShowDialog();
        }
    }
}
