using Checkers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CheckersWindowsUI
{
    public delegate void chosenMoveEventHandler(Move i_Move);

    public partial class FormGame : Form
    {
        const int k_LengthOfSquare = 50;    // should be 80
        public event chosenMoveEventHandler chosenMove;
        PictureBox[,] squaresBoard;
        PictureBox toolChosen = null;

        public FormGame()
        {
            InitializeComponent();
        }

        public void UpdateScoreLabels(string i_PlayerOneName, int i_PlayerOneScore, string i_PlayerTwoName, int i_PlayerTwoScore)
        {
            this.labelPlayer1Score.Text = string.Format("{0} : {1}", i_PlayerOneName, i_PlayerOneScore);
            this.labelPlayer2Score.Text = string.Format("{0} : {1}", i_PlayerTwoName, i_PlayerTwoScore);
        }

        public void initButtons(int i_BoardSize)
        {
            squaresBoard = new PictureBox[i_BoardSize, i_BoardSize];

            for (int lineNumber = 0; lineNumber < i_BoardSize; lineNumber++)
            {
                for (int columnNumber = 0; columnNumber < i_BoardSize; columnNumber++)
                {
                    squaresBoard[lineNumber, columnNumber] = new PictureBox();
                    squaresBoard[lineNumber, columnNumber].Size = new System.Drawing.Size(k_LengthOfSquare-10, k_LengthOfSquare-10);
                    squaresBoard[lineNumber, columnNumber].Location = new System.Drawing.Point(lineNumber * k_LengthOfSquare, columnNumber * k_LengthOfSquare);
                    squaresBoard[lineNumber, columnNumber].BackColor = lineNumber % 2 == 0 ? Color.Red : Color.Green; // for test
                    splitContainer1.Panel2.Controls.Add(squaresBoard[lineNumber, columnNumber]);
                }      
            }
        }

        public void initMatrixToBoard(Board i_Board)
        {
            for (int i = 0; i < i_Board.Size; ++i)
            {
                for (int j = 0; j < i_Board.Size; ++j)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        squaresBoard[i, j].Enabled = false;
                    }
                    else if (i_Board[i,j] != null)
                    {

                        squaresBoard[i, j].BackColor = i_Board[i, j].TeamSign == eTeamSign.PlayerX ?
                           Color.White : Color.CadetBlue;      // need to put a picture for team instead of color
                    }
                }
            }
        }

        private void pictureBox_Clicked(object sender, EventArgs e)
        {
            PictureBox gameTool = sender as PictureBox;

            if (gameTool.Image != null)
            {
                if (toolChosen == null)
                {
                    toolChosen = gameTool;
                    gameTool.BackColor = Color.LightBlue;
                }
                else if (toolChosen == gameTool)
                {
                    toolChosen = null;
                    gameTool.BackColor = Color.Transparent;
                }
                else
                {
                    toolChosen = null;
                    gameTool.BackColor = Color.Transparent;
                    //Checkers.Move nextMove = new Move(); // need to get the point of both location
                    //ChoseMove(nextMove);
                }
            }
        }
    }
}
