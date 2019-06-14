using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public partial class SelectionListBox : UserControl
    {
        Point MouseLoc = new Point();
        
        public CheckedListBox.ObjectCollection Items
        {
            get { return clbItems.Items; }
        }

        public CheckedListBox.CheckedIndexCollection CheckedIndices
        {
            get { return clbItems.CheckedIndices; }
        }

        public CheckedListBox.CheckedItemCollection CheckedItems
        {
            get { return clbItems.CheckedItems; }
        }

        private void SetBoxSize()
        {
            Height = 30 + (clbItems.Items.Count * 18);
        }

        public void Add(object Item)
        {
            if (Item != null) clbItems.Items.Add(Item);
            //
            SetBoxSize();
        }

        public void Add(object Item, bool State)
        {
            if (Item != null) clbItems.Items.Add(Item, State);
            //
            SetBoxSize();
        }

        public void Clear()
        {
            clbItems.Items.Clear();
            //
            SetBoxSize();
        }

        public void Remove(object Item)
        {
            if (Item != null) clbItems.Items.Remove(Item);
            //
            SetBoxSize();
        }

        public void RemoveAt(int Index)
        {
            if (Index > -1) clbItems.Items.RemoveAt(Index);
            //
            SetBoxSize();
        }

        public void SetChecked(int Index, bool State)
        {
            clbItems.SetItemChecked(Index, State);
        }

        public bool GetChecked(int Index)
        {
            return clbItems.GetItemChecked(Index);
        }

        public void SetCheckedForAll(bool State)
        {
            for (int i = 0; i < clbItems.Items.Count; i++)
                SetChecked(i, State);
        }

        public void SetCheckedAll()
        {
            SetCheckedForAll(true);
            //
            cbAllItem.Checked = true;
        }

        public void SetCheckedNone()
        {
            SetCheckedForAll(false);
            //
            cbAllItem.Checked = false;
        }

        public SelectionListBox()
        {
            InitializeComponent();
        }

        private void SelectionListBox_Load(object sender, EventArgs e)
        {

        }

        private void cbAllItem_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedForAll(cbAllItem.Checked);
        }

        private bool CheckForMouseContainsInBox(Point Location)
        {
            if (Location.X < 5) return false;
            else if (Location.X > Width - 5) return false;
            else if (Location.Y < 5) return false;
            else if (Location.Y > Height - 5) return false;
            //
            return true;
        }

        private void SelectionListBox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLoc = e.Location;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (CheckForMouseContainsInBox(MouseLoc)) return;
            else base.OnMouseLeave(e);
        }
    }
}
