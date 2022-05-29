using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckersWindowsUI
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDone_Click(object sender, EventArgs e)
        {

        }
    }
}
