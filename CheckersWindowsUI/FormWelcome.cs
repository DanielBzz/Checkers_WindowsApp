using System;
using System.Windows.Forms;
using Checkers;

namespace CheckersWindowsUI
{
    public partial class FormWelcome : Form
    {
        public event EventHandler StartGame;

        public FormWelcome()
        {
            InitializeComponent();
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            this.label1.Text = "English Checkers";
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (StartGame != null)
            {
                StartGame(this, null);
            }
        }
    }
}
