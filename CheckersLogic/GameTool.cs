﻿using System.Collections.Generic;

namespace Checkers
{
    public class GameTool
    {
        public enum eToolValue
        {
            Regular = 1,
            King = 4,
        }

        public enum eToolSign
        {
            ToolO = 'O',
            ToolX = 'X',
            ToolOKing = 'U',
            ToolXKing = 'K',
        }

        public enum eDirection
        {
            Up = -1,
            Down = 1,
            Left = -1,
            Right = 1,
        }

        private readonly eTeamSign r_TeamSign;
        private eToolSign m_ToolSign;
        private eToolValue m_Rank;
        private Point m_Location;

        public GameTool(eTeamSign i_Team, Point i_Location)
        {
            r_TeamSign = i_Team;
            m_ToolSign = (eToolSign)i_Team;
            m_Location = i_Location;
            m_Rank = eToolValue.Regular;
        }

        public eTeamSign TeamSign
        {
            get
            {
                return r_TeamSign;
            }
        }

        public eToolSign ToolSign
        {
            get
            {
                return m_ToolSign;
            }
        }

        public Point Location
        {
            get
            {
                return m_Location;
            }

            set
            {
                m_Location = value;
            }
        }

        public eToolValue Rank
        {
            get
            {
                return m_Rank;
            }
        }

        public bool IsKing()
        {
            return m_Rank == eToolValue.King;
        }

        public void MakeKing()
        {
            m_Rank = eToolValue.King;
            m_ToolSign = r_TeamSign == eTeamSign.PlayerBlack ? eToolSign.ToolXKing : eToolSign.ToolOKing;
        }

        public eDirection GetToolDirection()
        {
            return r_TeamSign == eTeamSign.PlayerBlack ? eDirection.Up : eDirection.Down;
        }

        public void AddValidMovesForTool(Board i_GameBoard, List<Move> io_PlayerValidMoves)
        {
            eDirection toolDirection = GetToolDirection();

            addOneDirectionValidMoves(i_GameBoard, io_PlayerValidMoves, toolDirection);
            if (IsKing())
            {
                toolDirection = toolDirection == eDirection.Up ? eDirection.Down : eDirection.Up;
                addOneDirectionValidMoves(i_GameBoard, io_PlayerValidMoves, toolDirection);
            }
        }

        public void CheckOppurturnitiToEat(Board i_GameBoard, List<Move> i_PlayerValidMoves)
        {
            eDirection toolDirection = GetToolDirection();

            addOneDirectionValidEatMoves(i_GameBoard, i_PlayerValidMoves, toolDirection);
            if (IsKing())
            {
                toolDirection = toolDirection == eDirection.Up ? eDirection.Down : eDirection.Up;
                addOneDirectionValidEatMoves(i_GameBoard, i_PlayerValidMoves, toolDirection);
            }
        }

        private void addOneDirectionValidMoves(Board i_GameBoard, List<Move> io_PlayerValidMoves, eDirection i_ToolDirection)
        {
            Point newPoint = new Point(m_Location.X + (int)eDirection.Left, m_Location.Y + (int)i_ToolDirection);

            if (checkIfValidMove(newPoint, i_GameBoard))
            {
                io_PlayerValidMoves.Add(new Move(m_Location, newPoint));
            }

            newPoint.X = m_Location.X + (int)eDirection.Right;
            if (checkIfValidMove(newPoint, i_GameBoard))
            {
                io_PlayerValidMoves.Add(new Move(m_Location, newPoint));
            }
        }

        private bool checkIfValidMove(Point i_AfterMove, Board i_GameBoard)
        {
            return i_GameBoard.IsPointInBoard(i_AfterMove) && i_GameBoard.IsSquareEmpty(i_AfterMove);
        }

        private bool checkIfOpponentInNextSquare(Point i_AfterMove, Board i_GameBoard)
        {
            return i_GameBoard.IsPointInBoard(i_AfterMove) && i_GameBoard.IsOpponentInSquare(i_AfterMove, r_TeamSign);
        }

        private void addOneDirectionValidEatMoves(Board i_GameBoard, List<Move> io_PlayerValidMoves, eDirection i_ToolDirection)
        {
            Point opponentSquare = new Point(m_Location.X + (int)eDirection.Left, m_Location.Y + (int)i_ToolDirection);
            Point newPoint = new Point(opponentSquare.X + (int)eDirection.Left, opponentSquare.Y + (int)i_ToolDirection);

            if (checkIfOpponentInNextSquare(opponentSquare, i_GameBoard) && checkIfValidMove(newPoint, i_GameBoard))
            {
                io_PlayerValidMoves.Add(new Move(m_Location, newPoint));
            }

            opponentSquare.X = m_Location.X + (int)eDirection.Right;
            newPoint.X = opponentSquare.X + (int)eDirection.Right;
            if (checkIfOpponentInNextSquare(opponentSquare, i_GameBoard) && checkIfValidMove(newPoint, i_GameBoard))
            {
                io_PlayerValidMoves.Add(new Move(m_Location, newPoint));
            }
        }
    }
}