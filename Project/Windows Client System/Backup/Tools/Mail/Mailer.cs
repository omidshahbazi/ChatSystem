using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace BinarySoftCo.Tools.Mail
{
    public class Mailer
    {
        MailSetting setting;
        MailMessage message;
        SmtpClient client;
        List<string> bccList = new List<string>();

        public List<string> BccList
        {
            get { return bccList; }
            set { bccList = value; }
        }

        public bool EnableSSL
        {
            get { return client.EnableSsl; }
            set { client.EnableSsl = value; }
        }

        public bool IsBodyHTML
        {
            get { return message.IsBodyHtml; }
            set { message.IsBodyHtml = value; }
        }

        public MailSetting Setting
        {
            get { return setting; }
        }

        private void Initial()
        {
            message = new MailMessage();
            //
            client = new SmtpClient(setting.Host, setting.SMTPPort);
            //
            client.Credentials = new System.Net.NetworkCredential(setting.EMail, setting.Password);
        }

        public Mailer(MailSetting Setting)
        {
            setting = Setting;
            //
            Initial();
        }

        public Mailer(string Host, int SMTPPort, string Email, string Password)
        {
            setting = new MailSetting(Email, "", "", Password, Host, SMTPPort, false, -1, "");
            //
            Initial();
        }

        public bool Send(string To, string DisplayName, string Subject, string Body)
        {
            return Send(To, DisplayName, Subject, Body, new string[] { });
        }

        public bool Send(string[] To, string DisplayName, string Subject, string Body)
        {
            return Send(To, DisplayName, Subject, Body, new string[] { });
        }

        public bool Send(string To, string DisplayName, string Subject, string Body, string AttachmentFile)
        {
            return Send(new string[] { To }, DisplayName, Subject, Body, new string[] { AttachmentFile });
        }

        public bool Send(string To, string DisplayName, string Subject, string Body, string[] AttachmentFile)
        {
            return Send(new string[] { To }, DisplayName, Subject, Body, AttachmentFile);
        }

        public bool Send(string[] To, string DisplayName, string Subject, string Body, string[] AttachmentFile)
        {
            bool temp = true;
            //
            for (int i = 0; i < To.Length; i++)
                message.To.Add(To[i]);
            //
            message.From = new System.Net.Mail.MailAddress(setting.EMail, DisplayName, Encoding.UTF8);
            //
            message.Subject = Subject;
            message.SubjectEncoding = Encoding.UTF8;
            //
            message.Body = Body;
            message.BodyEncoding = Encoding.UTF8;
            //
            if (!string.IsNullOrEmpty(setting.BCC))
                message.Bcc.Add(new MailAddress(setting.BCC, "رونوشت"));
            //
            if (bccList != null)
            foreach (string bcc in bccList)
                message.Bcc.Add(new MailAddress(bcc, "رونوشت"));
            //
            message.Priority = System.Net.Mail.MailPriority.High;
            //
            if (AttachmentFile != null)
                foreach (string st in AttachmentFile)
                {
                    System.Net.Mail.Attachment data = new System.Net.Mail.Attachment(st);
                    //
                    message.Attachments.Add(data);
                    //
                    data.Dispose();
                }
            //
            client.Timeout = 10000000;
            //
            try
            {
                client.Send(message);
            }
            catch (Exception er)
            {
                throw er;
                //System.Windows.Forms.MessageBox.Show(er.Message);
                //
                temp = false;
            }
            //
            return temp;
        }

        public bool Send(string To, string DisplayName, string Subject, string Body, MailAttachment AttachmentData)
        {
            List<MailAttachment> list = new List<MailAttachment>();
            list.Add(AttachmentData);
            //
            return Send(new string[] { To }, DisplayName, Subject, Body, list);
        }

        public bool Send(string To, string DisplayName, string Subject, string Body, List<MailAttachment> AttachmentData)
        {
            return Send(new string[] { To }, DisplayName, Subject, Body, AttachmentData);
        }

        public bool Send(string[] To, string DisplayName, string Subject, string Body, List<MailAttachment> AttachmentData)
        {
            AddAttachmentWithBytes(AttachmentData);
            //
            return Send(To, DisplayName, Subject, Body, new string[] { });
        }

        private void AddAttachmentWithBytes(List<MailAttachment> AttachmentData)
        {
            if (AttachmentData != null)
                foreach (MailAttachment ma in AttachmentData)
                {
                    System.Net.Mail.Attachment data = new System.Net.Mail.Attachment(new MemoryStream(ma.FileData), ma.FileName);
                    //
                    message.Attachments.Add(data);
                    //
                    //NOTE : if dispose any data object after trying to send message has exception that is cann't access to closed stream
                    //So don't dispose data object after add into Attachments
                    //data.Dispose();
                }
        }
    }
}