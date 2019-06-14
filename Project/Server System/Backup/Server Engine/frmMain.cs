using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using System.Net.Sockets;
using System.Net;

using BinarySoftCo.UIControls;
using BinarySoftCo.ChatSystem.ServerNetworking;
using BinarySoftCo.ChatSystem.ServerDataLayer;
using BinarySoftCo.ChatSystem.ClientDataLayer;

namespace BinarySoftCo.ChatSystem.ServerEngine
{
    public partial class frmMain : Form
    {
        BackgroundWorker bwListener,
            bw_CommandReader;
        //
        Socket serverSocket;
        List<SocketClient> connectedSocketContacts;
        List<HTTPClient> connectedHTTPContacts;

        private bool CheckManager()
        {
            frmLogin frmL = new frmLogin(false);
            bool t = frmL.ShowDialog();
            //
            AddToLog("User logged in " + (t ? "currectrly" : "failed"));
            //
            return t;
        }

        private void AddToLog(string Content)
        {
            LogManager.AppendLogFile(Content);
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            lbLog.Items.Insert(0, new Log(DateTime.Now, Content).ToString());
        }

        #region Notify Icon

        private void niTaskbar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void niTaskbar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(CheckManager())
                Show();
        }

        #endregion

        #region Engine Manager

        private void StartEngine()
        {
            AddToLog("Start server");
            bwListener.RunWorkerAsync();
            bw_CommandReader.RunWorkerAsync();
            //
            SetRunningStatus();
        }

        private void StopEngine()
        {
            AddToLog("Stop server");
            bwListener.CancelAsync();
            bw_CommandReader.CancelAsync();
            //
            lbLog.Items.Clear();
            //
            SetRunningStatus();
        }

        private void SetRunningStatus()
        {
            bStart.Enabled = !bwListener.IsBusy;
            bStop.Enabled = !bStart.Enabled;
        }

        #endregion

        #region Socket Clients

        private void AddNewSocketClient(Socket Socket)
        {
            SocketClient cm = new SocketClient(Socket);
            cm.CommandReceived += new CommandReceivedEventHandler(sc_CommandReceived);
            cm.ClientStatusRequest += new ClientStatusEventHandler(sc_ClientStatusRequest);
            cm.ClientAvailableStatusChanged += new ClientAvailableStatusChangedEventHandler(sc_ClientAvailableStatusChanged);
            cm.Disconnected += new DisconnectedEventHandler(sc_Disconnected);
            //
            RemoveSocketClient(cm, true);
            //
            connectedSocketContacts.Add(cm);
            AddToLog(cm.ToString() + " connected");
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            lbSocketLClients.Items.Add(cm.ToString());
        }

        private bool RemoveSocketClient(SocketClient Client, bool BeforSignIn)
        {
            lock (this)
            {
                int index = IndexOfSocketClient(Client, BeforSignIn);
                if (index > -1)
                {
                    connectedSocketContacts.RemoveAt(index);
                    AddToLog(Client.ToString() + " removed");
                    //
                    Control.CheckForIllegalCrossThreadCalls = false;
                    lbSocketLClients.Items.RemoveAt(index);
                    //
                    //Inform all clients that a client had been disconnected.
                    BroadCastCommandFor(Client.ContactInformation.DBID,
                        new Command(Client.ContactInformation.DBID, AvailableStatus.Offline));
                    //
                    return true;
                }
                return false;
            }
        }

        private int IndexOfSocketClient(SocketClient Client, bool BeforSignIn)
        {
            for (int i = 0; i < connectedSocketContacts.Count; i++)
                if (connectedSocketContacts[i].LoggedIn == !BeforSignIn &&
                    connectedSocketContacts[i].IPPort == Client.IPPort)
                    return i;
            //
            return -1;
        }

        private bool LoggedInSocketClientExsits(SocketClient Client)
        {
            foreach (SocketClient cm in connectedSocketContacts)
                if (cm.ContactInformation.DBID == Client.ContactInformation.DBID &&
                    cm.IPPort != Client.IPPort)
                    return true;
            //
            return false;
        }

