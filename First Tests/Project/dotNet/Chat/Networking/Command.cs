using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace BinarySoftCo.Networking.Chat
{
    /// <summary>
    /// The type of commands that you can sent to the clients.(Note : These are just some comman types.You should do the desired actions when a command received to the client yourself.)
    /// </summary>
    public enum CommandType
    {
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
        /// Send a text message to the server.Pass the body of text message as command's Metadata.
        /// </summary>
        Message,
        /// <summary>
        /// This command will sent to all clients when an specific client is had been logged in to the server.The metadata of this command is in this format : "RemoteClientIP:RemoteClientName"
        /// </summary>
        ClientLoginInform,
        /// <summary>
        /// This command will sent to all clients when an specific client is had been logged off from the server.
        /// </summary>
        ClientLogOffInform,
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

    /// <summary>
    /// The command class.
    /// </summary>
    public class Command
    {
        private CommandType cmdType;
        private string commandBody, senderName;
        private IPAddress senderIP;
        private int targetContactID;

        /// <summary>
        /// The type of command to send.If you wanna use the Message command type,create a Message class instead of command.
        /// </summary>
        public CommandType CommandType
        {
            get { return cmdType; }
            set { cmdType = value; }
        }

        /// <summary>
        /// [Gets/Sets] The IP address of command sender.
        /// </summary>
        public IPAddress SenderIP
        {
            get { return senderIP; }
            set { senderIP = value; }
        }

        /// <summary>
        /// [Gets/Sets] The name of command sender.
        /// </summary>
        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        /// <summary>
        /// [Gets/Sets] The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.
        /// </summary>
        public int TargetContactID
        {
            get { return targetContactID; }
            set { targetContactID = value; }
        }

        /// <summary>
        /// The body of the command.This string is different in various commands.
        /// <para>Message : The text of the message.</para>
        /// <para>ClientLoginInform,SendClientList : "RemoteClientIP:RemoteClientName".</para>
        /// <para>***WithTimer : The interval of timer in miliseconds..The default value is 60000 equal to 1 min.</para>
        /// <para>IsNameExists : 'True' or 'False'</para>
        /// <para>Otherwise pass the "" or null.</para>
        /// </summary>
        public string MetaData
        {
            get { return commandBody; }
            set { commandBody = value; }
        }

        /// <summary>
        /// Creates an instance of command object to send over the network.
        /// </summary>
        /// <param name="type">The type of command.If you wanna use the Message command type,create a Message class instead of command.</param>
        /// <param name="targetMachine">The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.</param>
        public Command(CommandType type, IPAddress SenderMachine, int TargetContactID)
        {
            cmdType = type;
            senderIP = SenderMachine;
            targetContactID = TargetContactID;
            commandBody = "";
        }

        /// <summary>
        /// Creates an instance of command object to send over the network.
        /// </summary>
        /// <param name="type">The type of command.If you wanna use the Message command type,create a Message class instead of command.</param>
        /// <param name="targetMachine">The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.</param>
        /// <param name="metaData">
        /// The body of the command.This string is different in various commands.
        /// <para>Message : The text of the message.</para>
        /// <para>ClientLoginInform,SendClientList : "RemoteClientIP:RemoteClientName".</para>
        /// <para>***WithTimer : The interval of timer in miliseconds..The default value is 60000 equal to 1 min.</para>
        /// <para>IsNameExists : 'True' or 'False'</para>
        /// <para>Otherwise pass the "" or null or use the next overriden constructor.</para>
        /// </param>
        public Command(CommandType type, IPAddress SenderMachine, int TargetContactID, string metaData)
            : this(type, SenderMachine, TargetContactID)
        {
            commandBody = metaData;
        }

        public override string ToString()
        {
            return commandBody;
        }
    }
}
