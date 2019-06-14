using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using BinarySoftCo.DatabaseAccess.SQL;
using System.Data.SqlClient;

namespace BinarySoftCo.ChatSystem.DataLayer
{
    public class BaseData
    {
        DBSQL dbS;
        
        public BaseData()
        {
            dbS = new DBSQL(".", "ChatSystem");
        }

        #region Users

        public bool GetUserLoginStatus(string Username, string Password)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Username", Username));
            param.Add(new SqlParameter("@Password", Password));
            //
            DataTable dtUser = dbS.ExecuteStoredProcReturn("CheckUser", param);
            //
            if (dtUser != null && dtUser.DefaultView.Count > 0)
                if (dtUser.DefaultView[0]["Username"].ToString() == Username &&
                    dtUser.DefaultView[0]["Password"].ToString() == Password)
                    return true;
            //
            return false;
        }

        #endregion

        #region Members

        public bool GetMemeberLoginStatus(string Username, string Password)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Username", Username));
            param.Add(new SqlParameter("@Password", Password));
            //
            DataTable dtUser = dbS.ExecuteStoredProcReturn("CheckMember", param);
            //
            if (dtUser != null && dtUser.DefaultView.Count > 0)
                if (dtUser.DefaultView[0]["Username"].ToString() == Username &&
                    dtUser.DefaultView[0]["Password"].ToString() == Password)
                    return true;
            //
            return false;
        }

        public Member GetMemeberInfo(int DBID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", DBID));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetMemberInfoWithID", param);
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
            {
                return new Member(
                    int.Parse(dtData.DefaultView[0]["MemberID"].ToString()),
                    dtData.DefaultView[0]["FirstName"].ToString(),
                    dtData.DefaultView[0]["MiddleName"].ToString(),
                    dtData.DefaultView[0]["LastName"].ToString(),
                    dtData.DefaultView[0]["NickName"].ToString(),
                    dtData.DefaultView[0]["Email"].ToString(),
                    dtData.DefaultView[0]["WebPage"].ToString(),
                    dtData.DefaultView[0]["Mobile"].ToString(),
                    dtData.DefaultView[0]["Phone"].ToString(),
                    dtData.DefaultView[0]["Address"].ToString(),
                    dtData.DefaultView[0]["Username"].ToString(),
                    dtData.DefaultView[0]["Password"].ToString(),
                    DateTime.Parse(dtData.DefaultView[0]["RegDate"].ToString()),
                    DateTime.Parse(dtData.DefaultView[0]["LastLogin"].ToString()),
                    bool.Parse(dtData.DefaultView[0]["IsActive"].ToString()));
            }
            //
            return new Member();
        }

        public Member GetMemeberInfo(string Username)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Username", Username));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetMemberInfoWithUsername", param);
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
            {
                return new Member(
                    int.Parse(dtData.DefaultView[0]["MemberID"].ToString()),
                    dtData.DefaultView[0]["FirstName"].ToString(),
                    dtData.DefaultView[0]["MiddleName"].ToString(),
                    dtData.DefaultView[0]["LastName"].ToString(),
                    dtData.DefaultView[0]["NickName"].ToString(),
                    dtData.DefaultView[0]["Email"].ToString(),
                    dtData.DefaultView[0]["WebPage"].ToString(),
                    dtData.DefaultView[0]["Mobile"].ToString(),
                    dtData.DefaultView[0]["Phone"].ToString(),
                    dtData.DefaultView[0]["Address"].ToString(),
                    dtData.DefaultView[0]["Username"].ToString(),
                    dtData.DefaultView[0]["Password"].ToString(),
                    DateTime.Parse(dtData.DefaultView[0]["RegDate"].ToString()),
                    DateTime.Parse(dtData.DefaultView[0]["LastLogin"].ToString()),
                    bool.Parse(dtData.DefaultView[0]["IsActive"].ToString()));
            }
            //
            return new Member();
        }

        public List<Member> GetRelatedMembersFor(int DBID)
        {
            List<Member> list = new List<Member>();
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@MemberID", DBID));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetRelatedMembers", param);
            //
            if (dtData != null)
                foreach (DataRowView drv in dtData.DefaultView)
                {
                    int ID1 = int.Parse(drv["MemberID1"].ToString()),
                        ID2 = int.Parse(drv["MemberID2"].ToString());
                    //
                    Member m = new Member();
                    //
                    if (ID1 != DBID)
                        m = GetMemeberInfo(ID1);
                    else if (ID2 != DBID)
                        m = GetMemeberInfo(ID2);
                    //
                    if (m.DBID != -1)
                        list.Add(m);
                }
            //
            return list;
        }

        #endregion

        #region Packet

        public void AddNewPacket(Queue queue, bool Delivered)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@FromMemberID", queue.FromMemberID));
            param.Add(new SqlParameter("@ToMemberID", queue.ToMemberID));
            param.Add(new SqlParameter("@SentDateTime", queue.SentDateTime));
            param.Add(new SqlParameter("@Message", queue.Message));
            param.Add(new SqlParameter("@StatusID", Delivered ? 1 : 2));
            //
            dbS.ExecuteStoredProc("AddNewPacket", param);
        }

        public void MakeAsDeliverPacket(int DBID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", DBID));
            //
            dbS.ExecuteStoredProc("MakeAsDeliveredPacket", param);
        }

        public List<Queue> GetAllPending()
        {
            List<Queue> list = new List<Queue>();
            //
            //
            return list;
        }

        public List<Queue> GetPendingTo(int ToMemberID)
        {
            List<Queue> list = new List<Queue>();
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@MemberID", ToMemberID));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetPendingFor", param);
            //
            if (dtData != null)
                for (int i = 0; i < dtData.DefaultView.Count; i++)
                {
                    list.Add(new Queue(
                    int.Parse(dtData.DefaultView[i]["ID"].ToString()),
                    int.Parse(dtData.DefaultView[i]["FromMemberID"].ToString()),
                    int.Parse(dtData.DefaultView[i]["ToMemberID"].ToString()),
                    DateTime.Parse(dtData.DefaultView[i]["SentDateTime"].ToString()),
                    dtData.DefaultView[i]["Message"].ToString()));
                }
            //
            return list;
        }

        #endregion
    }
}
