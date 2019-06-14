using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace BinarySoftCo.UIControls
{
    public partial class IPTextBox : UserControl
    {
        new public string Text
        {
            get
            {
                if (tbPart1.TextLength > 0 &&
                    tbPart2.TextLength > 0 &&
                    tbPart3.TextLength > 0 &&
                    tbPart4.TextLength > 0)
                    return tbPart1.Text + "." + tbPart2.Text + "." + tbPart3.Text + "." + tbPart4.Text;
                else
                    return IPAddress.None.ToString();
            }
            set
            {
                string[] parts = value.Split('.');
                //
                if (parts.Length == 4)
                {
                    foreach(string st in parts)
                        try { int.Parse(st); }
                        catch
                        {
                            return;
                        }
                    //
                    tbPart1.Text = parts[0];
                    tbPart2.Text = parts[1];
                    tbPart3.Text = parts[2];
                    tbPart4.Text = parts[3];
                }
            }
        }

        public IPAddress IP
        {
            get { return IPAddress.Parse(Text); }
            set { Text = value.ToString(); }
        }

        public IPTextBox()
        {
            InitializeComponent();
            //
            tbPart1.ResetText();
            tbPart2.ResetText();
            tbPart3.ResetText();
            tbPart4.ResetText();
        }

        private void IPTextBox_Load(object sender, EventArgs e)
        {

        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, 133, 22, specified);
        }
    }

    class IPTextBoxBase : TextBox
    {
        public IPTextBoxBase()
            : base()
        {
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            //
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
                if (e.KeyChar == (char)Keys.Space || e.KeyChar == '.')
                {
                    SendKeys.Send("{TAB}");
                    //
                    return;
                }
                else if (TextLength == 3)
                {
                    SendKeys.Send("{TAB}");
                    //
                    SendKeys.Send("{" + e.KeyChar + "}");
                    //
                    return;
                }
            //
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (TextLength > 0)
            {
                int x = int.Parse(Text);
                //
                if (x == 0 || x > 255)
                    ResetText();
            }
        }
    }
}
