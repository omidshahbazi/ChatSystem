using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

using BinarySoftCo.ChatSystem.ServerDataLayer;
using BinarySoftCo.ChatSystem.ClientDataLayer;

namespace BinarySoftCo.ChatSystem.ServerNetworking
{
    public class HTTPClient
    {
        #region Variables

        Member contactInfo;
        AvailableStatus status;
        System.Timers.Timer connected;

        #endregion

        #region Propeties

        public Member ContactInformation
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        public bool LoggedIn
        {
            get { return (contactInfo.DBID > -1); }
        }

        public AvailableStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        #endregion

        #region Events
        //
        /// <summary>
        /// Occurs when a client disconnected from this server.
        /// </summary>
        public event DisconnectedEventHandler Disconnected;

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

        public HTTPClient(Member ContactInfo)
        {
            contactInfo = ContactInfo;
            //
            connected = new System.Timers.Timer(300000);//every 5 (5 * 60 seconds) minutes
            connected.Elapsed += new System.Timers.ElapsedEventHandler(connected_Elapsed);
            connected.Start();
        }

        private void connected_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            OnDisconnected(new ClientEventArgs(this));
        }

        public void SendCommand(Command command)
        {
            Variables.BaseData.AddOutgoingCommand(command);
        }

        public void ClientSignalRecieved()
        {
            connected.Stop();
            connected.Start();
        }

