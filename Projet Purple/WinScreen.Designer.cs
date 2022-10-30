using System.ComponentModel;

namespace Projet_Purple
{
    partial class WinScreen
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
            this.winTitle = new System.Windows.Forms.PictureBox();
            this.buttonMenu = new System.Windows.Forms.PictureBox();
            this.buttonLeave = new System.Windows.Forms.PictureBox();
            this.winScreenTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.winTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winScreenTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // winTitle
            // 
            this.winTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.winTitle.BackColor = System.Drawing.Color.Transparent;
            this.winTitle.Image = global::Projet_Purple.Properties.Resources.winTitle;
            this.winTitle.Location = new System.Drawing.Point(275, 12);
            this.winTitle.Name = "winTitle";
            this.winTitle.Size = new System.Drawing.Size(711, 98);
            this.winTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.winTitle.TabIndex = 1;
            this.winTitle.TabStop = false;
            this.winTitle.Visible = false;
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.Image = global::Projet_Purple.Properties.Resources.buttonPauseMenuLow;
            this.buttonMenu.Location = new System.Drawing.Point(351, 499);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(559, 98);
            this.buttonMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonMenu.TabIndex = 106;
            this.buttonMenu.TabStop = false;
            this.buttonMenu.Visible = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            this.buttonMenu.MouseEnter += new System.EventHandler(this.buttonMenu_MouseEnter);
            this.buttonMenu.MouseLeave += new System.EventHandler(this.buttonMenu_MouseLeave);
            // 
            // buttonLeave
            // 
            this.buttonLeave.BackColor = System.Drawing.Color.Transparent;
            this.buttonLeave.Image = global::Projet_Purple.Properties.Resources.buttonPauseLeaveLow;
            this.buttonLeave.Location = new System.Drawing.Point(351, 639);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(559, 98);
            this.buttonLeave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonLeave.TabIndex = 105;
            this.buttonLeave.TabStop = false;
            this.buttonLeave.Visible = false;
            this.buttonLeave.Click += new System.EventHandler(this.buttonLeave_Click);
            this.buttonLeave.MouseEnter += new System.EventHandler(this.buttonLeave_MouseEnter);
            this.buttonLeave.MouseLeave += new System.EventHandler(this.buttonLeave_MouseLeave);
            // 
            // winScreenTimer
            // 
            this.winScreenTimer.Enabled = true;
            this.winScreenTimer.Interval = 35D;
            this.winScreenTimer.SynchronizingObject = this;
            this.winScreenTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.winScreenTimer_Elapsed);
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projet_Purple.Properties.Resources.winBackgroundM;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1271, 768);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.buttonLeave);
            this.Controls.Add(this.winTitle);
            this.Name = "WinScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinScreen";
            ((System.ComponentModel.ISupportInitialize)(this.winTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winScreenTimer)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Timers.Timer winScreenTimer;

        private System.Windows.Forms.PictureBox buttonMenu;
        private System.Windows.Forms.PictureBox buttonLeave;

        private System.Windows.Forms.PictureBox winTitle;

        #endregion
    }
}