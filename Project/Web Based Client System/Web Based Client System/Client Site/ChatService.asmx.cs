using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;

namespace BinarySoftCo.Client_Site
{
    /// <summary>
    /// Summary description for ChatService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]

    public class ChatService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public bool InitialDatabaseConncetion()
        {
            return DatabaseTerminal.InitialConncetion();
        }

        [WebMethod(EnableSession = true)]
        public void DisconnectDatabaseTerminal()
        {
            if (DatabaseTerminal.DB != null)
            {
                DatabaseTerminal.DB.Disconnect();
                DatabaseTerminal.DB = null;
            }
        }

        [WebMethod(EnableSession = true)]
        public bool InitialUserSession()
        {
            return (UserSession.MyMember != null);
        }

		[WebMethod(EnableSession = true)]
		public bool Login(string Email, string Password)
		{
            InitialDatabaseConncetion();
            //
            DataTable dtData = DatabaseTerminal.DB.ExecuteStoredProcReturn("GetMemberInfoWithUsername", new SqlParameter("Username", Email));
            //
            if (dtData != null && dtData.Rows.Count > 0)
                if ((dtData.Rows[0]["Username"].ToString() == Email || dtData.Rows[0]["Email"].ToString() == Email) &&
                    dtData.Rows[0]["Password"].ToString() == Password)
                {
                    UserSession.MyMember = new ChatMember(
                        int.Parse(dtData.Rows[0]["MemberID"].ToString()),
                        dtData.Rows[0]["FirstName"].ToString(),
                        dtData.Rows[0]["LastName"].ToString(),
                        bool.Parse(dtData.Rows[0]["Gender"].ToString()));
                    //
                    return true;
                }
            //
            UserSession.MyMember = null;
            //
            return false;
		}

        [WebMethod(EnableSession = true)]
        public void Logout()
        {
            UserSession.MyMember = null;
            UserSession.CurrentChatWithMemberID = -1;
            UserSession.Members = new List<ChatMember>();
        }

        [WebMethod(EnableSession = true)]
        public ChatMember GetMy()
        {
            return UserSession.MyMember;
        }

        [WebMethod(EnableSession = true)]
        public ChatMember GetMember()
        {
            foreach (ChatMember cm in UserSession.Members)
                if (cm.DBID == UserSession.CurrentChatWithMemberID)
                    return cm;
            //
            return null;
        }

        [WebMethod(EnableSession = true)]
        public List<ChatMember> GetMemberList()
        {
            InitialDatabaseConncetion();
            //
            List<ChatMember> list = new List<ChatMember>();
            //
            DataTable dtData = DatabaseTerminal.DB.ExecuteStoredProcReturn("GetRelatedMembers", new SqlParameter("MemberID", UserSession.MyMember.DBID));
            //
            if (dtData != null)
                foreach (DataRow dr in dtData.Rows)
                    list.Add(new ChatMember(
                        int.Parse(dr["MemberID"].ToString()),
                        dr["FirstName"].ToString(), dr["LastName"].ToString(),
                        (dr["Gender"] != DBNull.Value ? bool.Parse(dr["Gender"].ToString()) : true)));
            //
            UserSession.Members = list;
            return list;
        }

        [WebMethod(EnableSession = true)]
        public void SetChatWith(int ID)
        {
            UserSession.CurrentChatWithMemberID = ID;
        }

        [WebMethod(EnableSession = true)]
        public int GetChatWith()
        {
            return UserSession.CurrentChatWithMemberID;
        }

        [WebMethod(EnableSession = true)]
        public int? SendMessage(string Message)
        {
            InitialDatabaseConncetion();
            //
            DataTable dtData = DatabaseTerminal.DB.ExecuteStoredProcReturn("AddNewPacket",
                new SqlParameter("FromMemberID", UserSession.MyMember.DBID),
                new SqlParameter("ToMemberID", UserSession.CurrentChatWithMemberID),
                new SqlParameter("Message", Message.Trim()),
                new SqlParameter("StatusID", 2));
            //
            if (dtData != null && dtData.Rows.Count > 0)
                if (dtData.Rows[0]["ID"] != DBNull.Value)
                    return int.Parse(dtData.Rows[0]["ID"].ToString());
            //
            return new int?();
        }

        [WebMethod(EnableSession = true)]
        public List<ChatMessage> GetLatestMessages(int LastMessageID, int FromMemberID)
        {
            InitialDatabaseConncetion();
            //
            List<ChatMessage> list = new List<ChatMessage>();
            //
            DataTable dtData = DatabaseTerminal.DB.ExecuteStoredProcReturn("GetPendingFor",
                new SqlParameter("MemberID", UserSession.MyMember.DBID),
                new SqlParameter("LastID", LastMessageID),
                new SqlParameter("FromMemberID", FromMemberID));
            //
            if (dtData != null)
                foreach (DataRow dr in dtData.Rows)
                    list.Add(new ChatMessage(
                        int.Parse(dr["ID"].ToString()),
                        FromMemberID,
                        dr["Message"].ToString()));
            //
            return list;
        }
    }
}
