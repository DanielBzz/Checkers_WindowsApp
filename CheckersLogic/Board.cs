using System;
using System.Text;

namespace Checkers
{
    public class Board
    {
        private const GameTool k_Empty = null;
        private readonly GameTool[,] r_GameBoard;
        private readonly int r_Size;

        public Board(int i_BoardSize)
        {
            r_Size = i_BoardSize;
            r_GameBoard = new GameTool[r_Size, r_Size];
        }

        public int Size
        {
            get
            {
                return r_Size;
            }
        }

        public GameTool this[int i_Row, int i_Colum]
        {
            get
            {
                return r_GameBoard[i_Row, i_Colum];
            }

            set
            {
                r_GameBoard[i_Row, i_Colum] = value;
            }
        }

        public void AddToolToSquare(GameTool i_AddTool, Point i_NewLocation)
        {
            r_GameBoard[i_NewLocation.Y, i_NewLocation.X] = i_AddTool;
        }

        public void RemoveToolFromSquare(Point i_ToolLocation)
        {
            r_GameBoard[i_ToolLocation.Y, i_ToolLocation.X] = k_Empty;
        }

        public bool ToolInEndLine(GameTool i_Tool)
        {
            int endLine = i_Tool.GetToolDirection() == GameTool.eDirection.Up ? 0 : r_Size - 1;

            return i_Tool.Location.Y == endLine;
        }

        public bool IsPointInBoard(Point i_SquareLocation)
        {
            return i_SquareLocation.X < r_Size && i_SquareLocation.Y < r_Size && i_SquareLocation.X >= 0 && i_SquareLocation.Y >= 0;
        }

        public bool IsSquareEmpty(Point i_SquareLocation)
        {
            return r_GameBoard[i_SquareLocation.Y, i_SquareLocation.X] == k_Empty;
        }

        public bool IsOpponentInSquare(Point i_SquareLocation, eTeamSign i_ToolTeam)
        {
            return !IsSquareEmpty(i_SquareLocation) && r_GameBoard[i_SquareLocation.Y, i_SquareLocation.X].TeamSign != i_ToolTeam;
        }

        public void InitializeBoard(Player io_Player1, Player io_Player2)
        {
            initializeBufferZone();
            initializePlayersTools(io_Player1, io_Player2);
        }

        private void initializeBufferZone()
        {
            int startLoopIndex = (r_Size / 2) - 1;
            int endLoopIndex = (r_Size / 2) + 1;

            for (int i = startLoopIndex; i < endLoopIndex; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    r_GameBoard[i, j] = k_Empty;
                }
            }
        }

        private void initializePlayersTools(Player io_Player1, Player io_Player2)
        {
            int startLine = 0;
            int endLine = (r_Size / 2) - 1;

            arrangePlayerToolsOnBoard(io_Player2, startLine, endLine);
            startLine = (r_Size / 2) + 1;
            endLine = r_Size;
            arrangePlayerToolsOnBoard(io_Player1, startLine, endLine);
        }

        private void arrangePlayerToolsOnBoard(Player io_Player, int i_StartLine, int i_EndLine)
        {
            for (int i = i_StartLine; i < i_EndLine; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        GameTool newMember = new GameTool(io_Player.Team, new Point(j, i));
                        io_Player.PlayerTools.Add(newMember);
                        r_GameBoard[i, j] = newMember;
                    }
                    else
                    {
                        r_GameBoard[i, j] = k_Empty;
                    }
                }
            }
        }
    }
}