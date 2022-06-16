using System;
using System.Windows.Forms;
using Checkers;

namespace CheckersWindowsUI
{
    public class GameManagement
    {
        private readonly GameLogic r_Game = new GameLogic();
        private readonly FormWelcome r_WelcomeForm = new FormWelcome();
        private readonly FormGameSettings r_SettingsForm = new FormGameSettings();
        private readonly FormGame r_GameForm = new FormGame();
        private Timer timer = new System.Windows.Forms.Timer();

        public void Run()
        {
            Application.EnableVisualStyles();
            initFormsEvent();
            r_WelcomeForm.ShowDialog();
        }

        public void initFormsEvent()
        {
            r_WelcomeForm.StartGame += welcomeForm_StartGame;
            r_SettingsForm.DoneFillForm += settingsForm_DoneFillForm;
            r_GameForm.chosenMove += gameForm_ChosenMove;
            r_Game.GameOver += r_GameForm.game_GameOver;
            r_GameForm.NewMatch += StartNewSingleMatch;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            executeComputerTurn();
        }

        private void StartNewSingleMatch()
        {
            r_Game.ResetGame();
            r_GameForm.initMatrixToBoard(r_Game.Board);
            r_GameForm.UpdateScoreLabels(r_Game.CurrentPlayer.Name, r_Game.CurrentPlayer.Score,
                                        r_Game.OpponentPlayer.Name, r_Game.OpponentPlayer.Score);
            r_Game.BulidMoveList();
            r_GameForm.CurrentTeamTurn = r_Game.CurrentPlayer.Team;
        }

        private void endTurn()
        {
            r_Game.SwapPlayers();
            r_GameForm.CurrentTeamTurn = r_Game.CurrentPlayer.Team;
            r_Game.BulidMoveList();
            if (!r_Game.checkIfGameOver() && r_Game.IsComputerTurn())
            {
                executeComputerTurn();
            }
        }

        private void executeComputerTurn()
        {
            Move nextComputerMove = r_Game.GetComputerMove();
            r_GameForm.RegisterMoveToEvents(nextComputerMove);
            r_Game.ExecutePlayerMove(nextComputerMove);
            if (!r_Game.CheckForDoubleStrike(nextComputerMove.IsAnEatingStep()))
            {
                endTurn();
            }
            else
            {
                timer.Enabled = true;
                timer.Interval = 500;
                timer.Start();
            }
        }

        private void welcomeForm_StartGame(object sender, EventArgs e)
        {
            r_SettingsForm.ShowDialog();
        }

        private void settingsForm_DoneFillForm(object sender, EventArgs e)
        {
            r_Game.InitBoard(r_SettingsForm.BoardSize);
            r_Game.InitPlayer(r_SettingsForm.PlayerOneName);
            r_Game.SwapPlayers();
            r_Game.InitPlayer(r_SettingsForm.PlayerTwoName);
            r_Game.SwapPlayers();
            r_GameForm.InitBoardOnForm((int)r_SettingsForm.BoardSize);
            StartNewSingleMatch();
            r_SettingsForm.Hide(); // consider switching to Dispose
            r_WelcomeForm.Dispose();
            r_GameForm.ShowDialog();
        }

        private void gameForm_ChosenMove(Move i_Move)
        {
            if (r_Game.IsAvailableMove(i_Move))
            {
                r_Game.ExecutePlayerMove(i_Move);
                if (!r_Game.CheckForDoubleStrike(i_Move.IsAnEatingStep()))
                {
                    endTurn(); // maybe keep pointing on the tool in the ui
                }
            }
            else
            {
                r_GameForm.UnavailableMove();
            }
        }
    }
}
