using System;
using System.Windows.Forms;

namespace Projet_Purple
{
    public sealed partial class ChangeDifficultyScreen : Form
    {
        public ChangeDifficultyScreen()
        {
            InitializeComponent();
            DisplaySelectedDifficulty();
            if (HardDone)
            {
                BackgroundImage = Properties.Resources.titleBackground2Blur;
            }
        }

        public static string Difficulty = "peaceful";
        public static bool PeacefulDone, EasyDone, MediumDone, HardUnlocked, HardDone;

        private void backButton_Click(object sender, EventArgs e)
        {
            var optionScreen = new OptionScreen();
            optionScreen.Show();
            Hide();
        }

        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            backButton.Image = Properties.Resources.buttonBack;
        }

        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            backButton.Image = Properties.Resources.buttonBackLow;
        }

        private void peacefulDifficulty_Click(object sender, EventArgs e)
        {
            Difficulty = "peaceful";
            DisplaySelectedDifficulty();
        }

        private void peacefulDifficulty_MouseEnter(object sender, EventArgs e)
        {
            peacefulDifficulty.Image = "peaceful".Equals(Difficulty)
                ? Properties.Resources.peacefullDifficulty
                : Properties.Resources.peacefullDifficultyLow;
            difficultyDescription.Image = PeacefulDone
                ? Properties.Resources.difficultyPeacefullDescDone
                : Properties.Resources.difficultyPeacefullDesc;
        }

        private void peacefulDifficulty_MouseLeave(object sender, EventArgs e)
        {
            DisplaySelectedDifficulty();
        }

        private void easyDifficulty_Click(object sender, EventArgs e)
        {
            Difficulty = "easy";
            DisplaySelectedDifficulty();
        }

        private void easyDifficulty_MouseEnter(object sender, EventArgs e)
        {
            easyDifficulty.Image = "easy".Equals(Difficulty)
                ? Properties.Resources.easyDifficulty
                : Properties.Resources.easyDifficultyLow;
            difficultyDescription.Image = EasyDone
                ? Properties.Resources.difficultyEasyDescDone
                : Properties.Resources.difficultyEasyDesc;
        }

        private void easyDifficulty_MouseLeave(object sender, EventArgs e)
        {
            DisplaySelectedDifficulty();
        }

        private void mediumDifficulty_Click(object sender, EventArgs e)
        {
            Difficulty = "medium";
            DisplaySelectedDifficulty();
        }

        private void mediumDifficulty_MouseEnter(object sender, EventArgs e)
        {
            mediumDifficulty.Image = "medium".Equals(Difficulty)
                ? Properties.Resources.mediumDifficulty
                : Properties.Resources.mediumDifficultyLow;
            difficultyDescription.Image = MediumDone
                ? Properties.Resources.difficultyMediumDescDone
                : Properties.Resources.difficultyMediumDesc;
        }

        private void mediumDifficulty_MouseLeave(object sender, EventArgs e)
        {
            DisplaySelectedDifficulty();
        }

        private void hardDifficulty_Click(object sender, EventArgs e)
        {
            if (HardUnlocked)
            {
                Difficulty = "hard";
                DisplaySelectedDifficulty();
            }
        }

        private void hardDifficulty_MouseEnter(object sender, EventArgs e)
        {
            if (HardUnlocked)
            {
                hardDifficulty.Image = "hard".Equals(Difficulty)
                    ? Properties.Resources.hardDifficulty
                    : Properties.Resources.hardDifficultyLow;
                difficultyDescription.Image = HardDone
                    ? Properties.Resources.difficultyHardDescDone
                    : Properties.Resources.difficultyHardDesc;
            }
            else
            {
                hardDifficulty.Image = Properties.Resources.hardDifficultyLocked;
                difficultyDescription.Image = Properties.Resources.difficultyHardLockedDesc;
            }
        }

        private void hardDifficulty_MouseLeave(object sender, EventArgs e)
        {
            DisplaySelectedDifficulty();
        }

        private void DisplaySelectedDifficulty()
        {
            switch (Difficulty)
            {
                case "peaceful":
                    peacefulDifficulty.Image = Properties.Resources.peacefullDifficulty;
                    easyDifficulty.Image = Properties.Resources.easyDifficultyGray;
                    mediumDifficulty.Image = Properties.Resources.mediumDifficultyGray;
                    hardDifficulty.Image = HardUnlocked
                        ? Properties.Resources.hardDifficultyGray
                        : Properties.Resources.hardDifficultyLocked;
                    difficultyDescription.Image = PeacefulDone
                        ? Properties.Resources.difficultyPeacefullDescDone
                        : Properties.Resources.difficultyPeacefullDesc;
                    break;
                case "easy":
                    peacefulDifficulty.Image = Properties.Resources.peacefullDifficultyGray;
                    easyDifficulty.Image = Properties.Resources.easyDifficulty;
                    mediumDifficulty.Image = Properties.Resources.mediumDifficultyGray;
                    hardDifficulty.Image = HardUnlocked
                        ? Properties.Resources.hardDifficultyGray
                        : Properties.Resources.hardDifficultyLocked;
                    difficultyDescription.Image = EasyDone
                        ? Properties.Resources.difficultyEasyDescDone
                        : Properties.Resources.difficultyEasyDesc;
                    break;
                case "medium":
                    peacefulDifficulty.Image = Properties.Resources.peacefullDifficultyGray;
                    easyDifficulty.Image = Properties.Resources.easyDifficultyGray;
                    mediumDifficulty.Image = Properties.Resources.mediumDifficulty;
                    hardDifficulty.Image = HardUnlocked
                        ? Properties.Resources.hardDifficultyGray
                        : Properties.Resources.hardDifficultyLocked;
                    difficultyDescription.Image = MediumDone
                        ? Properties.Resources.difficultyMediumDescDone
                        : Properties.Resources.difficultyMediumDesc;
                    break;
                case "hard":
                    peacefulDifficulty.Image = Properties.Resources.peacefullDifficultyGray;
                    easyDifficulty.Image = Properties.Resources.easyDifficultyGray;
                    mediumDifficulty.Image = Properties.Resources.mediumDifficultyGray;
                    hardDifficulty.Image = Properties.Resources.hardDifficulty;
                    difficultyDescription.Image = HardDone
                        ? Properties.Resources.difficultyHardDescDone
                        : Properties.Resources.difficultyHardDesc;
                    break;
            }
        }
    }
}