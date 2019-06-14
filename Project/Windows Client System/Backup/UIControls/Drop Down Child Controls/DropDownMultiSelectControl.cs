using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public partial class DropDownMultiSelectControl : ListBox, IDropDownControl
    {
        public DropDownMultiSelectControl()
        {
            InitializeComponent();
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
                string roRetVal = string.Empty;
                if (this.SelectedItems.Count > 0)
                {
                    foreach (object selItems in this.SelectedItems )
                        roRetVal = string.Concat( roRetVal , selItems.ToString() ,"--");

                    roRetVal = roRetVal.Substring(0,roRetVal.Length-2);
                }
                return roRetVal;
            }
        }

        #endregion
    }
}
