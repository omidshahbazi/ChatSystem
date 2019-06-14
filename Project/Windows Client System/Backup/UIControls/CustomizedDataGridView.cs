using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public class CustomizedDataGridView : DataGridView
    {
        Color oddRowsBackColor = Color.White, 
            evenRowsBackColor = Color.LightBlue;

        private void ResetRowsDefaultCellStyle()
        {
            for (int i = 0; i < RowCount; i++)
                if (i % 2 == 0)
                    Rows[i].DefaultCellStyle.BackColor = evenRowsBackColor;
                else
                    Rows[i].DefaultCellStyle.BackColor = oddRowsBackColor;
        }

        public Color OddRowsBackColor
        {
            get { return oddRowsBackColor; }
            set 
            {
                oddRowsBackColor = value;
                //
                ResetRowsDefaultCellStyle();
            }
        }

        public Color EvenRowsBackColor
        {
            get { return evenRowsBackColor; }
            set
            {
                evenRowsBackColor = value;
                //
                ResetRowsDefaultCellStyle();
            }
        }

        public CustomizedDataGridView()
        {
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            //
            if (e.RowIndex % 2 == 0)
                Rows[e.RowIndex].DefaultCellStyle.BackColor = evenRowsBackColor;
            else
                Rows[e.RowIndex].DefaultCellStyle.BackColor = oddRowsBackColor;
        }
    }
}
