using System;
using System.Collections.Generic;
using System.Text;

using BinarySoftCo.ChatSystem.FileAccess;

namespace BinarySoftCo.ChatSystem.ServerDataLayer
{
    public class LogManager
    {
        public static void AppendLogFile(string Content)
        {
            List<Log> logs = FileManager.LoadLogs();
            //
            logs.Add(new Log(DateTime.Now, Content));
            //
            FileManager.Save(logs, File_Type.Log);
        }
    }

    [Serializable()]
    public class Log
    {
        #region Variables
        //
        DateTime dataTime;
        string content;
        //
        #endregion

        #region Properties

        public DateTime DateTime
        {
            get { return dataTime; }
        }

        public string Content
        {
            get { return content; }
        }

        #endregion

        public Log(DateTime DateTime, string Content)
        {
            dataTime = DateTime;
            content = Content;
        }

        public override string ToString()
        {
            return DateTime.ToString() + " - " + content;
        }
    }
}
