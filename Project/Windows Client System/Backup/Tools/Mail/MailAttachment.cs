using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.Tools.Mail
{
    public class MailAttachment
    {
        string fileName;
        byte[] fileData;

        public string FileName
        {
            get { return fileName; }
        }

        public byte[] FileData
        {
            get { return fileData; }
        }

        public string FileSize
        {
            get
            {
                return ((fileData.Length / 1000d / 1000d) > 1 ? (fileData.Length / 1000d / 1000d).ToString() + " MB" : (fileData.Length / 1000d) + " KB");
            }
        }

        public MailAttachment(string FileName, byte[] FileData)
        {
            fileName = FileName;
            fileData = FileData;
        }

        public override string ToString()
        {
            return fileName + " (" + FileSize + ")";
        }
    }
}
