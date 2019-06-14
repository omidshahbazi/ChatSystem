using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.Tools.Mail
{
    public class MailSetting
    {
        string eMail, subject, signature, password, host, bCC;
        int sMTPPort, managerUserInfoID;
        bool useSSL;

        public string EMail
        {
            get { return eMail; }
        }

        public string Subject
        {
            get { return subject; }
        }

        public string Signature
        {
            get { return signature; }
        }

        public string Password
        {
            get { return password; }
        }

        public string Host
        {
            get { return host; }
        }

        public int ManagerUserInfoID
        {
            get { return managerUserInfoID; }
        }

        public int SMTPPort
        {
            get { return sMTPPort; }
        }

        public bool UseSSL
        {
            get { return useSSL; }
        }

        public string BCC
        {
            get { return bCC; }
            set { bCC = value; }
        }

        public MailSetting(string EMail, string Subject, string Signature, string Password, string Host, int SMTPPort, bool UseSSL, int ManagerUserInfoID, string BCC)
        {
            eMail = EMail;
            subject = Subject;
            signature = Signature;
            password = Password;
            host = Host;
            sMTPPort = SMTPPort;
            useSSL = UseSSL;
            managerUserInfoID = ManagerUserInfoID;
            bCC = BCC;
        }
    }
}
