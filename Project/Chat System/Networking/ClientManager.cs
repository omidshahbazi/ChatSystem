using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

using ConstantsVariables;
using BinarySoftCo.ChatSystem.DataLayer;

namespace BinarySoftCo.ChatSystem.Networking
{
    public class ClientManager
    {
        #region Variables

        char Spliter = '\u00b6';
        public static char spliter = '^';

        Member contactInfo;
        NetworkStream stream;
        Socket socket;
        
        Semaphore semaphor = new Semaphore(1, 1);

        #endregion

        #region Properties

        public Member ContactInformation
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        public IPEndPoint IPPort
        {
            get
            {
                if (this.socket != null)
                    return (IPEndPoint)this.socket.RemoteEndPoint;
                else
                    return new IPEndPoint(IPAddress.None, 0);
            }
        }

        public IPAddress IP
        {
            get
            {
                if (this.socket != null)
                    return ((IPEndPoint)this.socket.RemoteEndPoint).Address;
                else
                    return IPAddress.None;
            }
        }

        public int Port
        {
            get
            {
                if (this.socket != null)
                    return ((IPEndPoint)this.socket.RemoteEndPoint).Port;
                else
                    return 0;
            }
        }

        public bool Connected
        {
            get
            {
                return this.socket.Connected;
            }
        }

        public bool LoggedIn
        {
            get { return (contactInfo.DBID > -1); }
        }

        #endregion

        #region Events
        //
        public event NewClientLoggedInEventHandler NewClientLoggedIn;

        /// <summary>
        /// Occurs when a command received from a remote client.
        /// </summary>
        public event CommandReceivedEventHandler CommandReceived;

        /// <summary>
        /// Occurs when a command had been sent to the remote client successfully.
        /// </summary>
        public event CommandSendingEventHandler CommandSending;

        /// <summary>
        /// Occurs when a client disconnected from this server.
        /// </summary>
        public event DisconnectedEventHandler Disconnected;

        protected virtual void OnNewClientLoggedIn(NewClientLoggedInEventArgs e)
        {
            if (NewClientLoggedIn != null)
                NewClientLoggedIn(this, e);
        }

        /// <summary>
        /// Occurs when a command received from a remote client.
        /// </summary>
        /// <param name="e">Received command.</param>
        protected virtual void OnCommandReceived(CommandEventArgs e)
        {
            if (CommandReceived != null)
                CommandReceived(this, e);
        }

        /// <summary>
        /// Occurs when a command had been sent to the remote client successfully.
        /// </summary>
        /// <param name="e">The sent command.</param>
        protected virtual void OnCommandSending(CommandSendingEventArgs e)
        {
            if (CommandSending != null)
                CommandSending(this, e);
        }

        /// <summary>
        /// Occurs when a client disconnected from this server.
        /// </summary>
        /// <param name="e">Client information.</param>
        protected virtual void OnDisconnected(ClientEventArgs e)
        {
            if (Disconnected != null)
                Disconnected(this, e);
        }
        //
        #endregion

        #region Constructor

        public ClientManager(Socket Socket)
        {
            this.socket = Socket;
            //
            this.stream = new NetworkStream(Socket);
            //
            BackgroundWorker bw_Reciever = new BackgroundWorker();
            bw_Reciever.WorkerSupportsCancellation = true;
            bw_Reciever.DoWork += new DoWorkEventHandler(RunReciever);
            bw_Reciever.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_Reciever_RunWorkerCompleted);
            bw_Reciever.RunWorkerAsync();
            //
            this.contactInfo = new Member();
        }

        #endregion

