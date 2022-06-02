namespace Gameeeee
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtAmmo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // player
            // 
            this.player.Image = global::Gameeeee.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(377, 235);
            this.player.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 6;
            this.player.TabStop = false;
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(891, 17);
            this.healthBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(260, 23);
            this.healthBar.TabIndex = 4;
            this.healthBar.Value = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(788, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Health";
            // 
            // txtHighScore
            // 
            this.txtHighScore.AutoSize = true;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtHighScore.Location = new System.Drawing.Point(485, 17);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(158, 29);
            this.txtHighScore.TabIndex = 2;
            this.txtHighScore.Text = "High Score: 0";
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtScore.Location = new System.Drawing.Point(236, 17);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(79, 29);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Kill: 0";
            // 
            // txtAmmo
            // 
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtAmmo.Location = new System.Drawing.Point(50, 17);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new System.Drawing.Size(114, 29);
            this.txtAmmo.TabIndex = 5;
            this.txtAmmo.Text = "Ammo: 0";
            this.txtAmmo.Click += new System.EventHandler(this.txtAmmo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1163, 814);
            this.Controls.Add(this.player);
            this.Controls.Add(this.txtAmmo);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Easy";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Button btnExist;
    }
}