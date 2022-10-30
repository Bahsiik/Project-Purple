using System;
using System.Timers;
using System.Windows.Forms;

namespace Projet_Purple
{
    /* It's a form that displays the win screen */
    public sealed partial class WinScreen : Form
    {
        /* It's the constructor of the form. It initializes the components and sets the background image. */
        public WinScreen()
        {
            InitializeComponent();
            BackgroundImage = "BylethM".Equals(OptionScreen.Appearance)
                ? Properties.Resources.winBackgroundM
                : Properties.Resources.winBackgroundF;
        }

        /* It's a variable that is used to count the number of times the timer has elapsed. */
        private int _index;
        
        /// <summary>
        /// The function is called every time the timer ticks. It increments the index, and if the index is less than or
        /// equal to 1, it makes the winTitle label visible and sets its top property to 0 - winTitle.Height. If the
        /// winTitle label's top property plus its height is less than 90, it increments the winTitle label's top property
        /// by 2. Otherwise, it makes the buttonMenu and buttonLeave buttons visible
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="ElapsedEventArgs">This is the event that is triggered when the timer has elapsed.</param>
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
        
        
        /// <summary>
        /// MENU BUTTON MANAGEMENT
        /// </summary>

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
        
        
        /// <summary>
        /// LEAVE BUTTON MANAGEMENT
        /// </summary>


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