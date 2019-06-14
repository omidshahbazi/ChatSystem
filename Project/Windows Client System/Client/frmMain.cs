using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

using BinarySoftCo.ChatSystem.ServerDataLayer;
using BinarySoftCo.ChatSystem.ClientDataLayer;
using BinarySoftCo.ChatSystem.ServerNetworking;
using BinarySoftCo.ChatSystem.ClientNetworking;
using BinarySoftCo.UIControls;

namespace BinarySoftCo.ChatSystem.Parsian_Chat
{
    sealed partial class frmMain : Form
    {
        frmFindMember frmFM;

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

        private void AddMember(Member member)
        {
            Variables.Server.SendCommand(new Command(CommandsType.AddNewFriend, member.DBID));
        }

        private void RequestMemberList()
        {
            albFriends.Items.Clear();
            //
            Variables.Server.SendCommand(new Command(CommandsType.GetRelatedMembers));
        }

        private Image GetImageForStatus(AvailableStatus Status)
        {
            Image temp = null;
            //
            switch (Status)
            {
                case AvailableStatus.Offline:
                    //
                    temp = Properties.Resources.Offline;
                    //
                    break;

                case AvailableStatus.Online:
                    //
                    temp = Properties.Resources.Online;
                    //
                    break;
            }
            //
            return temp;
        }

        public frmMain()
        {
            InitializeComponent();
            //
            Variables.Server.CommandReceived += new CommandReceivedEventHandler(Server_CommandReceived);
            Variables.Server.ClientAvailableStatusChanged+=new ClientAvailableStatusChangedEventHandler(Server_ClientAvailableStatusChanged);
            //
            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
            //
            RequestMemberList();
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
                }
                //
                recieved.RemoveAt(0);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Media.PlayLunchApplicationSound();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //
            Hide();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "بستن", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                niStatus.Dispose();
                //
                Media.PlayExitApplicationSound();
                //
                Program.SignOut();
                Variables.Server.Disconnect();
                Application.ExitThread();
            }
        }

        private void Server_ClientAvailableStatusChanged(object sender, ClientAvailableStatusChangedEventArgs e)
        {
            foreach (AdvancedListBoxItem albi in albFriends.Items)
            {
                if (((ClientMember)albi.Item).DBID == e.DBID)
                {
                    albi.Image = GetImageForStatus(e.Status);
                    break;
                }
            }
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
                    GetImageForStatus(status), new Size(15, 15)));
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

        private void niStatus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void bSearchMember_Click(object sender, EventArgs e)
        {
            if (frmFM == null)
            {
                frmFM = new frmFindMember();
                frmFM.NewMemberAdded += new frmFindMember.NewMemberAddedEventHandler(frmFM_NewMemberAdded);
                frmFM.FormClosed += new FormClosedEventHandler(frmFM_FormClosed);
            }
            //
            frmFM.Show();
            frmFM.BringToFront();
        }

        private void frmFM_NewMemberAdded(object sender, frmFindMember.NewMemberAddedEventArgs e)
        {
            foreach (Member m in e.Members)
                AddMember(m);
            //
            RequestMemberList();
        }

        private void frmFM_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFM = null;
        }

        private void albFriends_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<Member>)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void albFriends_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<Member>)))
            {
                List<Member> list = (List<Member>)e.Data.GetData(typeof(List<Member>));
                //
                foreach (Member m in list)
                    AddMember(m);
                //
                RequestMemberList();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (Selected != null)
                if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "حذف دوستی", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Variables.Server.SendCommand(new Command(CommandsType.DeleteFriend, Selected.DBID));
                    RequestMemberList();
                }
        }
    }
}
