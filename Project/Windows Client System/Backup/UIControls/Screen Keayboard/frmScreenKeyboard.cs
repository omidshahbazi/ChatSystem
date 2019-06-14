using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    partial class frmScreenKeyboard : Form
    {
        public frmScreenKeyboard()
        {
            InitializeComponent();
        }

        private void frmScreenKeyboard_Load(object sender, EventArgs e)
        {

        }
    }

    public class ScreenKeyboardDialog
    {
        public event UIControls.KeyboardEventHandler UserKeyPressed;
        public event FormClosedEventHandler Closed;

        private frmScreenKeyboard frmSK;

        public void Show(int Top)
        {
            Show(Top, KeyboardLayout.English);
        }

        public void Show(int Top, KeyboardLayout Layout)
        {
            frmSK = new frmScreenKeyboard();
            int x = (Screen.PrimaryScreen.Bounds.Width / 2) - (frmSK.Width / 2);
            //
            Show(new Point(x, Top), Layout);
        }

        public void Show(Point Location)
        {
            Show(Location, KeyboardLayout.English);
        }

        public void Show(Point Location, KeyboardLayout Layout)
        {
            frmSK = new frmScreenKeyboard();
            if (Location.X + frmSK.Width > Screen.PrimaryScreen.Bounds.Width)
                Show(Location.Y);
            else
            {
                frmSK.Keaboard.UserKeyPressed += new KeyboardEventHandler(UserKeyPressed);
                frmSK.FormClosed += new FormClosedEventHandler(Closed);
                //
                frmSK.Keaboard.KeyboardLayout = Layout;
                frmSK.Location = Location;
                //
                frmSK.Show();
            }
        }

        public void Close()
        {
            frmSK.Close();
        }
    }
}
