using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BinarySoftCo.ChatSystem.ServerDataLayer;
using BinarySoftCo.ChatSystem.ClientDataLayer;
using BinarySoftCo.ChatSystem.ServerNetworking;
using BinarySoftCo.ChatSystem.ClientNetworking;

namespace BinarySoftCo.ChatSystem.Parsian_Chat
{
    public partial class frmFindPerson : Form
    {
        bool Canceling = false;

        public Person Selected
        {
            get
            {
                if (dgvData.CurrentRow != null)
                    return (Person)dgvData.CurrentRow.Cells["xData"].Value;
                //
                return null;
            }
        }

        public frmFindPerson()
        {
            InitializeComponent();
            //
            Variables.Server.CommandReceived += new CommandReceivedEventHandler(Server_CommandReceived);
        }

        private void Server_CommandReceived(object sender, CommandEventArgs e)
        {
            if (e.Command.Type == CommandsType.PersonData)
            {
                string[] str = e.Command.Content.Split(Command.Spliter);
                //
                Person p = new Person(
                    int.Parse(str[0]),
                    str[1].Trim(),
                    str[2].Trim(),
                    str[3].Trim(),
                    str[4].Trim(),
                    str[5].Trim(),
                    str[6].Trim(),
                    str[7].Trim(),
                    str[8].Trim(),
                    str[9].Trim());
                //
                Control.CheckForIllegalCrossThreadCalls = false;
                //
                dgvData.Rows.Add(new object[]{
                    p,
                    p.FirstName,
                    p.MiddleName,
                    p.LastName,
                    p.NickName,
                    p.Email});
                //
                bSelect.Enabled = (dgvData.RowCount > 0);
            }
        }

        new public Person ShowDialog()
        {
            base.ShowDialog();
            //
            if (Canceling)
                return null;
            //
            return Selected;
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
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
                bSelect.Enabled = (dgvData.RowCount > 0);
                //
                Variables.Server.SendCommand(new Command(CommandsType.FindPerson, tbValue.Text));
            }
        }

        private void tbValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearch_Click(null, null);
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Canceling = true;
            Close();
        }
    }
}
