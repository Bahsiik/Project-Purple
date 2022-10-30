using System;
using System.Windows.Forms;

namespace Projet_Purple
{
    public partial class TitleScreen : Form
    {
        
        Form1 f1 = new Form1();
        public TitleScreen()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, EventArgs e)
        {
            f1.Show();
            this.Hide();
        }
        
        private void DisplayOption(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}