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

            for (int row = 0; row < i_BoardSize; row++)
            {
                for (int column = 0; column < i_BoardSize; column++)
                {
                    squaresBoard[row, column] = new PictureBox();
                    squaresBoard[row, column].Size = new System.Drawing.Size(k_LengthOfSquare-10, k_LengthOfSquare-10);
                    squaresBoard[row, column].Location = new System.Drawing.Point(column * k_LengthOfSquare, row * k_LengthOfSquare);
                    squaresBoard[row, column].Click += pictureBox_Clicked;
                    squaresBoard[row, column].BackColor = Color.LightGreen; 
                    splitContainer1.Panel2.Controls.Add(squaresBoard[row, column]);
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

        public void SwapPictures(Checkers.Point i_From, Checkers.Point i_Destination)
        {
            Image tempImage = squaresBoard[i_From.Y, i_From.X].Image;

            squaresBoard[i_From.Y, i_From.X].Image = squaresBoard[i_Destination.Y, i_Destination.X].Image;
            squaresBoard[i_Destination.Y, i_Destination.X].Image = tempImage;
        }

        private void pictureBox_Clicked(object sender, EventArgs e)
        {
            PictureBox chosenPictureBox = sender as PictureBox;

            if (chosenPictureBox.Image != null)
            {
                if (toolChosen == null)
                {
                    toolChosen = chosenPictureBox;
                    chosenPictureBox.BackColor = Color.LightBlue;
                }
                else if (toolChosen == chosenPictureBox)
                {
                    toolChosen = null;
                    chosenPictureBox.BackColor = Color.Transparent;
                }
                else
                {
                    Checkers.Point fromLocation = new Checkers.Point(toolChosen.Location.X / k_LengthOfSquare, toolChosen.Location.Y / k_LengthOfSquare);
                    Checkers.Point toLocation = new Checkers.Point(chosenPictureBox.Location.X / k_LengthOfSquare, chosenPictureBox.Location.Y / k_LengthOfSquare);
                    Move nextMove = new Move(fromLocation,toLocation);
                    
                    toolChosen = null;
                    chosenPictureBox.BackColor = Color.Transparent;
                    chosenMove(nextMove);
                }
            }
        }
    }
}
