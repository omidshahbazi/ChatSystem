using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using BinarySoftCo.DatabaseAccess.SQL;
using BinarySoftCo.ChatSystem.ServerNetworking;

namespace BinarySoftCo.ChatSystem.ServerDataLayer
{
    public class BaseData
    {
        DBSQL dbS;
        
        public BaseData()
        {
            dbS = new DBSQL(Constants.ServerAddress, "ChatSystem", "sa", "123");
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

        #region Persons

        #region Search
        
        public DataTable FilteInPersonsBase(string Value)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Value", Value));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("FilterInPersons", param);
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
                return dtData;
            //
            return new DataTable();
        }

        public List<Person> FilterInPersons(string Value)
        {
            DataTable dtData = FilteInPersonsBase(Value);
            //
            List<Person> persons = new List<Person>();
            //
            if (dtData != null)
                foreach (DataRowView drv in dtData.DefaultView)
                    persons.Add(new Person(
                        int.Parse(drv["ID"].ToString()),
                        drv["FirstName"].ToString(),
                        drv["MiddleName"].ToString(),
                        drv["LastName"].ToString(),
                        drv["NickName"].ToString(),
                        drv["Email"].ToString(),
                        drv["WebPage"].ToString(),
                        drv["Mobile"].ToString(),
                        drv["Phone"].ToString(),
                        drv["Address"].ToString()));
            //
            return persons;
        }

        #endregion

        #region Select

        public DataTable GetAllPersonsInfoBase()
        {
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetPersonsInfo");
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
                return dtData;
            //
            return new DataTable();
        }

        public List<Person> GetAllPersonsInfo()
        {
            DataTable dtData = GetAllPersonsInfoBase();
            //
            List<Person> persons = new List<Person>();
            //
            if (dtData != null)
                foreach (DataRowView drv in dtData.DefaultView)
                    persons.Add(new Person(
                        int.Parse(drv["ID"].ToString()),
                        drv["FirstName"].ToString(),
                        drv["MiddleName"].ToString(),
                        drv["LastName"].ToString(),
                        drv["NickName"].ToString(),
                        drv["Email"].ToString(),
                        drv["WebPage"].ToString(),
                        drv["Mobile"].ToString(),
                        drv["Phone"].ToString(),
                        drv["Address"].ToString()));
            //
            return persons;
        }

        #endregion

        #region Add,Edit,Delete

        public void AddPerson(Person person)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@FirstName", person.FirstName));
            param.Add(new SqlParameter("@MiddleName", person.MiddleName));
            param.Add(new SqlParameter("@LastName", person.LastName));
            param.Add(new SqlParameter("@NickName", person.NickName));
            param.Add(new SqlParameter("@Email", person.Email));
            param.Add(new SqlParameter("@WebPage", person.WebPage));
            param.Add(new SqlParameter("@Mobile", person.Mobile));
            param.Add(new SqlParameter("@Phone", person.Phone));
            param.Add(new SqlParameter("@Address", person.Address));
            //
            dbS.ExecuteStoredProc("AddPerson", param);
        }

