using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Media;

using BinarySoftCo.ChatSystem.ServerNetworking;
using BinarySoftCo.ChatSystem.ClientNetworking;
using BinarySoftCo.ChatSystem.ClientDataLayer;
using BinarySoftCo.ChatSystem.ClientFileAccess;

namespace BinarySoftCo.ChatSystem.Parsian_Chat
{
    static class Program
    {
        private static void LoadData()
        {
            Variables.Server = new ServerConnector();
            //
            Variables.LoginSettings = FileManager.LoadClientSetting();
        }

        public static void SignOut()
        {
            Variables.Server.SendCommand(new Command(CommandsType.SignOut));
            //
            Variables.LoginSettings.Password = Variables.LoginSettings.Username = "";
        }

        [STAThread]
        static void Main()
        {
            LoadData();
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //
            //while (flag)
            //{
                Application.Run(new frmLogin());
                //
                Application.Run(new frmMain());
                
            //}
        }
    }
}
