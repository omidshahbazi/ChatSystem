using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BinarySoftCo.ChatSystem.ServerNetworking;
using BinarySoftCo.ChatSystem.ClientNetworking;

namespace BinarySoftCo.ChatSystem.ClientDataLayer
{
    public partial class frmChat : Form
    {
        ClientInfo toMember;
        bool ShiftOrAlt = false;
        string contentAndSendetSpliter = "      ";

        private string MeString
        {
            get
            {
                string temp = "من";
                //
                for (int i = temp.Length; i <= toMember.ToString().Length; i++)
                    temp += " ";
                //
                return temp + contentAndSendetSpliter + contentAndSendetSpliter;
            }
        }

        public ClientInfo ToMember
        {
            get { return toMember; }
        }

        public frmChat(ClientInfo ToMember)
        {
            InitializeComponent();
            //
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo(1065));
            ptbLog.RightToLeft = ptbSend.RightToLeft =
                       (InputLanguage.CurrentInputLanguage.Culture.LCID == 1065 ?
                       RightToLeft.Yes :
                       RightToLeft.No);
            //
            Variables.Server.CommandReceived += new CommandReceivedEventHandler(Server_CommandReceived);
            //
            toMember = ToMember;
            //
            Text = toMember.ToString();
        }

        public frmChat(ClientInfo ToMember, Command RecievedCommand)
            : this(ToMember)
        {
            Server_CommandReceived(null, new CommandEventArgs(RecievedCommand));
        }

        private void Server_CommandReceived(object sender, CommandEventArgs e)
        {
            if (e.Command.Type == CommandsType.Message)
            {
                if (e.Command.FromMemberID == toMember.DBID)
                {
                    ptbLog.Text =
                        toMember.ToString() + contentAndSendetSpliter + e.Command.Content +
                        Environment.NewLine +
                        ptbLog.Text;
                }
            }
        }

        private void frmChat_Load(object sender, EventArgs e)
        {

        }

        private void frmChat_KeyUp(object sender, KeyEventArgs e)
        {
            if (ShiftOrAlt && (e.Alt || e.Shift))
            {
                if (ptbLog.RightToLeft == RightToLeft.Yes)
                    ptbLog.RightToLeft = ptbSend.RightToLeft = RightToLeft.No;
                else 
                    ptbLog.RightToLeft = ptbSend.RightToLeft = RightToLeft.Yes;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void frmChat_KeyDown(object sender, KeyEventArgs e)
        {
            ShiftOrAlt = (e.Alt || e.Shift);
        } 

        private void ptbSend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (e.Control)
                {
                    ptbSend.SelectionStart = ptbSend.TextLength;
                }
                else
                {
                    Variables.Server.SendCommand(new Command(toMember.DBID, ptbSend.Text, true));
                    //
                    ptbLog.Text =
                       MeString + ptbSend.Text +
                       ptbLog.Text;
                    //
                    ptbSend.ResetText();
                }
        }
    }
}
