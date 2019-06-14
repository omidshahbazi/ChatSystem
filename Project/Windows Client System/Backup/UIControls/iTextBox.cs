using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public class iTextbox : PersianTextBox
    {
        Color ForeColor_t, titleColor = Color.DarkGray;
        string title = "";
        //
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                SetTitleText();
            }
        }

        public Color TitleColor
        {
            get { return titleColor; }
            set { titleColor = value; }
        }
        //
        public iTextbox()
            : base()
        {
            Title = "";
        }

        public iTextbox(string Title)
            : this()
        {
            this.Title = Title;
        }
        //
        void SetTitleText()
        {
            ForeColor_t = ForeColor;
            //
            ForeColor = TitleColor;
            Text = title;
        }

        void SetNullText()
        {
            ForeColor = ForeColor_t;
            ResetText();
        }
        //
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (Text == title) SetNullText();
            else if ((e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete) && TextLength == 1) SetTitleText();
        }
    }
}