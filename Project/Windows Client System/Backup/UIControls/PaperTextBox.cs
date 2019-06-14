using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public class PaperTextBox : Panel
    {
        PersianTextBox textBox;

        public PaperTextBox()
            : base()
        {
            textBox = new PersianTextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Top;
            //
            Size = new Size(120, 200);
            //
            Controls.Add(textBox);
        }

        protected override void OnPrint(PaintEventArgs e)
        {
            base.OnPrint(e);
            //
            //using (Graphics g = e.Graphics)
            //{
            //    int height = (int)g.MeasureString("O", textBox.Font).Height;
            //    //
            //    while (height < Height)
            //    {
            //        g.DrawLine(Pens.Black, new Point(Left, height), new Point(Right, height));
            //        //
            //        height += height;
            //    }
            //}
            ////
            //textBox.SendToBack();
        }
    }
}
