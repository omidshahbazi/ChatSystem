using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace BinarySoftCo.UIControls
{
    [DefaultEvent("MouseClick")]
    public class ActiveLinkLabel : LinkLabel
    {
        Color linkColor_t, activeColor;

        public Color ActiveColor
        {
            get { return activeColor; }
            set { activeColor = value; }
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
        public ActiveLinkLabel()
            : base()
        {
            //if (!License.validLicense)
            //    Dispose();
            //
            LinkBehavior = LinkBehavior.NeverUnderline;
            activeColor = Color.Yellow;
        }

        protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
        {
            base.OnLinkClicked(e);
            //
            //base.OnMouseClick(new MouseEventArgs(e.Button, 0, 0, 0, 0));
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            //
            linkColor_t = LinkColor;
            //
            LinkColor = activeColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //
            LinkColor = linkColor_t;
        }
    }
}
