using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BinarySoftCo.ChatSystem.ServerDataLayer;

namespace BinarySoftCo.ChatSystem.System_Admin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //
            frmLogin frmL = new frmLogin(true);
            if (frmL.ShowDialog())
            {
                //Application.Run(new frmMemberList());
                Application.Run(new frmMain());
            }
        }
    }
}
