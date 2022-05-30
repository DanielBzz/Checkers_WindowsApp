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
    public partial class FormGame : Form
    {


        public FormGame()
        {
            InitializeComponent();
        }

        public void UpdateScoreLabels(string i_PlayerOneName, int i_PlayerOneScore, string i_PlayerTwoName, int i_PlayerTwoScore)
        {
            this.labelPlayer1Score.Text = string.Format("{0} : {1}", i_PlayerOneName, i_PlayerOneScore);
            this.labelPlayer2Score.Text = string.Format("{0} : {1}", i_PlayerTwoName, i_PlayerTwoScore);
        }
    }
}
