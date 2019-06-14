using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using BinarySoftCo.Networking.Chat;

namespace BinarySoftCo.Chat_Server
{
    public partial class frmMain : Form
    {
        const int ServerPort = 2324;

        BackgroundWorker bwListener;

        Socket server;

        private void StartToListen(object sender, DoWorkEventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, ServerPort));
            //
            server.Listen(200);
            //
            while (true)
            {
                CreateNewClientManager(server.Accept());
            }
        }

        private void CheckForAbnormalDC(ClientManager mngr)
        {
            RemoveClientManager(mngr);
        }

        private bool RemoveClientManager(ClientManager mngr)
        {
            lock (this)
            {
                int index = IndexOfClient(mngr);
                if (index != -1)
                {
                    Control.CheckForIllegalCrossThreadCalls = false;
                    listBox1.Items.RemoveAt(index);
                    Control.CheckForIllegalCrossThreadCalls = true;
                    //
                    //Inform all clients that a client had been disconnected.
                    Command cmd = new Command(BinarySoftCo.Networking.Chat.CommandType.ClientLogOffInform, mngr.IP, -1);
                    //
                    BroadCastCommand(cmd);
                    //
                    return true;
                }
                return false;
            }
        }

        private int IndexOfClient(ClientManager mngr)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
                if (((ClientManager) listBox1.Items[i]).IP.Equals(mngr.IP))
                    return i;
            //
            return -1;
        }

        private void BroadCastCommand(Command cmd)
        {
            foreach (ClientManager mngr in listBox1.Items)
                if (!mngr.IP.Equals(cmd.SenderIP))
                    mngr.SendCommand(cmd);
        }

        private void SendCommandToTarget(Command cmd)
        {
            foreach (ClientManager mngr in listBox1.Items)
                if (mngr.IP.Equals(cmd.TargetContactID))
                {
                    mngr.SendCommand(cmd);
                    return;
                }
        }

        private void SetCurrentClientSocket(int DBID, Socket socket)
        {
            foreach (ClientManager mngr in listBox1.Items)
                if (mngr.DBID == DBID)
                {
                    mngr.Socket = socket;
                    break;
                }
        }

        private void CreateNewClientManagerLoggedIn(Socket socket)
        {
            ClientManager cm = new ClientManager(socket);
            cm.CommandReceived += new CommandReceivedEventHandler(cm_CommandReceived);
            cm.Disconnected += new DisconnectedEventHandler(cm_Disconnected);
            //
            CheckForAbnormalDC(cm);
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            listBox1.Items.Add(cm);
            textBox1.AppendText(cm.IP.ToString() + ":" + cm.Port.ToString() + " connected!" + Environment.NewLine);
            Control.CheckForIllegalCrossThreadCalls = true;
        }

        private void cm_Disconnected(object sender, ClientEventArgs e)
        {
            //MessageBox.Show(e.Client.ClientName + " - " + e.Client.IP.ToString() + " disconnected!");
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            RemoveClientManager(e.Client);
            Control.CheckForIllegalCrossThreadCalls = false;
            textBox1.AppendText(e.Client.IP.ToString() + ":" + e.Client.Port.ToString() + " disconnected!" + Environment.NewLine);

        }

        private void cm_CommandReceived(object sender, CommandEventArgs e)
        {
            SendCommandToTarget(e.Command);
            //MessageBox.Show(e.Command.SenderName + " - " + e.Command.SenderIP.ToString() + " sended : " + e.Command.MetaData);
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            string st = e.Command.SenderIP.ToString() + " -> " + e.Command.MetaData;
            textBox1.AppendText(st + Environment.NewLine);
            textBox1.AppendText( Environment.NewLine);
            Control.CheckForIllegalCrossThreadCalls = true;
        }

        public frmMain()
        {
            InitializeComponent();
            //
            bwListener = new BackgroundWorker();
            bwListener.WorkerSupportsCancellation = true;
            bwListener.DoWork += new DoWorkEventHandler(StartToListen);
            bwListener.RunWorkerAsync();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }
    }
}