        private SocketClient GetSocketClientByID(int DBID)
        {
            foreach(SocketClient cm in connectedSocketContacts)
                if (cm.ContactInformation.DBID == DBID)
                    return cm;
            //
            return null;
        }

        private void sc_CommandReceived(object sender, CommandEventArgs e)
        {
            if(e.Command.Type == CommandsType.Message)
            {
                //Command cmd = e.Command;
                //cms
                ////send back to sender
                //SendCommandToTarget(e.Command);
                //
                //original methode to use for this switch body
                SendCommandToTarget(e.Command);
            }
        }

        private void sc_ClientStatusRequest(object sender, ClientStatusEventArgs e)
        {
            e.Status = GetStatusOfClient(e.Client);
        }

        private void sc_ClientAvailableStatusChanged(object sender, ClientAvailableStatusChangedEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //
            lbSocketLClients.Items.Clear();
            //
            foreach (SocketClient cm in connectedSocketContacts)
                lbSocketLClients.Items.Add(cm.ToString());
            //
            if (LoggedInSocketClientExsits(e.Client))
                RemoveSocketClient(e.Client, false);
            //
            if (e.Status != AvailableStatus.Offline)
                BroadCastCommandFor(e.Client.ContactInformation.DBID,
                    new Command(e.Client.ContactInformation.DBID, e.Status));
        }

        private void sc_Disconnected(object sender, ClientEventArgs e)
        {
            RemoveSocketClient(e.SocketClient, false);
        }

        #endregion

        #region HTTP Clients

        private HTTPClient AddNewHTTPClient(Member contactInfo)
        {
            HTTPClient hc = new HTTPClient(contactInfo);
            //
            hc.Disconnected += new DisconnectedEventHandler(hc_Disconnected);
            //
            RemoveHTTPClient(hc);
            //
            connectedHTTPContacts.Add(hc);
            AddToLog(hc.ToString() + " connected");
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            lbHTTPClients.Items.Add(hc.ToString());
            //
            BroadCastCommandFor(contactInfo.DBID,
                    new Command(contactInfo.DBID, AvailableStatus.Online));
            //
            return hc;
        }

        private void hc_Disconnected(object sender, ClientEventArgs e)
        {
            RemoveHTTPClient(e.HTTPClient);
        }

        private bool RemoveHTTPClient(HTTPClient Client)
        {
            lock (this)
            {
                int index = IndexOfHTTPClient(Client.ContactInformation.DBID);
                if (index > -1)
                {
                    connectedHTTPContacts.RemoveAt(index);
                    AddToLog(Client.ToString() + " removed");
                    //
                    Control.CheckForIllegalCrossThreadCalls = false;
                    lbHTTPClients.Items.RemoveAt(index);
                    //
                    //Inform all clients that a client had been disconnected.
                    BroadCastCommandFor(Client.ContactInformation.DBID,
                        new Command(Client.ContactInformation.DBID, AvailableStatus.Offline));
                    //
                    return true;
                }
                return false;
            }
        }

        private int IndexOfHTTPClient(int DBID)
        {
            for (int i = 0; i < connectedHTTPContacts.Count; i++)
                if (connectedHTTPContacts[i].ContactInformation.DBID == DBID)
                    return i;
            //
            return -1;
        }

        private HTTPClient GetHTTPClientByID(int DBID)
        {
            foreach (HTTPClient hc in connectedHTTPContacts)
                if (hc.ContactInformation.DBID == DBID)
                    return hc;
            //
            return null;
        }

        #endregion

        private AvailableStatus GetStatusOfClient(Member Client)
        {
            foreach (SocketClient sm in connectedSocketContacts)
                if (sm.ContactInformation.DBID == Client.DBID)
                    return sm.Status;
            //
            foreach (HTTPClient hm in connectedHTTPContacts)
                if (hm.ContactInformation.DBID == Client.DBID)
                    return hm.Status;
            //
            return AvailableStatus.Offline;
        }

