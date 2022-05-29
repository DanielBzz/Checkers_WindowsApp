using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Checkers;

namespace CheckersWindowsUI
{
    public delegate void DoneEventHandler(DoneEventArgs e);

    public partial class FormGameSettings : Form
    {
        eBoardSize m_size;
        public event DoneEventHandler DoneInit;

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.ReadOnly = false;
                textBoxPlayer2.TextAlign = HorizontalAlignment.Left;
                textBoxPlayer2.Text = "";
            }
            else
            {
                textBoxPlayer2.ReadOnly = true;
                textBoxPlayer2.TextAlign = HorizontalAlignment.Center;
                textBoxPlayer2.Text = "[ Computer ]";
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (!(radioButton6x6Size.Checked || radioButton8x8Size.Checked || radioButton10x10Size.Checked))
            {
                // pop up a notice that not valid input
            }
            else if (textBoxPlayer1.Text == "")
            {
                // pop up notice that not valid name
            }
            else if (checkBoxPlayer2.Checked && textBoxPlayer2.Text == "")
            {
                // pop up notice that not valid name
            }
            else
            {
                if (DoneInit != null)
                {
                    DoneEventArgs args = new DoneEventArgs();

                    args.boaedSize = m_size;
                    args.playerOneName = textBoxPlayer1.Text;
                    args.playerTwoName = textBoxPlayer2.Text;
                    DoneInit(args);
                }
            }
        }

        private void radioButton6x6Size_CheckedChanged(object sender, EventArgs e)
        {
            m_size = eBoardSize.Small;
        }

        private void radioButton10x10Size_CheckedChanged(object sender, EventArgs e)
        {
            m_size = eBoardSize.Large;
        }

        private void radioButton8x8Size_CheckedChanged(object sender, EventArgs e)
        {
            m_size = eBoardSize.Medium;
        }
    }

    public class DoneEventArgs : EventArgs
    {
        public eBoardSize boaedSize;
        public string playerOneName;
        public string playerTwoName;
    }
}