        public void UpdatePerson(Person person)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", person.PersonDBID));
            param.Add(new SqlParameter("@FirstName", person.FirstName));
            param.Add(new SqlParameter("@MiddleName", person.MiddleName));
            param.Add(new SqlParameter("@LastName", person.LastName));
            param.Add(new SqlParameter("@NickName", person.NickName));
            param.Add(new SqlParameter("@Email", person.Email));
            param.Add(new SqlParameter("@WebPage", person.WebPage));
            param.Add(new SqlParameter("@Mobile", person.Mobile));
            param.Add(new SqlParameter("@Phone", person.Phone));
            param.Add(new SqlParameter("@Address", person.Address));
            //
            dbS.ExecuteStoredProc("UpdatePerson", param);
        }

        public void DeletePerson(int DBID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", DBID));
            //
            dbS.ExecuteStoredProc("DeletePerson", param);
        }

        #endregion

        #endregion

        #region Members

        #region Check

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

        public bool CheckForMemberExists(string Username)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Username", Username));
            //
            DataTable dtUser = dbS.ExecuteStoredProcReturn("CheckForMemberExists", param);
            //
            if (dtUser != null && dtUser.DefaultView.Count > 0)
                if (int.Parse(dtUser.DefaultView[0]["flag"].ToString()) > 0)
                    return true;
            //
            return false;
        }

        #endregion

        #region Search

        public DataTable FilteInMembersBase(string Value)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Value", Value));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("FilterInMembers", param);
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
                return dtData;
            //
            return new DataTable();
        }

        public List<Member> FilteInMembers(string Value)
        {
            DataTable dtData = FilteInMembersBase(Value);
            //
            List<Member> members = new List<Member>();
            //
            if (dtData != null)
                foreach (DataRowView drv in dtData.DefaultView)
                    members.Add(new Member(
                        int.Parse(drv["MemberID"].ToString()),
                        int.Parse(drv["PersonID"].ToString()),
                        drv["FirstName"].ToString(),
                        drv["MiddleName"].ToString(),
                        drv["LastName"].ToString(),
                        drv["NickName"].ToString(),
                        drv["Email"].ToString(),
                        drv["WebPage"].ToString(),
                        drv["Mobile"].ToString(),
                        drv["Phone"].ToString(),
                        drv["Address"].ToString(),
                        drv["Username"].ToString(),
                        drv["Password"].ToString(),
                        DateTime.Parse(drv["RegDate"].ToString()),
                        DateTime.Parse(drv["LastLogin"].ToString()),
                        bool.Parse(drv["IsActive"].ToString())));
            //
            return members;
        }

        #endregion

        #region Select

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

        public DataTable GetAllMemebersInfoBase()
        {
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetMembersInfo");
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
                return dtData;
            //
            return new DataTable();
        }

        public List<Member> GetAllMembersInfo()
        {
            DataTable dtData = GetAllMemebersInfoBase();
            //
            List<Member> members = new List<Member>();
            //
            if (dtData != null)
                foreach (DataRowView drv in dtData.DefaultView)
                    members.Add(new Member(
                        int.Parse(drv["MemberID"].ToString()),
                        int.Parse(drv["PersonID"].ToString()),
                        drv["FirstName"].ToString(),
                        drv["MiddleName"].ToString(),
                        drv["LastName"].ToString(),
                        drv["NickName"].ToString(),
                        drv["Email"].ToString(),
                        drv["WebPage"].ToString(),
                        drv["Mobile"].ToString(),
                        drv["Phone"].ToString(),
                        drv["Address"].ToString(),
                        drv["Username"].ToString(),
                        drv["Password"].ToString(),
                        DateTime.Parse(drv["RegDate"].ToString()),
                        DateTime.Parse(drv["LastLogin"].ToString()),
                        bool.Parse(drv["IsActive"].ToString())));
            //
            return members;
        }

        public List<MemberRelation> GetRelationsFor(int DBID)
        {
            List<MemberRelation> list = new List<MemberRelation>();
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@MemberID", DBID));
            //GetRelations
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetRelatedMembers", param);
            //
            if (dtData != null)
                foreach (DataRowView drv in dtData.DefaultView)
                {
                    Member m = new Member(
                    int.Parse(drv["MemberID"].ToString()),
                    drv["FirstName"].ToString(),
                    drv["MiddleName"].ToString(),
                    drv["LastName"].ToString(),
                    drv["NickName"].ToString(),
                    drv["Email"].ToString(),
                    drv["WebPage"].ToString(),
                    drv["Mobile"].ToString(),
                    drv["Phone"].ToString(),
                    drv["Address"].ToString(),
                    drv["Username"].ToString(),
                    drv["Password"].ToString(),
                    DateTime.Parse(drv["RegDate"].ToString()),
                    DateTime.Parse(drv["LastLogin"].ToString()),
                    bool.Parse(drv["IsActive"].ToString()));
                    //
                    list.Add(new MemberRelation(
                        int.Parse(drv["ID"].ToString()),
                        m));
                }
            //
            return list;
        }

        public List<Member> GetRelatedMembersFor(int DBID)
        {
            List<Member> list = new List<Member>();
            //
            List<MemberRelation> ls = GetRelationsFor(DBID);
            //
            foreach (MemberRelation mr in ls)
                list.Add(mr.Member);
            //
            return list;
        }

        public MemberRelation GetRelationWith(int MemberID, int FriendID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@MemberID", MemberID));
            param.Add(new SqlParameter("@FriendID", FriendID));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("RelationWith", param);
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
            {
                Member m = new Member(
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
                //
                return new MemberRelation(
                    int.Parse(dtData.DefaultView[0]["ID"].ToString()),
                    m);
            }
            //
            return null;
        }

        #endregion

        #region Add,Edit,Delete

        public int AddMember(Member member)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@PersonID", member.PersonDBID));
            param.Add(new SqlParameter("@RegDate", member.RegisterDate));
            param.Add(new SqlParameter("@Username", member.Username));
            param.Add(new SqlParameter("@Password", member.Password));
            param.Add(new SqlParameter("@IsActive", member.IsActive.ToString()));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("AddMember", param);
            //
            return int.Parse(dtData.DefaultView[0]["ID"].ToString());
        }

        public int AddMemberWithPerson(Member member)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@FirstName", member.FirstName));
            param.Add(new SqlParameter("@MiddleName", member.MiddleName));
            param.Add(new SqlParameter("@LastName", member.LastName));
            param.Add(new SqlParameter("@NickName", member.NickName));
            param.Add(new SqlParameter("@Email", member.Email));
            param.Add(new SqlParameter("@WebPage", member.WebPage));
            param.Add(new SqlParameter("@Mobile", member.Mobile));
            param.Add(new SqlParameter("@Phone", member.Phone));
            param.Add(new SqlParameter("@Address", member.Address));
            param.Add(new SqlParameter("@RegDate", member.RegisterDate));
            param.Add(new SqlParameter("@Username", member.Username));
            param.Add(new SqlParameter("@Password", member.Password));
            param.Add(new SqlParameter("@IsActive", member.IsActive));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("AddMemberWithPerson", param);
            //
            return int.Parse(dtData.DefaultView[0]["ID"].ToString());
        }

        public void UpdateMember(Member member)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", member.PersonDBID));
            param.Add(new SqlParameter("@PersonID", member.PersonDBID));
            param.Add(new SqlParameter("@Username", member.Username));
            param.Add(new SqlParameter("@Password", member.Password));
            param.Add(new SqlParameter("@IsActive", member.IsActive.ToString()));
            //
            dbS.ExecuteStoredProc("UpdateMember", param);
        }

        public void DeleteMember(int DBID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", DBID));
            //
            dbS.ExecuteStoredProc("DeleteMember", param);
        }

        public void ActivationMember(int DBID, bool IsActive)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", DBID));
            param.Add(new SqlParameter("@IsActive", IsActive.ToString()));
            //
            dbS.ExecuteStoredProc("ActivationMember", param);
        }

        public int AddMemberRelation(int MemberID, int FriendID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@MemberID", MemberID));
            param.Add(new SqlParameter("@FriendID", FriendID));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("AddMemberRelation", param);
            //
            return int.Parse(dtData.DefaultView[0]["ID"].ToString());
        }

        public void DeleteMemberRelation(int DBID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", DBID));
            //
            dbS.ExecuteStoredProc("DeleteMemberRelation", param);
        }

        #endregion

        #endregion

        #region Packet

        #region Select

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

        #region Add,Edit,Delete

        public int AddNewPacket(Queue queue, bool Delivered)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@FromMemberID", queue.FromMemberID));
            param.Add(new SqlParameter("@ToMemberID", queue.ToMemberID));
            param.Add(new SqlParameter("@SentDateTime", queue.SentDateTime));
            param.Add(new SqlParameter("@Message", queue.Message));
            param.Add(new SqlParameter("@StatusID", Delivered ? 1 : 2));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("AddNewPacket", param);
            //
            return int.Parse(dtData.DefaultView[0]["ID"].ToString());
        }

        public void MakeAsDeliverPacket(int DBID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", DBID));
            //
            dbS.ExecuteStoredProc("MakeAsDeliveredPacket", param);
        }

        #endregion

        #endregion

        #region Commands

        #region Search

        #endregion

        #region Select

        public DataTable GetCommandsBase(bool Incoming)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Incoming", Incoming.ToString()));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetCommands", param);
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
                return dtData;
            //
            return new DataTable();
        }

        public List<Command> GetAllIncomingCommands()
        {
            List<Command> list = new List<Command>();
            //
            DataTable dtData = GetCommandsBase(true);
            //
            foreach (DataRowView drv in dtData.DefaultView)
                list.Add(new Command(
                    int.Parse(drv["ID"].ToString()),
                    (CommandsType)int.Parse(drv["Type"].ToString()),
                    int.Parse(drv["FromMemberID"].ToString()),
                    int.Parse(drv["ToMemberID"].ToString()),
                    drv["CommandContent"].ToString(),
                    drv["MetaData"].ToString()));
            //
            return list;
        }

        public List<Command> GetAllOutgoingCommands()
        {
            List<Command> list = new List<Command>();
            //
            DataTable dtData = GetCommandsBase(false);
            //
            foreach (DataRowView drv in dtData.DefaultView)
                list.Add(new Command(
                    int.Parse(drv["ID"].ToString()),
                    (CommandsType)int.Parse(drv["Type"].ToString()),
                    int.Parse(drv["FromMemberID"].ToString()),
                    int.Parse(drv["ToMemberID"].ToString()),
                    drv["CommandContent"].ToString(),
                    drv["MetaData"].ToString()));
            //
            return list;
        }

        public DataTable GetCommandsForBase(bool Incoming, int ToMemberID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Incoming", Incoming.ToString()));
            param.Add(new SqlParameter("@ToMemberID", ToMemberID));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("GetCommandsFor", param);
            //
            if (dtData != null && dtData.DefaultView.Count > 0)
                return dtData;
            //
            return new DataTable();
        }

        public List<Command> GetOutgoingCommandsFor(int ToMemberID)
        {
            List<Command> list = new List<Command>();
            //
            DataTable dtData = GetCommandsForBase(false, ToMemberID);
            //
            foreach (DataRowView drv in dtData.DefaultView)
                list.Add(new Command(
                    int.Parse(drv["ID"].ToString()),
                    (CommandsType)int.Parse(drv["Type"].ToString()),
                    int.Parse(drv["FromMemberID"].ToString()),
                    int.Parse(drv["ToMemberID"].ToString()),
                    drv["CommandContent"].ToString(),
                    drv["MetaData"].ToString()));
            //
            return list;
        }

        #endregion

        #region Add,Edit,Delete

        public int AddCommand(Command cmd, bool Incoming)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@Type", (int)cmd.Type));
            param.Add(new SqlParameter("@FromMemberID", cmd.FromMemberID));
            param.Add(new SqlParameter("@ToMemberID", cmd.ToMemberID));
            param.Add(new SqlParameter("@CommandContent", cmd.Content));
            param.Add(new SqlParameter("@MetaData", cmd.MetaData));
            param.Add(new SqlParameter("@SentDateTime", DateTime.Now.ToString()));
            param.Add(new SqlParameter("@Incoming", Incoming.ToString()));
            //
            DataTable dtData = dbS.ExecuteStoredProcReturn("AddCommand", param);
            //
            return int.Parse(dtData.DefaultView[0]["ID"].ToString());
        }

        public int AddIncomingCommand(Command cmd)
        {
            return AddCommand(cmd, true);
        }

        public int AddOutgoingCommand(Command cmd)
        {
            return AddCommand(cmd, false);
        }

        public void DeleteCommand(int DBID)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            //
            param.Add(new SqlParameter("@ID", DBID));
            //
            dbS.ExecuteStoredProc("DeleteCommand", param);
        }

        #endregion

        #endregion
    }
}