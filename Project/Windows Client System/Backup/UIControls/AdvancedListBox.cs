using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BinarySoftCo.UIControls
{
    public class AdvancedListBoxItem
    {
        private object item;
        private Image image;
        private Size imageScaleSize;

        public object Item
        {
            get { return item; }
            set { item = value; }
        }

        public Image Image
        {
            get { return image; }
            set
            {
                image = new Bitmap(imageScaleSize.Width, imageScaleSize.Height);
                //
                Graphics.FromImage(image).DrawImage(value,
                    new Rectangle(new Point(), imageScaleSize));
            }
        }

        public Size ImageScaleSize
        {
            get { return imageScaleSize; }
            set { imageScaleSize = value; }
        }

        public AdvancedListBoxItem()
        {
        }

        public AdvancedListBoxItem(object Item)
            : this()
        {
            item = Item;
        }

        public AdvancedListBoxItem(object Item, Image Image)
            : this(Item)
        {
            image = Image;
        }

        public AdvancedListBoxItem(object Item, Image Image, Size ImageScaledSize)
            : this(Item, Image)
        {
            imageScaleSize = ImageScaledSize;
            //
            image = new Bitmap(imageScaleSize.Width, imageScaleSize.Height);
            //
            Graphics.FromImage(image).DrawImage(Image,
                new Rectangle(new Point(), imageScaleSize));
        }

        public override string ToString()
        {
            return item != null ? item.ToString() : "";
        }
    }

    public class AdvancedListBox : ListBox
    {
        public AdvancedListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            //
            AdvancedListBoxItem item;
            Rectangle bounds = e.Bounds;
            //
            if (Items.Count > 0 && e.Index > -1)
            {
                try
                {
                    item = (AdvancedListBoxItem)Items[e.Index];
                }
                catch
                {
                    item = new AdvancedListBoxItem(Items[e.Index]);
                }
                //
                Point loc = new Point(bounds.Left, bounds.Top);
                //
                if (item.Image != null)
                {
                    e.Graphics.DrawImage(item.Image, loc);
                    loc.X += item.Image.Width;
                }
                if (item.Item != null)
                {
                    e.Graphics.DrawString(item.ToString(), e.Font,
                        new SolidBrush(e.ForeColor), loc);
                }
            }
            //
            base.OnDrawItem(e);
        }
    }
}
