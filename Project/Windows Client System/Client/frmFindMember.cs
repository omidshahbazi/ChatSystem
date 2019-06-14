using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BinarySoftCo.ChatSystem.ServerDataLayer;
using BinarySoftCo.ChatSystem.ClientNetworking;
using BinarySoftCo.ChatSystem.ClientDataLayer;
using BinarySoftCo.ChatSystem.ServerNetworking;

namespace BinarySoftCo.ChatSystem.Parsian_Chat
{
    public partial class frmFindMember : Form
    {
        public delegate void NewMemberAddedEventHandler(object sender, NewMemberAddedEventArgs e);

        public class NewMemberAddedEventArgs
        {
            List<Member> members;

            public List<Member> Members
            {
                get
                {
                    return members;
                }
            }

            public NewMemberAddedEventArgs(List<Member> Members)
            {
                members = Members;
            }
        }

        public event NewMemberAddedEventHandler NewMemberAdded;

        protected virtual void OnNewMemberAdded(NewMemberAddedEventArgs e)
        {
            if (NewMemberAdded != null)
                NewMemberAdded(this, e);
        }

        public List<Member> Selected
        {
            get
            {
                List<Member> list = new List<Member>();
                //
                if (dgvData.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dgvr in dgvData.SelectedRows)
                        list.Add((Member)dgvr.Cells["xData"].Value);
                }
                //
                return list;
            }
        }

        public frmFindMember()
        {
            InitializeComponent();
            //
            Variables.Server.CommandReceived += new CommandReceivedEventHandler(Server_CommandReceived);
        }

        private void Server_CommandReceived(object sender, CommandEventArgs e)
        {
            if (e.Command.Type == CommandsType.MemberData)
            {
                string[] str = e.Command.Content.Split(Command.Spliter);
                //
                Member m = new Member(
                    int.Parse(str[0]),
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
                    DateTime.Now,DateTime.Now,
                    true);
                //
                Control.CheckForIllegalCrossThreadCalls = false;
                //
                dgvData.Rows.Add(new object[]{
                    m,
                    m.Username,
                    m.FirstName,
                    m.LastName,
                    m.Email,
                    m.Address});
                //
                bAdd.Enabled = (dgvData.RowCount > 0);
            }
        }

        private void frmFindMember_Load(object sender, EventArgs e)
        {

        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            bSearch.Enabled = (tbValue.Text.Trim().Length > 0);
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (tbValue.Text.Trim().Length > 0)
            {
                dgvData.Rows.Clear();
                //
                bAdd.Enabled = (dgvData.RowCount > 0);
                //
                Variables.Server.SendCommand(new Command(CommandsType.FindMember, tbValue.Text));
            }
        }

        private void tbValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearch_Click(null, null);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (Selected.Count > 0)
                OnNewMemberAdded(new NewMemberAddedEventArgs(Selected));
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvData_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Selected.Count > 0)
            {
                dgvData.DoDragDrop(Selected, DragDropEffects.Copy);
            }
        }
    }
}
