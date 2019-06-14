using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.ChatSystem.ClientDataLayer
{
    [Serializable()]
    public class LoginSettings
    {
        string username, password;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        bool autoLogin = true, autoStart = true;

        public bool AutoLogin
        {
            get { return autoLogin; }
            set { autoLogin = value; }
        }

        public bool AutoStart
        {
            get { return autoStart; }
            set { autoStart = value; }
        }
    }
}
