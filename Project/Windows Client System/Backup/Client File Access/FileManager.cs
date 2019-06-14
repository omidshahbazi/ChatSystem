using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

using BinarySoftCo.ChatSystem.ClientDataLayer;

namespace BinarySoftCo.ChatSystem.ClientFileAccess
{
    public enum File_Type
    {
        ClienSetting
    }

    public class FileManager
    {
        const string SettingsExtensions = ".appf";

        private static string Path
        {
            get { return Application.StartupPath + @"\Settings\"; }
        }

        private static void CheckPathExists()
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }

        public static void Save(object SettingObject, File_Type Type)
        {
            CheckPathExists();
            //
            using (StreamWriter sw = new StreamWriter(Path + Type.ToString() + SettingsExtensions))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(sw.BaseStream, SettingObject);
            }
        }

        public static object LoadSetting(File_Type Type)
        {
            if (Directory.Exists(Path) &&
                File.Exists(Path + Type.ToString() + SettingsExtensions))
            {
                using (StreamReader sr = new StreamReader(Path + Type.ToString() + SettingsExtensions))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return bf.Deserialize(sr.BaseStream);
                }
            }
            //
            return null;
        }

        public static LoginSettings LoadClientSetting()
        {
            object obj = LoadSetting(File_Type.ClienSetting);
            //
            if (obj != null) return (LoginSettings)obj;
            //
            return new LoginSettings();
        }
    }
}
