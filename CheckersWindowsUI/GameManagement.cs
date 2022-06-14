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
        FormWelcome m_WelcomeForm = new FormWelcome();
        FormGameSettings m_SettingsForm = new FormGameSettings();
        FormGame m_GameForm = new FormGame();
        //FormEndMatch m_EndMatchForm = new FormEndMatch();  // not sure we need it 

        public void initFormsEvent()
        {
            m_WelcomeForm.StartGame += welcomeForm_StartGame;
            m_SettingsForm.DoneFillForm += settingsForm_DoneFillForm;   // AFTER WE DONE INIT WE NEED TO CALL THE RUN GAME FORM 
            m_GameForm.ChoseMove += gameForm_ChoseMove;
        }

        private void gameForm_ChoseMove(Move i_Move)
        {
            if (r_Game.IsAvailabeMove(i_Move))
            {
                r_Game.ExecutePlayerMove(i_Move);
                // add changes in the ui
            }
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            initFormsEvent();
            m_WelcomeForm.ShowDialog();
        }
    
        private void welcomeForm_StartGame()
        {
            m_SettingsForm.ShowDialog();
        } 
        
        private void settingsForm_DoneFillForm()
        {
            r_Game.InitBoard(m_SettingsForm.BoardSize);
            r_Game.InitPlayer(m_SettingsForm.PlayerOneName);
            r_Game.SwapPlayers();
            r_Game.InitPlayer(m_SettingsForm.PlayerTwoName);
            r_Game.SwapPlayers();
            m_GameForm.initButtons((int)m_SettingsForm.BoardSize);
            StartNewSingleMatch();
        }

        private void StartNewSingleMatch()
        {
            r_Game.ResetGame();
            m_GameForm.initMatrixToBoard(r_Game.Board);
            m_GameForm.UpdateScoreLabels(r_Game.CurrentPlayer.Name, r_Game.CurrentPlayer.Score,
                                        r_Game.OpponentPlayer.Name, r_Game.OpponentPlayer.Score);
            // more things we should do berfore start a new game
            m_GameForm.ShowDialog();
        }
    }
}
