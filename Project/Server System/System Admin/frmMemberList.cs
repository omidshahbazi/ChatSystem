using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BinarySoftCo.ChatSystem.ServerDataLayer;

namespace BinarySoftCo.ChatSystem.System_Admin
{
    public partial class frmMemberList : Form
    {
        bool forSelection;
        frmMemberEntry frmME;

        private void LoadData()
        {
            FillInDataGridView(Variables.BaseData.GetAllMembersInfo());
        }

        private void FillInDataGridView(List<Member> list)
        {
            dgvData.Rows.Clear();
            //
            foreach (Member m in list)
                dgvData.Rows.Add(new object[]{
                    m,
                    m.Username,
                    m.IsActive ? "فعال" : "غیر فعال",
                    m.FirstName,
                    m.LastName,
                    m.Address});
            //
            bRelations.Enabled = bActive.Enabled = bInactive.Enabled = bEdit.Enabled = bDelete.Enabled = (list.Count > 0);
        }

        private List<Member> Selected
        {
            get
            {
                List<Member> temp = new List<Member>();
                //
                foreach (DataGridViewRow dgvr in dgvData.SelectedRows)
                    temp.Add((Member)dgvr.Cells["xData"].Value);
                //
                return temp;
            }
        }

        public frmMemberList()
        {
            InitializeComponent();
            //
            LoadData();
        }

        public frmMemberList(bool ForSelection)
            : this()
        {
            TopMost = forSelection = ForSelection;
            //
            bNew.Visible = bEdit.Visible = bDelete.Visible =
                bRelations.Visible = bActive.Visible = bInactive.Visible = !ForSelection;
            //
            bExit.Visible = ForSelection;
        }

        private void frmPersonList_Load(object sender, EventArgs e)
        {

        }

        private void tbMixSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbMixSearch.TextLength > 0)
                FillInDataGridView(Variables.BaseData.FilteInMembers(tbMixSearch.Text));
            else LoadData();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            frmME = new frmMemberEntry();
            frmME.ShowDialog();
            tbMixSearch_TextChanged(null, null);
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            frmME = new frmMemberEntry(Selected[0]);
            frmME.ShowDialog();
            tbMixSearch_TextChanged(null, null);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Member m in Selected)
                    Variables.BaseData.DeleteMember(m.DBID);
                //
                tbMixSearch_TextChanged(null, null);
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            bRelations.Enabled = bEdit.Enabled = (Selected.Count == 1);
        }

        private void bActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "فعال کردن", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Member m in Selected)
                    Variables.BaseData.ActivationMember(m.DBID, true);
                //
                tbMixSearch_TextChanged(null, null);
            }
        }

        private void bInactive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "غیر فعال کردن", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Member m in Selected)
                    Variables.BaseData.ActivationMember(m.DBID, false);
                //
                tbMixSearch_TextChanged(null, null);
            }
        }

        private void bRelations_Click(object sender, EventArgs e)
        {
            frmMemberRelations frmMR = new frmMemberRelations(Selected[0]);
            frmMR.ShowDialog();
        }

        private void dgvData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Selected.Count > 0)
            {
                dgvData.DoDragDrop(Selected, DragDropEffects.Copy);
            }
        }
    }
}
