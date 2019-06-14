using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public class GraphicalButton : Panel
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
        public event EventHandler Clicked;

        #region Variables
        //
        bool isMouseIn = false;

        Image defaultImage,
            mouseOverImage,
            mouseDownImage;
        //
        #endregion
        //
        #region Properties
        //
        public Image DefaultImage
        {
            get { return defaultImage; }
            set
            {
                defaultImage = BackgroundImage = value;
            }
        }

        public Image MouseOverImage
        {
            get { return mouseOverImage; }
            set
            {
                mouseOverImage = value;
            }
        }

        public Image MouseDownImage
        {
            get { return mouseDownImage; }
            set
            {
                BackgroundImage = value;
                mouseDownImage = value;
            }
        }
        //
        #endregion
        //
        public GraphicalButton()
        {
            //if (!License.validLicense)
            //    Dispose();
            //
            Size = new Size();
        }

        public GraphicalButton(Image DefaultImage, Image MouseOverImage, Image MouseDownImage)
            : this()
        {
            //if (MouseOverImage.Width <= MouseDownImage.Width)
            //{
            //    Size = MouseOverImage.Size;
            //    if (MouseOverImage.Width >= MouseUpImage.Width) Size = MouseUpImage.Size;
            //}
            //else
            //{
            //    Size = MouseDownImage.Size;
            //    if (MouseDownImage.Width >= MouseUpImage.Width) Size = MouseUpImage.Size;
            //}
            defaultImage = DefaultImage;
            BackgroundImage = DefaultImage;
            Size = DefaultImage.Size;
            //
            this.MouseOverImage = MouseOverImage;
            this.MouseDownImage = MouseDownImage;
        }

        public GraphicalButton(Image DefaultImage, Image MouseOverImage, Image MouseDownImage, Size Size)
            : this(DefaultImage, MouseOverImage, MouseDownImage)
        {
            this.Size = Size;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (isMouseIn)
            {
                BackgroundImage = defaultImage;
                isMouseIn = !isMouseIn;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (!isMouseIn)
            {
                BackgroundImage = mouseOverImage;
                isMouseIn = !isMouseIn;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            BackgroundImage = mouseDownImage;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            BackgroundImage = mouseOverImage;
        }

        protected override void OnClick(EventArgs e)
        {
            if (Clicked != null)
                Clicked(this, e);
        }
    }
}