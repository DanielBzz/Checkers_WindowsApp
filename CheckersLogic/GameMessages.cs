using System;
using System.Text;

namespace Checkers
{
    public class GameMessages
    {
        public static string GameIntro()
        {
            return "HELLO AND WELCOME TO CHECKERS, ENJOY!";
        }


        public static string WrongInputMsg()
        {
            return "Wrong input, please try again";
        }

        public static string WinningMsg(GameLogic i_Game)
        {
            return $"{i_Game.Winner.Name} wins with {i_Game.CurrentWinnerScore} points, Congrats !!!";
        }

        public static string DrawMsg()
        {
            return "It's a draw !";
        }

        public static string KeepPlayingMsg()
        {
            string msg = @"Would you like to play another round ?:
1. Yes.
2. No.";

            return msg;
        }

        public static string GoodByeMsg()
        {
            return "Bye Bye :)";
        }

        public static string QuitGameMsg(GameLogic i_Game)
        {
            return $"{i_Game.CurrentPlayer.Name} quit the match and got 3 points penalty";
        }

        public static string StatusMsg(GameLogic i_Game)
        {
            string msg = string.Format(@"{0} has {1} points.{4}{2} has {3} points.{4}", i_Game.CurrentPlayer.Name, i_Game.CurrentPlayer.Score,
                                      i_Game.OpponentPlayer.Name, i_Game.OpponentPlayer.Score, Environment.NewLine);

            return msg;
        }
    }
}
