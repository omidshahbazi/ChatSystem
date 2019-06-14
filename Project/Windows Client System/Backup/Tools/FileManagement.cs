using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySoftCo.Tools.General
{
    public class FileManagement
    {
        [Serializable()]
        public class FileData
        {
            string fileName;
            byte[] data;
            DateTime modifiedDateTime;
            
            public string FileName
            {
                get {return fileName;}
            }

            public byte[] Data
            {
                get {return data;}
            }

            public DateTime ModifiedDateTime
            {
                get { return modifiedDateTime; } 
            }

            public FileData(string FileName, byte[] Data, DateTime ModifiedDateTime)
            {
                fileName = FileName;
                data = Data;
                modifiedDateTime = ModifiedDateTime;
            }

            public override string ToString()
            {
                return fileName;
            }
        }

        [Serializable()]
        public class Files
        {
            List<FileData> list;

            public List<FileData> List
            {
                get { return list; }
            }

            public Files()
            {
                list = new List<FileData>();
            }

            public Files(List<FileData> List)
            {
                list = List;
            }
        }

        readonly static string tempFilePath = Application.StartupPath + @"\" + new Random(DateTime.Now.Millisecond).Next(9432323, 428128175).ToString() + ".tmp";

        public static byte[] MergeFiles(string[] FilesPath)
        {
            Files f = new Files();
            //
            foreach (string file in FilesPath)
                if (!string.IsNullOrEmpty(file))
                    f.List.Add(new FileData(Path.GetFileName(file), File.ReadAllBytes(file), new FileInfo(file).LastWriteTime));
            //
            using (FileStream fs = new FileStream(tempFilePath, FileMode.OpenOrCreate))
                new BinaryFormatter().Serialize(fs, f);
            //
            byte[] bytes = File.ReadAllBytes(tempFilePath);
            //
            File.Delete(tempFilePath);
            //
            return bytes;
        }

        public static Files SplitFile(string FilePath)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open))
                {
                    object o = new BinaryFormatter().Deserialize(fs);
                    //
                    if (o != null)
                        return (Files)o;
                }
            }
            //
            return new Files();
        }

        //const string spliter = "&خ@%ع$)ی!آ";

        //private static byte[] Spliter
        //{
        //    get { return Encoding.ASCII.GetBytes(spliter); }
        //}

        //public static byte[] MergeFiles(string[] FilesPath)
        //{
        //    byte[] bytes = new byte[0];
        //    //
        //    List<byte[]> list = new List<byte[]>();
        //    //
        //    foreach (string file in FilesPath)
        //    {
        //        byte[] bt = File.ReadAllBytes(file);
        //        //
        //        list.Add(bt);
        //        //
        //        bytes = new byte[Spliter.Length + bt.Length + bytes.Length];
        //    }
        //    //
        //    int BytesIndex = 0;
        //    //
        //    foreach (byte[] bt in list)
        //    {
        //        for (int i = 0; i < Spliter.Length; i++)
        //        {
        //            bytes[BytesIndex] = Spliter[i];
        //            BytesIndex++;
        //        }
        //        //
        //        for (int i = 0; i < bt.Length; i++)
        //        {
        //            bytes[BytesIndex] = bt[i];
        //            BytesIndex++;
        //        }
        //    }
        //    //
        //    return bytes;
        //}

        //public static List<byte[]> SplitFile(string FilePath)
        //{
        //    List<byte[]> list = new List<byte[]>();
        //    //
        //    byte[] bytes = File.ReadAllBytes(FilePath);
        //    //
        //    bool isNew = false;
        //    //
        //    List<byte> bts = new List<byte>();
        //    //
        //    for (int i = 0; i < bytes.Length; i++)
        //    {
        //        byte bt = bytes[i];
        //        //
        //        if (bt == Spliter[0])
        //        {
        //            int j = i;
        //            //
        //            foreach (byte b in Spliter)
        //            {
        //                if (bytes[j] == b)
        //                {
        //                    j++;
        //                    isNew = true;
        //                }
        //                else
        //                {
        //                    isNew = false;
        //                    break;
        //                }
        //            }
        //            //
        //            if (isNew)
        //            {
        //                if (bts.Count > 0)
        //                    list.Add(bts.ToArray());
        //                //
        //                bts = new List<byte>();
        //            }
        //        }
        //        //
        //        bts.Add(bt);
        //    }
        //    //
        //    return list;
        //}
    }
}
