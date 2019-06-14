using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public class RequiredTextBox : TextBox
    {
        bool required = false;

        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

        public bool Validate
        {
            get
            {
                OnLeave(null);
                return (Text.Trim().Length > 0);
            }
        }

        public RequiredTextBox()
            : base()
        {

        }

        protected override void InitLayout()
        {
            base.InitLayout();
            //
            if (required)
                BackColor = Color.White;
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            //
            if (required)
                BackColor = Color.White;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            //
            if (required)
                if (Text.Trim().Length == 0)
                    BackColor = Color.Red;
                else
                    BackColor = Color.White;
        }
    }
}
