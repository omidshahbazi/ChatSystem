using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConstantsVariables;

namespace BinarySoftCo.ChatSystem.ServerEngine
{
    public partial class frmLogin : Form
    {
        bool inEntryPoint = true,
            trueUser = false;

        public frmLogin(bool InEntryPoint)
        {
            InitializeComponent();
            //
            inEntryPoint = InEntryPoint;
        }

        public bool ShowDialog()
        {
            base.ShowDialog();
            //
            return trueUser;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            tbUsername.Text = "admin";
            tbPassword.Text = "123";
            bLogin_Click(null, null);
        }

        private void frmLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) bLogin_Click(null, null);
            else if (e.KeyCode == Keys.Escape) bCancel_Click(null, null);
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            trueUser = Variables.BaseData.GetUserLoginStatus(tbUsername.Text, tbPassword.Text);
            if (trueUser)
                bCancel_Click(null, null);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
