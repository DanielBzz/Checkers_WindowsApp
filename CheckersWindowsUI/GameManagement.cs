using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckersWindowsUI
{
    public class GameManagement
    {
        public void Run()
        {
            Application.EnableVisualStyles();
            new FormGameSettings().ShowDialog();
        }
    }
}
