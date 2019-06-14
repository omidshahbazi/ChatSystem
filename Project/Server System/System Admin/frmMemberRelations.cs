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
    public partial class frmMemberRelations : Form
    {
        Member member;
        frmMemberList frmML;

        private Member current
        {
            set
            {
                member = value;
                //
                clbFriends.Items.Clear();
                //
                List<MemberRelation> list = Variables.BaseData.GetRelationsFor(value.DBID);
                //
                foreach (MemberRelation mr in list)
                    clbFriends.Items.Add(mr);
                //
                if (list.Count > 0)
                    clbFriends.SelectedIndex = 0;
            }
        }

        private bool ExistsInList(Member Member)
        {
            foreach (MemberRelation mr in clbFriends.Items)
                if (mr.Member.DBID == Member.DBID)
                    return true;
            //
            return false;
        }

        public frmMemberRelations(Member member)
        {
            InitializeComponent();
            //
            current = member;
            //
            Text += member.ToString();
        }

        private void frmMemberRelations_Load(object sender, EventArgs e)
        {

        }

        private void frmMemberRelations_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmML != null) frmML.Close();
        }

        private void frmMemberRelations_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                bExit_Click(null, null);
            else if (e.KeyCode == Keys.Delete)
                clbFriends_MouseUp(null, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bMutual_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "تغییر رابطه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
        }

        private void clbFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bool wanna = ((MemberRelation)clbFriends.SelectedItem).WannaRelationFromBase;
            //
            //bMutual.BackColor = 
            //    (wanna ?
            //    Color.Green :
            //    Color.Red);
        }

        private void clbFriends_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void clbFriends_MouseUp(object sender, MouseEventArgs e)
        {
            if (clbFriends.SelectedIndex > -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (MessageBox.Show("آیا مایل به ادامه میباشید ؟", "حذف رابطه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MemberRelation mr = (MemberRelation)clbFriends.SelectedItem;
                        //
                        Variables.BaseData.DeleteMemberRelation(mr.DBID);
                        //
                        current = member;
                    }
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (frmML == null)
            {
                frmML = new frmMemberList(true);
                frmML.FormClosed += new FormClosedEventHandler(frmML_FormClosed);
                frmML.Show();
            }
        }

        private void frmML_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmML = null;
        }

        private void clbFriends_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(List<Member>)))
                e.Effect = DragDropEffects.Copy;
        }

        private void clbFriends_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy)
            {
                List<Member> list = (List<Member>)e.Data.GetData(typeof(List<Member>));
                //
                foreach (Member m in list)
                    if (m.DBID != member.DBID && !ExistsInList(m))
                    {
                        int ID = Variables.BaseData.AddMemberRelation(member.DBID, m.DBID);
                        //
                        current = member;
                    }
            }
        }
    }
}
