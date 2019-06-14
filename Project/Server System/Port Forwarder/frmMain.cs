using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Port_Forwarder
{
    public partial class frmMain : Form
    {
        private void ResetPortForwarderLocation()
        {
            for (int i = 0; i < spPortForwarders.Controls.Count; i++)
                spPortForwarders.Controls[i].Location = new Point(0, i * spPortForwarders.Controls[i].Location.Y);
        }

        private void AddNewPortForwarder()
        {
            spPortForwarders.Controls.Add(new SinglePortForwardData());
            //
            ResetPortForwarderLocation();
        }

        public frmMain()
        {
            InitializeComponent();
            //
            AddNewPortForwarder();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
