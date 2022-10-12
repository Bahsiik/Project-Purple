using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Projet_Purple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _playerLocation = player.Location;

            _easyEnemyLocation = easyEnemy.Location;
            _mediumEnemyLocation = mediumEnemy.Location;
            _hardEnemyLocation = hardEnemy.Location;

            _verticalPlatformLocation = verticalPlatform.Location;
            _horizontalPlatformLocation = horizontalPlatform.Location;
        }

        // Player variables
        private bool _goLeft;
        private bool _goRight;
        private bool _jumping;
        private int _jumpSpeed = 10;
        private int _force = 8;
        private bool _onGround;
        private readonly Point _playerLocation;

        // Misc variables
        private int _score;
        private bool _getPowerUp;

        // Moving platforms
        private int _verticalSpeed = 2;
        private readonly Point _verticalPlatformLocation;
        private int _horizontalSpeed = 2;
        private readonly Point _horizontalPlatformLocation;

        // Enemies
        private int _easyEnemySpeed = 2;
        private readonly Point _easyEnemyLocation;
        private int _mediumEnemySpeed = 3;
        private readonly Point _mediumEnemyLocation;
        private int _hardEnemySpeed = 4;
        private readonly Point _hardEnemyLocation;

        // End game
        private bool _win;
        private bool _lose;

        private void GameLoop(object sender, ElapsedEventArgs e)
        {
            PlayerMovement();
            EnemyMovement();
            PlatformMovement();
            
            ScoreManagement();
            
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    x.BringToFront();
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (player.Top + player.Height < x.Top + (x.Height / 3))
                        {
                            _force = 8;
                            player.Top = x.Top - player.Height;
                            _onGround = true;
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                    {
                        if (_getPowerUp)
                        {
                            x.Visible = false;
                            _score += 1;
                        }
                        else
                        {
                            _lose = true;
                            player.BackColor = Color.Gray;
                            gameTimer.Stop();
                            lblScore.Text = $"Score : {_score}\nYou died, press R to restart";
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "coins")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                    {
                        x.Visible = false;
                        _score++;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "powerUp")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                    {
                        x.Visible = false;
                        _getPowerUp = true;
                        player.BackColor = Color.Purple;
                    }
                }
            }

            

            if (player.Bounds.IntersectsWith(end.Bounds) && end.BackColor == Color.Chartreuse)
            {
                _win = true;
                gameTimer.Stop();
                lblScore.Text = $"Score : {_score}\nYou won, press R to restart";
            }

            if (player.Top + player.Height > this.ClientSize.Height + 60)
            {
                _lose = true;
                lblScore.Text = $"Score : {_score}\nYou died, press R to restart";
            }
            
            
        }

        private void PlayerMovement()
        {
            player.Top += _jumpSpeed;
            if (player.Left < 0) _goLeft = false;
            if (player.Right > this.ClientSize.Width) _goRight = false;
            if (_jumping && _force < 0) _jumping = false;
            if (_goLeft) player.Left -= 5;
            if (_goRight) player.Left += 5;
            if (_jumping && _force > 0 && _onGround)
            {
                _jumpSpeed = -10;
                _force -= 1;
            }
            else
            {
                _jumpSpeed = 5;
                _onGround = false;
            }
        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        _goLeft = true;
                        break;
                    case Keys.Right:
                        _goRight = true;
                        break;
                    case Keys.Space:
                        if (!_jumping)
                        {
                            _jumping = true;
                            _onGround = false;
                        }

                        break;
                }
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _goLeft = false;
                    break;
                case Keys.Right:
                    _goRight = false;
                    break;
                case Keys.Space:
                    _jumping = false;
                    break;
                case Keys.R:
                    if (_win || _lose) Restart();
                    break;
            }
        }

        // Reload the game
        private void Restart()
        {
            gameTimer.Start();
            _lose = false;
            _win = false;
            _score = 0;

            // Reset player position
            player.Location = _playerLocation;

            // Reset enemies position
            easyEnemy.Location = _easyEnemyLocation;
            mediumEnemy.Location = _mediumEnemyLocation;
            hardEnemy.Location = _hardEnemyLocation;

            // Reset platforms position
            verticalPlatform.Location = _verticalPlatformLocation;
            horizontalPlatform.Location = _horizontalPlatformLocation;

            // set visibility
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "coins") x.Visible = true;
                if (x is PictureBox && (string)x.Tag == "enemy") x.Visible = true;
            }

            // reset powerUp
            _getPowerUp = false;
            powerUp.Visible = false;
            player.BackColor = Color.Blue;
            
            end.BackColor = Color.Black;
        }


        private void ScoreManagement()
        {
            lblScore.Text = _score < 10
                ? $"Score : {_score}\nYou need at least 10 coins to open the gate"
                : $"Score : {_score}\nThe gate is now open, you can end the game";
            
            switch (_score)
            {
                case 10:
                    end.BackColor = Color.Chartreuse;
                    break;
                case 15:
                    powerUp.Visible = true;
                    break;
                case 20:
                    lblScore.Text = "You collected the 20 coins, go to the end to win !";
                    break;
            }
        }

        private void PlatformMovement()
        {
            verticalPlatform.Top += _verticalSpeed;
            if (verticalPlatform.Top < 200 || verticalPlatform.Top > 435) _verticalSpeed = -_verticalSpeed;

            horizontalPlatform.Left += _horizontalSpeed;
            if (horizontalPlatform.Left < 300 || horizontalPlatform.Left > 550) _horizontalSpeed = -_horizontalSpeed;
        }

        private void EnemyMovement()
        {
            easyEnemy.Left += _easyEnemySpeed;
            if (easyEnemy.Left < easyEnemyPlatform.Left ||
                easyEnemy.Left + easyEnemy.Width > easyEnemyPlatform.Left + easyEnemyPlatform.Width)
                _easyEnemySpeed = -_easyEnemySpeed;

            mediumEnemy.Left += _mediumEnemySpeed;
            if (mediumEnemy.Left < mediumEnemyPlatform.Left ||
                mediumEnemy.Left + mediumEnemy.Width > mediumEnemyPlatform.Left + mediumEnemyPlatform.Width)
                _mediumEnemySpeed = -_mediumEnemySpeed;

            hardEnemy.Left += _hardEnemySpeed;
            if (hardEnemy.Left < hardEnemyPlatform.Left ||
                hardEnemy.Left + hardEnemy.Width > hardEnemyPlatform.Left + hardEnemyPlatform.Width)
                _hardEnemySpeed = -_hardEnemySpeed;
        }
    }
}