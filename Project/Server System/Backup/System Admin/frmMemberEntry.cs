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
    public partial class frmMemberEntry : Form
    {
        bool inEditMode = false;
        //
        Member m_t = new Member();

        public Member EntryData
        {
            get
            {
                Person p = (Person)pcbPerson.SelectedItem;
                //
                return new Member(
                    m_t.DBID,
                    p.PersonDBID,
                    p.FirstName,
                    p.MiddleName,
                    p.LastName,
                    p.NickName,
                    p.Email,
                    p.WebPage,
                    p.Mobile,
                    p.Phone,
                    p.Address,
                    tbUsername.Text,
                    tbPass1.Text,
                    DateTime.Now, DateTime.Now, cbIsActive.Checked);
            }
            set
            {
                m_t = value;
                //
                foreach(Person p in pcbPerson.Items)
                    if (p.PersonDBID == m_t.PersonDBID)
                    {
                        pcbPerson.SelectedItem = p;
                        break;
                    }
                //
                tbUsername.Text = m_t.Username;
                tbPass1.Text = tbPass2.Text = m_t.Password;
                cbIsActive.Checked = m_t.IsActive;
            }
        }

        private void LoadPersons()
        {
            pcbPerson.Items.Clear();
            //
            List<Person> list = Variables.BaseData.GetAllPersonsInfo();
            //
            foreach (Person p in list)
                pcbPerson.Items.Add(p);
            //
            pcbPerson.SelectedIndex = 0;
        }

        public frmMemberEntry()
        {
            InitializeComponent();
            //
            LoadPersons();
        }

        public frmMemberEntry(Member Editable)
            : this()
        {
            if (Editable.PersonDBID < 0)
                Close();
            //
            Text = "ویرایش " + Editable.ToString();
            //
            inEditMode = true;
            //
            EntryData = Editable;
        }

        private void frmPersonEntry_Load(object sender, EventArgs e)
        {

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (Variables.BaseData.CheckForMemberExists(EntryData.Username))
            {
                MessageBox.Show(".شخص دیگری اکانتی مشابه این اکانت به ثبت رسانده است", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //
            if (inEditMode)
            {
                if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "ویرایش", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Variables.BaseData.UpdateMember(EntryData);
            }
            else
                Variables.BaseData.AddMember(EntryData);
            //
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "انصراف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void cbShowChar_CheckedChanged(object sender, EventArgs e)
        {
            tbPass1.UseSystemPasswordChar =
                tbPass2.UseSystemPasswordChar =
                !cbShowChar.Checked;
        }

        private void bEditPerson_Click(object sender, EventArgs e)
        {
            frmPersonEntry frmPE = new frmPersonEntry((Person)pcbPerson.SelectedItem);
            frmPE.ShowDialog();
            int index = pcbPerson.SelectedIndex;
            LoadPersons();
            pcbPerson.SelectedIndex = index;
            pcbPerson.Focus();
        }

        private void frmMemberEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                bSave_Click(null, null);
            else if (e.KeyChar == (char)Keys.Escape)
                bCancel_Click(null, null);
        }
    }
}
