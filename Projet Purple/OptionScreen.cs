using System;
using System.Timers;
using System.Windows.Forms;

namespace Projet_Purple
{
    public sealed partial class OptionScreen : Form
    {
        public static string Appearance = "BylethM";
        
        public OptionScreen()
        {
            InitializeComponent();
            if (Appearance == "BylethM")
            {
                BylethM.Image = Properties.Resources.bylethPortrait;
                BylethF.Image = Properties.Resources.bylethFPortraitGray;
            }
            else
            {
                BylethM.Image = Properties.Resources.bylethPortraitGray;
                BylethF.Image = Properties.Resources.bylethFPortrait;
            }
            
            if (ChangeDifficultyScreen.HardDone)
            {
                BackgroundImage = Properties.Resources.titleBackground2Blur;
            }
        }

        private void BylethM_Click(object sender, EventArgs e)
        {
            Appearance = "BylethM";
            BylethM.Image = Properties.Resources.bylethPortrait;
            BylethF.Image = Properties.Resources.bylethFPortraitGray;
        }

        private void BylethF_Click(object sender, EventArgs e)
        {
            Appearance = "BylethF";
            BylethM.Image = Properties.Resources.bylethPortraitGray;
            BylethF.Image = Properties.Resources.bylethFPortrait;
        }

        private void BylethM_MouseEnter(object sender, EventArgs e)
        {
            if (Appearance != "BylethM")
            {
                BylethM.Image = Properties.Resources.bylethPortraitLow;
            }
        }

        private void BylethF_MouseEnter(object sender, EventArgs e)
        {
            if (Appearance != "BylethF")
            {
                BylethF.Image = Properties.Resources.bylethFPortraitLow;
            }
        }

        private void BylethM_MouseLeave(object sender, EventArgs e)
        {
            if (Appearance != "BylethM")
            {
                BylethM.Image = Properties.Resources.bylethPortraitGray;
            }
        }

        private void BylethF_MouseLeave(object sender, EventArgs e)
        {
            if (Appearance != "BylethF")
            {
                BylethF.Image = Properties.Resources.bylethFPortraitGray;
            }
        }
        
        private void BackMenuButton(object sender, EventArgs e)
        {
            this.Hide();
            var titleScreen = new TitleScreen();
            titleScreen.Show();
        }

        private void BackButton_Enter(object sender, EventArgs e)
        {
            backButton.Image = Properties.Resources.buttonBack;
        }

        private void BackButton_Leave(object sender, EventArgs e)
        {
            backButton.Image = Properties.Resources.buttonBackLow;
        }
        
        private void buttonChangeDifficulty_Click(object sender, EventArgs e)
        {
            var difficultyScreen = new ChangeDifficultyScreen();
            difficultyScreen.Show();
            Hide();
        }

        private void buttonChangeDifficulty_MouseEnter(object sender, EventArgs e)
        {
            buttonChangeDifficulty.Image = Properties.Resources.buttonDifficultyChange;
        }

        private void buttonChangeDifficulty_MouseLeave(object sender, EventArgs e)
        {
            buttonChangeDifficulty.Image = Properties.Resources.buttonDifficultyChangeLow;
        }
    }
}