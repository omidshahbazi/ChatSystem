using Microsoft.Win32;

namespace BinarySoftCo.Tools.API
{
    public class AutoStart
    {
        private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// Sets the autostart value for the assembly.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
        public static void SetAutoStart(bool IsAutoStart, string KeyName, string AssemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            //
            if (IsAutoStart)
                key.SetValue(KeyName, AssemblyLocation);
            else
                if (key.GetValue(KeyName) != null)
                    key.DeleteValue(KeyName);
        }

        /// <summary>
        /// Returns whether auto start is enabled.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
        public static bool IsAutoStartEnabled(string KeyName, string AssemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
            if (key == null)
                return false;

            string value = (string)key.GetValue(KeyName);
            if (value == null)
                return false;

            return (value == AssemblyLocation);
        }
    }
}
