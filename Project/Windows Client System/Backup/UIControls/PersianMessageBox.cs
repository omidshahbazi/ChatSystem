using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public static class PersianMessageBox
    {
        private delegate int CallBack_WinProc(int uMsg, int wParam, int lParam);
        private delegate int CallBack_EnumWinProc(int hWnd, int lParam);

        #region Extenal Methods
        //
        [DllImport("user32.dll")]
        static extern int GetWindowLong(int hwnd, int nIndex);

        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        static extern int SetWindowsHookEx(int idHook, CallBack_WinProc lpfn, int hmod, int dwThreadId);

        [DllImport("user32.dll")]
        static extern int UnhookWindowsHookEx(int hHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SetWindowText(int hwnd, string lpString);

        [DllImport("user32.dll")]
        static extern int EnumChildWindows(int hWndParent, CallBack_EnumWinProc lpEnumFunc, int lParam);

        [DllImport("user32.dll")]
        static extern int GetClassName(int hwnd, StringBuilder lpClassName, int nMaxCount);
        //
        #endregion

        #region Variables
        //
        static int TopCount;
        static int ButtonCount;

        static MessageBoxButtons buttons;

        private const int GWL_HINSTANCE = (-6);
        private const int HCBT_ACTIVATE = 5;
        private const int WH_CBT = 5;

        private static int hHook;
        //
        #endregion

        #region Private Mathods
        //
        private static int WinProc(int uMsg, int wParam, int lParam)
        {
            CallBack_EnumWinProc myEnumProc = new CallBack_EnumWinProc(EnumWinProc);
            //
            if (uMsg == HCBT_ACTIVATE)
            {
                EnumChildWindows(wParam, myEnumProc, 0);
                UnhookWindowsHookEx(hHook);
            }
            //
            return 0;
        }

        private static int EnumWinProc(int hWnd, int lParam)
        {
            StringBuilder strBuffer = new StringBuilder(256);
            //
            TopCount += 1;
            //
            GetClassName(hWnd, strBuffer, strBuffer.Capacity);
            string ss = strBuffer.ToString();
            //
            if (ss.ToUpper().StartsWith("BUTTON"))
            {
                ButtonCount += 1;
                //
                SetWindowTextInternal(hWnd, ButtonCount);
            }
            //
            return 1;
        }

        private static void SetWindowTextInternal(int hWnd, int buttonIndex)
        {
            string st = "";
            //
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    //
                    if (buttonIndex == 1)
                        st = "انصراف";
                    else if (buttonIndex == 2)
                        st = "تلاش مجدد";
                    else if (buttonIndex == 3)
                        st = "ادامه";
                    //
                    break;

                case MessageBoxButtons.OK:
                    //
                    st = "تائید";
                    //
                    break;

                case MessageBoxButtons.OKCancel:
                    //
                    if (buttonIndex == 1)
                        st = "تائید";
                    else if (buttonIndex == 2)
                        st = "انصراف";
                    //
                    break;

                case MessageBoxButtons.RetryCancel:
                    //
                    if (buttonIndex == 1)
                        st = "تلاش مجدد";
                    else if (buttonIndex == 2)
                        st = "انصراف";
                    //
                    break;

                case MessageBoxButtons.YesNo:
                    //
                    if (buttonIndex == 1)
                        st = "تائید";
                    else if (buttonIndex == 2)
                        st = "خیر";
                    //
                    break;

                case MessageBoxButtons.YesNoCancel:
                    //
                    if (buttonIndex == 1)
                        st = "تائید";
                    else if (buttonIndex == 2)
                        st = "خیر";
                    else if (buttonIndex == 3)
                        st = "انصراف";
                    //
                    break;
            }
            //
            SetWindowText(hWnd, st);
        }
        //
        #endregion

        public static DialogResult Show(string Text)
        {
            return Show(Text, null, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string Text, string Caption)
        {
            return Show(Text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string Text, string Caption, MessageBoxIcon Icon)
        {
            return Show(Text, Caption, MessageBoxButtons.OK, Icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string Text, string Caption, MessageBoxButtons Buttons)
        {
            return Show(Text, Caption, Buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string Text, string Caption, MessageBoxButtons Buttons, MessageBoxDefaultButton DefaultButton)
        {
            return Show(Text, Caption, Buttons, MessageBoxIcon.Information, DefaultButton);
        }

        public static DialogResult Show(string Text, string Caption, MessageBoxButtons Buttons, MessageBoxIcon Icon)
        {
            return Show(Text, Caption, Buttons, Icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string Text, string Caption, MessageBoxButtons Buttons, MessageBoxIcon Icon, MessageBoxDefaultButton DefaultButton)
        {
            int hInst;
            int Thread;
            //
            TopCount = 0;
            ButtonCount = 0;
            //
            buttons = Buttons;
            //
            if (string.IsNullOrEmpty(Caption))
                Caption = Application.ProductName;
            //
            CallBack_WinProc myWndProc = new CallBack_WinProc(WinProc);
            //
            hInst = GetWindowLong(0, GWL_HINSTANCE);
            Thread = GetCurrentThreadId();
            hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread);
            //
            return MessageBox.Show(
                BinarySoftCo.Tools.General.NumberConvertor.EnglishToPersian(Text), 
                BinarySoftCo.Tools.General.NumberConvertor.EnglishToPersian(Caption), 
                buttons, Icon, DefaultButton, MessageBoxOptions.RightAlign);
        }
    }
}
