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
        private int _index;
        private int _index2;
        private int _index3;
        private int _questDone;
        private bool _dead, _deathAnim;

        // Moving platforms
        private int _verticalSpeed = 1;
        private int _horizontalSpeed = 2;
        private readonly Point _verticalPlatformLocation, _horizontalPlatformLocation;

        // Enemies
        private int _enemyAnim;
        private int _easyEnemySpeed = 2;
        private int _mediumEnemySpeed = 5;
        private bool _mediumEnemyLeft, _mediumEnemyAnimLeft;
        private bool _mediumEnemyAnimRight = true;
        private int _hardEnemySpeed = 7;
        private bool _hardEnemyLeft, _hardEnemyAnimLeft;
        private bool _hardEnemyAnimRight = true;
        private readonly Point _easyEnemyLocation, _mediumEnemyLocation, _hardEnemyLocation;

        // End game
        private bool _win, _lose;


        private void GameLoop(object sender, ElapsedEventArgs e)
        {
            if (!_dead)
            {
                PlayerMovement();
                PlayerAnimation();
                EnemyMovement();
                EnemyAnimation();
                PlatformMovement();
                ScoreManagement();
                QuestDone(_questDone);
                foreach (Control x in this.Controls)
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                    {
                        switch (x.Tag)
                        {
                            case "platform":
                                PlatformInteraction(x);
                                break;

                            case "enemy":
                                EnemyInteraction(x);
                                break;

                            case "coins":
                                x.Visible = false;
                                _score++;
                                break;

                            case "powerUp":
                                x.Visible = false;
                                _getPowerUp = true;
                                _questDone = 2;
                                break;
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
            }
            else if (_dead)
            {
                DeathAnimation();
            }

            lblMission.SendToBack();
            player.BringToFront();


            debugLbl.Text = "_index3: " + _index3 + "\n_dead: " + _dead + "_force" + _force;
        }

        private void DeathAnimation()
        {
            _index3++;
            if (_index3 > 15)
            {
                player.Top -= _force;
                _force--;
                if (_force < -15)
                {
                    _force = -15;
                }
            }
        }

        private void EnemyInteraction(Control x)
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
                _dead = true;
                _force = Gravity;
                lblScore.Text = $"Score : {_score}\nYou died, press R to restart";
            }
        }

        private void PlatformInteraction(Control x)
        {
            if (player.Bottom < x.Top + 8)
            {
                _jumping = false;
                _onGround = true;
                player.Top = x.Top - player.Height;
                if (!_dead)
                {
                    _force = 0;
                }
            }
            else if (player.Right > x.Left && player.Left < x.Left - player.Width + 10 && _goRight &&
                     x.Name != "verticalPlatform")
            {
                player.Left = x.Left - player.Width;
            }
            else if (player.Left < x.Right && player.Right > x.Right + player.Width - 10 && _goLeft &&
                     x.Name != "verticalPlatform")
            {
                player.Left = x.Right;
            }
            else if (player.Top < x.Bottom && x.Name != "verticalPlatform")
            {
                player.Top = x.Top + x.Height;
                _force = 0;
            }
        }

        private void QuestDone(int quest)
        {
            switch (quest)
            {
                case 1:
                    lblMission.Text = "You got all the coins, now go to the end to win !";
                    break;
                case 2:
                    lblMission.Text = "You got the powerUp, you can now kill your enemy !";
                    break;
            }
        }


        private void PlayerAnimation()
        {
            _index++;

            if (_goLeft)
            {
                if (!_animLeft)
                {
                    _animLeft = true;
                    _animIdle = _animRight = false;
                    player.Image = _getPowerUp
                        ? Properties.Resources.bylethRunLeftCrest
                        : Properties.Resources.bylethRunLeft;
                }

                if (_index % 12 == 0)
                {
                    player.Image = _getPowerUp
                        ? Properties.Resources.bylethRunLeftCrest
                        : Properties.Resources.bylethRunLeft;
                }
            }
            else if (_goRight)
            {
                if (!_animRight)
                {
                    _animRight = true;
                    _animIdle = _animLeft = false;
                    player.Image = _getPowerUp
                        ? Properties.Resources.bylethRunRightCrest
                        : Properties.Resources.bylethRunRight;
                }

                if (_index % 12 == 0)
                {
                    player.Image = _getPowerUp
                        ? Properties.Resources.bylethRunRightCrest
                        : Properties.Resources.bylethRunRight;
                }
            }
            else if (!_animIdle)
            {
                _animLeft = _animRight = false;
                _animIdle = true;
                player.Image = _getPowerUp ? Properties.Resources.bylethIdleCrest : Properties.Resources.bylethIdle;
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
            {
                _mediumEnemyLeft = !_mediumEnemyLeft;
                _mediumEnemySpeed = -_mediumEnemySpeed;
            }

            hardEnemy.Left += _hardEnemySpeed;
            if (hardEnemy.Left < hardEnemyPlatform.Left ||
                hardEnemy.Left + hardEnemy.Width > hardEnemyPlatform.Left + hardEnemyPlatform.Width)
            {
                _hardEnemyLeft = !_hardEnemyLeft;
                _hardEnemySpeed = -_hardEnemySpeed;
            }
        }

        private void EnemyAnimation()
        {
            _enemyAnim++;
            if (_hardEnemyLeft)
            {
                if (!_hardEnemyAnimLeft)
                {
                    _hardEnemyAnimLeft = true;
                    _hardEnemyAnimRight = false;
                    hardEnemy.Image = Properties.Resources.hardEnemyLeft;
                }

                if (_enemyAnim % 24 == 0)
                {
                    hardEnemy.Image = Properties.Resources.hardEnemyLeft;
                }
            }
            else
            {
                if (!_hardEnemyAnimRight)
                {
                    _hardEnemyAnimRight = true;
                    _hardEnemyAnimLeft = false;
                    hardEnemy.Image = Properties.Resources.hardEnemyRight;
                }

                if (_enemyAnim % 24 == 0)
                {
                    hardEnemy.Image = Properties.Resources.hardEnemyRight;
                }
            }

            //same for medium enemy
            if (_mediumEnemyLeft)
            {
                if (!_mediumEnemyAnimLeft)
                {
                    _mediumEnemyAnimLeft = true;
                    _mediumEnemyAnimRight = false;
                    mediumEnemy.Image = Properties.Resources.mediumEnemyLeft;
                }

                if (_enemyAnim % 24 == 0)
                {
                    mediumEnemy.Image = Properties.Resources.mediumEnemyLeft;
                }
            }
            else
            {
                if (!_mediumEnemyAnimRight)
                {
                    _mediumEnemyAnimRight = true;
                    _mediumEnemyAnimLeft = false;
                    mediumEnemy.Image = Properties.Resources.mediumEnemyRight;
                }

                if (_enemyAnim % 24 == 0)
                {
                    mediumEnemy.Image = Properties.Resources.mediumEnemyRight;
                }
            }
        }
    }
}