using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BinarySoftCo.ChatSystem.ClientDataLayer;
using BinarySoftCo.ChatSystem.ServerNetworking;
using BinarySoftCo.ChatSystem.ClientNetworking;
using BinarySoftCo.UIControls;

namespace BinarySoftCo.ChatSystem.Parsian_Chat
{
    sealed partial class frmMain : Form
    {
        List<Command> recieved = new List<Command>();

        private ClientMember Selected
        {
            get
            {
                if (albFriends.SelectedIndex > -1)
                    return (ClientMember)((AdvancedListBoxItem)albFriends.SelectedItem).Item;
                return null;
            }
        }

        private ClientMember GetClientMemberByID(int ToMemberID)
        {
            foreach (AdvancedListBoxItem albi in albFriends.Items)
            {
                ClientMember cm = (ClientMember)albi.Item;
                if (cm.DBID == ToMemberID)
                    return cm;
            }
            //
            return null;
        }

        public frmMain()
        {
            InitializeComponent();
            //
            Variables.Server.CommandReceived += new CommandReceivedEventHandler(Server_CommandReceived);
            //
            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            if (recieved.Count > 0)
            {
                ClientMember cm = GetClientMemberByID(recieved[0].FromMemberID);
                //
                if (cm != null)
                {
                    if (cm.ChatPage == null)
                    {
                        cm.ChatPage = new frmChat(cm, recieved[0]);
                        cm.ChatPage.FormClosed += new FormClosedEventHandler(frmChat_FormClosed);
                    }
                    //
                    cm.ChatPage.Show();
                    cm.ChatPage.BringToFront();
                    cm.ChatPage.WindowState = FormWindowState.Normal;
                }
                //
                recieved.RemoveAt(0);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Variables.Server.SendCommand(new Command(CommandsType.GetRelatedMembers));
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //
            Hide();
        }

        private void Server_CommandReceived(object sender, CommandEventArgs e)
        {
            if (e.Command.Type == CommandsType.GetRelatedMembersResponse)
            {
                string[] str = e.Command.MetaData.Split(Command.Spliter);
                //
                AvailableStatus status = (AvailableStatus)int.Parse(str[0]);
                //
                albFriends.Items.Add(new AdvancedListBoxItem(
                    new ClientMember(int.Parse(str[1]), str[2], status),
                    (status == AvailableStatus.Online ? Properties.Resources.Online : Properties.Resources.Offline), new Size(15, 15)));
            }
            else if (e.Command.Type == CommandsType.Message)
            {
                recieved.Add(e.Command);
            }
        }

        private void albFriends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Selected != null)
            {
                if (Selected.ChatPage == null)
                {
                    Selected.ChatPage = new frmChat(Selected);
                    Selected.ChatPage.FormClosed += new FormClosedEventHandler(frmChat_FormClosed);
                }
                //
                Selected.ChatPage.Show();
                Selected.ChatPage.BringToFront();
                Selected.ChatPage.WindowState = FormWindowState.Normal;
            }
        }

        private void frmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetClientMemberByID(((frmChat)sender).ToMember.DBID).ChatPage = null;
        }

        private void bSignOut_Click(object sender, EventArgs e)
        {
            Program.SignOut();
            Application.Restart();
            bExit_Click(null, null);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Program.SignOut();
            Variables.Server.Disconnect();
            Application.ExitThread();
        }

        private void niStatus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }
    }
}
