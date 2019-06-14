using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace BinarySoftCo.ChatSystem.Networking
{
    /// <summary>
    /// Occurs when a client logged in successfuly.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">EventArgs.</param>
    public delegate void NewClientLoggedInEventHandler(object sender, NewClientLoggedInEventArgs e);

    public class NewClientLoggedInEventArgs : EventArgs
    {
        ClientManager client;

        public ClientManager Client
        {
            get { return client; }
        }

        /// <summary>
        /// Creates an instance of ClientEventArgs class.
        /// </summary>
        /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
        public NewClientLoggedInEventArgs(ClientManager Client)
        {
            client = Client;
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
        ClientManager client;

        public ClientManager Client
        {
            get { return client; }
        }

        /// <summary>
        /// Creates an instance of ClientEventArgs class.
        /// </summary>
        /// <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
        public ClientEventArgs(ClientManager Client)
        {
            client = Client;
        }
    }
}
