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
        // FORM OF THE RUN GAME...
        FormEndMatch m_EndMatchForm = new FormEndMatch();

        public void initForms()
        {
            m_WelcomeForm.StartGame += welcomeForm_StartGame;
            m_SettingsForm.DoneInit += settingsForm_DoneInit;   // AFTER WE DONE INIT WE NEED TO CALL THE RUN GAME FORM 
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            initForms();
            m_WelcomeForm.ShowDialog();
            
        }
    
        private void welcomeForm_StartGame()
        {
            m_SettingsForm.ShowDialog();
        } 
        
        private void settingsForm_DoneInit(DoneEventArgs e)
        {
            r_Game.InitBoard(e.boaedSize);
            r_Game.InitPlayer(e.playerOneName);
            r_Game.SwapPlayers();
            r_Game.InitPlayer(e.playerTwoName);
            r_Game.SwapPlayers();
        }
    }
}
