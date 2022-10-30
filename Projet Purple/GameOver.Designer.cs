using System.ComponentModel;

namespace Projet_Purple
{
    partial class GameOver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameOverTitle = new System.Windows.Forms.PictureBox();
            this.tipLabel = new System.Windows.Forms.Label();
            this.buttonLeave = new System.Windows.Forms.PictureBox();
            this.buttonMenu = new System.Windows.Forms.PictureBox();
            this.gameOverTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // gameOverTitle
            // 
            this.gameOverTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.gameOverTitle.Image = global::Projet_Purple.Properties.Resources.gameOverTitle;
            this.gameOverTitle.Location = new System.Drawing.Point(30, 18);
            this.gameOverTitle.Name = "gameOverTitle";
            this.gameOverTitle.Size = new System.Drawing.Size(1204, 340);
            this.gameOverTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameOverTitle.TabIndex = 0;
            this.gameOverTitle.TabStop = false;
            // 
            // tipLabel
            // 
            this.tipLabel.Font = new System.Drawing.Font("Britannic Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.tipLabel.Location = new System.Drawing.Point(81, 382);
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(1126, 66);
            this.tipLabel.TabIndex = 1;
            this.tipLabel.Text = "Tip: You can change the difficulty in the option !";
            this.tipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tipLabel.Visible = false;
            // 
            // buttonLeave
            // 
            this.buttonLeave.BackColor = System.Drawing.Color.Transparent;
            this.buttonLeave.Image = global::Projet_Purple.Properties.Resources.buttonPauseLeaveLow;
            this.buttonLeave.Location = new System.Drawing.Point(339, 645);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(559, 98);
            this.buttonLeave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonLeave.TabIndex = 102;
            this.buttonLeave.TabStop = false;
            this.buttonLeave.Visible = false;
            this.buttonLeave.Click += new System.EventHandler(this.buttonLeave_Click);
            this.buttonLeave.MouseEnter += new System.EventHandler(this.buttonLeave_MouseEnter);
            this.buttonLeave.MouseLeave += new System.EventHandler(this.buttonLeave_MouseLeave);
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.Image = global::Projet_Purple.Properties.Resources.buttonPauseMenuLow;
            this.buttonMenu.Location = new System.Drawing.Point(339, 505);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(559, 98);
            this.buttonMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonMenu.TabIndex = 104;
            this.buttonMenu.TabStop = false;
            this.buttonMenu.Visible = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            this.buttonMenu.MouseEnter += new System.EventHandler(this.buttonMenu_MouseEnter);
            this.buttonMenu.MouseLeave += new System.EventHandler(this.buttonMenu_MouseLeave);
            // 
            // gameOverTimer
            // 
            this.gameOverTimer.Enabled = true;
            this.gameOverTimer.Interval = 30D;
            this.gameOverTimer.SynchronizingObject = this;
            this.gameOverTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.gameOverTimer_Elapsed);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1271, 768);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.buttonLeave);
            this.Controls.Add(this.tipLabel);
            this.Controls.Add(this.gameOverTitle);
            this.Name = "GameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOver";
            ((System.ComponentModel.ISupportInitialize)(this.gameOverTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverTimer)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Timers.Timer gameOverTimer;

        private System.Windows.Forms.PictureBox buttonLeave;
        private System.Windows.Forms.PictureBox buttonMenu;

        private System.Windows.Forms.Label tipLabel;

        private System.Windows.Forms.PictureBox gameOverTitle;

        #endregion
    }
}