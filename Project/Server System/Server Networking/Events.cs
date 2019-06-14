using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using BinarySoftCo.ChatSystem.ServerDataLayer;
using BinarySoftCo.ChatSystem.ClientDataLayer;
using BinarySoftCo.ChatSystem.ServerNetworking;

namespace BinarySoftCo.ChatSystem.ServerNetworking
{
    /// <summary>
    /// Occurs when a client logged in successfuly.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void ClientStatusEventHandler(object sender, ClientStatusEventArgs e);

    public class ClientStatusEventArgs : EventArgs
    {
        Member client;
        AvailableStatus status;

        public Member Client
        {
            get { return client; }
        }

        public AvailableStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Creates an instance of ClientEventArgs class.
        /// </summary>
        /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
        public ClientStatusEventArgs(Member Client)
        {
            client = Client;
        }
    }

    /// <summary>
    /// Occurs when a client logged in successfuly.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void ClientAvailableStatusChangedEventHandler(object sender, ClientAvailableStatusChangedEventArgs e);

    public class ClientAvailableStatusChangedEventArgs : EventArgs
    {
        SocketClient client;
        AvailableStatus status;

        public SocketClient Client
        {
            get { return client; }
        }

        public AvailableStatus Status
        {
            get { return status; }
        }

        /// <summary>
        /// Creates an instance of ClientEventArgs class.
        /// </summary>
        /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
        public ClientAvailableStatusChangedEventArgs(SocketClient Client, AvailableStatus Status)
        {
            client = Client;
            status = Status;
        }
    }

    /// <summary>
    /// Occurs when a command had been sent to the remote client successfully.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void CommandSendingEventHandler(object sender, CommandSendingEventArgs e);

    public class CommandSendingEventArgs : EventArgs
    {
        bool sent = false;

        public bool Sent
        {
            get { return sent; }
        }

        /// <summary>
        /// Creates an instance of ClientEventArgs class.
        /// </summary>
        /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
        public CommandSendingEventArgs(bool Sent)
        {
            sent = Sent;
        }
    }

    /// <summary>
    /// Occurs when a command received from a client.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">The received command object.</param>
    public delegate void CommandReceivedEventHandler(object sender, CommandEventArgs e);

    /// <summary>
    /// The class that contains information about received command.
    /// </summary>
    public class CommandEventArgs : EventArgs
    {
        private IPEndPoint iPEndPoint;
        /// <summary>
        /// The sender IPEndPoint.
        /// </summary>
        public IPEndPoint IPEndPoint
        {
            get { return iPEndPoint; }
            set { iPEndPoint = value; }
        }

        private Command command;
        /// <summary>
        /// The received command.
        /// </summary>
        public Command Command
        {
            get { return command; }
        }

        /// <summary>
        /// Creates an instance of CommandEventArgs class.
        /// </summary>
        /// <param name="cmd">The received command.</param>
        public CommandEventArgs(Command cmd)
        {
            this.command = cmd;
        }

        /// <summary>
        /// Creates an instance of CommandEventArgs class.
        /// </summary>
        /// <param name="IPEndPoint">The sender IPEndPoint.</param>
        /// <param name="cmd">The received command.</param>
        public CommandEventArgs(IPEndPoint IPEndPoint, Command cmd)
            : this(cmd)
        {
            this.IPEndPoint = IPEndPoint;
        }
    }

    /// <summary>
    /// Occurs when a remote client had been disconnected from the server.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">The client information.</param>
    public delegate void DisconnectedEventHandler(object sender, ClientEventArgs e);

    /// <summary>
    /// Client event args.
    /// </summary>
    public class ClientEventArgs : EventArgs
    {
        SocketClient socketClient;
        HTTPClient hTTPClient;

        public SocketClient SocketClient
        {
            get { return socketClient; }
        }

        public HTTPClient HTTPClient
        {
            get { return hTTPClient; }
        }

        /// <summary>
        /// Creates an instance of ClientEventArgs class.
        /// </summary>
        /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
        public ClientEventArgs(SocketClient Client)
        {
            socketClient = Client;
        }

        /// <summary>
        /// Creates an instance of ClientEventArgs class.
        /// </summary>
        /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
        public ClientEventArgs(HTTPClient Client)
        {
            hTTPClient = Client;
        }
    }
}
