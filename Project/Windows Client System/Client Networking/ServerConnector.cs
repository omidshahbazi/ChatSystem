using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using BinarySoftCo.ChatSystem.ServerNetworking;
using BinarySoftCo.ChatSystem.ServerDataLayer;
using BinarySoftCo.ChatSystem.ClientDataLayer;

namespace BinarySoftCo.ChatSystem.ClientNetworking
{
    public class ServerConnector
    {
        #region Variables

        NetworkStream stream;

        TcpClient tcpCon;

        Semaphore semaphor = new Semaphore(1, 1);

        List<Command> queue = new List<Command>();

        #endregion

        #region Properties

        public IPEndPoint IPPort
        {
            get
            {
                if (this.tcpCon != null)
                    return (IPEndPoint)this.tcpCon.Client.RemoteEndPoint;
                else
                    return new IPEndPoint(IPAddress.None, 0);
            }
        }

        public IPAddress IP
        {
            get
            {
                if (this.tcpCon != null)
                    return ((IPEndPoint)this.tcpCon.Client.RemoteEndPoint).Address;
                else
                    return IPAddress.None;
            }
        }

        public int Port
        {
            get
            {
                if (this.tcpCon != null)
                    return ((IPEndPoint)this.tcpCon.Client.RemoteEndPoint).Port;
                else
                    return 0;
            }
        }

        public bool Connected
        {
            get
            {
                return this.tcpCon.Connected;
            }
        }

        #endregion

        #region Events
        //
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
        /// Occurs when new client logged in.
        /// </summary>
        /// <param name="e">Logged in client</param>
        protected virtual void OnClientAvailableStatusChanged(ClientAvailableStatusChangedEventArgs e)
        {
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

        public ServerConnector()
        {
            BackgroundWorker bw_Connector = new BackgroundWorker();
            bw_Connector.DoWork += new DoWorkEventHandler(bw_Connector_DoWork);
            bw_Connector.RunWorkerAsync();
            //
            BackgroundWorker bw_QueueSender = new BackgroundWorker();
            bw_QueueSender.DoWork += new DoWorkEventHandler(bw_QueueSender_DoWork);
            bw_QueueSender.RunWorkerAsync();
        }

        private void bw_Connector_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (tcpCon == null || !tcpCon.Connected)
                {
                    try
                    {
                        this.tcpCon = new TcpClient();
                        this.tcpCon.Connect(Constants.ServerAddress1, Constants.ServerPort);
                        //
                        this.stream = new NetworkStream(this.tcpCon.Client);
                        //
                        BackgroundWorker bw_Reciever = new BackgroundWorker();
                        bw_Reciever.WorkerSupportsCancellation = true;
                        bw_Reciever.DoWork += new DoWorkEventHandler(RunReciever);
                        bw_Reciever.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_Reciever_RunWorkerCompleted);
                        bw_Reciever.RunWorkerAsync();
                        break;
                    }
                    catch (SocketException se)
                    {
                    }
                }
                else Thread.Sleep(20000);
            }
        }

        private void bw_QueueSender_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (queue.Count > 0 && tcpCon.Connected)
                {
                    SendCommand(queue[0]);
                    //
                    queue.RemoveAt(0);
                }
                else Thread.Sleep(10000);
            }
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
            try
            {
                while (tcpCon.Connected)
                {
                    try
                    {
                        byte[] buffer = new byte[1000];
                        int readBytes = stream.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
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
                            OnClientAvailableStatusChanged(new ClientAvailableStatusChangedEventArgs(int.Parse(str[1]), (AvailableStatus)int.Parse(str[1])));
                        }
                        //
                        #endregion
                        //
                        #region Sign In Result
                        //
                        else if (ct == CommandsType.SignInSuccessful ||
                                 ct == CommandsType.SignInFailed)
                        {
                            OnCommandReceived(new CommandEventArgs(new Command(ct)));
                        }
                        //
                        #endregion
                        //
                        #region Get Related Member Response
                        //
                        else if (ct == CommandsType.GetRelatedMembersResponse)
                        {
                            OnCommandReceived(new CommandEventArgs(
                                new Command((AvailableStatus)int.Parse(str[1]), int.Parse(str[2]), str[3])));
                        }
                        //
                        #endregion
                        //
                        #region Message
                        //
                        else if (ct == CommandsType.Message)
                        {
                            OnCommandReceived(new CommandEventArgs(IPPort,
                                new Command(int.Parse(str[1]), str[2].Trim(), false)));
                        }
                        //
                        #endregion
                        //
                        #region Person Data
                        //
                        else if (ct == CommandsType.PersonData)
                        {
                            OnCommandReceived(new CommandEventArgs(IPPort, new Command(
                                int.Parse(str[1]),
                                str[2],
                                str[3],
                                str[4],
                                str[5],
                                str[6],
                                str[7],
                                str[8],
                                str[9],
                                str[10])));
                        }
                        //
                        #endregion
                        //
                        #region Register New Member Result
                        //
                        else if (ct == CommandsType.RegisterMemberSuccessful || ct == CommandsType.RegisterMemberFailed)
                        {
                            OnCommandReceived(new CommandEventArgs(new Command(
                                (ct == CommandsType.RegisterMemberSuccessful),
                                str[1].Trim())));
                        }
                        //
                        #endregion
                        //
                        #region Member Data
                        //
                        else if (ct == CommandsType.MemberData)
                        {
                            OnCommandReceived(new CommandEventArgs(IPPort, new Command(
                                int.Parse(str[1]),
                                str[2],
                                str[3],
                                str[4],
                                str[5],
                                str[6],
                                str[7],
                                str[8],
                                str[9],
                                str[10],
                                str[11],
                                str[12])));
                        }
                        //
                        #endregion
                        //
                        #region Clien Available Status Changed
                        //
                        else if (ct == CommandsType.ClienAvailableStatusChanged)
                        {
                            OnClientAvailableStatusChanged(new ClientAvailableStatusChangedEventArgs(
                                int.Parse(str[1]), (AvailableStatus)int.Parse(str[2])));
                        }
                        //
                        #endregion
                    }
                    catch (IOException er)
                    {
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
            }
            catch
            {
            }
            //
            OnDisconnected(new ClientEventArgs(-1));
            Disconnect();
        }
        //
        #endregion

        #region Sender
        //
        private bool SendCommandToServer(Command cmd)
        {
            try
            {
                semaphor.WaitOne();
                //
                byte[] data = new byte[0];
                //
                data = Encoding.UTF8.GetBytes(cmd.ToString());
                stream.Write(data, 0, data.Length);
                //
                stream.Flush();
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
            try
            {
                if (this.tcpCon != null && this.tcpCon.Client.Connected)
                {
                    BackgroundWorker bw_Sender = new BackgroundWorker();
                    bw_Sender.DoWork += new DoWorkEventHandler(bw_Sender_DoWork);
                    bw_Sender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_Sender_RunWorkerCompleted);
                    bw_Sender.RunWorkerAsync(cmd);
                }
                else
                {
                    queue.Add(cmd);
                    OnCommandSending(new CommandSendingEventArgs(cmd, false));
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message + " in Sending");
            }
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
            e.Result = SendCommandToServer((Command)e.Argument);
        }

        #endregion

        public bool Disconnect()
        {
            try
            {

                tcpCon.Client.Shutdown(SocketShutdown.Both);
                tcpCon.Close();
                //
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return IP.ToString() + ":" + Port;
        }
    }
}