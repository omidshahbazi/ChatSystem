using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public class ActiveAnimatedButton : PictureBox
    {
        Image fixedImage, animateImage;

        public Image FixedImage
        {
            get { return fixedImage; }
            set { Image = fixedImage = value; }
        }

        public Image AnimateImage
        {
            get { return animateImage; }
            set { animateImage = value; }
        }

        public ActiveAnimatedButton()
            : base()
        {
            Cursor = Cursors.Hand;
        }

        public ActiveAnimatedButton(Image FixedImage, Image AnimateImage)
            : this()
        {
            Image = fixedImage = FixedImage;
            animateImage = AnimateImage;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            //
            Image = animateImage;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //
            Image = fixedImage;
        }
    }
}