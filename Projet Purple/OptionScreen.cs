using System;
using System.Timers;
using System.Windows.Forms;

namespace Projet_Purple
{
    /* It's a form that allows the user to change the appearance of the main character and see the bindings */
    public sealed partial class OptionScreen : Form
    {
        /* It's a variable that allows to know which character is selected. */
        public static string Appearance = "BylethM";
        
        /* It's the constructor of the class. It's called when the form is created. */
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

        
        /// <summary>
        /// When the user clicks on the BylethM button, the Appearance variable is set to "BylethM" and the BylethF button's
        /// image is set to the grayed version of Byleth's portrait, while the BylethM button's image is set to the
        /// colored version of Byleth's portrait
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
        private void BylethM_Click(object sender, EventArgs e)
        {
            Appearance = "BylethM";
            BylethM.Image = Properties.Resources.bylethPortrait;
            BylethF.Image = Properties.Resources.bylethFPortraitGray;
        }

        /// <summary>
        /// When the user clicks on the BylethF button, the Appearance variable is set to "BylethF" and the BylethM button's
        /// image is set to the grayed out version of Byleth's portrait, while the BylethF button's image is set to the
        /// colored version of Byleth's portrait
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
        private void BylethF_Click(object sender, EventArgs e)
        {
            Appearance = "BylethF";
            BylethM.Image = Properties.Resources.bylethPortraitGray;
            BylethF.Image = Properties.Resources.bylethFPortrait;
        }
        
        
        /// <summary>
        /// BYLETHM & BYLETHF BUTTONS MANAGEMENT
        /// </summary>

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
        
        
        /// <summary>
        /// BACK BUTTON MANAGEMENT
        /// </summary>
        
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
        
        
        /// <summary>
        /// CHANGE DIFFICULTY BUTTON MANAGEMENT
        /// </summary>
        
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