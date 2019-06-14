using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace BinarySoftCo.UIControls
{
    [Serializable]
    public partial class DropDownControl : ComboBox
    {
        #region Constants
        
        private const int TEXTBOX_PADDING = 3;
        private const int WM_USER = 0x0400;
        private const int WM_REFLECT = WM_USER + 0x1C00;
        private const int WM_COMMAND = 0x0111;
        private const int WM_CLICK = 513;

        private const int CBN_DROPDOWN = 7;
        private const int CBN_CLOSEUP = 8;

        #endregion

        #region Instance Member

        private ToolStripControlHost moTreeViewHost;
        protected ToolStripDropDown cmbDropDown;
        private PersianTextBox txtTextBox;
        protected IDropDownControl oChildControl;
        protected TreeNode _intiallySelectedNode = null;
        private bool _bOpened = false;

        #endregion

        #region Propeties

        [Browsable(false)]
        public object SelectedObject
        {
            get 
            {
                return oChildControl == null ?
                    "" :
                    oChildControl.SelectedValue;
            }
            set
            {
                if (oChildControl != null)
                    oChildControl.SelectedValue = value;
            }
        }

        [Browsable(false)]
        public string DisplayText
        {
            get
            {
                return oChildControl == null ?
                    "" :
                    oChildControl.DisplayText;
            }
            set
            {
                if (txtTextBox != null)
                    txtTextBox.Text = value;
            }
        }

        #endregion

        #region Constructors

        public DropDownControl()
        { }

        #endregion

        #region Methods

        public void AddControl(IDropDownControl roChildControl)
        {
            try
            {
                oChildControl = roChildControl;
                txtTextBox = new PersianTextBox();
                txtTextBox.RightToLeft = RightToLeft.Yes;
                txtTextBox.TabStop = false;
                txtTextBox.TabIndex = this.TabIndex;
                txtTextBox.KeyDown += new KeyEventHandler(txtTextBox_KeyDown);
                oChildControl.SetUserInterface();
                moTreeViewHost = new ToolStripControlHost((Control)oChildControl);
                CloseDropDownControlHandler oCloseCombo = new CloseDropDownControlHandler(CloseCombo);
                oChildControl.CloseDropDownControlDelegate = oCloseCombo;

                cmbDropDown = new ToolStripDropDown();
                cmbDropDown.Items.Add(moTreeViewHost);
                cmbDropDown.AutoClose = true;

                this.DropDownStyle = ComboBoxStyle.DropDownList;

                txtTextBox.BackColor = BackColor;
                txtTextBox.BorderStyle = BorderStyle.None;
                txtTextBox.ForeColor = ForeColor;
                txtTextBox.Location = new Point(TEXTBOX_PADDING, TEXTBOX_PADDING);
                txtTextBox.Multiline = true;
                txtTextBox.ReadOnly = true;
                txtTextBox.Size = new Size((Size.Width - SystemInformation.VerticalScrollBarWidth - 2 * TEXTBOX_PADDING), Size.Height - 2 * TEXTBOX_PADDING);
                txtTextBox.Text = Text;
                this.txtTextBox.Click += new EventHandler(txtTextBox_Click);
                txtTextBox.Enter += new EventHandler(txtTextBox_Enter);
                this.Controls.Add(txtTextBox);
                cmbDropDown.Closed += new ToolStripDropDownClosedEventHandler(cmbDropDown_Closed);
                this.EnabledChanged += new EventHandler(EXTCombo_EnabledChanged); 
                //
                LoadChildControl();
            }
            catch (Exception roExcep )
            {
                MessageBox.Show(roExcep.Message);
            }
        }

        private void ShowDropDown()
        {
            LoadChildControl();
            _bOpened = true;
        }

        public void LoadChildControl()
        {
            moTreeViewHost.Width = DropDownWidth;
            moTreeViewHost.Height = DropDownHeight;
            ((Control)oChildControl).Width = DropDownWidth;
            cmbDropDown.Show(this, 0, this.Height);
        }

        public void SetControlVisibility(bool rbVisibility)
        {
            this.txtTextBox.Visible = rbVisibility;
            this.Visible = rbVisibility;
        }

        private void CloseCombo()
        {
            cmbDropDown.Close();
        }

        #endregion

        #region Events Handlers

        private void txtTextBox_KeyDown(object roSender, KeyEventArgs roArgs)
        {
            try
            {
                if (roArgs.KeyCode != Keys.Down)
                    return;
                ShowDropDown();
            }
            catch (Exception roExcep)
            {
                MessageBox.Show(roExcep.Message);
            }
        }

        void EXTCombo_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.Enabled)
                    txtTextBox.BackColor = SystemColors.Control;
                else
                    txtTextBox.BackColor = BackColor;
            }
            catch (Exception roExcep)
            {
                MessageBox.Show(roExcep.Message);
            }
        }

        void txtTextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTextBox.Focus();
            }
            catch (Exception roExcep)
            {
                MessageBox.Show(roExcep.Message);
            }
        }

        protected virtual void cmbDropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            try
            {
                this.txtTextBox.Text = oChildControl.DisplayText;
                //
                OnSelectedIndexChanged(new EventArgs());
                OnSelectedItemChanged(new EventArgs());
                OnSelectedValueChanged(new EventArgs());
                OnSelectionChangeCommitted(new EventArgs());
            }
            catch (Exception roExcep)
            {
                MessageBox.Show(roExcep.Message);
            }
        }

        private void txtTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bOpened)
                {
                    _bOpened = false;
                    return;
                }
                ShowDropDown();
            }
            catch (Exception roExcep)
            {
                MessageBox.Show(roExcep.Message);
            }
        }

        #endregion

        #region Windowproc Overrides
        /// <summary>
        /// This will return hi word (highest 16 bits)
        /// </summary>
        public static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }
        /// <summary>
        /// Overrided win proc event handler
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
                {
                    if (!_bOpened)
                        ShowDropDown();

                    return;
                }
            }
            else if (m.Msg == WM_CLICK)
            {
                if (!_bOpened)
                    ShowDropDown();
                else
                    _bOpened = false;

                return;
            }
            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (cmbDropDown != null)
                {
                    cmbDropDown.Dispose();
                    cmbDropDown = null;
                }
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
