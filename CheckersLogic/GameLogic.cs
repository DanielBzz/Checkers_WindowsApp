using System;
using System.Collections.Generic;

namespace Checkers
{
    public class GameLogic
    {
        private Board m_Board = null;
        private Player m_CurrentPlayer = null;
        private Player m_OpponentPlayer = null;
        private Player m_Winner = null;
        private int? m_CurrentMatchWinnerScore = null;
        public event Action<string> GameOver;

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }

        internal Player Winner
        {
            get
            {
                return m_Winner;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }

        public Player OpponentPlayer
        {
            get
            {
                return m_OpponentPlayer;
            }
        }

        internal int CurrentWinnerScore
        {
            get
            {
                return m_CurrentMatchWinnerScore.Value;
            }
        }

        public void InitPlayer(string i_Name)
        {
            eTeamSign sign = m_OpponentPlayer == null ? eTeamSign.PlayerBlack : eTeamSign.PlayerRed;
            m_CurrentPlayer = new Player(i_Name, sign);
        }

        public void InitBoard(eBoardSize i_Size)
        {
            m_Board = new Board((int)i_Size);
        }

        public bool IsAvailableMove(Move i_Move)
        {
            bool isAvailabe = false;

            foreach (Move move in m_CurrentPlayer.ValidMoves)
            {
                if (Move.IsEquals(move, i_Move))
                {
                    isAvailabe = true;
                    break;
                }
            }

            return isAvailabe;
        }

        public void BulidMoveList()
        {
            m_CurrentPlayer.ValidMoves.Clear();

            foreach (GameTool tool in m_CurrentPlayer.PlayerTools)
            {
                tool.CheckOppurturnitiToEat(m_Board, m_CurrentPlayer.ValidMoves);
            }

            if (m_CurrentPlayer.ValidMoves.Count == 0)
            {
                foreach (GameTool tool in m_CurrentPlayer.PlayerTools)
                {
                    tool.AddValidMovesForTool(m_Board, m_CurrentPlayer.ValidMoves);
                }
            }
        }

        public void ExecutePlayerMove(Move i_Move)
        {
            i_Move.MakeMove(m_Board, m_OpponentPlayer.PlayerTools, m_CurrentPlayer.ValidMoves);
        }

        public bool CheckForDoubleStrike(bool i_LastMoveEat)
        {
            return i_LastMoveEat && !(m_CurrentPlayer.ValidMoves.Count == 0);
        }

        public void SwapPlayers()
        {
            Player tempPlayer = m_CurrentPlayer;

            m_CurrentPlayer = m_OpponentPlayer;
            m_OpponentPlayer = tempPlayer;
        }

        public bool checkIfGameOver()
        {
            bool isGameOver = m_CurrentPlayer.ValidMoves.Count == 0;

            if (isGameOver)
            {
                OnGameOver();
            }

            return isGameOver;
        }

        protected virtual void OnGameOver()
        { 
            updateWinnerScore(m_OpponentPlayer, m_CurrentPlayer);
            if (GameOver != null)
            {
                GameOver.Invoke(m_Winner.Name);
            }
        }

        public void ResetGame()
        {
            if (m_CurrentPlayer.Team == eTeamSign.PlayerRed)
            {
                SwapPlayers();
            }

            m_CurrentPlayer.ResetPlayerForNewGame();
            m_OpponentPlayer.ResetPlayerForNewGame();
            Board.InitializeBoard(m_CurrentPlayer, m_OpponentPlayer);
            m_CurrentMatchWinnerScore = 0;
        }

        public Move GetComputerMove()
        {
            Random random = new Random();

            System.Threading.Thread.Sleep(4000);

            return m_CurrentPlayer.ValidMoves[random.Next(m_CurrentPlayer.ValidMoves.Count - 1)];
        }

        public void CurrentPlayerQuitMatch()        // we dont need it in this version
        {
            SwapPlayers();
            m_CurrentPlayer.Score -= 3;
        }

        public bool IsComputerTurn()
        {
            return m_CurrentPlayer.IsComputer();
        }

        private void updateWinnerScore(Player i_Winner, Player i_Loser)
        {
            int winnerToolCount = 0;
            int loserToolCount = 0;

            foreach (GameTool tool in i_Winner.PlayerTools)
            {
                winnerToolCount += (int)tool.Rank;
            }

            foreach (GameTool tool in i_Loser.PlayerTools)
            {
                loserToolCount += (int)tool.Rank;
            }

            m_CurrentMatchWinnerScore = Math.Abs(winnerToolCount - loserToolCount);
            i_Winner.Score += m_CurrentMatchWinnerScore.Value;
            m_Winner = i_Winner;
        }
    }
}
