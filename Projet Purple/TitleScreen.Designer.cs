using System.ComponentModel;

namespace Projet_Purple
{
    partial class TitleScreen
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
            this.startButton = new System.Windows.Forms.PictureBox();
            this.optionButton = new System.Windows.Forms.PictureBox();
            this.quitButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.startButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.Image = global::Projet_Purple.Properties.Resources.mainButtonTextLow;
            this.startButton.Location = new System.Drawing.Point(527, 183);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(722, 186);
            this.startButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.startButton.TabIndex = 0;
            this.startButton.TabStop = false;
            this.startButton.Click += new System.EventHandler(this.StartGame);
            this.startButton.MouseEnter += new System.EventHandler(this.StartButton_Enter);
            this.startButton.MouseLeave += new System.EventHandler(this.StartButton_Leave);
            // 
            // optionButton
            // 
            this.optionButton.BackColor = System.Drawing.Color.Transparent;
            this.optionButton.Image = global::Projet_Purple.Properties.Resources.buttonOptionLow;
            this.optionButton.Location = new System.Drawing.Point(622, 392);
            this.optionButton.Name = "optionButton";
            this.optionButton.Size = new System.Drawing.Size(559, 98);
            this.optionButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.optionButton.TabIndex = 1;
            this.optionButton.TabStop = false;
            this.optionButton.Click += new System.EventHandler(this.DisplayOption);
            this.optionButton.MouseEnter += new System.EventHandler(this.OptionButton_Enter);
            this.optionButton.MouseLeave += new System.EventHandler(this.OptionButton_Leave);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Transparent;
            this.quitButton.Image = global::Projet_Purple.Properties.Resources.buttonQuitLow;
            this.quitButton.Location = new System.Drawing.Point(622, 519);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(559, 98);
            this.quitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.quitButton.TabIndex = 2;
            this.quitButton.TabStop = false;
            this.quitButton.Click += new System.EventHandler(this.QuitGame);
            this.quitButton.MouseEnter += new System.EventHandler(this.QuitButton_Enter);
            this.quitButton.MouseLeave += new System.EventHandler(this.QuitButton_Leave);
            // 
            // TitleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Projet_Purple.Properties.Resources.titleBackground1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1251, 768);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.optionButton);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "TitleScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.startButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitButton)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox quitButton;

        private System.Windows.Forms.PictureBox optionButton;

        private System.Windows.Forms.PictureBox startButton;

        #endregion
    }
}