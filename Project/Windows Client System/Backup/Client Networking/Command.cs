using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using BinarySoftCo.ChatSystem.ClientDataLayer;

namespace BinarySoftCo.ChatSystem.ServerNetworking
{
    public enum CommandsType : int
    {
        Message = 1,

        SignIn = 2,

        SignOut = 3,

        SignInSuccessful = 4,

        SignInFailed = 5,

        GetRelatedMembers = 6,

        GetRelatedMembersResponse = 7,

        FindPerson = 8,

        PersonData = 9,

        RegisterMemberWithNewPerson = 10,

        RegisterMemberWithOldPerson = 11,

        RegisterMemberSuccessful = 12,

        RegisterMemberFailed = 13,

        FindMember = 14,

        MemberData = 15,

        AddNewFriend = 16,

        DeleteFriend = 17,

        ClienAvailableStatusChanged = 18,

        GetCommands = 19,
        
        HTTPClientSignal = 20
    }

    public class Command
    {
        #region Variables
        //
        public const char Spliter = '^';
        //
        int dBID = -1;
        string content, metaData;
        CommandsType type;
        int fromMemberID, toMemberID;
        //
        #endregion

        #region Properties
        //
        public int DBID
        {
            get { return dBID; }
        }

        public CommandsType Type
        {
            get { return type; }
            set { type = value; }
        }

        public int FromMemberID
        {
            get { return fromMemberID; }
            set { fromMemberID = value; }
        }

