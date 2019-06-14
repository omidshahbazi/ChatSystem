using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using BinarySoftCo.Tools.General;

namespace BinarySoftCo.UIControls
{
    public class PersianComboBox : ComboBox
    {
        public class License
        {
            internal static bool validLicense = false;
            //
            public static string AboutLicense
            {
                set { validLicense = (value == BinarySoftCo.Security.RelationKey.NewKey); }
            }
        }
        //
        List<object> items;
        bool filterMode = true,
            temp = false,
            required = false;

        public bool FilterMode
        {
            get { return filterMode; }
            set { filterMode = value; }
        }

        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

        public bool Validate
        {
            get
            {
                if (required)
                    if (SelectedIndex > -1)
                        BackColor = Color.White;
                    else
                        BackColor = Color.Red;
                //
                return (BackColor == Color.White);
            }
        }

        public PersianComboBox()
        {
            //if (!License.validLicense)
            //    Dispose();
        }
        //
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = !filterMode;
            //
            temp = true;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (temp && DropDownStyle != ComboBoxStyle.DropDownList && filterMode)
            {
                if (items == null || items.Count == 0)
                {
                    items = new List<object>();
                    //
                    foreach (object o in Items)
                        items.Add(o);
                }
                //
                Items.Clear();
                //
                foreach (object o in items)
                    if (o.ToString().Contains(Text))
                        Items.Add(o);
                //
                DroppedDown = true;
                //
                if (Text.Length > 0)
                    SelectionStart = Text.Length;
                //
                temp = false;
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            //
            OnLeave(null);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            //
            Validate.ToString();
        }

        public string Text
        {
            get { return NumberConvertor.PersianToEnglish(base.Text); }
            set { base.Text = NumberConvertor.EnglishToPersian(value); }
        }
    }
}
