using System;
using System.Windows.Forms;
using Checkers;

namespace CheckersWindowsUI
{
    public delegate void DoneEventHandler();

    public partial class FormGameSettings : Form
    {
        public event DoneEventHandler DoneFillForm;

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
                textBoxPlayer2.Text = "";
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
                MessageBox.Show("Invalid player 1 name, insert name.");
            }
            else if (checkBoxPlayer2.Checked && string.IsNullOrEmpty(textBoxPlayer2.Text))
            {
                MessageBox.Show(string.Format("Invalid player 2 name,{0}insert name or unchecked the box.", Environment.NewLine));
            }
            else
            {
                this.Close();
                if (DoneFillForm != null)
                {
                    DoneFillForm();
                }
            }
        }
    }
}
