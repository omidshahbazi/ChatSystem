using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    [Serializable]
    public partial class DropDownTreeViewControl : PersianTreeView , IDropDownControl
    {

        public DropDownTreeViewControl()
        {
            //InitializeComponent();
        }

        private CloseDropDownControlHandler CloseEXTCombo;

        protected override void OnDoubleClick(EventArgs e)
        {
            CloseEXTCombo();
            base.OnDoubleClick(e);
        }

        #region IEXTCombo Members

        public void SetUserInterface()
        {
            this.BorderStyle = BorderStyle.None;
            this.HideSelection = false;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        public CloseDropDownControlHandler CloseDropDownControlDelegate
        {
            get { return CloseEXTCombo; }
            set { CloseEXTCombo = value; }
        }

        public string DisplayText
        {
            get
            {
                if (this.SelectedNode == null)
                    return string.Empty;
                else
                    return this.SelectedNode.Text;
            }
        }

        public object SelectedValue
        {
            get
            {
                return SelectedNode;
            }
            set
            {
                SelectedNode = (TreeNode)value;
            }
        }

        #endregion
    }
}
