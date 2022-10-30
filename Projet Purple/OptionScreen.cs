using System;
using System.Windows.Forms;

namespace Projet_Purple
{
    public partial class OptionScreen : Form
    {
        public static string Appearance = "BylethM";
        
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

        private void AppearanceBylethMClick(object sender, EventArgs e)
        {
            Appearance = "BylethM";
        }

        private void AppearanceBylethFClick(object sender, EventArgs e)
        {
            Appearance = "BylethF";
        }
    }
}