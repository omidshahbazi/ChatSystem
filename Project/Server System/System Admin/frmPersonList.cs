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
    public partial class frmPersonList : Form
    {
        frmPersonEntry frmPE;

        private void LoadData()
        {
            FillInDataGridView(Variables.BaseData.GetAllPersonsInfo());
        }

        private void FillInDataGridView(List<Person> list)
        {
            dgvData.Rows.Clear();
            //
            foreach (Person p in list)
                dgvData.Rows.Add(new object[]{
                    p,
                    p.FirstName,
                    p.MiddleName,
                    p.LastName,
                    p.NickName,
                    p.Address});
            //
            bEdit.Enabled = bDelete.Enabled = (list.Count > 0);
        }

        private Person Selected
        {
            get
            {
                Person temp = new Person();
                //
                if (dgvData.CurrentRow != null)
                    temp = (Person)dgvData.CurrentRow.Cells["xData"].Value;
                //
                return temp;
            }
        }

        public frmPersonList()
        {
            InitializeComponent();
            //
            LoadData();
        }

        private void frmPersonList_Load(object sender, EventArgs e)
        {

        }

        private void tbMixSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbMixSearch.TextLength > 0)
                FillInDataGridView(Variables.BaseData.FilterInPersons(tbMixSearch.Text));
            else LoadData();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            frmPE = new frmPersonEntry();
            frmPE.ShowDialog();
            tbMixSearch_TextChanged(null, null);
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            frmPE = new frmPersonEntry(Selected);
            frmPE.ShowDialog();
            tbMixSearch_TextChanged(null, null);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Variables.BaseData.DeletePerson(Selected.PersonDBID);
                tbMixSearch_TextChanged(null, null);
            }
        }
    }
}
