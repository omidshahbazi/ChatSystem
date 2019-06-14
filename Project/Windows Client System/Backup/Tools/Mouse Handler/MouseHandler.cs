using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace BinarySoftCo.Tools.Handler
{
    public static class MouseHandler
    {
        public enum MouseButtons
        {
            Left,
            Right,
            Middle
        }

        enum MouseEventFlags
        {
            Absolute = 0x00008000,
            Move = 0x00000001,
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        #region Import Parameters
        //
        // Get a handle to an application window.
        [DllImport("user32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //
        // Activate an application window.
        [DllImport("user32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        //
        // Handling the mouse device.
        [DllImport("user32.dll")]
        public static extern void mouse_event(int Button, int PointX, int PointY, int cButtons, int dwExtraInfo);
        //
        // Set the location of cursor.
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        //
        #endregion

        public static void SetMousePosition(int X, int Y)
        {
            SetMousePosition(new Point(X, Y));
        }

        public static void SetMousePosition(Point Position)
        {
            SetCursorPos(Position.X, Position.Y);
        }

        public static void MouseClick(int X, int Y, MouseButtons Button)
        {
            MouseClick(new Point(X, Y), Button);
        }

        public static void MouseClick(Point Position, MouseButtons Button)
        {
            MouseDown(Position, Button);
            //
            MouseUp(Position, Button);
        }

        public static void MouseClick(MouseButtons Button)
        {
            MouseDown(Button);
            //
            MouseUp(Button);
        }

        public static void MouseDown(int X, int Y, MouseButtons Button)
        {
            MouseDown(new Point(X, Y), Button);
        }

        public static void MouseDown(Point Position, MouseButtons Button)
        {
            SetMousePosition(Position);
            //
            MouseDown(Button);
        }

        public static void MouseDown(MouseButtons Button)
        {
            switch (Button)
            {
                case MouseButtons.Left:
                    mouse_event((int)MouseEventFlags.LeftDown, 0, 0, 0, 0);
                    break;

                case MouseButtons.Middle:
                    mouse_event((int)MouseEventFlags.MiddleDown, 0, 0, 0, 0);
                    break;

                case MouseButtons.Right:
                    mouse_event((int)MouseEventFlags.RightDown, 0, 0, 0, 0);
                    break;
            }
        }

        public static void MouseUp(int X, int Y, MouseButtons Button)
        {
            MouseUp(new Point(X, Y), Button);
        }

        public static void MouseUp(Point Position, MouseButtons Button)
        {
            SetMousePosition(Position);
            //
            MouseUp(Button);
        }

        public static void MouseUp(MouseButtons Button)
        {
            switch (Button)
            {
                case MouseButtons.Left:
                    mouse_event((int)MouseEventFlags.LeftUp, 0, 0, 0, 0);
                    break;

                case MouseButtons.Middle:
                    mouse_event((int)MouseEventFlags.MiddleUp, 0, 0, 0, 0);
                    break;

                case MouseButtons.Right:
                    mouse_event((int)MouseEventFlags.RightUp, 0, 0, 0, 0);
                    break;
            }
        }
    }
}