        public int ToMemberID
        {
            get { return toMemberID; }
            set { toMemberID = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string MetaData
        {
            get { return metaData; }
            set { metaData = value; }
        }
        //
        #endregion

        public Command(CommandsType Type)
        {
            type = Type;
            //
            fromMemberID = toMemberID = -1;
            //
            content = metaData = "";
        }

        public Command(int DBID, CommandsType Type, int FromMemberID, int ToMemberID, string Content, string MetaData)
            : this(Type)
        {
            dBID = DBID;
            fromMemberID = FromMemberID;
            toMemberID = ToMemberID;
            content = Content;
            metaData = MetaData;
        }

        /// <summary>
        /// For Client Login
        /// </summary>
        public Command(string Username, string Password)
            : this(CommandsType.SignIn)
        {
            content = metaData = Username + Spliter.ToString() + Password;
        }

        /// <summary>
        /// For Get Related Members Response
        /// </summary>
        public Command(AvailableStatus Status, int MemberID, string FullMemberName)
            : this(CommandsType.GetRelatedMembersResponse)
        {
            content = metaData = ((int)Status).ToString() + Spliter.ToString() + MemberID.ToString() + Spliter.ToString() + FullMemberName;
        }

        /// <summary>
        /// For Message
        /// </summary>
        public Command(int MemberID, string Content, bool Outgoing)
            : this(CommandsType.Message)
        {
            if (Outgoing)
                toMemberID = MemberID;
            else
                fromMemberID = MemberID;
            //
            content = Content;
            metaData = toMemberID + Spliter.ToString() + content;
        }

        /// <summary>
        /// For Related Message
        /// </summary>
        public Command(int FromMemberID, int ToMemberID, string Content)
            : this(CommandsType.Message)
        {
            fromMemberID = FromMemberID;
            toMemberID = ToMemberID;
            //
            content = Content;
            metaData = fromMemberID + Spliter.ToString() + content;
        }

        /// <summary>
        /// For Find Person/Member
        /// </summary>
        public Command(CommandsType Type, string Value)
            : this(Type)
        {
            content = metaData = Value;
        }

        /// <summary>
        /// For Person Data
        /// </summary>
        public Command(int DBID, string FirstName, string MiddleName, string LastName, string NickName, string Email, string WebPage, string Mobile, string Phone, string Address)
            : this(CommandsType.PersonData)
        {
            content = metaData =
                " " + DBID + Spliter.ToString() + " " +
                FirstName + Spliter.ToString() + " " +
                MiddleName + Spliter.ToString() + " " +
                LastName + Spliter.ToString() + " " +
                NickName + Spliter.ToString() + " " +
                Email + Spliter.ToString() + " " +
                WebPage + Spliter.ToString() + " " +
                Mobile + Spliter.ToString() + " " +
                Phone + Spliter.ToString() + " " +
                Address;
        }

        /// <summary>
        /// For Member Data
        /// </summary>
        public Command(int DBID, string FirstName, string MiddleName, string LastName, string NickName, string Email, string WebPage, string Mobile, string Phone, string Address, string Username, string Password)
            : this(CommandsType.MemberData)
        {
            content = metaData =
                " " + DBID + Spliter.ToString() + " " +
                FirstName + Spliter.ToString() + " " +
                MiddleName + Spliter.ToString() + " " +
                LastName + Spliter.ToString() + " " +
                NickName + Spliter.ToString() + " " +
                Email + Spliter.ToString() + " " +
                WebPage + Spliter.ToString() + " " +
                Mobile + Spliter.ToString() + " " +
                Phone + Spliter.ToString() + " " +
                Address + Spliter.ToString() + " " +
                Username + Spliter.ToString() + " " +
                Password;
        }

        /// <summary>
        /// For Register With New Person
        /// </summary>
        public Command(string FirstName, string MiddleName, string LastName, string NickName, string Email, string WebPage, string Mobile, string Phone, string Address, string Username, string Password)
            : this(CommandsType.RegisterMemberWithNewPerson)
        {
            content = metaData =
                FirstName + Spliter.ToString() + " " +
                MiddleName + Spliter.ToString() + " " +
                LastName + Spliter.ToString() + " " +
                NickName + Spliter.ToString() + " " +
                Email + Spliter.ToString() + " " +
                WebPage + Spliter.ToString() + " " +
                Mobile + Spliter.ToString() + " " +
                Phone + Spliter.ToString() + " " +
                Address + Spliter.ToString() + " " +
                Username + Spliter.ToString() + " " +
                Password;
        }

        /// <summary>
        /// For Register With Old Person
        /// </summary>
        public Command(int PersonID, string Username, string Password)
            : this(CommandsType.RegisterMemberWithOldPerson)
        {
            content = metaData =
                PersonID + Spliter.ToString() + " " +
                Username + Spliter.ToString() + " " +
                Password;
        }

        /// <summary>
        /// Add New/Delete Friend
        /// </summary>
        public Command(CommandsType Type, int FreindID)
            : this(Type)
        {
            content = metaData = FreindID.ToString();
        }

        /// <summary>
        /// Client Available Status Changed
        /// </summary>
        public Command(int MemberID, AvailableStatus Status)
            : this(CommandsType.ClienAvailableStatusChanged)
        {
            content = metaData = 
                " " + MemberID.ToString() + " " + Spliter + 
                " " + ((int)Status).ToString();
        }

        /// <summary>
        /// For Register Member Result
        /// </summary>
        public Command(bool Successful, string MessageContent)
            : this(Successful ? 
            CommandsType.RegisterMemberSuccessful :
            CommandsType.RegisterMemberFailed)
        {
            content = metaData = MessageContent;
        }

        public override string ToString()
        {
            string temp = ((int)type).ToString();
            //
            switch (type)
            {
                case CommandsType.SignIn:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.SignInFailed:
                    //Nothing
                    break;

                case CommandsType.SignInSuccessful:
                    //Nothing
                    break;

                case CommandsType.SignOut:
                    //Nothing
                    break;

                case CommandsType.GetRelatedMembers:
                    //Nothing
                    break;

                case CommandsType.GetRelatedMembersResponse:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.Message:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.FindPerson:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.PersonData:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.RegisterMemberWithNewPerson:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.RegisterMemberWithOldPerson:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.RegisterMemberSuccessful:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.RegisterMemberFailed:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.FindMember:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.MemberData:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.AddNewFriend:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.DeleteFriend:
                    temp += Spliter.ToString() + metaData;
                    break;

                case CommandsType.ClienAvailableStatusChanged:
                    temp += Spliter.ToString() + metaData;
                    break;
            }
            //
            return temp;
        }
    }
}