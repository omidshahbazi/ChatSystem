using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.IO;
using System.Windows.Forms;

namespace BinarySoftCo.Tools.API
{
    public class WindowsServiceManagement
    {
        static ServiceController sc;

        public static bool InstalledLocaly(string ServiceName)
        {
            sc = new ServiceController(ServiceName);
            //
            try
            {
                if (sc.Status != ServiceControllerStatus.Running) ;
                //
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Install(string ServiceName, string FilePath)
        {
            if (InstalledLocaly(ServiceName))
                Stop(ServiceName);
            //
            try
            {
                File.WriteAllBytes(Application.StartupPath + @"\IU.exe", Properties.Resources.IU);
                //
                System.Diagnostics.Process.Start(Application.StartupPath + @"\IU.exe ", "\"" + FilePath + "\"").WaitForExit();
                //
                File.Delete(Application.StartupPath + @"\IU.exe");
                //
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool InstallAndStart(string ServiceName, string FilePath)
        {
            try
            {
                Install(ServiceName, FilePath);
                return Start(ServiceName);
            }
            catch
            {
                return false;
            }
        }

        public static bool Uninstall(string ServiceName, string FilePath)
        {
            if (InstalledLocaly(ServiceName))
                Stop(ServiceName);
            //
            try
            {
                File.WriteAllBytes(Application.StartupPath + @"\IU.exe", Properties.Resources.IU);
                //
                System.Diagnostics.Process.Start(Application.StartupPath + @"\IU.exe ", " /u " + "\"" + FilePath + "\"").WaitForExit();
                //
                File.Delete(Application.StartupPath + @"\IU.exe");
                File.Delete(FilePath);
                //
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Start(string ServiceName)
        {
            if (InstalledLocaly(ServiceName))
            {
                if (!Started(ServiceName))
                    try
                    {
                        sc.Start();
                        //
                        return true;
                    }
                    catch
                    {
                    }
            }
            //
            return false;
        }

        public static bool Stop(string ServiceName)
        {
            if (InstalledLocaly(ServiceName))
            {
                if (Started(ServiceName))
                    try
                    {
                        sc.Stop();
                        //
                        return true;
                    }
                    catch
                    {
                    }
            }
            //
            return false;
        }

        public static bool Restart(string ServiceName)
        {
            Stop(ServiceName);
            return Start(ServiceName);
        }

        public static bool Started(string ServiceName)
        {
            if (InstalledLocaly(ServiceName))
            {
                sc = new ServiceController(ServiceName);
                //
                return (sc.Status == ServiceControllerStatus.Running);
            }
            //
            return false;
        }
    }
}
