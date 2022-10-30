using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Projet_Purple
{
    /* It's the main class of the game, it's the one that makes everything work */
    public sealed partial class GameScreen : Form
    {
        /* The above code is initializing the game screen. */
        public GameScreen()
        {
            InitializeComponent();

            _playerLocation = player.Location;

            _easyEnemyLocation = easyEnemy.Location;
            _mediumEnemyLocation = mediumEnemy.Location;
            _hardEnemyLocation = hardEnemy.Location;

            _verticalPlatformLocation = verticalPlatform.Location;
            _horizontalPlatformLocation = horizontalPlatform.Location;

            DifficultyManagement();
        }


        // Player variables
        private bool _goLeft, _goRight, _jumping, _onGround, _animRight, _animLeft, _animIdle;
        private int _force;
        private const int Gravity = 12;
        private readonly Point _playerLocation;

        // Misc variables
        private int _life = 3;

        private int _score,
            _quest,
            _playerAnimationIndex,
            _questDoneAnimationIndex,
            _deathAnimationIndex,
            _crestAppearIndex;

        private bool _getPowerUp, _questDone1, _questDone2, _questDone3, _pause;

        // Moving platforms
        private int _verticalSpeed = 1;
        private int _horizontalSpeed = 2;
        private readonly Point _verticalPlatformLocation, _horizontalPlatformLocation;

        // Enemies
        private int _enemyAnim, _easyEnemySpeed, _mediumEnemySpeed, _hardEnemySpeed;
        private bool _mediumEnemyLeft, _mediumEnemyAnimLeft, _hardEnemyLeft, _hardEnemyAnimLeft;
        private bool _mediumEnemyAnimRight = true;
        private bool _hardEnemyAnimRight = true;
        private readonly Point _easyEnemyLocation, _mediumEnemyLocation, _hardEnemyLocation;

        // End game
        private bool _win, _lose, _dead;


        /// <summary>
        /// It's the main function of the game, it's the one that makes everything work
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="ElapsedEventArgs">This is the event arguments that are passed to the event handler.</param>
        private void GameLoop(object sender, ElapsedEventArgs e)
        {
            if (!_dead)
            {
                PlayerMovement();
                EnemyMovement();
                PlayerAnimation();
                EnemyAnimation();
                PlatformMovement();
                ScoreManagement();

                /* The above code is checking for collisions between the player and the other objects in the game. */
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
                                    _questDoneAnimationIndex = 0;
                                    _questDone2 = true;
                                }

                                break;
                        }
                    }
                }

                /* The above code is checking if the player has reached the end of the level and if the player has
                collected enough coins. If the player has reached the end of the level and collected enough coins, the
                game will stop and the win screen will be displayed. */
                if (player.Bounds.IntersectsWith(end.Bounds) && _score >= 100)
                {
                    _win = true;
                    gameTimer.Stop();
                    DifficultiesDoneManagement();
                    var winScreen = new WinScreen();
                    winScreen.Show();
                    Hide();
                }

                /* Checking if the player has fallen off the screen. If so, it will display the endLBL and set the text to
                "You lose !\n(Press R to restart)". */
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

                /* Checking if the quest is not equal to 0. If it is not equal to 0, it will call the QuestDone function. */
                if (_quest != 0)
                {
                    QuestDone(_quest);
                }

                /* The above code is checking if the powerUp is visible. If it is, then it will run the
                CrestAppearAnimation method. */
                if (powerUp.Visible)
                {
                    CrestAppearAnimation();
                }


                scoreLBL.Text = "x" + _score;
                lblMission.SendToBack();
                player.BringToFront();
                horizontalPlatform.BringToFront();
                verticalPlatform.BringToFront();
            }
            else if (_dead)
            {
                DeathAnimation();
                DisplayLife();

                /* Checking if the player has gone off the screen. */
                if (player.Top > this.ClientSize.Height)
                {
                    endLBL.Visible = true;
                    endLBL.Text = "You lose !\n(Press R to restart)";
                }

                /* Checking if the quest is not equal to 0. If it is not equal to 0, it will call the QuestDone function. */
                if (_quest != 0)
                {
                    QuestDone(_quest);
                }

                /* The above code is checking if the powerUp is visible. If it is, then it will run the
                CrestAppearAnimation method. */
                if (powerUp.Visible)
                {
                    CrestAppearAnimation();
                }
            }
        }

        

        /// <summary>
        /// CONTROLS
        /// </summary>
        
        /// <summary>
        /// When a key is pressed, the function checks if the key is one of the keys that can be used to control the player,
        /// and if it is, it sets the corresponding boolean to true
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="KeyEventArgs">The event data generated by a KeyDown or KeyUp event.</param>
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            {
                switch (e.KeyCode)
                {
                    case Keys.Q:
                    case Keys.Left:
                        _goLeft = true;
                        break;
                    case Keys.D:
                    case Keys.Right:
                        _goRight = true;
                        break;
                    case Keys.Z:
                    case Keys.Up:
                    case Keys.Space:
                        if (_onGround)
                        {
                            _jumping = true;
                            _onGround = false;
                            _force = Gravity;
                        }

                        break;
                    case Keys.R:
                        if (_win || (_lose && player.Top > this.ClientSize.Height)) Restart();
                        break;
                    case Keys.Escape:
                        if (!_win && !_lose)
                        {
                            _pause = !_pause;
                            if (_pause)
                            {
                                gameTimer.Stop();
                                pauseResumeButton.Visible = true;
                                pauseMenuButton.Visible = true;
                                pauseLeaveButton.Visible = true;
                                pauseResumeButton.BringToFront();
                                pauseMenuButton.BringToFront();
                                pauseLeaveButton.BringToFront();
                            }
                            else
                            {
                                gameTimer.Start();
                                pauseResumeButton.Visible = false;
                                pauseMenuButton.Visible = false;
                                pauseLeaveButton.Visible = false;
                            }
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// If the key is up, then the player is not moving
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="KeyEventArgs">This is the event that is triggered when a key is pressed.</param>
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                case Keys.Left:
                    _goLeft = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    _goRight = false;
                    break;
            }
        }


        
        /// <summary>
        /// MOVEMENT
        /// </summary>
        
        /// <summary>
        /// If the player is moving left, move the player left. If the player is moving right, move the player right. If the
        /// player is jumping, move the player up. If the player is not jumping, move the player down
        /// </summary>
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
        
        /// <summary>
        /// If the platform is at the top of the screen, move it down. If it's at the bottom of the screen, move it up
        /// </summary>
        private void PlatformMovement()
        {
            verticalPlatform.Top += _verticalSpeed;
            if (verticalPlatform.Top < topFlag.Bottom || verticalPlatform.Bottom > bottomFlag.Top)
                _verticalSpeed = -_verticalSpeed;

            horizontalPlatform.Left += _horizontalSpeed;
            if (horizontalPlatform.Left < 300 || horizontalPlatform.Left > 600) _horizontalSpeed = -_horizontalSpeed;
        }

        /// <summary>
        /// The easy enemy moves back and forth on its platform, the medium enemy moves back and forth on its platform, and
        /// the hard enemy moves back and forth between the two flags
        /// </summary>
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
        
        
        
        /// <summary>
        /// COLLISIONS
        /// </summary>
        
        /// <summary>
        /// If the player has a power up, the enemy is removed from the screen and the player's score is increased. If the
        /// player does not have a power up, the player's life is decreased and the player is set to dead
        /// </summary>
        /// <param name="Control">The control that is being interacted with.</param>
        private void EnemyInteraction(Control x)
        {
            if (_getPowerUp)
            {
                x.Visible = false;
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

        /// <summary>
        /// Check the collision between the player and the platforms.
        /// </summary>
        /// <param name="Control">The platform that the player is interacting with.</param>
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
        
        
        
        /// <summary>
        /// ANIMATION
        /// </summary>
        
        /// <summary>
        /// If the player is moving left, then the player's image is set to the left running animation. If the player is
        /// moving right, then the player's image is set to the right running animation. If the player is not moving, then
        /// the player's image is set to the idle animation
        /// </summary>
        private void PlayerAnimation()
        {
            _playerAnimationIndex++;

            if (_goLeft)
            {
                if (!_animLeft)
                {
                    _animLeft = true;
                    _animIdle = _animRight = false;
                    if (OptionScreen.Appearance == "BylethM")
                    {
                        player.Image = _getPowerUp
                            ? Properties.Resources.bylethRunLeftCrest
                            : Properties.Resources.bylethRunLeft;
                    }
                    else
                    {
                        player.Image = _getPowerUp
                            ? Properties.Resources.bylethFRunLeftCrest
                            : Properties.Resources.bylethFRunLeft;
                    }
                }

                if (_playerAnimationIndex % 12 == 0)
                {
                    if (OptionScreen.Appearance == "BylethM")
                    {
                        player.Image = _getPowerUp
                            ? Properties.Resources.bylethRunLeftCrest
                            : Properties.Resources.bylethRunLeft;
                    }
                    else
                    {
                        player.Image = _getPowerUp
                            ? Properties.Resources.bylethFRunLeftCrest
                            : Properties.Resources.bylethFRunLeft;
                    }
                }
            }
            else if (_goRight)
            {
                if (!_animRight)
                {
                    _animRight = true;
                    _animIdle = _animLeft = false;
                    if (OptionScreen.Appearance == "BylethM")
                    {
                        player.Image = _getPowerUp
                            ? Properties.Resources.bylethRunRightCrest
                            : Properties.Resources.bylethRunRight;
                    }
                    else
                    {
                        player.Image = _getPowerUp
                            ? Properties.Resources.bylethFRunRightCrest
                            : Properties.Resources.bylethFRunRight;
                    }
                }

                if (_playerAnimationIndex % 12 == 0)
                {
                    if (OptionScreen.Appearance == "BylethM")
                    {
                        player.Image = _getPowerUp
                            ? Properties.Resources.bylethRunRightCrest
                            : Properties.Resources.bylethRunRight;
                    }
                    else
                    {
                        player.Image = _getPowerUp
                            ? Properties.Resources.bylethFRunRightCrest
                            : Properties.Resources.bylethFRunRight;
                    }
                }
            }
            else if (!_animIdle)
            {
                _animLeft = _animRight = false;
                _animIdle = true;
                if (OptionScreen.Appearance == "BylethM")
                {
                    player.Image = _getPowerUp
                        ? Properties.Resources.bylethIdleCrest
                        : Properties.Resources.bylethIdle;
                }
                else
                {
                    player.Image = _getPowerUp
                        ? Properties.Resources.bylethFIdleCrest
                        : Properties.Resources.bylethFIdle;
                }
            }
        }
        
        /// <summary>
        /// If the enemy is moving left, then the enemy's image is set to the left image, and if the enemy is moving right,
        /// then the enemy's image is set to the right image
        /// </summary>
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
        
        /// <summary>
        /// The function is called every time the timer ticks. It increments the index by one and if the index is greater
        /// than 72, it changes the image to the final image
        /// </summary>
        private void CrestAppearAnimation()
        {
            _crestAppearIndex++;
            if (_crestAppearIndex > 72)
            {
                powerUp.Image = Properties.Resources.Crest_of_Flames;
            }
        }

        /// <summary>
        /// If the player is dead, then the player's sprite is sent to the back of the screen, the death animation index is
        /// incremented, and if the death animation index is greater than 15, then the player's sprite is moved up the
        /// screen and the force is decremented (animation like Mario dying).
        /// </summary>
        private void DeathAnimation()
        {
            player.SendToBack();
            _deathAnimationIndex++;
            if (_deathAnimationIndex > 15)
            {
                player.Top -= _force;
                _force--;
                if (_force < -15)
                {
                    _force = -15;
                }
            }
        }
        
        
        
        /// <summary>
        /// RESTART
        /// </summary>
        
        /// <summary>
        /// It resets the game to its original state
        /// </summary>
        private void Restart()
        {
            gameTimer.Start();
            // Reset all necessary variables
            lblMission.Visible = _questDone1 =
                _questDone2 = _questDone3 = endLBL.Visible = _animIdle = _win = _dead = _lose = false;
            _quest = _playerAnimationIndex = _questDoneAnimationIndex = _deathAnimationIndex = _score = 0;

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
        
        
        
        /// <summary>
        /// MISCELLANEOUS
        /// </summary>
        
        /// <summary>
        /// If the player has scored 50 points, the power up will appear. If the player has scored 100 points, the door will
        /// open
        /// </summary>
        private void ScoreManagement()
        {
            if (_score >= 50 && !_getPowerUp)
            {
                if (!_questDone1)
                {
                    _quest = 1;
                    _questDoneAnimationIndex = 0;
                    _questDone1 = true;
                }

                powerUp.Visible = true;
            }

            if (_score >= 100)
            {
                if (!_questDone3)
                {
                    _quest = 3;
                    _questDoneAnimationIndex = 0;
                    _questDone3 = true;
                }

                end.Image = Properties.Resources.openDoor;
            }
        }
        
        /// <summary>
        /// If the quest is done, show the label and move it to the left, then move it back to the right.
        /// </summary>
        /// <param name="quest">The quest that has been completed.</param>
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

            if (_questDoneAnimationIndex <= 1 && quest != 0)
            {
                lblMission.Visible = true;
                lblMission.Left = this.ClientSize.Width;
            }
            else if (_questDoneAnimationIndex > 0 && _questDoneAnimationIndex < 38)
            {
                lblMission.Left -= 10;
            }
            else if (_questDoneAnimationIndex > 130)
            {
                lblMission.Left += 10;
            }

            if (_questDoneAnimationIndex > 200)
            {
                _quest = 0;
                _questDoneAnimationIndex = 0;
            }

            _questDoneAnimationIndex++;
        }
        
        /// <summary>
        /// This function displays the number of lives the player has left (show the game over screen if the player has
        /// 0 lives left).
        /// </summary>
        private void DisplayLife()
        {
            switch (_life)
            {
                case 0:
                    _lose = true;
                    gameTimer.Stop();
                    var gameOver = new GameOver();
                    gameOver.Show();
                    Hide();
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
        
        /// <summary>
        /// This function is used to manage the difficulty of the game (change the enemies shown and their speed).
        /// </summary>
        private void DifficultyManagement()
        {
            switch (ChangeDifficultyScreen.Difficulty)
            {
                case "peaceful":
                    easyEnemy.Visible = false;
                    mediumEnemy.Visible = false;
                    hardEnemy.Visible = false;
                    break;
                case "easy":
                    easyEnemy.Visible = true;
                    mediumEnemy.Visible = true;
                    hardEnemy.Visible = false;
                    _easyEnemySpeed = 1;
                    _mediumEnemySpeed = 2;
                    break;
                case "medium":
                    easyEnemy.Visible = true;
                    mediumEnemy.Visible = true;
                    hardEnemy.Visible = true;
                    _easyEnemySpeed = 2;
                    _mediumEnemySpeed = 3;
                    _hardEnemySpeed = 4;
                    break;
                case "hard":
                    easyEnemy.Visible = true;
                    mediumEnemy.Visible = true;
                    hardEnemy.Visible = true;
                    _easyEnemySpeed = 4;
                    _mediumEnemySpeed = 5;
                    _hardEnemySpeed = 6;
                    break;
            }
        }

        /// <summary>
        /// It sets the difficulty to done if the player has completed it. Unlock the hard difficulty if the player has
        /// done all the difficulties.
        /// </summary>
        private static void DifficultiesDoneManagement()
        {
            switch (ChangeDifficultyScreen.Difficulty)
            {
                case "peaceful":
                    ChangeDifficultyScreen.PeacefulDone = true;
                    break;
                case "easy":
                    ChangeDifficultyScreen.EasyDone = true;
                    break;
                case "medium":
                    ChangeDifficultyScreen.MediumDone = true;
                    break;
                case "hard":
                    ChangeDifficultyScreen.HardDone = true;
                    break;
            }

            if (ChangeDifficultyScreen.PeacefulDone && ChangeDifficultyScreen.EasyDone &&
                ChangeDifficultyScreen.MediumDone)
            {
                ChangeDifficultyScreen.HardUnlocked = true;
            }
        }
        


        /// <summary>
        /// RESUME BUTTON MANAGEMENT
        /// </summary>
        private void pauseResumeButton_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
            pauseResumeButton.Visible = false;
            pauseMenuButton.Visible = false;
            pauseLeaveButton.Visible = false;
        }

        private void pauseResumeButton_MouseEnter(object sender, EventArgs e)
        {
            pauseResumeButton.Image = Properties.Resources.buttonPauseResume;
        }

        private void pauseResumeButton_MouseLeave(object sender, EventArgs e)
        {
            pauseResumeButton.Image = Properties.Resources.buttonPauseResumeLow;
        }


        /// <summary>
        /// MENU BUTTON MANAGEMENT
        /// </summary>
        private void pauseMenuButton_Click(object sender, EventArgs e)
        {
            var titleScreen = new TitleScreen();
            titleScreen.Show();
            Hide();
        }

        private void pauseMenuButton_MouseEnter(object sender, EventArgs e)
        {
            pauseMenuButton.Image = Properties.Resources.buttonPauseMenu;
        }

        private void pauseMenuButton_MouseLeave(object sender, EventArgs e)
        {
            pauseMenuButton.Image = Properties.Resources.buttonPauseMenuLow;
        }


        /// <summary>
        /// LEAVE BUTTON MANAGEMENT
        /// </summary>
        private void pauseLeaveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pauseLeaveButton_MouseEnter(object sender, EventArgs e)
        {
            pauseLeaveButton.Image = Properties.Resources.buttonPauseLeave;
        }

        private void pauseLeaveButton_MouseLeave(object sender, EventArgs e)
        {
            pauseLeaveButton.Image = Properties.Resources.buttonPauseLeaveLow;
        }
    }
}