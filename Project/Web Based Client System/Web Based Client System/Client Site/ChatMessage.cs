using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinarySoftCo.Client_Site
{
    public class ChatMessage
    {
        private int dBID, fromMemberID;
        private string body;

        public int DBID
        {
            get { return dBID; }
        }

        public int FromMemberID
        {
            get { return fromMemberID; }
        }

        public string Body
        {
            get { return body; }
        }

        public ChatMessage(int DBID, int FromMemberID, string Body)
        {
            dBID = DBID;
            fromMemberID = FromMemberID;
            body = Body;
        }

        public override string ToString()
        {
            return body;
        }
    }
}