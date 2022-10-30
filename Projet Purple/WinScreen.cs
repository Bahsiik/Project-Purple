using System;
using System.Timers;
using System.Windows.Forms;

namespace Projet_Purple
{
    public sealed partial class WinScreen : Form
    {
        public WinScreen()
        {
            InitializeComponent();
            BackgroundImage = "BylethM".Equals(OptionScreen.Appearance)
                ? Properties.Resources.winBackgroundM
                : Properties.Resources.winBackgroundF;
        }

        private int _index;


        private void winScreenTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _index++;
            if (_index <= 1)
            {
                winTitle.Visible = true;
                winTitle.Top = 0 - winTitle.Height;
            }

            if (winTitle.Top + winTitle.Height < 90)
            {
                winTitle.Top += 2;
            }
            else
            {
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