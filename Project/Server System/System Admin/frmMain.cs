using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.ChatSystem.System_Admin
{
    public partial class frmMain : Form
    {
        private frmPersonList frmPL;
        private frmPersonEntry frmPE;

        private frmMemberList frmML;
        private frmMemberEntry frmME;

        private ToolStripButton tsbSelectedBase;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void tsbBaseItems_Click(object sender, EventArgs e)
        {
            tsbSelectedBase = (ToolStripButton)sender;
            if (tsbSelectedBase.Alignment == ToolStripItemAlignment.Right)
                tsbSelectedBase.Alignment = ToolStripItemAlignment.Left;
            else
            {
                foreach (ToolStripItem tsi in tsBaseItems.Items)
                    if (tsi is ToolStripButton)
                        if (tsi.Alignment == ToolStripItemAlignment.Right)
                        {
                            tsi.Alignment = ToolStripItemAlignment.Left;
                            break;
                        }
                //
                tsbSelectedBase.Alignment = ToolStripItemAlignment.Right;
            }
            //
            tsSubItems.Visible = (tsbSelectedBase.Alignment == ToolStripItemAlignment.Right);
        }

        private void tsbSubItems_Click(object sender, EventArgs e)
        {
            if (tsbSelectedBase == tsbPersons)
            {
                if (sender == tsbList)
                {
                    frmPL = new frmPersonList();
                    frmPL.Disposed += new EventHandler(frm_Disposed);
                    frmPL.ShowDialog();
                }
                else if (sender == tsbAdd)
                {
                    frmPE = new frmPersonEntry();
                    frmPE.Disposed += new EventHandler(frm_Disposed);
                    frmPE.ShowDialog();
                }
            }
            else if (tsbSelectedBase == tsbUsers)
            {
            }
            else if (tsbSelectedBase == tsbMembers)
            {
                if (sender == tsbList)
                {
                    frmML = new frmMemberList();
                    frmML.Disposed += new EventHandler(frm_Disposed);
                    frmML.ShowDialog();
                }
                else if (sender == tsbAdd)
                {
                    frmME = new frmMemberEntry();
                    frmME.Disposed += new EventHandler(frm_Disposed);
                    frmME.ShowDialog();
                }
            }
        }

        private void frm_Disposed(object sender, EventArgs e)
        {
            if (sender == frmPL) frmPL = null;
        }
    }
}
