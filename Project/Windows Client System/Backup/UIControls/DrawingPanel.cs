using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public class DrawingPanel : Panel
    { 
        bool inDrawing = false;
        Point lastPoint = new Point();
        Graphics graph;
        MouseButtons drawingWithButton = MouseButtons.None;

        public bool InDrawing
        {
            get { return inDrawing; }
        }

        public MouseButtons DrawingWithButton
        {
            get { return drawingWithButton; }
            set { drawingWithButton = value; }
        }

        public void Clear()
        {
            graph.Clear(BackColor);
        }

        public DrawingPanel()
            : base()
        {
            BackColor = Color.White;
            //
            OnSizeChanged(null);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //
            graph = CreateGraphics();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            inDrawing = true;
            //
            lastPoint = e.Location;
            //
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!(drawingWithButton != MouseButtons.None && e.Button != drawingWithButton))
                if (graph != null && inDrawing)
                {
                    graph.DrawLine(Pens.Black, lastPoint, e.Location);
                    //
                    lastPoint = e.Location;
                }
            //
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            inDrawing = false;
            //
            base.OnMouseUp(e);
        }
    }
}
