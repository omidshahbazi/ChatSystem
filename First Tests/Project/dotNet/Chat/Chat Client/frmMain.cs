using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Chat_Client
{
    public partial class frmMain : Form
    {
        NetworkStream ns;
        private void ShowLoginForm()
        {
            frmLogin frmL = new frmLogin();
            if(!frmL.ShowDialog())
                ShowLoginForm();
        }

        public frmMain()
        {
            InitializeComponent();
            //
            //ShowLoginForm();
            TcpClient tc= new TcpClient("127.0.0.1", 2324);

            ns = new NetworkStream(tc.Client);
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string s = "Message\u00b6192.168.238.2\u00b6A";


            byte[]bytes=BitConverter.GetBytes(s.Length);
            ns.Write(bytes,0,bytes.Length);

            bytes = Encoding.ASCII.GetBytes(s);
            ns.Write(bytes, 0, bytes.Length);
        }
    }
}
