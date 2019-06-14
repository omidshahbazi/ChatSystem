using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public class PersianMaskedTextBox : PersianTextBox
    {
        private string mask;

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
        public PersianMaskedTextBox()
            : base()
        {
            //if (!License.validLicense)
            //    Dispose();
        }
        //
        public string Mask
        {
            get { return mask; }
            set
            {
                mask = value;
                MaxLength = mask.Length;
                //
                ResetText();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || 
                e.KeyChar == (char)Keys.Delete)
            {

            }
            else if (mask != "")
            {
                // Suppress the typed character.
                e.Handled = true;

                string newText = Text;

                if (SelectionLength > 0)
                    newText = newText.Remove(SelectionStart, SelectionLength);

                // Loop through the mask, adding fixed characters as needed.
                // If the next allowed character matches what the user has
                // typed in (a number or letter), that is added to the end.
                //
                for (int i = SelectionStart; i < MaxLength; i++)
                {
                    if (mask[i].ToString() == "#")
                    {
                        // Allow the keypress as long as it is a number.
                        if (Char.IsDigit(e.KeyChar))
                        {
                            //newText += e.KeyChar.ToString();
                            newText = newText.Insert(i, e.KeyChar.ToString());
                            //
                            break;
                        }
                        else
                            return;
                    }
                    else if (mask[i].ToString() == ".")
                    {
                        // Allow the keypress as long as it is a letter.
                        if (Char.IsLetter(e.KeyChar))
                        {
                            //newText += e.KeyChar.ToString();
                            newText = newText.Insert(i, e.KeyChar.ToString());
                            //
                            break;
                        }
                        else
                        {
                            // Invalid entry; exit and don't change the text.
                            return;
                        }
                    }
                    else
                    {
                        // Insert the mask character.
                        newText += mask[i];
                        //break;
                    }
                }
                //
                int selectionStart = TextLength;
                //
                if (SelectionLength > 0)
                    selectionStart = SelectionStart;
                //
                // Update the text.
                Text = newText;
                //
                SelectionStart = selectionStart + 2;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //e.Handled = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            e.Handled = !(e.KeyCode == Keys.Left);
        }
    }
}
