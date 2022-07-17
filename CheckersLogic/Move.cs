using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    public delegate void MoveEventHandler(Point i_From, Point i_Destination);

    public class Move
    {
        public event MoveEventHandler MoveTool;

        public event Action<Point> EatTool;

        public event Action<Point> SwitchedToKing;

        private const int k_Jump2Squares = 2;
        private readonly bool m_EatMove;
        private Point m_CurrentPoint;
        private Point m_DestinationPoint;

        public Move(Point i_From, Point i_To)
        {
            m_CurrentPoint = i_From;
            m_DestinationPoint = i_To;
            m_EatMove = Math.Abs(m_CurrentPoint.X - m_DestinationPoint.X) == k_Jump2Squares;
        }

        public static bool IsEquals(Move i_FirstMove, Move i_SecondMove)
        {
            bool isEqual = Equals(i_FirstMove.m_CurrentPoint, i_SecondMove.m_CurrentPoint) &&
                Equals(i_FirstMove.m_DestinationPoint, i_SecondMove.m_DestinationPoint) && i_FirstMove.m_EatMove == i_SecondMove.m_EatMove;

            return isEqual;
        }

        public bool IsAnEatingStep()
        {
            return m_EatMove;
        }

        public void MakeMove(Board io_GameBoard, List<GameTool> io_OpponentTools, List<Move> io_PlayerMoves)
        {
            GameTool toolToMove = io_GameBoard[m_CurrentPoint.Y, m_CurrentPoint.X];

            OnMove(io_GameBoard, toolToMove);
            if (m_EatMove)
            {
                OnEat(io_GameBoard, io_OpponentTools);
                io_PlayerMoves.Clear();
                toolToMove.CheckOppurturnitiToEat(io_GameBoard, io_PlayerMoves);
            }

            checkIfBecomeKing(toolToMove, io_GameBoard);
        }

        protected virtual void OnMove(Board io_GameBoard, GameTool io_ToolToMove)
        {
            io_GameBoard.RemoveToolFromSquare(io_ToolToMove.Location);
            io_GameBoard.AddToolToSquare(io_ToolToMove, m_DestinationPoint);
            io_ToolToMove.Location = m_DestinationPoint;
            if (MoveTool != null)
            {
                MoveTool.Invoke(m_CurrentPoint, m_DestinationPoint);
            }
        }

        protected virtual void OnEat(Board io_GameBoard, List<GameTool> io_OpponentTools)
        {
            GameTool toolToDelete = io_GameBoard[(m_CurrentPoint.Y + m_DestinationPoint.Y) / 2, (m_CurrentPoint.X + m_DestinationPoint.X) / 2];

            io_GameBoard.RemoveToolFromSquare(toolToDelete.Location);
            io_OpponentTools.Remove(toolToDelete);
            if (MoveTool != null)
            {
                EatTool.Invoke(toolToDelete.Location);
            }
        }

        protected virtual void OnSwitchToKing(GameTool io_Tool)
        {
            io_Tool.MakeKing();
            if (SwitchedToKing != null)
            {
                SwitchedToKing.Invoke(io_Tool.Location);
            }
        }

        private void checkIfBecomeKing(GameTool io_Tool, Board i_GameBoard)
        {
            if (!io_Tool.IsKing() && i_GameBoard.ToolInEndLine(io_Tool))
            {
                OnSwitchToKing(io_Tool);
            }
        }
    }
}