        private void BroadCastCommandFor(int MemberID, Command command)
        {
            List<Member> list = Variables.BaseData.GetRelatedMembersFor(MemberID);
            //
            foreach (Member m in list)
            {
                foreach (SocketClient sc in connectedSocketContacts)
                    if (m.DBID == sc.ContactInformation.DBID)
                        sc.SendCommand(command);
                //
                foreach (HTTPClient hc in connectedHTTPContacts)
                    if (m.DBID == hc.ContactInformation.DBID)
                        hc.SendCommand(command);
            }
        }

        private void SendCommandToTarget(Command command)
        {
            SocketClient sc = GetSocketClientByID(command.ToMemberID);
            HTTPClient hc = new HTTPClient(new Member());
            //
            if (sc != null)
                sc.SendCommand(command);
            else
            {
                hc = GetHTTPClientByID(command.ToMemberID);
                if (hc != null)
                    hc.SendCommand(command);
            }
            //
            if (command.ToMemberID != command.FromMemberID)
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                //
                if (command.ToMemberID > -1)
                {
                    Variables.BaseData.AddNewPacket(new Queue(command.FromMemberID, command.ToMemberID,
                        command.Content), (sc != null));
                    //
                    try
                    {
                        tbMessagesLog.Text = (GetSocketClientByID(command.FromMemberID) != null ? GetSocketClientByID(command.FromMemberID).ContactInformation.ToString() : GetHTTPClientByID(command.FromMemberID).ContactInformation.ToString()) + " : " + command.Content + " -> " +
                            Variables.BaseData.GetMemeberInfo(command.ToMemberID).ToString() +
                            Environment.NewLine + tbMessagesLog.Text;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    tbMessagesLog.Text = GetSocketClientByID(command.FromMemberID).ContactInformation.ToString() + " : " + command.Content + " -> مدیر سرور" +
                        Environment.NewLine + tbMessagesLog.Text;
                }

            }
        }

        public frmMain()
        {
            InitializeComponent();
            //
            bwListener = new BackgroundWorker();
            bwListener.WorkerSupportsCancellation = true;
            bwListener.DoWork += new DoWorkEventHandler(bwListener_StartListener);
            //
            bw_CommandReader = new BackgroundWorker();
            bw_CommandReader.WorkerSupportsCancellation = true;
            bw_CommandReader.DoWork += new DoWorkEventHandler(bw_CommandReader_DoWork);
            //
            StartEngine();
            //
            connectedSocketContacts = new List<SocketClient>();
            connectedHTTPContacts = new List<HTTPClient>();
        }

