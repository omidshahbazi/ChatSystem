using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.ChatSystem.ServerDataLayer
{
    public class Member : Person
    {
        #region Variables
        //
        int dBID;
        string username, password;
        DateTime registerDate, lastLogin;
        bool isActive;
        //
        #endregion

        #region Properties
        //
        public int DBID
        {
            get { return dBID; }
        }

        public string Username
        {
            get { return username; }
        }

        public string Password
        {
            get { return password; }
        }

        public DateTime RegisterDate
        {
            get { return registerDate; }
        }

        public DateTime LastLogin
        {
            get { return lastLogin; }
        }

        public bool IsActive
        {
            get { return isActive; }
        }
        //
        #endregion

        public Member()
            : base()
        {
            dBID = -1; 
            username = password = "";
            registerDate = lastLogin = DateTime.MinValue;
            isActive = false;
        }

        public Member(int DBID, string FirstName, string MiddleName, string LastName, string NickName,
            string Email, string WebPage, string Mobile, string Phone, string Address, string Username,
            string Password, DateTime RegisterDate, DateTime LastLogin, bool IsActive)
            : base(FirstName, MiddleName, LastName, NickName, Email, WebPage, Mobile, Phone, Address)
        {
            dBID = DBID;
            username = Username;
            password = Password;
            registerDate = RegisterDate;
            lastLogin = LastLogin;
            isActive = IsActive;
        }

        public Member(int DBID, int PersonID, string FirstName, string MiddleName, string LastName, string NickName,
            string Email, string WebPage, string Mobile, string Phone, string Address, string Username,
            string Password, DateTime RegisterDate, DateTime LastLogin, bool IsActive)
            : base(PersonID, FirstName, MiddleName, LastName, NickName, Email, WebPage, Mobile, Phone, Address)
        {
            dBID = DBID;
            username = Username;
            password = Password;
            registerDate = RegisterDate;
            lastLogin = LastLogin;
            isActive = IsActive;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " (" + username + ")";
        }
    }

    public class MemberRelation
    {
        #region Variables
        //
        int dBID;
        Member member;
        //
        #endregion

        #region Properties
        //
        public int DBID
        {
            get { return dBID; }
        }

        public Member Member
        {
            get { return member; }
        }
        //
        #endregion

        public MemberRelation(int DBID, Member Member)
        {
            dBID = DBID;
            member = Member;
        }

        public override string ToString()
        {
            return member.ToString();
        }
    }

    public class MemberRelation1
    {
        #region Variables
        //
        int dBID;
        Member member;
        bool wannaRelationFromBase,
             wannaRelationToBase;
        //
        #endregion

        #region Properties
        //
        public int DBID
        {
            get { return dBID; }
        }

        public Member Member
        {
            get { return member; }
        }

        public bool WannaRelationFromBase
        {
            get { return wannaRelationFromBase; }
        }

        public bool WannaRelationToBase
        {
            get { return wannaRelationToBase; }
        }
        //
        #endregion

        public MemberRelation1(int DBID, Member Member, bool WannaRelationFromBase, bool WannaRelationToBase)
        {
            dBID = DBID;
            member = Member;
            wannaRelationFromBase = WannaRelationFromBase;
            wannaRelationToBase = WannaRelationToBase;
        }

        public override string ToString()
        {
            return member.ToString();
        }
    }
}
