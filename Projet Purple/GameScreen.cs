﻿using System.Drawing;
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
        private int _quest;
        private bool _dead;
        private int _crestAppearIndex;
        private bool _questDone1, _questDone2, _questDone3;
        private int _life = 3;

        // Moving platforms
        private int _verticalSpeed = 1;
        private int _horizontalSpeed = 2;
        private readonly Point _verticalPlatformLocation, _horizontalPlatformLocation;

        // Enemies
        private int _enemyAnim;
        private int _easyEnemySpeed = 2;
        private int _mediumEnemySpeed = 4;
        private bool _mediumEnemyLeft, _mediumEnemyAnimLeft;
        private bool _mediumEnemyAnimRight = true;
        private int _hardEnemySpeed = 6;
        private bool _hardEnemyLeft, _hardEnemyAnimLeft;
        private bool _hardEnemyAnimRight = true;
        private readonly Point _easyEnemyLocation, _mediumEnemyLocation, _hardEnemyLocation;

        // End game
        private bool _win, _lose;


        private void GameLoop(object sender, ElapsedEventArgs e)
        {
            label1.Text = "Life: " + _life;
            if (!_dead)
            {
                PlayerMovement();
                PlayerAnimation();
                EnemyMovement();
                EnemyAnimation();
                PlatformMovement();
                ScoreManagement();

                
                

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

                            case "coins1":
                                x.Visible = false;
                                _score++;
                                break;

                            case "coins5":
                                x.Visible = false;
                                _score += 5;
                                break;

                            case "coins10":
                                x.Visible = false;
                                _score += 10;
                                break;

                            case "coins25":
                                x.Visible = false;
                                _score += 25;
                                break;

                            case "coins50":
                                x.Visible = false;
                                _score += 50;
                                break;

                            case "powerUp":
                                x.Visible = false;
                                _getPowerUp = true;
                                if (!_questDone2)
                                {
                                    _quest = 2;
                                    _index2 = 0;
                                    _questDone2 = true;
                                }

                                break;
                        }
                    }
                }
                
                if (player.Bounds.IntersectsWith(end.Bounds) && _score >= 100)
                {
                    _win = true;
                    endLBL.Visible = true;
                    endLBL.Text = "You win !\n(Press R to restart)";
                    gameTimer.Stop();
                }

                if (player.Top > this.ClientSize.Height)
                {
                    if (!_lose)
                    {
                        _life--;                
                    }
                    DisplayLife();

                    _lose = true;
                    endLBL.Visible = true;
                    endLBL.Text = "You lose !\n(Press R to restart)";
                }
                
                if (_quest != 0)
                {
                    QuestDone(_quest);
                }

                if (powerUp.Visible)
                {
                    CrestAppearAnimation();
                }

                

                scoreLBL.Text = "Score: " + _score;
                lblMission.SendToBack();
                player.BringToFront();
                horizontalPlatform.BringToFront();
                verticalPlatform.BringToFront();
            }
            else if (_dead)
            {
                DeathAnimation();
                
                DisplayLife();
                
                if (player.Top > this.ClientSize.Height)
                {
                    endLBL.Visible = true;
                    endLBL.Text = "You lose !\n(Press R to restart)";
                }
                
                if (_quest != 0)
                {
                    QuestDone(_quest);
                }
                
                if (powerUp.Visible)
                {
                    CrestAppearAnimation();
                }
            }
        }

        private void DisplayLife()
        {
            switch (_life)
            {
                case 0:
                    _lose = true;
                    heart1.Visible = false;
                    heart2.Visible = false;
                    heart3.Visible = false;
                    break;
                case 1:
                    heart1.Visible = true;
                    heart2.Visible = false;
                    heart3.Visible = false;
                    break;
                case 2:
                    heart1.Visible = true;
                    heart2.Visible = true;
                    heart3.Visible = false;
                    break;
                case 3:
                    heart1.Visible = true;
                    heart2.Visible = true;
                    heart3.Visible = true;
                    break;
            }
        }


        private void QuestDone(int quest)
        {
            switch (quest)
            {
                case 1:
                    lblMission.Text = "The Fire Emblem has appeared!";
                    break;
                case 2:
                    lblMission.Text = "You got the Fire Emblem,\nyou can now kill your enemy!";
                    break;
                case 3:
                    lblMission.Text = "You got all the rupees,\nyou can now go to the end!";
                    break;
            }

            if (_index2 <= 1 && quest != 0)
            {
                lblMission.Visible = true;
                lblMission.Left = this.ClientSize.Width;
            }
            else if (_index2 > 0 && _index2 < 38)
            {
                lblMission.Left -= 10;
            }
            else if (_index2 > 130)
            {
                lblMission.Left += 10;
            }
            if (_index2 > 200)
            {
                _quest = 0;
                _index2 = 0;
            }

            _index2++;
        }

        private void ScoreManagement()
        {
            if (_score >= 50 && !_getPowerUp)
            {
                if (!_questDone1)
                {
                    _quest = 1;
                    _index2 = 0;
                    _questDone1 = true;
                }

                powerUp.Visible = true;
            }

            if (_score >= 100)
            {
                if (!_questDone3)
                {
                    _quest = 3;
                    _index2 = 0;
                    _questDone3 = true;
                }
                end.Image = Properties.Resources.openDoor;
            }
        }

        private void CrestAppearAnimation()
        {
            _crestAppearIndex++;
            if (_crestAppearIndex > 72)
            {
                powerUp.Image = Properties.Resources.Crest_of_Flames;
            }
        }

        private void DeathAnimation()
        {
            player.SendToBack();
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
                _life--;

                _lose = true;
                _dead = true;
                player.Image = Properties.Resources.deathFrame;
                _force = Gravity;
            }
        }

        private void PlatformInteraction(Control x)
        {
            if (player.Bottom < x.Top + 8 && _force < 0 && !_dead)
            {
                _jumping = false;
                _onGround = true;
                player.Top = x.Top - player.Height;
                _force = 0;
                if (x.Name == "horizontalPlatform")
                {
                    player.Left += _horizontalSpeed;
                }
            }
            else if (player.Right > x.Left && player.Left < x.Left - player.Width + 10 && _goRight &&
                     x.Name != "verticalPlatform" && x.Name != "horizontalPlatform")
            {
                player.Left = x.Left - player.Width;
            }
            else if (player.Left < x.Right && player.Right > x.Right + player.Width - 10 && _goLeft &&
                     x.Name != "verticalPlatform" && x.Name != "horizontalPlatform")
            {
                player.Left = x.Right;
            }
            else if (player.Top < x.Bottom && x.Name != "verticalPlatform" && x.Name != "horizontalPlatform" && !_dead)
            {
                player.Top = x.Top + x.Height;
                _force = 0;
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
                    if ((_win || _lose) && player.Top > this.ClientSize.Height ) Restart();
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
            _dead = false;
            _animIdle = false;
            _index3 = 0;
            _index2 = 0;
            _index = 0;
            endLBL.Visible = false;
            _questDone1 = _questDone2 = _questDone3 = false;
            _quest = 0;
            lblMission.Visible = false;

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
                if (x is PictureBox && (string)x.Tag == "coins1") x.Visible = true;
                if (x is PictureBox && (string)x.Tag == "coins5") x.Visible = true;
                if (x is PictureBox && (string)x.Tag == "coins10") x.Visible = true;
                if (x is PictureBox && (string)x.Tag == "coins25") x.Visible = true;
                if (x is PictureBox && (string)x.Tag == "coins50") x.Visible = true;
                if (x is PictureBox && (string)x.Tag == "enemy") x.Visible = true;
            }

            // Reset powerUp
            _getPowerUp = false;
            powerUp.Visible = false;

            // Reset end
            end.Image = Properties.Resources.closedDoor;
        }


        private void PlatformMovement()
        {
            verticalPlatform.Top += _verticalSpeed;
            if (verticalPlatform.Top < topFlag.Bottom || verticalPlatform.Bottom > bottomFlag.Top)
                _verticalSpeed = -_verticalSpeed;

            horizontalPlatform.Left += _horizontalSpeed;
            if (horizontalPlatform.Left < 300 || horizontalPlatform.Left > 600) _horizontalSpeed = -_horizontalSpeed;
        }

        private void EnemyMovement()
        {
            easyEnemy.Left += _easyEnemySpeed;
            if (easyEnemy.Left < easyEnemyPlatform.Left || easyEnemy.Right > easyEnemyPlatform.Right)
                _easyEnemySpeed = -_easyEnemySpeed;

            mediumEnemy.Left += _mediumEnemySpeed;
            if (mediumEnemy.Left < mediumEnemyPlatform.Left || mediumEnemy.Right > mediumEnemyPlatform.Right)
            {
                _mediumEnemyLeft = !_mediumEnemyLeft;
                _mediumEnemySpeed = -_mediumEnemySpeed;
            }

            hardEnemy.Left += _hardEnemySpeed;
            if (hardEnemy.Left < leftFlag.Right || hardEnemy.Right > rightFlag.Left)
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