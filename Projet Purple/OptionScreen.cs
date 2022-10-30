using System;
using System.Windows.Forms;

namespace Projet_Purple
{
    public partial class OptionScreen : Form
    {
        public OptionScreen()
        {
            InitializeComponent();
        }


        private void BackMenuButton(object sender, EventArgs e)
        {
            this.Hide();
            var titleScreen = new TitleScreen();
            titleScreen.Show();
        }
    }
}