        public override string ToString()
        {
            return contactInfo.ToString();
        }
    }

    public class SocketClient
    {
        #region Variables

        Member contactInfo;
        NetworkStream stream;
        Socket socket;
        AvailableStatus status;
        
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

        public AvailableStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        #endregion

        #region Events
        //
        /// <summary>
        /// Occurs when new client logged in and request related friend's status.
        /// </summary>
        public event ClientStatusEventHandler ClientStatusRequest;

        /// <summary>
        /// Occurs when new client logged in.
        /// </summary>
        public event ClientAvailableStatusChangedEventHandler ClientAvailableStatusChanged;

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

        /// <summary>
        /// Occurs when new client logged in and request related friend's status.
        /// </summary>
        /// <param name="e">Current client and it status</param>
        protected virtual void OnClientStatusRequest(ClientStatusEventArgs e)
        {
            if (ClientStatusRequest != null)
                ClientStatusRequest(this, e);
        }

        /// <summary>
        /// Occurs when new client logged in.
        /// </summary>
        /// <param name="e">Logged in client</param>
        protected virtual void OnClientAvailableStatusChanged(ClientAvailableStatusChangedEventArgs e)
        {
            status = e.Status;
            //
            if (ClientAvailableStatusChanged != null)
                ClientAvailableStatusChanged(this, e);
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

        public SocketClient(Socket Socket)
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
                    //
                    buffer = new byte[1000];
                    if (stream.Read(buffer, 0, buffer.Length) == 0)
                        break;
                    //
                    string text = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Split('\0')[0];
                    //
                    string[] str = text.Split(Command.Spliter);
                    //
                    CommandsType ct = (CommandsType)int.Parse(str[0]);
                    //
                    #region Sign In
                    //
                    if (ct == CommandsType.SignIn)
                    {
                        if (Variables.BaseData.GetMemeberLoginStatus(str[1], str[2].Split('\0')[0]))
                        {
                            ContactInformation = Variables.BaseData.GetMemeberInfo(str[1]);
                            //
                            SendCommandToClient(new Command(CommandsType.SignInSuccessful));
                            //
                            OnClientAvailableStatusChanged(new ClientAvailableStatusChangedEventArgs(this, AvailableStatus.Online));
                            //
                            List<Queue> list = Variables.BaseData.GetPendingTo(contactInfo.DBID);
                            foreach (Queue q in list)
                            {
                                SendCommand(new Command(q.FromMemberID, q.Message, true));
                                Variables.BaseData.MakeAsDeliverPacket(q.DBID);
                            }
                        }
                        else
                            SendCommandToClient(new Command(CommandsType.SignInFailed));
                    }
                    //
                    #endregion
                    //
                    #region Sign Out
                    //
                    else if (ct == CommandsType.SignOut)
                    {
                        contactInfo = new Member();
                        OnClientAvailableStatusChanged(new ClientAvailableStatusChangedEventArgs(this, AvailableStatus.Offline));
                    }
                    //
                    #endregion
                    //
                    #region Get Related Members
                    //
                    else if (ct == CommandsType.GetRelatedMembers)
                    {
                        SendCommandToClient(new Command(AvailableStatus.Online, -1, "مدیر سیستم"));
                        //
                        //check for every one for offline online he/she
                        List<Member> list = Variables.BaseData.GetRelatedMembersFor(contactInfo.DBID);
                        foreach (Member m in list)
                        {
                            ClientStatusEventArgs csea = new ClientStatusEventArgs(m);
                            OnClientStatusRequest(csea);
                            //
                            SendCommandToClient(new Command(csea.Status, m.DBID, m.ToString()));
                        }
                    }
                    //
                    #endregion
                    //
                    #region Message
                    //
                    else if (ct == CommandsType.Message)
                    {
                        OnCommandReceived(new CommandEventArgs(IPPort, new Command(contactInfo.DBID, int.Parse(str[1]), str[2].Trim())));
                    }
                    //
                    #endregion
                    //
                    #region Find Person
                    //
                    else if (ct == CommandsType.FindPerson)
                    {
                        List<Person> list = Variables.BaseData.FilterInPersons(str[1]);
                        foreach (Person p in list)
                        {
                            SendCommandToClient(new Command(
                                p.PersonDBID,
                                p.FirstName,
                                p.MiddleName,
                                p.LastName,
                                p.NickName,
                                p.Email,
                                p.WebPage,
                                p.Mobile,
                                p.Phone,
                                p.Address));
                        }
                    }
                    //
                    #endregion
                    //
                    #region Register Member With Old Person
                    //
                    else if (ct == CommandsType.RegisterMemberWithOldPerson)
                    {
                        if (Variables.BaseData.CheckForMemberExists(str[2].Trim()))
                        {
                            SendCommandToClient(new Command(false, ".این نام کاربری قبلا به ثبت رسیده است"));
                            return;
                        }
                        //
                        int ID = Variables.BaseData.AddMember(new Member(-1,
                                int.Parse(str[1]), "", "", "", "", "", "", "", "", "",
                                str[2].Trim(),
                                str[3].Trim(),
                                DateTime.Now, DateTime.Now, true));
                        //
                        SendCommandToClient(new Command((ID > -1), ".عملیات با مشکل مواجه شد.لطفا مجددا تلاش کنید"));
                    }
                    //
                    #endregion
                    //
                    #region Register Member With Person
                    //
                    else if (ct == CommandsType.RegisterMemberWithNewPerson)
                    {
                        if (Variables.BaseData.FilterInPersons(str[5].Trim()).Count > 0)
                        {
                            SendCommandToClient(new Command(false, ".قبلا با این ایمیل شخصی ثبت نام کرده است"));
                            return;
                        }
                        //
                        else if (Variables.BaseData.CheckForMemberExists(str[10].Trim()))
                        {
                            SendCommandToClient(new Command(false, ".این نام کاربری قبلا به ثبت رسیده است"));
                            return;
                        }
                        //
                        int ID = Variables.BaseData.AddMemberWithPerson(new Member(-1,
                                str[1].Trim(),
                                str[2].Trim(),
                                str[3].Trim(),
                                str[4].Trim(),
                                str[5].Trim(),
                                str[6].Trim(),
                                str[7].Trim(),
                                str[8].Trim(),
                                str[9].Trim(),
                                str[10].Trim(),
                                str[11].Trim(),
                                DateTime.Now, DateTime.Now, true));
                        //
                        SendCommandToClient(new Command((ID > -1), ".عملیات با مشکل مواجه شد.لطفا مجددا تلاش کنید"));
                    }
                    //
                    #endregion
                    //
                    #region Find Member
                    //
                    else if (ct == CommandsType.FindMember)
                    {
                        List<Member> list = Variables.BaseData.FilteInMembers(str[1]);
                        foreach (Member m in list)
                        {
                            SendCommandToClient(new Command(
                                m.DBID,
                                m.FirstName,
                                m.MiddleName,
                                m.LastName,
                                m.NickName,
                                m.Email,
                                m.WebPage,
                                m.Mobile,
                                m.Phone,
                                m.Address,
                                m.Username,
                                "*********"));
                        }
                    }
                    //
                    #endregion
                    //
                    #region Add New Friend
                    //
                    else if (ct == CommandsType.AddNewFriend)
                    {
                        if (Variables.BaseData.GetRelationWith(contactInfo.DBID, int.Parse(str[1])) == null)
                            Variables.BaseData.AddMemberRelation(contactInfo.DBID, int.Parse(str[1]));
                    }
                    //
                    #endregion
                    //
                    #region Delete Friend
                    //
                    else if (ct == CommandsType.DeleteFriend)
                    {
                        MemberRelation mr = Variables.BaseData.GetRelationWith(contactInfo.DBID, int.Parse(str[1]));
                        Variables.BaseData.DeleteMemberRelation(mr.DBID);
                    }
                    //
                    #endregion
                    //
                    #region Other
                    //
                    else
                    {
                        MessageBox.Show("NOTHING TO DO!!!");
                        //Command cmd = new Command(ct, contactInfo.DBID, int.Parse(str[1]), (int)CommandsType.Message + spliter.ToString() + contactInfo.DBID.ToString() + spliter.ToString() + str[2].Trim());
                        //OnCommandReceived(new CommandEventArgs(IPPort, cmd));
                    }
                    //
                    #endregion
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
        private bool SendCommandToClient(Command cmd)
        {
            try
            {
                semaphor.WaitOne();
                //
                byte[] data = Encoding.UTF8.GetBytes(cmd.ToString());
                //
                stream.Write(data, 0, data.Length);
                //MessageBox.Show(data.Length.ToString() + Environment.NewLine + cmd.ToString() + Environment.NewLine + cmd.ToString().Length.ToString());
                //
                //stream.Flush();
                //
                Thread.Sleep(300);
                //
                semaphor.Release();
                //
                return true;
            }
            catch (Exception er)
            {
                semaphor.Release();
                //
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

        private void bw_Sender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnCommandSending(new CommandSendingEventArgs((!e.Cancelled && e.Error == null && (bool)e.Result)));
            //
            ((BackgroundWorker)sender).Dispose();
            GC.Collect();
        }

        private void bw_Sender_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SendCommandToClient((Command)e.Argument);
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