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
    public partial class frmNewMember : Form
    {
        int pageIndex = 1;
        Person selected;

        public Person Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                //
                if (selected == null)
                {
                    tbFirstName.ResetText();
                    tbMiddleName.ResetText();
                    tbLastName.ResetText();
                    tbNickName.ResetText();
                    ltbEmail.ResetText();
                    ltbWebPage.ResetText();
                    ptbMobile.ResetText();
                    ptbPhone.ResetText();
                    ptbAddress.ResetText();
                }
                else
                {
                    tbFirstName.Text = selected.FirstName;
                    tbMiddleName.Text = selected.MiddleName;
                    tbLastName.Text = selected.LastName;
                    tbNickName.Text = selected.NickName;
                    ltbEmail.Text = selected.Email;
                    ltbWebPage.Text = selected.WebPage;
                    ptbMobile.Text = selected.Mobile;
                    ptbPhone.Text = selected.Phone;
                    ptbAddress.Text = selected.Address;
                    //
                    pPersonData.Enabled = false;
                }
            }
        }

        public frmNewMember()
        {
            InitializeComponent();
            //
            Variables.Server.CommandReceived += new CommandReceivedEventHandler(Server_CommandReceived);
        }

        private void Server_CommandReceived(object sender, CommandEventArgs e)
        {
            if (e.Command.Type == CommandsType.RegisterMemberSuccessful)
            {
            }
            else if (e.Command.Type == CommandsType.RegisterMemberFailed)
            {
                lResult.Text = e.Command.Content;
            }
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            //
            pbWait.Visible = false;
            pFinish.BringToFront();
            //
            bNext.Visible = true;
        }

        private void frmNewMember_Load(object sender, EventArgs e)
        {

        }

        private void rbHasProfile_CheckedChanged(object sender, EventArgs e)
        {
            llSelectPerson.Enabled = rbHasProfile.Checked;
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            pageIndex++;
            //
            switch (pageIndex)
            {
                case 2:
                    //
                    if (rbHasProfile.Checked)
                    {
                        if (selected == null)
                        {
                            pageIndex--;
                            //
                            return;
                        }
                    }
                    //
                    pPersonData.BringToFront();
                    //
                    break;

                case 3:
                    //
                    if (tbFirstName.Validate &&
                        tbLastName.Validate &&
                       ltbEmail.Validate)
                    {
                        pMemberData.BringToFront();
                        //
                        bNext.Text = "اتمام";
                    }
                    else pageIndex--;
                    //
                    break;

                case 4:
                    //
                    if (tbPassword1.Text != tbPassword2.Text)
                    {
                        tbPassword2.ResetText();
                        pMemberData.BringToFront();
                        //
                        bNext.Text = "بعدی";
                        //
                        pageIndex--;
                        //
                        return;
                    }
                    //
                    bCancel.Visible = bNext.Visible = bBack.Visible = false;
                    //
                    pbWait.Visible = true;
                    pbWait.BringToFront();
                    //
                    if (rbHasProfile.Checked)
                    {
                        Variables.Server.SendCommand(new Command(selected.PersonDBID, tbUsername.Text, tbPassword1.Text));
                    }
                    else if (rbNewProfile.Checked)
                    {
                        Variables.Server.SendCommand(new Command(
                            tbFirstName.Text,
                            tbMiddleName.Text,
                            tbLastName.Text,
                            tbNickName.Text,
                            ltbEmail.Text,
                            ltbWebPage.Text,
                            ptbMobile.Text,
                            ptbPhone.Text,
                            ptbAddress.Text,
                            tbUsername.Text, 
                            tbPassword1.Text));
                    }
                    //
                    break;

                case 5:
                    //
                    Close();
                    //
                    break;
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            pageIndex--;
            //
            switch (pageIndex)
            {
                case 1:
                    //
                    pRegisterType.BringToFront();
                    //
                    Selected = null;
                    pPersonData.Enabled = true;
                    //
                    break;

                case 2:
                    //
                    if (rbHasProfile.Checked)
                    {
                        if (selected == null)
                            pageIndex--;
                    }
                    //
                    pPersonData.BringToFront();
                    //
                    break;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {

        }

        private void llSelectPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFindPerson frmFP = new frmFindPerson();
            Selected = frmFP.ShowDialog();
            //
            if (Selected != null)
                bNext_Click(null, null);
            //
            Variables.Server.CommandReceived += new CommandReceivedEventHandler(Server_CommandReceived);
        }
    }
}
