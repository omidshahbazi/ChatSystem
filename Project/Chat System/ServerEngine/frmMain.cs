using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using System.Net.Sockets;
using System.Net;

using BinarySoftCo.UIControls;
using ConstantsVariables;
using BinarySoftCo.ChatSystem.Networking;
using BinarySoftCo.ChatSystem.DataLayer;

namespace BinarySoftCo.ChatSystem.ServerEngine
{
    public partial class frmMain : Form
    {
        BackgroundWorker bwListener;
        Socket serverSocket;
        List<ClientManager> connectedContacts;

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
            //
            SetRunningStatus();
        }

        private void StopEngine()
        {
            AddToLog("Stop server");
            bwListener.CancelAsync();
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

        #region Clients Manager

        private void AddNewClient(Socket Socket)
        {
            ClientManager cm = new ClientManager(Socket);
            cm.CommandReceived += new CommandReceivedEventHandler(cm_CommandReceived);
            cm.NewClientLoggedIn += new NewClientLoggedInEventHandler(cm_NewClientLoggedIn);
            cm.Disconnected += new DisconnectedEventHandler(cm_Disconnected);
            //
            RemoveClient(cm);
            //
            connectedContacts.Add(cm);
            AddToLog(cm.ToString() + " connected");
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            lbLoggedInClients.Items.Add(cm.ToString());
        }

        private bool RemoveClient(ClientManager Client)
        {
            lock (this)
            {
                int index = IndexOfClient(Client);
                if (index > -1)
                {
                    connectedContacts.RemoveAt(index);
                    AddToLog(Client.ToString() + " removed");
                    //
                    Control.CheckForIllegalCrossThreadCalls = false;
                    lbLoggedInClients.Items.RemoveAt(index);
                    //
                    //Inform all clients that a client had been disconnected.
                    BroadCastCommand(new Command(CommandsType.ClientLogOut, Client.ContactInformation.DBID));
                    //
                    return true;
                }
                return false;
            }
        }

        private void BroadCastCommand(Command command)
        {
            List<Member> list = Variables.BaseData.GetRelatedMembersFor(command.ContactID);
            //
            foreach (Member m in list)
                foreach (ClientManager cm in connectedContacts)
                    if (m.DBID == cm.ContactInformation.DBID)
                        cm.SendCommand(command);
        }

        private int IndexOfClient(ClientManager Client)
        {
            for (int i = 0; i < connectedContacts.Count; i++)
                if (connectedContacts[i].IPPort == Client.IPPort)
                    return i;
            //
            return -1;
        }

        private bool IndexOfLoggedInClient(ClientManager Client)
        {
            foreach (ClientManager cm in connectedContacts)
                if (cm.ContactInformation.DBID == Client.ContactInformation.DBID &&
                    cm.IPPort != Client.IPPort)
                    return true;
            //
            return false;
        }

        private ClientManager GetClientWithID(int DBID)
        {
            foreach(ClientManager cm in connectedContacts)
                if (cm.ContactInformation.DBID == DBID)
                    return cm;
            //
            return null;
        }

        private ClientManager GetClientWithIPEndPoint(IPEndPoint IPEndPoint)
        {
            foreach (ClientManager cm in connectedContacts)
                if (cm.IPPort == IPEndPoint)
                    return cm;
            //
            return null;
        }

        private void cm_CommandReceived(object sender, CommandEventArgs e)
        {
            if (e.Command.CommandType != CommandsType.ClientLogOut)
            {
                //send back to sender
                SendCommandToTarget(new Command(e.Command.CommandType, e.Command.ContactID, e.Command.ContactID, e.Command.MetaData.Insert(e.Command.MetaData.LastIndexOf('^') + 1, "<")));
                //
                //original methode to use for this switch body
                SendCommandToTarget(e.Command);
            }
        }

        private void cm_NewClientLoggedIn(object sender, NewClientLoggedInEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //
            if (IndexOfLoggedInClient(e.Client))
                RemoveClient(e.Client);
            //
            lbLoggedInClients.Items.Clear();
            //
            foreach (ClientManager cm in connectedContacts)
                lbLoggedInClients.Items.Add(cm.ToString());
            //
            List<Queue> list = Variables.BaseData.GetPendingTo(e.Client.ContactInformation.DBID);
            foreach (Queue q in list)
            {
                //e.Client.SendCommand(new Command(CommandsType.Message, q.FromMemberID, q.ToMemberID, q.Message));
                e.Client.SendMessage(q.FromMemberID, q.Message);
                Variables.BaseData.MakeAsDeliverPacket(q.DBID);
            }
        }

        private void cm_Disconnected(object sender, ClientEventArgs e)
        {
            RemoveClient(e.Client);
        }

        private void SendCommandTo(IPEndPoint TargetIPPort, Command command)
        {
            ClientManager cm = GetClientWithIPEndPoint(TargetIPPort);
            //
            if (cm != null)
                cm.SendCommand(command);
        }

        private void SendCommandToTarget(Command command)
        {
            ClientManager cm = GetClientWithID(command.TargetContactID);
            //
            if (cm != null)
                cm.SendCommand(command);
            //
            if (command.ContactID != command.TargetContactID)
            {
                Variables.BaseData.AddNewPacket(new Queue(command.ContactID, command.TargetContactID,
                    command.MetaData.Split(ClientManager.spliter)[2]),
                    (cm != null));
                //
                Control.CheckForIllegalCrossThreadCalls = false;
                tbMessagesLog.Text = GetClientWithID(command.ContactID).ContactInformation.ToString() + " : " + command.MetaData.Split(ClientManager.spliter)[2] + " -> " +
                    Variables.BaseData.GetMemeberInfo(command.TargetContactID).ToString() +
                    Environment.NewLine + tbMessagesLog.Text;
            }
        }

        #endregion

        public frmMain()
        {
            InitializeComponent();
            //
            bwListener = new BackgroundWorker();
            bwListener.WorkerSupportsCancellation = true;
            bwListener.DoWork += new DoWorkEventHandler(bwListener_StartListener);
            StartEngine();
            //
            connectedContacts = new List<ClientManager>();
        }

        private void bwListener_StartListener(object sender, DoWorkEventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, Constants.ServerPort));
            serverSocket.Listen(200); 
            //
            while (true)
                AddNewClient(serverSocket.Accept());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

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
                    StopEngine();
                    //
                    AddToLog("Close Server");
                    Application.ExitThread();
                    //
                    Process.GetCurrentProcess().Kill();
                }
        }

        private void lbLoggedInClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSend.ResetText();
            lSendMessage.ResetText();
            //
            if (lbLoggedInClients.SelectedIndex > -1)
                lSendMessage.Text = string.Format(lSendMessage.Tag.ToString(), lbLoggedInClients.SelectedItem.ToString());
            //
            tbSend.ReadOnly = !(lbLoggedInClients.SelectedIndex > -1);
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
                    if (lbLoggedInClients.SelectedIndex > -1)
                    {
                        connectedContacts[lbLoggedInClients.SelectedIndex].SendMessage(-1, tbSend.Text);
                        //
                        Control.CheckForIllegalCrossThreadCalls = false;
                        tbMessagesLog.Text = "Server : " + tbSend.Text + " -> " +
                            connectedContacts[lbLoggedInClients.SelectedIndex].ContactInformation.ToString() +
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
