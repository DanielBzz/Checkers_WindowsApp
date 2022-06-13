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
    public partial class Form1 : Form
    {
        const int k_LengthOfSquare = 60;    // should be 80
        PictureBox[,] squaresBoard;

        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateScoreLabels(string i_PlayerOneName, int i_PlayerOneScore, string i_PlayerTwoName, int i_PlayerTwoScore)
        {
            this.labelPlayer1Score.Text = string.Format("{0} : {1}", i_PlayerOneName, i_PlayerOneScore);
            this.labelPlayer2Score.Text = string.Format("{0} : {1}", i_PlayerTwoName, i_PlayerTwoScore);
        }

        private void labelPlayer2Score_Click(object sender, EventArgs e)
        {

        }

        public void initButtons(int i_BoardSize)
        {
            squaresBoard = new PictureBox[i_BoardSize, i_BoardSize];

            for (int lineNumber = 0; lineNumber < i_BoardSize; lineNumber++)
            {
                for (int columnNumber = 0; columnNumber < i_BoardSize; columnNumber++)
                {
                    squaresBoard[lineNumber, columnNumber] = new PictureBox();
                    squaresBoard[lineNumber, columnNumber].Size = new System.Drawing.Size(k_LengthOfSquare - 10, k_LengthOfSquare - 10);
                    squaresBoard[lineNumber, columnNumber].Location = new System.Drawing.Point(lineNumber * k_LengthOfSquare, columnNumber * k_LengthOfSquare);
                    squaresBoard[lineNumber, columnNumber].BackColor = lineNumber % 2 == 0 ? Color.Red : Color.Green; // for test
                    tableLayoutPanel1.Controls.Add(squaresBoard[lineNumber, columnNumber]);
                }
            }
        }
    }
}
