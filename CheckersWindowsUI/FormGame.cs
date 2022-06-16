using System;
using System.Drawing;
using System.Windows.Forms;
using Checkers;

namespace CheckersWindowsUI
{
    public delegate void chosenMoveEventHandler(Move i_Move);

    public partial class FormGame : Form
    {
        public event chosenMoveEventHandler chosenMove;

        public event Action NewMatch;

        private const int k_LengthOfSquare = 60;
        private PictureBox[,] m_SquaresBoard;
        private PictureBox r_ToolChosen = null;
        private eTeamSign m_CurrentTeamTurn;

        public eTeamSign CurrentTeamTurn
        {
            set
            {
                m_CurrentTeamTurn = value;
            }
        }

        public FormGame()
        {
            InitializeComponent();
        }

        public void UpdateScoreLabels(string i_PlayerOneName, int i_PlayerOneScore, string i_PlayerTwoName, int i_PlayerTwoScore)
        {
            labelPlayer1Score.Text = string.Format("{0} : {1}", i_PlayerOneName, i_PlayerOneScore);
            labelPlayer2Score.Text = string.Format("{0} : {1}", i_PlayerTwoName, i_PlayerTwoScore);
        }

        public void InitBoardOnForm(int i_BoardSize)
        {
            int additionalSize = (i_BoardSize - (int)eBoardSize.Small) * k_LengthOfSquare;

            Size += new Size(additionalSize, additionalSize);
            m_SquaresBoard = new PictureBox[i_BoardSize, i_BoardSize];
            for (int row = 0; row < i_BoardSize; row++)
            {
                for (int column = 0; column < i_BoardSize; column++)
                {
                    m_SquaresBoard[row, column] = new PictureBox
                    {
                        Size = new System.Drawing.Size(k_LengthOfSquare, k_LengthOfSquare),
                        Location = new System.Drawing.Point(column * k_LengthOfSquare, row * k_LengthOfSquare),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                    };

                    m_SquaresBoard[row, column].Click += pictureBox_Clicked;
                    splitContainer1.Panel2.Controls.Add(m_SquaresBoard[row, column]);
                }
            }
        }

        public void initMatrixToBoard(Board i_Board)
        {
            for (int row = 0; row < i_Board.Size; ++row)
            {
                for (int column = 0; column < i_Board.Size; ++column)
                {
                    if (row % 2 == column % 2)
                    {
                        m_SquaresBoard[row, column].Enabled = false;
                    }
                    else if (i_Board[row, column] != null)
                    {
                        eTeamSign teamSign = i_Board[row, column].TeamSign;
                        m_SquaresBoard[row, column].Image = teamSign == eTeamSign.PlayerRed ?
                                                    Properties.Resources.RedTool : Properties.Resources.BlackTool;
                        m_SquaresBoard[row, column].Tag = teamSign;
                    }
                    else
                    {
                        m_SquaresBoard[row, column].Image = null;
                        m_SquaresBoard[row, column].Tag = null;
                    }
                }
            }
        }

        public void UnavailableMove()
        {
            MessageBox.Show("Unavailable Move, try again");
        }

        public void game_GameOver(string i_WinnerName)
        {
            DialogResult result = MessageBox.Show(
                string.Format("{0} Won !!!{1}Play Another Round?", i_WinnerName, Environment.NewLine),
                "Checkers",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                NewMatch?.Invoke();
            }
            else
            {
                Close();
            }
        }

        private void pictureBox_Clicked(object sender, EventArgs e)
        {
            PictureBox chosenPictureBox = sender as PictureBox;

            if (r_ToolChosen == null && chosenPictureBox.Tag is eTeamSign sign && sign.Equals(m_CurrentTeamTurn))
            {
                r_ToolChosen = chosenPictureBox;
                chosenPictureBox.BackColor = Color.LightSkyBlue;
            }
            else if (r_ToolChosen != null)
            {
                if (r_ToolChosen == chosenPictureBox)
                {
                    chosenPictureBox.BackColor = Color.Transparent;
                    r_ToolChosen = null;
                }
                else
                {
                    OnChosenMove(chosenPictureBox);
                }
            }
        }

        protected virtual void OnChosenMove(PictureBox i_DestinationBox)
        {
            Checkers.Point fromLocation = new Checkers.Point(r_ToolChosen.Location.X / k_LengthOfSquare, r_ToolChosen.Location.Y / k_LengthOfSquare);
            Checkers.Point toLocation = new Checkers.Point(i_DestinationBox.Location.X / k_LengthOfSquare, i_DestinationBox.Location.Y / k_LengthOfSquare);
            Move nextMove = initNextMove(fromLocation, toLocation);

            r_ToolChosen.BackColor = Color.Transparent;
            r_ToolChosen = null;
            if (chosenMove != null)
            {
                chosenMove(nextMove);
            }
        }

        private Move initNextMove(Checkers.Point i_FromLocation, Checkers.Point i_ToLocation)
        {
            Move nextMove = new Move(i_FromLocation, i_ToLocation);

            RegisterMoveToEvents(nextMove);

            return nextMove;
        }

        public void RegisterMoveToEvents(Move io_Move)
        {
            io_Move.MoveTool += nextMove_MoveTool;
            io_Move.EatTool += nextMove_EatTool;
            io_Move.SwitchedToKing += nextMove_switchKing;
        }

        private void nextMove_switchKing(Checkers.Point i_Location)
        {
            eTeamSign teamSign = (eTeamSign)m_SquaresBoard[i_Location.Y, i_Location.X].Tag;

            if (teamSign == eTeamSign.PlayerRed)
            {
                m_SquaresBoard[i_Location.Y, i_Location.X].Image = Properties.Resources.RedKing;
            }
            else
            {
                m_SquaresBoard[i_Location.Y, i_Location.X].Image = Properties.Resources.BlackKing;
            }
        }

        private void nextMove_EatTool(Checkers.Point i_Location)
        {
            m_SquaresBoard[i_Location.Y, i_Location.X].Image = null;
            m_SquaresBoard[i_Location.Y, i_Location.X].Tag = null;
        }

        private void nextMove_MoveTool(Checkers.Point i_From, Checkers.Point i_Destination)
        {
            m_SquaresBoard[i_Destination.Y, i_Destination.X].Image = m_SquaresBoard[i_From.Y, i_From.X].Image;
            m_SquaresBoard[i_Destination.Y, i_Destination.X].Tag = m_SquaresBoard[i_From.Y, i_From.X].Tag;
            m_SquaresBoard[i_From.Y, i_From.X].Image = null;
            m_SquaresBoard[i_From.Y, i_From.X].Tag = null;
        }
    }
}
