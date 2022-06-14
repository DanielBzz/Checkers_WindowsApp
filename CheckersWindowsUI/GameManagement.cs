using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
        
        private void StartNewSingleMatch()
        {
            r_Game.ResetGame();
            r_GameForm.initMatrixToBoard(r_Game.Board);
            r_GameForm.UpdateScoreLabels(r_Game.CurrentPlayer.Name, r_Game.CurrentPlayer.Score,
                                        r_Game.OpponentPlayer.Name, r_Game.OpponentPlayer.Score);
            // more things we should do berfore start a new game
            r_GameForm.ShowDialog();
        }

        private void settingsForm_DoneFillForm()
        {
            r_Game.InitBoard(r_SettingsForm.BoardSize);
            r_Game.InitPlayer(r_SettingsForm.PlayerOneName);
            r_Game.SwapPlayers();
            r_Game.InitPlayer(r_SettingsForm.PlayerTwoName);
            r_Game.SwapPlayers();
            r_GameForm.initButtons((int)r_SettingsForm.BoardSize);
            StartNewSingleMatch();
        }

        private void welcomeForm_StartGame()
        {
            r_SettingsForm.ShowDialog();
        } 
        
        private void gameForm_ChosenMove(Move i_Move)
        {


            if (r_Game.IsAvailableMove(i_Move))
            {
                r_Game.ExecutePlayerMove(i_Move);
                //r_GameForm.SwapPictures(i_Move);
                if (r_Game.CheckForDoubleStrike(i_Move.IsAnEatingStep()))
                { 
                    // keep pointing on the tool in the ui 
                    // ask for another move and dont change the player
                }
            }
            else 
            {
                // need event handler for wrong move
            }
        }
    }
}
