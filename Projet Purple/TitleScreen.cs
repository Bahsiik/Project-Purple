using System;
using System.Windows.Forms;

namespace Projet_Purple
{
    public partial class TitleScreen : Form
    {
        
        private readonly GameScreen  _gameScreen = new GameScreen();
        private readonly OptionScreen  _optionScreen = new OptionScreen();
        public TitleScreen()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, EventArgs e)
        {
            _gameScreen.Show();
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

    }
}