        #region Reciever
        //
        private void bw_Reciever_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //connection droped
        }

        private void RunReciever(object sender, DoWorkEventArgs e)
        {
            while (socket.Connected)
            {
                try
                {
                    byte[] buffer;
                    int readBytes;
                    //
                    buffer = new byte[1000];
                    readBytes = stream.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                        break;
                    //
                    string text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    //
                    string[] str = text.Split(Spliter);
                    //
                    str[str.Length - 1] = str[str.Length - 1].Split('\0')[0];
                    //
                    CommandsType ct = (CommandsType)int.Parse(str[0]);
                    if (ct == CommandsType.ClientLogIn)
                    {
                        if (Variables.BaseData.GetMemeberLoginStatus(str[1], str[2].Split('\0')[0]))
                        {
                            ContactInformation = Variables.BaseData.GetMemeberInfo(str[1]);

                            SendCommandToClient(new Command(CommandsType.ClientLogInSuccessful));
                            //
                            OnNewClientLoggedIn(new NewClientLoggedInEventArgs(this));
                        }
                        else
                            SendCommandToClient(new Command(CommandsType.ClientLogInFailed));
                    }
                    else if (ct == CommandsType.GetRelatedMembers)
                    {
                        //check for every one for offline online he/she
                        List<Member> list = Variables.BaseData.GetRelatedMembersFor(contactInfo.DBID);
                        foreach (Member m in list)
                        {
                            SendCommandToClient(new Command(CommandsType.GetRelatedMembers,
                                (int)CommandsType.GetRelatedMembers + spliter.ToString() + m.DBID + spliter.ToString() + m.ToString() + "\0"));
                        }
                    }
                    else if (ct == CommandsType.ClientLogOut)
                    {
                        Command cmd = new Command(ct, contactInfo.DBID, int.Parse(str[1]), str[2].Trim());
                        OnCommandReceived(new CommandEventArgs(IPPort, cmd));
                    }
                    else
                    {
                        Command cmd = new Command(ct, contactInfo.DBID, int.Parse(str[1]), (int)CommandsType.Message + spliter.ToString() + contactInfo.DBID.ToString() + spliter.ToString() + str[2].Trim());
                        OnCommandReceived(new CommandEventArgs(IPPort, cmd));
                    }
                }
                catch (System.IO.IOException er)
                {
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            //
            OnDisconnected(new ClientEventArgs(this));
            Disconnect();
        }
        //
        #endregion

        #region Sender
        //
        private bool SendCommandToClient(string MetaData)
        {
            try
            {
                semaphor.WaitOne();

                //MessageBox.Show( cmd.MetaData.Substring(0,1000)+"-");
                //Test
                byte[] data = Encoding.UTF8.GetBytes(MetaData + "\0");
                stream.Write(data, 0, data.Length);
                stream.Flush();

                ////Type
                //byte[] buffer = new byte[4];
                //buffer = BitConverter.GetBytes((int)cmd.CommandType);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();

                ////Sender IP
                //byte[] senderIPBuffer = Encoding.ASCII.GetBytes(cmd.ContactID.ToString());
                //buffer = new byte[4];
                //buffer = BitConverter.GetBytes(senderIPBuffer.Length);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();
                //stream.Write(senderIPBuffer, 0, senderIPBuffer.Length);
                //stream.Flush();

                ////Sender Name
                //byte[] senderNameBuffer = Encoding.Unicode.GetBytes(cmd.ContactID.ToString());
                //buffer = new byte[4];
                //buffer = BitConverter.GetBytes(senderNameBuffer.Length);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();
                //stream.Write(senderNameBuffer, 0, senderNameBuffer.Length);
                //stream.Flush();

                ////Target
                //byte[] ipBuffer = Encoding.ASCII.GetBytes(cmd.TargetContactID.ToString());
                //buffer = new byte[4];
                //buffer = BitConverter.GetBytes(ipBuffer.Length);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();
                //stream.Write(ipBuffer, 0, ipBuffer.Length);
                //stream.Flush();

                ////Meta Data.
                //if (cmd.MetaData == null || cmd.MetaData == "")
                //    cmd.MetaData = "\n";

                //byte[] metaBuffer = Encoding.Unicode.GetBytes(cmd.MetaData);
                //buffer = new byte[4];
                //buffer = BitConverter.GetBytes(metaBuffer.Length);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();
                //stream.Write(metaBuffer, 0, metaBuffer.Length);
                //stream.Flush();

                semaphor.Release();
                return true;
            }
            catch(Exception er)
            {
                semaphor.Release();
                return false;
            }
        }

        private bool SendCommandToClient(Command cmd)
        {
            try
            {
                semaphor.WaitOne();

                //MessageBox.Show( cmd.MetaData.Substring(0,1000)+"-");
                //Test
                byte[] data = Encoding.UTF8.GetBytes(cmd.MetaData + "\0");
                stream.Write(data, 0, data.Length);
                stream.Flush();

                ////Type
                //byte[] buffer = new byte[4];
                //buffer = BitConverter.GetBytes((int)cmd.CommandType);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();

                ////Sender IP
                //byte[] senderIPBuffer = Encoding.ASCII.GetBytes(cmd.ContactID.ToString());
                //buffer = new byte[4];
                //buffer = BitConverter.GetBytes(senderIPBuffer.Length);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();
                //stream.Write(senderIPBuffer, 0, senderIPBuffer.Length);
                //stream.Flush();

                ////Sender Name
                //byte[] senderNameBuffer = Encoding.Unicode.GetBytes(cmd.ContactID.ToString());
                //buffer = new byte[4];
                //buffer = BitConverter.GetBytes(senderNameBuffer.Length);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();
                //stream.Write(senderNameBuffer, 0, senderNameBuffer.Length);
                //stream.Flush();

                ////Target
                //byte[] ipBuffer = Encoding.ASCII.GetBytes(cmd.TargetContactID.ToString());
                //buffer = new byte[4];
                //buffer = BitConverter.GetBytes(ipBuffer.Length);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();
                //stream.Write(ipBuffer, 0, ipBuffer.Length);
                //stream.Flush();

                ////Meta Data.
                //if (cmd.MetaData == null || cmd.MetaData == "")
                //    cmd.MetaData = "\n";

                //byte[] metaBuffer = Encoding.Unicode.GetBytes(cmd.MetaData);
                //buffer = new byte[4];
                //buffer = BitConverter.GetBytes(metaBuffer.Length);
                //stream.Write(buffer, 0, 4);
                //stream.Flush();
                //stream.Write(metaBuffer, 0, metaBuffer.Length);
                //stream.Flush();

                semaphor.Release();
                return true;
            }
            catch (Exception er)
            {
                semaphor.Release();
                return false;
            }
        }

        public void SendCommand(Command cmd)
        {
            if (this.socket != null && this.socket.Connected)
            {
                BackgroundWorker bw_Sender = new BackgroundWorker();
                bw_Sender.DoWork += new DoWorkEventHandler(bw_Sender_DoWork);
                bw_Sender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_Sender_RunWorkerCompleted);
                bw_Sender.RunWorkerAsync(cmd);
            }
            else
                OnCommandSending(new CommandSendingEventArgs(false));
        }

        public void SendMessage(int FromMemberID, string Message)
        {
            SendCommandToClient((int)CommandsType.Message + spliter.ToString() + FromMemberID + spliter.ToString() + Message);
        }

        private void bw_Sender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnCommandSending(new CommandSendingEventArgs((!e.Cancelled && e.Error == null && (bool)e.Result)));
            //
            ((BackgroundWorker)sender).Dispose();
            GC.Collect();
        }

        private void bw_Sender_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SendCommandToClient(((Command)e.Argument).MetaData);
        }

        #endregion

        public bool Disconnect()
        {
            if (socket != null && socket.Connected)
            {
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    //
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return true;
        }

        public override string ToString()
        {
            return (LoggedIn ?
                contactInfo.ToString() :
                IP.ToString() + ":" + Port);
        }
    }
}
