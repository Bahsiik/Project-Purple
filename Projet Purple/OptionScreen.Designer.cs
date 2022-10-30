using System.ComponentModel;

namespace Projet_Purple
{
    partial class OptionScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(66, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 105);
            this.label1.TabIndex = 0;
            this.label1.Text = "Controls";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(63, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "Walk to the right";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(63, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 49);
            this.label3.TabIndex = 2;
            this.label3.Text = "Walk to the left";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(63, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 49);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jump";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(238, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 49);
            this.label5.TabIndex = 4;
            this.label5.Text = "Right arrow / D";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(238, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 49);
            this.label6.TabIndex = 5;
            this.label6.Text = "Left arrow / Q";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(238, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 49);
            this.label7.TabIndex = 6;
            this.label7.Text = "Up arrow / Z / Spacebar";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(752, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(412, 105);
            this.label8.TabIndex = 7;
            this.label8.Text = "Choose your character";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(752, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 199);
            this.button1.TabIndex = 8;
            this.button1.Text = "Byleth (M)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(994, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 199);
            this.button2.TabIndex = 9;
            this.button2.Text = "Byleth (F)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(424, 599);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(311, 105);
            this.button3.TabIndex = 10;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BackMenuButton);
            // 
            // OptionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 768);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OptionScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionScreen";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        #endregion
    }
}