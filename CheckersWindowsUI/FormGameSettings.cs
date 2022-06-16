using System;
using System.Windows.Forms;
using Checkers;

namespace CheckersWindowsUI
{
    public partial class FormGameSettings : Form
    {
        public event EventHandler DoneFillForm;

        public FormGameSettings()
        {
            InitializeComponent();
        }

        public eBoardSize BoardSize
        {
            get
            {
                if (radioButtonSmallSize.Checked)
                {
                    return eBoardSize.Small;
                }
                else if (radioButtonMediumSize.Checked)
                {
                    return eBoardSize.Medium;
                }
                else
                {
                    return eBoardSize.Large;
                }
            }
        }

        public string PlayerOneName
        {
            get
            {
                return textBoxPlayer1.Text;
            }
        }

        public string PlayerTwoName
        {
            get
            {
                return textBoxPlayer2.Text;
            }
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.ReadOnly = false;
                textBoxPlayer2.TextAlign = HorizontalAlignment.Left;
                textBoxPlayer2.Text = string.Empty;
            }
            else
            {
                textBoxPlayer2.ReadOnly = true;
                textBoxPlayer2.TextAlign = HorizontalAlignment.Center;
                textBoxPlayer2.Text = "Computer";
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPlayer1.Text))
            {
                MessageBox.Show(string.Format("Player 1 invalid name,{0}Try Again", Environment.NewLine));
            }
            else if (checkBoxPlayer2.Checked && string.IsNullOrEmpty(textBoxPlayer2.Text))
            {
                MessageBox.Show(string.Format("Player 2 invalid name,{0}Try Again", Environment.NewLine));
            }
            else
            {
                Close();
                if (DoneFillForm != null)
                {
                    DoneFillForm(this, null);
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == (char)Keys.Space;
        }
    }
}
