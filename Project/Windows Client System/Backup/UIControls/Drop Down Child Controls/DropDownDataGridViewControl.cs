using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public partial class DropDownDataGridViewControl : CustomizedDataGridView, IDropDownControl
    {
        public DropDownDataGridViewControl()
        {
            InitializeComponent();
        }

        public DropDownDataGridViewControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private CloseDropDownControlHandler CloseEXTCombo;
        protected override void OnDoubleClick(EventArgs e)
        {
            CloseEXTCombo();
            base.OnDoubleClick(e);
        }

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
                if (this.CurrentRow == null)
                    return string.Empty;
                else
                    return this.CurrentRow.Cells[0].Value.ToString() + " | " + this.CurrentRow.Cells[1].Value.ToString();
            }
        }


        public object SelectedValue
        {
            get 
            {
                return CurrentRow;
            }
            set
            {
                CurrentCell = this[0, (int)value];
            }
        }
    }
}
