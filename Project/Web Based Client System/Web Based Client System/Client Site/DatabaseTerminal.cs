using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BinarySoftCo.DatabaseAccess.SQL;

namespace BinarySoftCo.Client_Site
{
    public static class DatabaseTerminal
    {
        private static DBSQL dB;

        public static DBSQL DB
        {
            get { return dB; }
            set { dB = value; }
        }

        public static bool InitialConncetion()
        {
            dB = new DBSQL(".", "Test1", "a123l", "ChatSystem"); ;
            //
            return dB.Connected;
        }
    }
}