using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public class PersianNumericTextBox : PersianTextBox
    {
        bool canInsertDOT = true, thousandSeperator = false;
        double maximumValue = 100.0d;

        public bool CanInsertDOT
        {
            get { return canInsertDOT; }
            set { canInsertDOT = value; }
        }

        public bool ThousandSeperator
        {
            get { return thousandSeperator; }
            set { thousandSeperator = value; }
        }

        public double Value
        {
            get 
            {
                if (string.IsNullOrEmpty(Text))
                    return 0.0d;
                else
                    try
                    {
                        return double.Parse(Text);
                    }
                    catch
                    {
                        return 0;
                    }
            }
            set
            {
                Text = value.ToString();
                //
                if (value > maximumValue)
                    Text = maximumValue.ToString();
            }
        }

        //new public string Text
        //{
        //    get { return base.Text; }
        //    set
        //    {
        //        base.Text = value;
        //        //
        //        for (int i = TextLength - 1; i >= 0; i--)
        //        {
        //            MessageBox.Show(TextLength.ToString());

        //            Text.Insert(i, ",");
        //        }
        //    }
        //}

        public double MaximumValue
        {
            get { return maximumValue; }
            set
            {
                maximumValue = value;
                //
                if (Value > maximumValue)
                    Value = maximumValue;
            }
        }

        public PersianNumericTextBox()
            : base()
        {
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            //
            e.Handled = !((char.IsNumber(e.KeyChar) && (!canInsertDOT ? e.KeyChar != '.' : true))
                || e.KeyChar == (char)Keys.Back);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            //
            MaximumValue = maximumValue;
        }
    }
}
