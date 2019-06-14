using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Port_Forwarder
{
    public partial class SinglePortForwardData : UserControl
    {
        new public bool ForwardingEnabled
        {
            get { return cbEnabled.Checked; }
            set { cbEnabled.Checked = value; }
        }

        public IPAddress IP
        {
            get { return iptbAddress.IP; }
            set { iptbAddress.IP = value; }
        }

        public string IPString
        {
            get { return IP.ToString(); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    IP = IPAddress.Parse(value);
                else
                    IP = IPAddress.None;
            }
        }

        public int ExternalPort
        {
            get { return (int)nudExternalPort.Value; }
            set { nudExternalPort.Value = value; }
        }

        public int InternalPort
        {
            get { return (int)nudInternalPort.Value; }
            set { nudInternalPort.Value = value; }
        }

        public string ApplicationName
        {
            get { return tbApplication.Text; }
            set { tbApplication.Text = value; }
        }

        public SinglePortForwardData()
        {
            InitializeComponent();
        }

        private void SinglePortForwardData_Load(object sender, EventArgs e)
        {

        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, 439, 28, specified);
        }
    }
}
