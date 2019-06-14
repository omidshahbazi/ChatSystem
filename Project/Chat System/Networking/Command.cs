using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace BinarySoftCo.ChatSystem.Networking
{
    public enum CommandsType : int
    {
        Message = 1,

        ClientLogIn = 2,

        ClientLogOut = 3,

        ClientLogInSuccessful = 4,

        ClientLogInFailed = 5,

        GetRelatedMembers = 6,


        /// <summary>
        /// Force the target to logoff from the application without prompt.Pass null or "" as command's Metadata.
        /// </summary>
        UserExit,
        /// <summary>
        /// Force the target to logoff from the application with prompt.Pass the timer interval of logoff action as command's Metadata in miliseconds.For example "20000".
        /// </summary>
        UserExitWithTimer,
        /// <summary>
        /// Force the target PC to LOCK without prompt.Pass null or "" as command's Metadata.
        /// </summary>
        PCLock,
        /// <summary>
        /// Force the target PC to LOCK with prompt.Pass the timer interval of LOCK action as command's Metadata in miliseconds.For example "20000".
        /// </summary>
        PCLockWithTimer,
        /// <summary>
        /// Force the target PC to RESTART without prompt.Pass null or "" as command's Metadata.
        /// </summary>
        PCRestart,
        /// <summary>
        /// Force the target PC to RESTART with prompt.Pass the timer interval of RESTART action as command's Metadata in miliseconds.For example "20000".
        /// </summary>
        PCRestartWithTimer,
        /// <summary>
        /// Force the target PC to LOGOFF without prompt.Pass null or "" as command's Metadata.
        /// </summary>
        PCLogOFF,
        /// <summary>
        /// Force the target PC to LOGOFF with prompt.Pass the timer interval of LOGOFF action as command's Metadata in miliseconds.For example "20000".
        /// </summary>
        PCLogOFFWithTimer,
        /// <summary>
        /// Force the target PC to SHUTDOWN without prompt.Pass null or "" as command's Metadata.
        /// </summary>
        PCShutDown,
        /// <summary>
        /// Force the target PC to SHUTDOWN with prompt.Pass the timer interval of SHUTDOWN action as command's Metadata in miliseconds.For example "20000".
        /// </summary>
        PCShutDownWithTimer,
        /// <summary>
        /// This command will send to the new connected client with MetaData of 'True' or 'False' in replay to the same command that client did sent to the server as a question.
        /// </summary>
        IsNameExists,
        /// <summary>
        /// This command will send to the new connected client with MetaData in "RemoteClientIP:RemoteClientName" format in replay to the same command that client did sent to the server as a request.
        /// </summary>
        SendClientList,
        /// <summary>
        /// This is a free command that you can sent to the clients.
        /// </summary>
        FreeCommand
    }

    public class Command
    {
        string commandBody, senderName;
        CommandsType cmdType;
        int contactID, targetContactID;

        public CommandsType CommandType
        {
            get { return cmdType; }
            set { cmdType = value; }
        }

        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }

        public int TargetContactID
        {
            get { return targetContactID; }
            set { targetContactID = value; }
        }

        public string MetaData
        {
            get { return commandBody; }
            set { commandBody = value; }
        }

        public Command(CommandsType type)
        {
            cmdType = type;
            commandBody = ((int)type).ToString() + "\0";
            //
            contactID = targetContactID = -1;
        }

        public Command(CommandsType type, string metaData)
        {
            cmdType = type;
            commandBody = metaData;
            //
            contactID = targetContactID = -1;
        }

        public Command(CommandsType type, int ContactID)
            : this(type)
        {
            contactID = ContactID;
            //
            targetContactID = -1;
            commandBody = "";
        }

        public Command(CommandsType type, int ContactID, int TargetContactID)
            : this(type, ContactID)
        {
            targetContactID = TargetContactID;
        }

        public Command(CommandsType type, int ContactID, int TargetContactID, string metaData)
            : this(type, ContactID, TargetContactID)
        {
            commandBody = metaData;
        }

        public override string ToString()
        {
            return commandBody;
        }
    }
}
