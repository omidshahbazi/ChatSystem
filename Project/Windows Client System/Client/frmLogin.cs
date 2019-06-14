using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using BinarySoftCo.ChatSystem.ClientFileAccess;
using BinarySoftCo.ChatSystem.ServerNetworking;
using BinarySoftCo.ChatSystem.ClientNetworking;
using BinarySoftCo.ChatSystem.ClientDataLayer;
using BinarySoftCo.UIControls;
using BinarySoftCo.Tools;

namespace BinarySoftCo.ChatSystem.Parsian_Chat
{
    sealed partial class frmLogin : Form
    {
        bool ExitFromThread = true,
            CancelLogining = false;
        int tryToConnect = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        public frmLogin()
        {
            InitializeComponent();
            //
            tbUsername.Text = Variables.LoginSettings.Username;
            tbPassword.Text = Variables.LoginSettings.Password;
            cbAutoLogin.Checked = Variables.LoginSettings.AutoLogin;
            cbAutoStart.Checked = Variables.LoginSettings.AutoStart;
            //
            if (cbAutoLogin.Checked)
                bLogin_Click(null, null);
            //
            Variables.Server.CommandReceived += new BinarySoftCo.ChatSystem.ClientNetworking.CommandReceivedEventHandler(Server_CommandReceived);
        }

        private void Server_CommandReceived(object sender, BinarySoftCo.ChatSystem.ClientNetworking.CommandEventArgs e)
        {
            if (!CancelLogining)
            {
                if (e.Command.Type == CommandsType.SignInSuccessful)
                {
                    Variables.LoginSettings.Username = tbUsername.Text;
                    if (cbAutoLogin.Checked)
                        Variables.LoginSettings.Password = tbPassword.Text;
                    else 
                        Variables.LoginSettings.Password = "";
                    //
                    FileManager.Save(Variables.LoginSettings, File_Type.ClienSetting);
                    //
                    ExitFromThread = false;
                    Control.CheckForIllegalCrossThreadCalls = false;
                    Close();
                }
                else if (e.Command.Type == CommandsType.SignInFailed)
                {
                    tryToConnect++;
                    if (cbAutoLogin.Checked && tryToConnect < 4)
                        bLogin_Click(null, null);
                    else
                    {
                        Control.CheckForIllegalCrossThreadCalls = false;
                        //
                        pbWait.SendToBack();
                        //
                        tbPassword.ResetText();
                        tbPassword.Focus();
                    }
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExitFromThread)
                Application.ExitThread();
        }

        private void frmLogin_KeyUp(object sender, KeyEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //
            if (e.KeyCode == Keys.Enter)
            {
                if (!bLogin.Focused)
                    SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                frmLogin_FormClosing(null, null);
            }
            //
            lCapsLockOn.Visible = (((ushort)GetKeyState(0x14) & 0xffff) != 0 && tbPassword.Focused);
        }

        private void cbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            Variables.LoginSettings.AutoLogin = cbAutoLogin.Checked;
            FileManager.Save(Variables.LoginSettings, File_Type.ClienSetting);
        }

        private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            //AutoStart.SetAutoStart(cbAutoStart.Checked, Properties.Resources.ApplicationName, Application.ExecutablePath);
            //
            Variables.LoginSettings.AutoStart = cbAutoStart.Checked;
            FileManager.Save(Variables.LoginSettings, File_Type.ClienSetting);
        }

        private void llNewUsername_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNewMember frmNM = new frmNewMember();
            frmNM.ShowDialog();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.TextLength > 0 && tbPassword.TextLength > 0)
            {
                CancelLogining = false;
                //
                Control.CheckForIllegalCrossThreadCalls = false;
                pbWait.BringToFront();
                Variables.Server.SendCommand(new Command(tbUsername.Text, tbPassword.Text));
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            CancelLogining = true;
            //
            pbWait.SendToBack();
        }
    }
}
