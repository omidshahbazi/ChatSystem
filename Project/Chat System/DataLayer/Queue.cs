using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.ChatSystem.DataLayer
{
    public class Queue
    {
        #region Variables

        int dBID, fromMemberID, toMemberID;
        DateTime sentDateTime;
        string message;

        #endregion

        #region Properties

        public int DBID
        {
            get { return dBID; }
        }

        public int FromMemberID
        {
            get { return fromMemberID; }
        }

        public int ToMemberID
        {
            get { return toMemberID; }
        }

        public DateTime SentDateTime
        {
            get { return sentDateTime; }
        }

        public string Message
        {
            get { return message; }
        }

        #endregion

        public Queue(int FromMemberID, int ToMemberID, string Message)
        {
            dBID = -1;
            fromMemberID = FromMemberID;
            toMemberID = ToMemberID;
            message = Message;
            //
            sentDateTime = DateTime.Now;
        }

        public Queue(int DBID, int FromMemberID, int ToMemberID, DateTime SentDateTime, string Message)
            : this (FromMemberID, ToMemberID, Message)
        {
            dBID = DBID;
            sentDateTime = SentDateTime;
        }
    }
}
