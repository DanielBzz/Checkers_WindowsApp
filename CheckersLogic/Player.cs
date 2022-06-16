using System.Collections.Generic;

namespace Checkers
{
    public class Player
    {
        public enum ePlayerType
        {
            Computer = 1,
            Human,
        }

        private readonly string r_Name;
        private readonly ePlayerType r_PlayerType;
        private readonly eTeamSign r_Team;
        private readonly List<GameTool> r_PlayerTools = new List<GameTool>();
        private readonly List<Move> r_ValidMovesList = new List<Move>();
        private int m_Score = 0;

        public Player(string i_PlayerName, eTeamSign i_Team)
        {
            r_Name = i_PlayerName;
            r_Team = i_Team;
            r_PlayerType = i_PlayerName == "Computer" ? ePlayerType.Computer : ePlayerType.Human;
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public eTeamSign Team
        {
            get
            {
                return r_Team;
            }
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public List<GameTool> PlayerTools
        {
            get
            {
                return r_PlayerTools;
            }
        }

        public List<Move> ValidMoves
        {
            get
            {
                return r_ValidMovesList;
            }
        }

        public bool IsComputer()
        {
            return r_PlayerType == ePlayerType.Computer;
        }

        public void ResetPlayerForNewGame()
        {
            r_PlayerTools.Clear();
            r_ValidMovesList.Clear();
        }
    }
}