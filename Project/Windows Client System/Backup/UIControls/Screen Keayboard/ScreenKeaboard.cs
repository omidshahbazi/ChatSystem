using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    [DefaultEvent("UserKeyPressed")]
    public partial class ScreenKeaboard : UserControl
    {
        private bool shiftIndicator = false;
        private bool capsLockIndicator = false;
        private bool altORShiftIsDown = false;
        private bool canChangeLanguage = true;
        private KeyboardLayout keyboardLayout = KeyboardLayout.English;
        //
        public static Size BaseSize = new Size(819, 282);
        //
        [Category("Mouse"), Description("Return value of mouseclicked key")]
        public event KeyboardEventHandler UserKeyPressed;

        protected virtual void OnUserKeyPressed(KeyboardEventArgs e)
        {
            if (UserKeyPressed != null)
                UserKeyPressed(this, e);
        }
        //
        private string HandleTheMouseClick(Single x, Single y)
        {
            string KeyPressed = null;
            //
            if (x >= 4 && x < 815 && y >= 3 && y < 277) //  keyboard section
            {
                if (y < 58)
                {
                    if (x >= 4 && x < 59)
                    {
                        switch (keyboardLayout)
                        {
                            case KeyboardLayout.English: KeyPressed = HandleShiftableKey("`"); break;

                            case KeyboardLayout.Farsi: KeyPressed = HandleShiftableKey("ژ"); break;
                        }
                    }
                    else if (x >= 67 && x < 112) KeyPressed = HandleShiftableKey("1");
                    else if (x >= 112 && x < 165) KeyPressed = HandleShiftableKey("2");
                    else if (x >= 165 && x < 220) KeyPressed = HandleShiftableKey("3");
                    else if (x >= 220 && x < 275) KeyPressed = HandleShiftableKey("4");
                    else if (x >= 275 && x < 328) KeyPressed = HandleShiftableKey("5");
                    else if (x >= 328 && x < 380) KeyPressed = HandleShiftableKey("6");
                    else if (x >= 380 && x < 435) KeyPressed = HandleShiftableKey("7");
                    else if (x >= 435 && x < 490) KeyPressed = HandleShiftableKey("8");
                    else if (x >= 490 && x < 545) KeyPressed = HandleShiftableKey("9");
                    else if (x >= 545 && x < 600) KeyPressed = HandleShiftableKey("0");
                    else if (x >= 600 && x < 655) KeyPressed = HandleShiftableKey("-");
                    else if (x >= 655 && x < 705) KeyPressed = HandleShiftableKey("=");
                    else if (x >= 705 && x < 815) KeyPressed = "{BACKSPACE}";
                    else KeyPressed = null;
                }
                else if (y >= 58 && y < 114)
                {
                    switch (keyboardLayout)
                    {
                        case KeyboardLayout.English:
                            //
                            if (x >= 85 && x < 140) KeyPressed = HandleShiftableCapslockableKey("q");
                            else if (x >= 140 && x < 193) KeyPressed = HandleShiftableCapslockableKey("w");
                            else if (x >= 193 && x < 247) KeyPressed = HandleShiftableCapslockableKey("e");
                            else if (x >= 247 && x < 300) KeyPressed = HandleShiftableCapslockableKey("r");
                            else if (x >= 300 && x < 355) KeyPressed = HandleShiftableCapslockableKey("t");
                            else if (x >= 355 && x < 409) KeyPressed = HandleShiftableCapslockableKey("y");
                            else if (x >= 409 && x < 463) KeyPressed = HandleShiftableCapslockableKey("u");
                            else if (x >= 463 && x < 517) KeyPressed = HandleShiftableCapslockableKey("i");
                            else if (x >= 517 && x < 571) KeyPressed = HandleShiftableCapslockableKey("o");
                            else if (x >= 571 && x < 625) KeyPressed = HandleShiftableCapslockableKey("p");
                            else if (x >= 625 && x < 680) KeyPressed = HandleShiftableKey("{[}");
                            else if (x >= 680 && x < 733) KeyPressed = HandleShiftableKey("{]}");
                            else if (x >= 733 && x < 815) KeyPressed = HandleShiftableKey("\\");
                            else KeyPressed = null;
                            //
                            break;

                        case KeyboardLayout.Farsi:
                            //
                            if (x >= 85 && x < 140) KeyPressed = HandleShiftableCapslockableKey("ض");
                            else if (x >= 140 && x < 193) KeyPressed = HandleShiftableCapslockableKey("ص");
                            else if (x >= 193 && x < 247) KeyPressed = HandleShiftableCapslockableKey("ث");
                            else if (x >= 247 && x < 300) KeyPressed = HandleShiftableCapslockableKey("ق");
                            else if (x >= 300 && x < 355) KeyPressed = HandleShiftableCapslockableKey("ف");
                            else if (x >= 355 && x < 409) KeyPressed = HandleShiftableCapslockableKey("غ");
                            else if (x >= 409 && x < 463) KeyPressed = HandleShiftableCapslockableKey("ع");
                            else if (x >= 463 && x < 517) KeyPressed = HandleShiftableCapslockableKey("ه");
                            else if (x >= 517 && x < 571) KeyPressed = HandleShiftableCapslockableKey("خ");
                            else if (x >= 571 && x < 625) KeyPressed = HandleShiftableCapslockableKey("ح");
                            else if (x >= 625 && x < 680) KeyPressed = HandleShiftableCapslockableKey("ج");
                            else if (x >= 680 && x < 733) KeyPressed = HandleShiftableCapslockableKey("چ");
                            else if (x >= 733 && x < 839) KeyPressed = HandleShiftableCapslockableKey("پ");
                            else KeyPressed = null;
                            //
                            break;
                    }
                }
                else if (y >= 114 && y < 168)
                {
                    switch (keyboardLayout)
                    {
                        case KeyboardLayout.English:
                            //
                            if (x >= 4 && x < 113) HandleCapsLock();
                            if (x >= 113 && x < 167) KeyPressed = HandleShiftableCapslockableKey("a");
                            else if (x >= 167 && x < 221) KeyPressed = HandleShiftableCapslockableKey("s");
                            else if (x >= 221 && x < 275) KeyPressed = HandleShiftableCapslockableKey("d");
                            else if (x >= 275 && x < 330) KeyPressed = HandleShiftableCapslockableKey("f");
                            else if (x >= 330 && x < 383) KeyPressed = HandleShiftableCapslockableKey("g");
                            else if (x >= 383 && x < 437) KeyPressed = HandleShiftableCapslockableKey("h");
                            else if (x >= 437 && x < 491) KeyPressed = HandleShiftableCapslockableKey("j");
                            else if (x >= 491 && x < 545) KeyPressed = HandleShiftableCapslockableKey("k");
                            else if (x >= 545 && x < 599) KeyPressed = HandleShiftableCapslockableKey("l");
                            else if (x >= 599 && x < 653) KeyPressed = HandleShiftableKey(";");
                            else if (x >= 653 && x < 706) KeyPressed = HandleShiftableKey("'");
                            else if (x >= 706 && x < 815) KeyPressed = "{ENTER}";
                            else KeyPressed = null;
                            //
                            break;

                        case KeyboardLayout.Farsi:
                            //
                            if (x >= 4 && x < 113) HandleCapsLock();
                            if (x >= 113 && x < 167) KeyPressed = HandleShiftableCapslockableKey("ش");
                            else if (x >= 167 && x < 221) KeyPressed = HandleShiftableCapslockableKey("س");
                            else if (x >= 221 && x < 275) KeyPressed = HandleShiftableCapslockableKey("ی");
                            else if (x >= 275 && x < 330) KeyPressed = HandleShiftableCapslockableKey("ب");
                            else if (x >= 330 && x < 383) KeyPressed = HandleShiftableCapslockableKey("ل");
                            else if (x >= 383 && x < 437) KeyPressed = HandleShiftableCapslockableKey("ا");
                            else if (x >= 437 && x < 491) KeyPressed = HandleShiftableCapslockableKey("ت");
                            else if (x >= 491 && x < 545) KeyPressed = HandleShiftableCapslockableKey("ن");
                            else if (x >= 545 && x < 599) KeyPressed = HandleShiftableCapslockableKey("م");
                            else if (x >= 599 && x < 653) KeyPressed = HandleShiftableCapslockableKey("ک");
                            else if (x >= 653 && x < 706) KeyPressed = HandleShiftableCapslockableKey("گ");
                            else if (x >= 706 && x < 815) KeyPressed = "{ENTER}";
                            else KeyPressed = null;
                            //
                            break;
                    }
                }
                else if (y >= 168 && y < 221)
                {
                    switch (keyboardLayout)
                    {
                        case KeyboardLayout.English:
                            //
                            if (x >= 4 && x < 140) HandleShiftClick();
                            if (x >= 140 && x < 194) KeyPressed = HandleShiftableCapslockableKey("z");
                            else if (x >= 194 && x < 248) KeyPressed = HandleShiftableCapslockableKey("x");
                            else if (x >= 248 && x < 302) KeyPressed = HandleShiftableCapslockableKey("c");
                            else if (x >= 302 && x < 356) KeyPressed = HandleShiftableCapslockableKey("v");
                            else if (x >= 356 && x < 410) KeyPressed = HandleShiftableCapslockableKey("b");
                            else if (x >= 410 && x < 464) KeyPressed = HandleShiftableCapslockableKey("n");
                            else if (x >= 464 && x < 518) KeyPressed = HandleShiftableCapslockableKey("m");
                            else if (x >= 518 && x < 572) KeyPressed = HandleShiftableKey(",");
                            else if (x >= 572 && x < 626) KeyPressed = HandleShiftableKey(".");
                            else if (x >= 626 && x < 680) KeyPressed = HandleShiftableKey("/");
                            else if (x >= 680 && x < 815) HandleShiftClick();
                            else KeyPressed = null;
                            //
                            break;

                        case KeyboardLayout.Farsi:
                            //
                            if (x >= 4 && x < 140) HandleShiftClick();
                            if (x >= 140 && x < 194) KeyPressed = HandleShiftableCapslockableKey("ظ");
                            else if (x >= 194 && x < 248) KeyPressed = HandleShiftableCapslockableKey("ط");
                            else if (x >= 248 && x < 302) KeyPressed = HandleShiftableCapslockableKey("ز");
                            else if (x >= 302 && x < 356) KeyPressed = HandleShiftableCapslockableKey("ر");
                            else if (x >= 356 && x < 410) KeyPressed = HandleShiftableCapslockableKey("ذ");
                            else if (x >= 410 && x < 464) KeyPressed = HandleShiftableCapslockableKey("د");
                            else if (x >= 464 && x < 518) KeyPressed = HandleShiftableCapslockableKey("ئ");
                            else if (x >= 518 && x < 572) KeyPressed = HandleShiftableCapslockableKey("و");
                            else if (x >= 572 && x < 626) KeyPressed = HandleShiftableKey(".");
                            else if (x >= 626 && x < 680) KeyPressed = HandleShiftableKey("/");
                            else if (x >= 680 && x < 815) HandleShiftClick();
                            else KeyPressed = null;
                            //
                            break;
                    }
                }
                else if (y >= 221 && y < 277)
                {
                    if (x >= 218 && x < 597) KeyPressed = " ";
                    else KeyPressed = null;
                }
            }
            else if (x >= 827 && x < 989 && y >= 27 && y < 193)   //  cursor keys
            {
                if (y < 83)
                {
                    if (x < 880) KeyPressed = "{INSERT}";
                    else if (x >= 880 && x < 934) KeyPressed = "{UP}";
                    else if (x >= 934) KeyPressed = HandleShiftableKey("{HOME}");
                    else KeyPressed = null;
                }
                else if (y >= 83 && y < 137)
                {
                    if (x < 880) KeyPressed = "{LEFT}";
                    else if (x >= 934) KeyPressed = "{RIGHT}";
                    else KeyPressed = null;
                }
                else if (y >= 137)
                {
                    if (x < 880) KeyPressed = "{DELETE}";
                    else if (x >= 880 && x < 934) KeyPressed = "{DOWN}";
                    else if (x >= 934) KeyPressed = HandleShiftableKey("{END}");
                    else KeyPressed = null;
                }
                else KeyPressed = null;
            }
            if (KeyPressed != null)
            {
                if (shiftIndicator) HandleShiftClick();
                //
                return KeyPressed;
            }
            else
                return null;
        }

        private string HandleShiftableKey(string theKey)
        {
            if (shiftIndicator)
            {
                return "+" + theKey;
            }
            else
            {
                return theKey;
            }
        }

        private string HandleShiftableCapslockableKey(string theKey)
        {
            if (capsLockIndicator)
            {
                return "+" + theKey;
            }
            else if (shiftIndicator)
            {
                return "+" + theKey;
            }
            else
            {
                return theKey;
            }
        }

        private void HandleShiftClick()
        {
            if (shiftIndicator)
            {
                shiftIndicator = false;
                pLeftShiftDown.Visible = false;
                pRightShiftDown.Visible = false;
            }
            else
            {
                shiftIndicator = true;
                pLeftShiftDown.Visible = true;
                pRightShiftDown.Visible = true;
            }
        }

        private void HandleCapsLock()
        {
            if (capsLockIndicator)
            {
                capsLockIndicator = false;
                pCapsLockDown.Visible = false;
            }
            else
            {
                capsLockIndicator = true;
                pCapsLockDown.Visible = true;
            }
        }
        //
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        public bool CanChangeLanguage
        {
            get { return canChangeLanguage; }
            set { canChangeLanguage = value; }
        }

        public KeyboardLayout KeyboardLayout
        {
            get { return keyboardLayout; }
            set
            {
                keyboardLayout = value;
                //
                switch (keyboardLayout)
                {
                    case KeyboardLayout.English:
                        //
                        BackgroundImage = Properties.Resources.Keyboard_English;
                        //
                        break;

                    case KeyboardLayout.Farsi:
                        //
                        BackgroundImage = Properties.Resources.Keyboard_Farsi;
                        //
                        break;
                }
            }
        }
        //
        public ScreenKeaboard()
        {
            InitializeComponent();
        }

        private void ScreenKeaboard_Load(object sender, EventArgs e)
        {
            // position the capslock and shift down overlays
            //
            pCapsLockDown.Left = Convert.ToInt16(Width * 5 / BaseSize.Width);
            pCapsLockDown.Top = Convert.ToInt16(Height * 115 / BaseSize.Height);
            pLeftShiftDown.Left = Convert.ToInt16(Width * 5 / BaseSize.Width);
            pLeftShiftDown.Top = Convert.ToInt16(Height * 169 / BaseSize.Height);
            pRightShiftDown.Left = Convert.ToInt16(Width * 681 / BaseSize.Width);
            pRightShiftDown.Top = pLeftShiftDown.Top;


            // size the capslock and shift down overlays

            pCapsLockDown.Width = Convert.ToInt16(Width * 110 / BaseSize.Width);
            pCapsLockDown.Height = Convert.ToInt16(Height * 55 / BaseSize.Height);
            pLeftShiftDown.Width = Convert.ToInt16(Width * 136 / BaseSize.Width);
            pLeftShiftDown.Height = Convert.ToInt16(Height * 55 / BaseSize.Height);
            pRightShiftDown.Width = Convert.ToInt16(Width * 135 / BaseSize.Width);
            pRightShiftDown.Height = pLeftShiftDown.Height;
        }

        private void ScreenKeaboard_MouseClick(object sender, MouseEventArgs e)
        {
            Single xpos = e.X;
            Single ypos = e.Y;

            xpos = BaseSize.Width * (xpos / Width);
            ypos = BaseSize.Height * (ypos / Height);

            string key = HandleTheMouseClick(xpos, ypos);

            if (!string.IsNullOrEmpty(key))
                OnUserKeyPressed(new KeyboardEventArgs(key));
        }

        private void pLeftShiftState_MouseClick(object sender, MouseEventArgs e)
        {
            HandleShiftClick();
        }

        private void pRightShiftState_MouseClick(object sender, MouseEventArgs e)
        {
            HandleShiftClick();
        }

        private void pCapsLockState_MouseClick(object sender, MouseEventArgs e)
        {
            HandleCapsLock();
        }

        private void ScreenKeaboard_KeyDown(object sender, KeyEventArgs e)
        {
            if(canChangeLanguage)
                altORShiftIsDown = e.Alt || e.Shift; ;
        }

        private void ScreenKeaboard_KeyUp(object sender, KeyEventArgs e)
        {
            if (canChangeLanguage)
                if (altORShiftIsDown && (e.Alt || e.Shift))
                {
                    if (keyboardLayout == KeyboardLayout.English)
                        KeyboardLayout = KeyboardLayout.Farsi;
                    else
                        KeyboardLayout = KeyboardLayout.English;
                }
                else if (e.KeyCode == Keys.Escape)
                    ((Form)Parent).Close();
        }
    }

    public enum KeyboardLayout
    {
        English,
        Farsi
    }
}

