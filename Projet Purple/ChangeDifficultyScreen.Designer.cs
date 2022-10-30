using System.ComponentModel;

namespace Projet_Purple
{
    partial class ChangeDifficultyScreen
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
            this.backButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.peacefulDifficulty = new System.Windows.Forms.PictureBox();
            this.easyDifficulty = new System.Windows.Forms.PictureBox();
            this.mediumDifficulty = new System.Windows.Forms.PictureBox();
            this.hardDifficulty = new System.Windows.Forms.PictureBox();
            this.difficultyDescription = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peacefulDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.Image = global::Projet_Purple.Properties.Resources.buttonBackLow;
            this.backButton.Location = new System.Drawing.Point(362, 645);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(545, 98);
            this.backButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backButton.TabIndex = 16;
            this.backButton.TabStop = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.backButton.MouseEnter += new System.EventHandler(this.backButton_MouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.backButton_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Projet_Purple.Properties.Resources.optionCategoryChooseDifficulty;
            this.pictureBox1.Location = new System.Drawing.Point(362, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // peacefulDifficulty
            // 
            this.peacefulDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.peacefulDifficulty.Image = global::Projet_Purple.Properties.Resources.peacefullDifficulty;
            this.peacefulDifficulty.Location = new System.Drawing.Point(39, 184);
            this.peacefulDifficulty.Name = "peacefulDifficulty";
            this.peacefulDifficulty.Size = new System.Drawing.Size(260, 260);
            this.peacefulDifficulty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.peacefulDifficulty.TabIndex = 18;
            this.peacefulDifficulty.TabStop = false;
            this.peacefulDifficulty.Click += new System.EventHandler(this.peacefulDifficulty_Click);
            this.peacefulDifficulty.MouseEnter += new System.EventHandler(this.peacefulDifficulty_MouseEnter);
            this.peacefulDifficulty.MouseLeave += new System.EventHandler(this.peacefulDifficulty_MouseLeave);
            // 
            // easyDifficulty
            // 
            this.easyDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.easyDifficulty.Image = global::Projet_Purple.Properties.Resources.easyDifficultyGray;
            this.easyDifficulty.Location = new System.Drawing.Point(344, 184);
            this.easyDifficulty.Name = "easyDifficulty";
            this.easyDifficulty.Size = new System.Drawing.Size(260, 260);
            this.easyDifficulty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.easyDifficulty.TabIndex = 19;
            this.easyDifficulty.TabStop = false;
            this.easyDifficulty.Click += new System.EventHandler(this.easyDifficulty_Click);
            this.easyDifficulty.MouseEnter += new System.EventHandler(this.easyDifficulty_MouseEnter);
            this.easyDifficulty.MouseLeave += new System.EventHandler(this.easyDifficulty_MouseLeave);
            // 
            // mediumDifficulty
            // 
            this.mediumDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.mediumDifficulty.Image = global::Projet_Purple.Properties.Resources.mediumDifficultyGray;
            this.mediumDifficulty.Location = new System.Drawing.Point(654, 184);
            this.mediumDifficulty.Name = "mediumDifficulty";
            this.mediumDifficulty.Size = new System.Drawing.Size(260, 260);
            this.mediumDifficulty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mediumDifficulty.TabIndex = 20;
            this.mediumDifficulty.TabStop = false;
            this.mediumDifficulty.Click += new System.EventHandler(this.mediumDifficulty_Click);
            this.mediumDifficulty.MouseEnter += new System.EventHandler(this.mediumDifficulty_MouseEnter);
            this.mediumDifficulty.MouseLeave += new System.EventHandler(this.mediumDifficulty_MouseLeave);
            // 
            // hardDifficulty
            // 
            this.hardDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.hardDifficulty.Image = global::Projet_Purple.Properties.Resources.hardDifficultyLocked;
            this.hardDifficulty.Location = new System.Drawing.Point(967, 184);
            this.hardDifficulty.Name = "hardDifficulty";
            this.hardDifficulty.Size = new System.Drawing.Size(260, 260);
            this.hardDifficulty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hardDifficulty.TabIndex = 21;
            this.hardDifficulty.TabStop = false;
            this.hardDifficulty.Click += new System.EventHandler(this.hardDifficulty_Click);
            this.hardDifficulty.MouseEnter += new System.EventHandler(this.hardDifficulty_MouseEnter);
            this.hardDifficulty.MouseLeave += new System.EventHandler(this.hardDifficulty_MouseLeave);
            // 
            // difficultyDescription
            // 
            this.difficultyDescription.BackColor = System.Drawing.Color.Transparent;
            this.difficultyDescription.Image = global::Projet_Purple.Properties.Resources.difficultyPeacefullDesc;
            this.difficultyDescription.Location = new System.Drawing.Point(399, 475);
            this.difficultyDescription.Name = "difficultyDescription";
            this.difficultyDescription.Size = new System.Drawing.Size(470, 151);
            this.difficultyDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.difficultyDescription.TabIndex = 22;
            this.difficultyDescription.TabStop = false;
            // 
            // ChangeDifficultyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projet_Purple.Properties.Resources.titleBackground1Blur;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1271, 768);
            this.Controls.Add(this.difficultyDescription);
            this.Controls.Add(this.hardDifficulty);
            this.Controls.Add(this.mediumDifficulty);
            this.Controls.Add(this.easyDifficulty);
            this.Controls.Add(this.peacefulDifficulty);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backButton);
            this.Name = "ChangeDifficultyScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeDifficultyScreen";
            ((System.ComponentModel.ISupportInitialize)(this.backButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peacefulDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyDescription)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox difficultyDescription;

        private System.Windows.Forms.PictureBox peacefulDifficulty;
        private System.Windows.Forms.PictureBox easyDifficulty;
        private System.Windows.Forms.PictureBox mediumDifficulty;
        private System.Windows.Forms.PictureBox hardDifficulty;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.PictureBox backButton;

        #endregion
    }
}