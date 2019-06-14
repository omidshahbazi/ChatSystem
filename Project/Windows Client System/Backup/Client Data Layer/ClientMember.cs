using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.ChatSystem.ClientDataLayer
{
    public class ClientInfo
    {
        int dBID;
        string fullName;
        AvailableStatus status;
        
        public int DBID
        {
            get { return dBID; }
        }

        public string FullName
        {
            get { return fullName; }
        }

        public AvailableStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public ClientInfo(int DBID, string FullName, AvailableStatus Status)
        {
            dBID = DBID;
            fullName = FullName;
            status = Status;
        }

        public override string ToString()
        {
            return fullName;
        }
    }

    public class ClientMember : ClientInfo
    {
        frmChat chatPage;

        public frmChat ChatPage
        {
            get { return chatPage; }
            set { chatPage = value; }
        }

        public ClientMember(int DBID, string FullName, AvailableStatus Status)
            : base(DBID, FullName, Status)
        {
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
