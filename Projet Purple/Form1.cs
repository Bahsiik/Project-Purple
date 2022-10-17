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
        private bool _goLeft, _goRight, _jumping, _onGround, _animRight, _animLeft, _animIdle;
        private int _force;
        private readonly Point _playerLocation;

        // Misc variables
        private int _score;
        private bool _getPowerUp;
        private const int Gravity = 12;
        private int index;

        // Moving platforms
        private int _verticalSpeed = 1;
        private int _horizontalSpeed = 2;
        private readonly Point _verticalPlatformLocation, _horizontalPlatformLocation;

        // Enemies
        private int _easyEnemySpeed = 2;
        private int _mediumEnemySpeed = 3;
        private int _hardEnemySpeed = 4;
        private readonly Point _easyEnemyLocation, _mediumEnemyLocation, _hardEnemyLocation;


        // End game
        private bool _win, _lose;

        private void GameLoop(object sender, ElapsedEventArgs e)
        {
            PlayerMovement();
            PlayerAnimation();
            EnemyMovement();
            PlatformMovement();
            ScoreManagement();
            
            debugLbl.Text = "_animRight: " + _animRight + "\n_animLeft: " + _animLeft + "\n_animIdle: " + _animIdle;


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        /* It's checking if the player is touching a platform. */
                        if (player.Bottom < x.Top + 8)
                        {
                            /* It's checking if the player is on the ground. */
                            _jumping = false;
                            _onGround = true;
                            player.Top = x.Top - player.Height;
                            _force = 0;
                        }
                        /* It's checking if the player touch the left side of a platform. */
                        else if (player.Right > x.Left && _goRight &&
                                 player.Left < x.Left)
                        {
                            player.Left = x.Left - player.Width;
                        }
                        /* It's checking if the player touch the right side of a platform. */
                        else if (player.Left < x.Right && _goLeft &&
                                 player.Right > x.Right)
                        {
                            player.Left = x.Right;
                        }
                        /* It's checking if the player touch the bottom of a platform. */
                        else if (player.Top < x.Top + x.Height)
                        {
                            player.Top = x.Top + x.Height;
                            _force = 0;
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible && _getPowerUp)
                    {
                        x.Visible = false;
                        _score += 1;
                    }
                    else if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                    {
                        _lose = true;
                        player.BackColor = Color.Gray;
                        gameTimer.Stop();
                        lblScore.Text = $"Score : {_score}\nYou died, press R to restart";
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

            if (player.Top > this.ClientSize.Height)
            {
                _lose = true;
                lblScore.Text = $"Score : {_score}\nYou died, press R to restart";
            }

            player.BringToFront();
        }

        private void PlayerAnimation()
        {
            index++;

            if (_goLeft)
            {
                if (!_animLeft)
                {
                    _animLeft = true;
                    _animIdle = _animRight = false;
                    player.Image = Properties.Resources.bylethRunLeft;
                }

                if (index % 12 == 0)
                {
                    player.Image = Properties.Resources.bylethRunLeft;
                }
            }
            else if (_goRight)
            {
                if (!_animRight)
                {
                    _animRight = true;
                    _animIdle =_animLeft = false;
                    player.Image = Properties.Resources.bylethRunRight;
                }

                if (index % 12 == 0)
                {
                    player.Image = Properties.Resources.bylethRunRight;
                }
            }
            else if (!_animIdle)
            {
                _animLeft = _animRight = false;
                _animIdle = true;
                player.Image = Properties.Resources.bylethIdle;
            }
        }

        private void PlayerMovement()
        {
            if (_goLeft) player.Left -= 5;

            if (_goRight) player.Left += 5;

            if (player.Left < 0) player.Left = 0;
            if (player.Right > this.ClientSize.Width) player.Left = this.ClientSize.Width - player.Width;

            if (_jumping)
            {
                _onGround = false;
                player.Top -= _force;
                _force--;
                if (_force < -6)
                {
                    _force = -6;
                }
            }
            else
            {
                _onGround = false;
                _force--;
                player.Top -= _force;
                if (_force < -6)
                {
                    _force = -6;
                }
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
                        if (_onGround)
                        {
                            _jumping = true;
                            _onGround = false;
                            _force = Gravity;
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

            // Reset visibility
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "coins") x.Visible = true;
                if (x is PictureBox && (string)x.Tag == "enemy") x.Visible = true;
            }

            // Reset powerUp
            _getPowerUp = false;
            powerUp.Visible = false;
            player.BackColor = Color.Blue;

            // Reset end
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
                case 15 when !_getPowerUp:
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
            if (verticalPlatform.Top < 175 || verticalPlatform.Top > 300) _verticalSpeed = -_verticalSpeed;

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