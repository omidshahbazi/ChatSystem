using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

using BinarySoftCo.ChatSystem.ServerDataLayer;

namespace BinarySoftCo.ChatSystem.FileAccess
{
    public enum File_Type
    {
        Log
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

        public static List<Log> LoadLogs()
        {
            object obj = LoadSetting(File_Type.Log);
            //
            if (obj != null) return (List<Log>)obj;
            //
            return new List<Log>();
        }
    }
}