        private void bwListener_StartListener(object sender, DoWorkEventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, Constants.ServerPort));
            serverSocket.Listen(200);
            //
            while (true)
                AddNewSocketClient(serverSocket.Accept());
        }

        private void bw_CommandReader_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                List<Command> cmds = Variables.BaseData.GetAllIncomingCommands();
                //
                if (cmds.Count > 0)
                    foreach (Command c in cmds)
                    {
                        string[] str = c.Content.Split(Command.Spliter);
                        //
                        HTTPClient hc = GetHTTPClientByID(c.ToMemberID);
                        //
                        #region Sign In
                        //
                        if (c.Type == CommandsType.SignIn)
                        {
                            if (Variables.BaseData.GetMemeberLoginStatus(str[0], str[1].Split('\0')[0]))
                            {
                                hc = AddNewHTTPClient(Variables.BaseData.GetMemeberInfo(str[0]));
                                //
                                Command cmd = new Command(CommandsType.SignInSuccessful);
                                hc.SendCommand(new Command(-1, cmd.Type, c.FromMemberID, c.FromMemberID,
                                    hc.ContactInformation.DBID.ToString(),
                                    hc.ContactInformation.DBID.ToString()));
                                //
                                BroadCastCommandFor(c.FromMemberID, new Command(c.FromMemberID, AvailableStatus.Online));
                                //
                                List<Queue> list = Variables.BaseData.GetPendingTo(c.FromMemberID);
                                foreach (Queue q in list)
                                {
                                    hc.SendCommand(new Command(q.FromMemberID, q.Message, true));
                                    Variables.BaseData.MakeAsDeliverPacket(q.DBID);
                                }
                            }
                            else
                                Variables.BaseData.AddCommand(new Command(-1, CommandsType.SignInFailed, c.FromMemberID, c.FromMemberID, "", ""), false);
                        }
                        //
                        #endregion
                        //
                        #region Sign Out
                        //
                        else if (c.Type == CommandsType.SignOut)
                        {
                            if(hc != null)
                                RemoveHTTPClient(hc);
                        }
                        //
                        #endregion
                        //
                        #region Get Related Members
                        //
                        else if (c.Type == CommandsType.GetRelatedMembers)
                        {
                            hc.SendCommand(new Command(AvailableStatus.Online, -1, "مدیر سیستم"));
                            //
                            //check for every one for offline online he/she
                            List<Member> list = Variables.BaseData.GetRelatedMembersFor(hc.ContactInformation.DBID);
                            foreach (Member m in list)
                            {
                                hc.SendCommand(new Command(
                                    GetStatusOfClient(hc.ContactInformation), 
                                    m.DBID, m.ToString()));
                            }
                        }
                        //
                        #endregion
                        //
                        #region Message
                        //
                        else if (c.Type == CommandsType.Message)
                        {
                            SendCommandToTarget(c);
                        }
                        //
                        #endregion
                        //
                        #region Find Person
                        //
                        else if (c.Type == CommandsType.FindPerson)
                        {
                            //List<Person> list = Variables.BaseData.FilterInPersons(str[1]);
                            //foreach (Person p in list)
                            //{
                            //    hc.SendCommand(new Command(
                            //        p.PersonDBID,
                            //        p.FirstName,
                            //        p.MiddleName,
                            //        p.LastName,
                            //        p.NickName,
                            //        p.Email,
                            //        p.WebPage,
                            //        p.Mobile,
                            //        p.Phone,
                            //        p.Address));
                            //}
                        }
                        //
                        #endregion
                        //
                        #region Register Member With Old Person
                        //
                        else if (c.Type == CommandsType.RegisterMemberWithOldPerson)
                        {
                            //if (Variables.BaseData.CheckForMemberExists(str[2].Trim()))
                            //{
                            //    SendCommandToClient(new Command(false, ".این نام کاربری قبلا به ثبت رسیده است"));
                            //    return;
                            //}
                            ////
                            //int ID = Variables.BaseData.AddMember(new Member(-1,
                            //        int.Parse(str[1]), "", "", "", "", "", "", "", "", "",
                            //        str[2].Trim(),
                            //        str[3].Trim(),
                            //        DateTime.Now, DateTime.Now, true));
                            ////
                            //SendCommandToClient(new Command((ID > -1), ".عملیات با مشکل مواجه شد.لطفا مجددا تلاش کنید"));
                        }
                        //
                        #endregion
                        //
                        #region Register Member With Person
                        //
                        else if (c.Type == CommandsType.RegisterMemberWithNewPerson)
                        {
                            //if (Variables.BaseData.FilterInPersons(str[5].Trim()).Count > 0)
                            //{
                            //    SendCommandToClient(new Command(false, ".قبلا با این ایمیل شخصی ثبت نام کرده است"));
                            //    return;
                            //}
                            ////
                            //else if (Variables.BaseData.CheckForMemberExists(str[10].Trim()))
                            //{
                            //    SendCommandToClient(new Command(false, ".این نام کاربری قبلا به ثبت رسیده است"));
                            //    return;
                            //}
                            ////
                            //int ID = Variables.BaseData.AddMemberWithPerson(new Member(-1,
                            //        str[1].Trim(),
                            //        str[2].Trim(),
                            //        str[3].Trim(),
                            //        str[4].Trim(),
                            //        str[5].Trim(),
                            //        str[6].Trim(),
                            //        str[7].Trim(),
                            //        str[8].Trim(),
                            //        str[9].Trim(),
                            //        str[10].Trim(),
                            //        str[11].Trim(),
                            //        DateTime.Now, DateTime.Now, true));
                            ////
                            //SendCommandToClient(new Command((ID > -1), ".عملیات با مشکل مواجه شد.لطفا مجددا تلاش کنید"));
                        }
                        //
                        #endregion
                        //
                        #region Find Member
                        //
                        else if (c.Type == CommandsType.FindMember)
                        {
                            List<Member> list = Variables.BaseData.FilteInMembers(str[1]);
                            foreach (Member m in list)
                            {
                                hc.SendCommand(new Command(
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
                        else if (c.Type == CommandsType.AddNewFriend)
                        {
                            if (Variables.BaseData.GetRelationWith(hc.ContactInformation.DBID, int.Parse(str[1])) == null)
                                Variables.BaseData.AddMemberRelation(hc.ContactInformation.DBID, int.Parse(str[1]));
                        }
                        //
                        #endregion
                        //
                        #region Delete Friend
                        //
                        else if (c.Type == CommandsType.DeleteFriend)
                        {
                            MemberRelation mr = Variables.BaseData.GetRelationWith(hc.ContactInformation.DBID, int.Parse(str[1]));
                            Variables.BaseData.DeleteMemberRelation(mr.DBID);
                        }
                        //
                        #endregion
                        //
                        #region Client Signal Recieved
                        //
                        else if (c.Type == CommandsType.HTTPClientSignal)
                        {
                            hc = GetHTTPClientByID(c.FromMemberID);
                            if (hc != null)
                                hc.ClientSignalRecieved();
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
                        //
                        Variables.BaseData.DeleteCommand(c.DBID);
                    }
                else
                    Thread.Sleep(5000);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddToLog("Minimize Server");
            e.Cancel = true;
            Hide();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            if (CheckManager())
                if (TransparentMessage.Show("Close Server", "Are you sure you want to end task the server engine any way?") == DialogResult.Yes)
                {
                    niTaskbar.Dispose();
                    //
                    StopEngine();
                    //
                    AddToLog("Close Server");
                    Application.ExitThread();
                    //
                    Process.GetCurrentProcess().Kill();
                }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (TransparentMessage.Show("Start Server", "Are you sure you want to start server ?") == DialogResult.No) return;
            //
            StartEngine();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            if (CheckManager())
            {
                if (TransparentMessage.Show("Stop Server", "Are you sure you want to stop server ?") == DialogResult.No) return;
                //
                StopEngine();
            }
        }

        private void bManagement_Click(object sender, EventArgs e)
        {
            if (CheckManager())
            {
                System.Diagnostics.Process.Start(@"..\..\..\System Admin\bin\Debug\System Admin.exe");
            }
        }

        private void lbLoggedInClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSend.ResetText();
            lSendMessage.ResetText();
            //
            if (lbSocketLClients.SelectedIndex > -1)
                lSendMessage.Text = string.Format(lSendMessage.Tag.ToString(), lbSocketLClients.SelectedItem.ToString());
            //
            tbSend.ReadOnly = !(lbSocketLClients.SelectedIndex > -1);
        }

        private void tbSend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (e.Control)
                {
                    //tbSend.Text += Environment.NewLine;
                    tbSend.SelectionStart = tbSend.TextLength;
                }
                else
                {
                    if (lbSocketLClients.SelectedIndex > -1)
                    {
                        connectedSocketContacts[lbSocketLClients.SelectedIndex].SendCommand(
                            new Command(-1, tbSend.Text, true));
                        //
                        Control.CheckForIllegalCrossThreadCalls = false;
                        //
                        tbMessagesLog.Text = "Server : " + tbSend.Text + " -> " +
                            connectedSocketContacts[lbSocketLClients.SelectedIndex].ContactInformation.ToString() +
                            Environment.NewLine + tbMessagesLog.Text;
                    }
                    //
                    tbSend.ResetText();
                }
        }

        private void tbSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Enter);
        }
    }
}
