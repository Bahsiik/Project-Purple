using System;
using System.Timers;
using System.Windows.Forms;

namespace Projet_Purple
{
    /* It's a form that displays the game over screen */
    public sealed partial class GameOver : Form
    {
        /* It's the constructor of the class. */
        public GameOver()
        {
            InitializeComponent();
        }

        /* It's a variable that is used to count the number of times the timer has elapsed. */
        private int _index;


        /// <summary>
        /// The function is called when the timer is elapsed. It makes the game over title visible and moves it down until
        /// it reaches a certain place of the screen. Then it makes the tip label, the menu button and the leave button visible
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="ElapsedEventArgs">The ElapsedEventArgs class contains the event data associated with an Elapsed
        /// event.</param>
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


        /// <summary>
        /// When the button is clicked, the title screen is shown and the current screen is closed
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            var titleScreen = new TitleScreen();
            titleScreen.Show();
            Close();
        }

        /// <summary>
        /// MENU BUTTON (mouse enter and leave)
        /// </summary>
        private void buttonMenu_MouseEnter(object sender, EventArgs e)
        {
            buttonMenu.Image = Properties.Resources.buttonPauseMenu;
        }

        private void buttonMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonMenu.Image = Properties.Resources.buttonPauseMenuLow;
        }


        /// <summary>
        /// This function closes the application when the user clicks the "Leave" button
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">This is a class that contains the event data.</param>
        private void buttonLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// LEAVE BUTTON (mouse enter and leave)
        /// </summary>
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