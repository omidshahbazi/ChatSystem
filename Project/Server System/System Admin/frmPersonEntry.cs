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
    public partial class frmPersonEntry : Form
    {
        bool inEditMode = false;
        //
        Person p_t = new Person();

        public Person EntryData
        {
            get
            {
                return new Person(
                    p_t.PersonDBID,
                    tbFirstName.Text,
                    tbMiddleName.Text,
                    tbLastName.Text,
                    tbNickName.Text,
                    ltbEmail.Text,
                    ltbWebPage.Text,
                    ptbMobile.Text,
                    ptbPhone.Text,
                    ptbAddress.Text);
            }
            set
            {
                p_t = value;
                //
                tbFirstName.Text = p_t.FirstName;
                tbMiddleName.Text = p_t.MiddleName;
                tbLastName.Text = p_t.LastName;
                tbNickName.Text = p_t.NickName;
                ltbEmail.Text = p_t.Email;
                ltbWebPage.Text = p_t.WebPage;
                ptbMobile.Text = p_t.Mobile;
                ptbPhone.Text = p_t.Phone;
                ptbAddress.Text = p_t.Address;
            }
        }

        public frmPersonEntry()
        {
            InitializeComponent();
        }

        public frmPersonEntry(Person Editable)
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
            if (inEditMode)
                if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "ویرایش", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Variables.BaseData.UpdatePerson(EntryData);
                else
                {
                    List<Person> list = Variables.BaseData.FilterInPersons(EntryData.Email);
                    if (list.Count > 0)
                    {
                        MessageBox.Show(".قبلا با این ایمیل شخصی ثبت نام کرده است", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    //
                    Variables.BaseData.AddPerson(EntryData);
                }
            //
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "انصراف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void frmPersonEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                bSave_Click(null, null);
            else if (e.KeyChar == (char)Keys.Escape)
                bCancel_Click(null, null);
        }
    }
}
