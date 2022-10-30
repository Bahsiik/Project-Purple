using System;
using System.Windows.Forms;

namespace Projet_Purple
{
    /* This class is the main menu of the game. It has three buttons: Start, Option, and Quit. The Start button will start
    the game, the Option button will open the option menu, and the Quit button will quit the game */
    public sealed partial class TitleScreen : Form
    {
        
        /* Creating a new instance of the OptionScreen class. */
        private readonly OptionScreen  _optionScreen = new OptionScreen();
        /* This is the constructor of the TitleScreen class. It initializes the components of the form and checks if the
        player has completed the hard mode. If the player has completed the hard mode, the background image of the title
        screen will be changed. */
        public TitleScreen()
        {
            InitializeComponent();
            if (ChangeDifficultyScreen.HardDone)
            {
                BackgroundImage = Properties.Resources.titleBackground2;
            }
        }

        /// <summary>
        /// The function StartGame is called when the user clicks the "Start Game" button. It creates a new GameScreen
        /// object and shows it, while hiding the current screen
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">This is a class that contains no data. It is used by events that do not need to pass any
        /// additional information to an event handler when an event is raised.</param>
        private void StartGame(object sender, EventArgs e)
        {
            var gameScreen = new GameScreen();
            gameScreen.Show();
            this.Hide();
        }
        
        /// <summary>
        /// This function is called when the user clicks on the "Options" button. It displays the options screen and hides
        /// the main menu screen.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">This is a class that contains no data. It is used by events that do not pass any data to
        /// an event handler when an event is raised.</param>
        private void DisplayOption(object sender, EventArgs e)
        {
            _optionScreen.Show();
            this.Hide();
        }

        /// <summary>
        /// This function is called when the user clicks the "Quit" button. It closes the application
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">This is a class that contains no data. It is used by events that do not need to pass any
        /// additional information to an event handler when an event is raised.</param>
        private void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// START BUTTON MANAGEMENT
        /// </summary>

        private void StartButton_Enter(object sender, EventArgs e)
        {
            startButton.Image = Properties.Resources.mainButtonText;
        }
        
        private void StartButton_Leave(object sender, EventArgs e)
        {
            startButton.Image = Properties.Resources.mainButtonTextLow;
        }
        
        
        /// <summary>
        /// OPTION BUTTON MANAGEMENT
        /// </summary>

        private void OptionButton_Enter(object sender, EventArgs e)
        {
            optionButton.Image = Properties.Resources.buttonOption;
        }
        
        private void OptionButton_Leave(object sender, EventArgs e)
        {
            optionButton.Image = Properties.Resources.buttonOptionLow;
        }
        
        
        /// <summary>
        /// QUIT BUTTON MANAGEMENT
        /// </summary>
        
        private void QuitButton_Enter(object sender, EventArgs e)
        {
            quitButton.Image = Properties.Resources.buttonQuit;
        }
        
        private void QuitButton_Leave(object sender, EventArgs e)
        {
            quitButton.Image = Properties.Resources.buttonQuitLow;
        }
    }
}