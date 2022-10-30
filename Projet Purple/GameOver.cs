using System;
using System.Timers;
using System.Windows.Forms;

namespace Projet_Purple
{
    public sealed partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private int _index;

        private void gameOverTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _index++;
            if (_index <= 1)
            {
                gameOverTitle.Visible = true;
                gameOverTitle.Top = 150 - gameOverTitle.Height;
            }
            if (gameOverTitle.Top + gameOverTitle.Height < 300)
            {
                gameOverTitle.Top += 1;
            }
            else
            {
                tipLabel.Visible = true;
                buttonMenu.Visible = true;
                buttonLeave.Visible = true;
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            var titleScreen = new TitleScreen();
            titleScreen.Show();
            Close();
        }

        private void buttonMenu_MouseEnter(object sender, EventArgs e)
        {
            buttonMenu.Image = Properties.Resources.buttonPauseMenu;
        }

        private void buttonMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonMenu.Image = Properties.Resources.buttonPauseMenuLow;
        }

        private void buttonLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLeave_MouseEnter(object sender, EventArgs e)
        {
            buttonLeave.Image = Properties.Resources.buttonPauseLeave;
        }

        private void buttonLeave_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave.Image = Properties.Resources.buttonPauseLeaveLow;
        }
    }
}