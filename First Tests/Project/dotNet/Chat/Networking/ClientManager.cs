using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace BinarySoftCo.Networking.Chat
{
    public class ClientManager
    {
        int dBID;
        NetworkStream stream;
        Socket socket;
        string clientName;
        Semaphore semaphor = new Semaphore(1, 1);

        #region Properties

        public int DBID
        {
            get { return this.dBID; }
            set { this.dBID = value; }
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

        /// <summary>
        /// Gets the IP address of connected remote client.This is 'IPAddress.None' if the client is not connected.
        /// </summary>
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

        /// <summary>
        /// Gets the port number of connected remote client.This is -1 if the client is not connected.
        /// </summary>
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

        /// <summary>
        /// [Gets] The value that specifies the remote client is connected to this server or not.
        /// </summary>
        public bool Connected
        {
            get
            {
                return this.socket.Connected;
            }
        }

        public Socket Socket
        {
            get { return socket; }
            set
            {
                socket = value;
                //
                stream = new NetworkStream(Socket);
                //
                BackgroundWorker bw_Reciever = new BackgroundWorker();
                bw_Reciever.WorkerSupportsCancellation = true;
                bw_Reciever.DoWork += new DoWorkEventHandler(RunReciever);
                bw_Reciever.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_Reciever_RunWorkerCompleted);
                bw_Reciever.RunWorkerAsync();
            }
        }

        #endregion

        #region Events
        //
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

        public ClientManager(int DBID)
        {
            this.dBID = DBID;
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
                    ////Read the command's target size.
                    //buffer = new byte[4];
                    //readBytes = stream.Read(buffer, 0, 4);
                    //if (readBytes == 0)
                    //    break;
                    //int size = BitConverter.ToInt32(buffer, 0);
                    //MessageBox.Show(size.ToString());
                    //
                    //Read the command's target.
                    buffer = new byte[32423553];
                    readBytes = stream.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                        break;
                    //
                    string text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    //
                    string [] str=text.Split('\u00b6');

                    //
                    //MessageBox.Show(text);
                    ////Read the command's target size.
                    //byte[] buffer = new byte[4];
                    //int readBytes = stream.Read(buffer, 0, 4);
                    //if (readBytes == 0)
                    //    break;
                    //int ipSize = BitConverter.ToInt32(buffer, 0);

                    ////Read the command's target.
                    //buffer = new byte[ipSize];
                    //readBytes = stream.Read(buffer, 0, ipSize);
                    //if (readBytes == 0)
                    //    break;
                    //string ip = Encoding.ASCII.GetString(buffer);
                    //IPAddress cmdTarget = IPAddress.Parse(ip);
                    ////IPAddress cmdTarget = IPAddress.None;

                    ////Read the command's Type.
                    //buffer = new byte[4];
                    //readBytes = stream.Read(buffer, 0, 4);
                    //if (readBytes == 0)
                    //    break;
                    //CommandType cmdType = (CommandType)(BitConverter.ToInt32(buffer, 0));

                    

                    ////Read the command's MetaData size.
                    //string cmdMetaData = "";
                    //buffer = new byte[4];
                    //readBytes = stream.Read(buffer, 0, 4);
                    //if (readBytes == 0)
                    //    break;
                    //int metaDataSize = BitConverter.ToInt32(buffer, 0);

                    ////Read the command's Meta data.
                    //buffer = new byte[metaDataSize];
                    //readBytes = stream.Read(buffer, 0, metaDataSize);
                    //if (readBytes == 0)
                    //    break;
                    //cmdMetaData = Encoding.Unicode.GetString(buffer);
                    //MessageBox.Show(cmdMetaData);

                    //Command cmd = new Command(cmdType, IP, cmdTarget, cmdMetaData);
                    //if (cmd.CommandType == CommandType.ClientLoginInform)
                    //    cmd.SenderName = cmd.MetaData.Split(':')[1];
                    //else
                    //    cmd.SenderName = ClientName;
                    ////
                    //OnCommandReceived(new CommandEventArgs(cmd));
                    //
                    Command cmd = new Command(CommandType.Message, IP, int.Parse(str[1]), str[2]);
                    if (cmd.CommandType == CommandType.ClientLoginInform)
                        cmd.SenderName = cmd.MetaData.Split(':')[1];
                    else
                        cmd.SenderName = "?";
                    //
                    OnCommandReceived(new CommandEventArgs(cmd));
                }
                catch(Exception er)
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
                //Type
                byte[] buffer = new byte[4];
                buffer = BitConverter.GetBytes((int)cmd.CommandType);
                stream.Write(buffer, 0, 4);
                stream.Flush();

                //Sender IP
                byte[] senderIPBuffer = Encoding.ASCII.GetBytes(cmd.SenderIP.ToString());
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(senderIPBuffer.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                stream.Write(senderIPBuffer, 0, senderIPBuffer.Length);
                stream.Flush();

                //Sender Name
                byte[] senderNameBuffer = Encoding.Unicode.GetBytes(cmd.SenderName.ToString());
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(senderNameBuffer.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                stream.Write(senderNameBuffer, 0, senderNameBuffer.Length);
                stream.Flush();

                //Target
                byte[] ipBuffer = Encoding.ASCII.GetBytes(cmd.TargetContactID.ToString());
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(ipBuffer.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                stream.Write(ipBuffer, 0, ipBuffer.Length);
                stream.Flush();

                //Meta Data.
                if (cmd.MetaData == null || cmd.MetaData == "")
                    cmd.MetaData = "\n";

                byte[] metaBuffer = Encoding.Unicode.GetBytes(cmd.MetaData);
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(metaBuffer.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                stream.Write(metaBuffer, 0, metaBuffer.Length);
                stream.Flush();

                semaphor.Release();
                return true;
            }
            catch
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

        private void bw_Sender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnCommandSending(new CommandSendingEventArgs(
                    (!e.Cancelled && e.Error == null && (bool)e.Result)));
            //
            ((BackgroundWorker)sender).Dispose();
            GC.Collect();
        }

        private void bw_Sender_DoWork(object sender, DoWorkEventArgs e)
        {
            Command cmd = (Command)e.Argument;
            e.Result = SendCommandToClient(cmd);
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
            return IP.ToString() + ":" + Port;
        }
    }
}
