using System;
using System.Windows.Forms;

namespace Projet_Purple
{
    public partial class TitleScreen : Form
    {
        
        private readonly OptionScreen  _optionScreen = new OptionScreen();
        public TitleScreen()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, EventArgs e)
        {
            var gameScreen = new GameScreen();
            gameScreen.Show();
            this.Hide();
        }
        
        private void DisplayOption(object sender, EventArgs e)
        {
            _optionScreen.Show();
            this.Hide();
        }

        private void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void StartButton_Enter(object sender, EventArgs e)
        {
            startButton.Image = Properties.Resources.mainButtonText;
        }
        
        private void StartButton_Leave(object sender, EventArgs e)
        {
            startButton.Image = Properties.Resources.mainButtonTextLow;
        }

        private void OptionButton_Enter(object sender, EventArgs e)
        {
            optionButton.Image = Properties.Resources.buttonOption;
        }
        
        private void OptionButton_Leave(object sender, EventArgs e)
        {
            optionButton.Image = Properties.Resources.buttonOptionLow;
        }
        
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