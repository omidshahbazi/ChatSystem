using System;
using System.Collections.Generic;
using System.Text;

using BinarySoftCo.ChatSystem.ClientNetworking;

namespace BinarySoftCo.ChatSystem.ClientDataLayer
{
    public class Constants
    {
        public const int ServerPort = 2324;
    }

    public class Variables
    {
        static LoginSettings loginSettings;

        public static LoginSettings LoginSettings
        {
            get { return loginSettings; }
            set { loginSettings = value; }
        }

        static ServerConnector server;

        public static ServerConnector Server
        {
            get { return server; }
            set { server = value; }
        }
    }
}
