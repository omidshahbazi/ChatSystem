using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public enum LinkType
    {
        Email,
        WebSite
    }

    public class LinkTextBox : RequiredTextBox
    {
        public event EventHandler LinkClicked;

        Color linkColor, activeColor, activeLinkColor;
        LinkType linkType;

        public Color LinkColor
        {
            get { return linkColor; }
            set
            {
                linkColor = ForeColor = value;
            }
        }

        public Color ActiveColor
        {
            get { return activeColor; }
            set { activeColor = value; }
        }

        public Color ActiveLinkColor
        {
            get { return activeLinkColor; }
            set { activeLinkColor = value; }
        }

        public LinkType LinkType
        {
            get { return linkType; }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            linkType = (Text.Contains("@") ? LinkType.Email : LinkType.WebSite);
        }

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
        public LinkTextBox()
            : base()
        {
            //if (!License.validLicense)
            //    Dispose();
            //
            LinkColor = Color.Blue;
            activeColor = Color.Red;
            activeLinkColor = Color.Yellow;
            // 
            Cursor = Cursors.Hand;
            //
            Font = new Font(Font.FontFamily, Font.Size, FontStyle.Underline);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            //
            ForeColor = activeColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //
            ForeColor = linkColor;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e); 
            //
            ForeColor = activeLinkColor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            //
            ForeColor = activeColor;
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            //
            if (LinkClicked != null) LinkClicked(this, new EventArgs());
            //
            System.Diagnostics.Process.Start(
                (linkType == LinkType.Email ?
                "mailto:" + Text :
                (!Text.ToLower().StartsWith("http://") && !Text.ToLower().StartsWith("www.") ?
                "http://" + Text :
                Text)));
        }
    }
}
