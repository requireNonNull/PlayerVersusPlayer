namespace aivftw
{
    partial class OnlineGameForm
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
            this.AttackButton = new System.Windows.Forms.Button();
            this.HealButton = new System.Windows.Forms.Button();
            this.TankButton = new System.Windows.Forms.Button();
            this.ShieldButton = new System.Windows.Forms.Button();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.EnemyNameLabel = new System.Windows.Forms.Label();
            this.EnemyHealthLabel = new System.Windows.Forms.Label();
            this.SelectYourselfButton = new System.Windows.Forms.Button();
            this.SelectEnemyButton = new System.Windows.Forms.Button();
            this.InfoButton = new System.Windows.Forms.Button();
            this.EnemyInfoButton = new System.Windows.Forms.Button();
            this.OpponnentNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AttackButton
            // 
            this.AttackButton.AutoSize = true;
            this.AttackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AttackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AttackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttackButton.ForeColor = System.Drawing.Color.White;
            this.AttackButton.Location = new System.Drawing.Point(12, 412);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(91, 26);
            this.AttackButton.TabIndex = 0;
            this.AttackButton.Text = "Attack";
            this.AttackButton.UseVisualStyleBackColor = false;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            this.AttackButton.MouseHover += new System.EventHandler(this.AttackButton_MouseHover);
            // 
            // HealButton
            // 
            this.HealButton.AutoSize = true;
            this.HealButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HealButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HealButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealButton.ForeColor = System.Drawing.Color.White;
            this.HealButton.Location = new System.Drawing.Point(109, 412);
            this.HealButton.Name = "HealButton";
            this.HealButton.Size = new System.Drawing.Size(91, 26);
            this.HealButton.TabIndex = 1;
            this.HealButton.Text = "Heal";
            this.HealButton.UseVisualStyleBackColor = false;
            this.HealButton.Click += new System.EventHandler(this.HealButton_Click);
            this.HealButton.MouseHover += new System.EventHandler(this.HealButton_MouseHoverAsync);
            // 
            // TankButton
            // 
            this.TankButton.AutoSize = true;
            this.TankButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TankButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TankButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TankButton.ForeColor = System.Drawing.Color.White;
            this.TankButton.Location = new System.Drawing.Point(206, 412);
            this.TankButton.Name = "TankButton";
            this.TankButton.Size = new System.Drawing.Size(91, 26);
            this.TankButton.TabIndex = 2;
            this.TankButton.Text = "Spot";
            this.TankButton.UseVisualStyleBackColor = false;
            this.TankButton.Click += new System.EventHandler(this.TankButton_Click);
            this.TankButton.MouseHover += new System.EventHandler(this.TankButton_MouseHover);
            // 
            // ShieldButton
            // 
            this.ShieldButton.AutoSize = true;
            this.ShieldButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ShieldButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShieldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShieldButton.ForeColor = System.Drawing.Color.White;
            this.ShieldButton.Location = new System.Drawing.Point(303, 412);
            this.ShieldButton.Name = "ShieldButton";
            this.ShieldButton.Size = new System.Drawing.Size(91, 26);
            this.ShieldButton.TabIndex = 3;
            this.ShieldButton.Text = "Shield";
            this.ShieldButton.UseVisualStyleBackColor = false;
            this.ShieldButton.Click += new System.EventHandler(this.ShieldButton_Click);
            this.ShieldButton.MouseHover += new System.EventHandler(this.ShieldButton_MouseHover);
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNameLabel.Location = new System.Drawing.Point(12, 341);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(93, 16);
            this.PlayerNameLabel.TabIndex = 4;
            this.PlayerNameLabel.Text = "PlayerName";
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthLabel.Location = new System.Drawing.Point(12, 366);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(52, 16);
            this.HealthLabel.TabIndex = 5;
            this.HealthLabel.Text = "Health";
            // 
            // EnemyNameLabel
            // 
            this.EnemyNameLabel.AutoSize = true;
            this.EnemyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyNameLabel.Location = new System.Drawing.Point(693, 341);
            this.EnemyNameLabel.Name = "EnemyNameLabel";
            this.EnemyNameLabel.Size = new System.Drawing.Size(95, 16);
            this.EnemyNameLabel.TabIndex = 6;
            this.EnemyNameLabel.Text = "EnemyName";
            // 
            // EnemyHealthLabel
            // 
            this.EnemyHealthLabel.AutoSize = true;
            this.EnemyHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyHealthLabel.Location = new System.Drawing.Point(736, 366);
            this.EnemyHealthLabel.Name = "EnemyHealthLabel";
            this.EnemyHealthLabel.Size = new System.Drawing.Size(52, 16);
            this.EnemyHealthLabel.TabIndex = 7;
            this.EnemyHealthLabel.Text = "Health";
            // 
            // SelectYourselfButton
            // 
            this.SelectYourselfButton.AutoSize = true;
            this.SelectYourselfButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SelectYourselfButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SelectYourselfButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectYourselfButton.ForeColor = System.Drawing.Color.Black;
            this.SelectYourselfButton.Location = new System.Drawing.Point(12, 310);
            this.SelectYourselfButton.Name = "SelectYourselfButton";
            this.SelectYourselfButton.Size = new System.Drawing.Size(126, 28);
            this.SelectYourselfButton.TabIndex = 8;
            this.SelectYourselfButton.Text = "Select Yourself";
            this.SelectYourselfButton.UseVisualStyleBackColor = false;
            this.SelectYourselfButton.Click += new System.EventHandler(this.SelectYourselfButton_Click);
            // 
            // SelectEnemyButton
            // 
            this.SelectEnemyButton.AutoSize = true;
            this.SelectEnemyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SelectEnemyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SelectEnemyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectEnemyButton.ForeColor = System.Drawing.Color.Black;
            this.SelectEnemyButton.Location = new System.Drawing.Point(662, 310);
            this.SelectEnemyButton.Name = "SelectEnemyButton";
            this.SelectEnemyButton.Size = new System.Drawing.Size(126, 28);
            this.SelectEnemyButton.TabIndex = 9;
            this.SelectEnemyButton.Text = "Select Enemy";
            this.SelectEnemyButton.UseVisualStyleBackColor = false;
            this.SelectEnemyButton.Click += new System.EventHandler(this.SelectEnemyButton_Click);
            // 
            // InfoButton
            // 
            this.InfoButton.AutoSize = true;
            this.InfoButton.BackColor = System.Drawing.Color.White;
            this.InfoButton.Enabled = false;
            this.InfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoButton.ForeColor = System.Drawing.Color.Black;
            this.InfoButton.Location = new System.Drawing.Point(303, 12);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(126, 28);
            this.InfoButton.TabIndex = 10;
            this.InfoButton.UseVisualStyleBackColor = false;
            this.InfoButton.Visible = false;
            // 
            // EnemyInfoButton
            // 
            this.EnemyInfoButton.AutoSize = true;
            this.EnemyInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.EnemyInfoButton.Enabled = false;
            this.EnemyInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnemyInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyInfoButton.ForeColor = System.Drawing.Color.Black;
            this.EnemyInfoButton.Location = new System.Drawing.Point(604, 366);
            this.EnemyInfoButton.Name = "EnemyInfoButton";
            this.EnemyInfoButton.Size = new System.Drawing.Size(126, 28);
            this.EnemyInfoButton.TabIndex = 11;
            this.EnemyInfoButton.UseVisualStyleBackColor = false;
            this.EnemyInfoButton.Visible = false;
            // 
            // OpponnentNameLabel
            // 
            this.OpponnentNameLabel.AutoSize = true;
            this.OpponnentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpponnentNameLabel.Location = new System.Drawing.Point(12, 162);
            this.OpponnentNameLabel.Name = "OpponnentNameLabel";
            this.OpponnentNameLabel.Size = new System.Drawing.Size(123, 16);
            this.OpponnentNameLabel.TabIndex = 12;
            this.OpponnentNameLabel.Text = "OpponnentName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "OpponnentHealth";
            // 
            // OnlineGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OpponnentNameLabel);
            this.Controls.Add(this.EnemyInfoButton);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.SelectEnemyButton);
            this.Controls.Add(this.SelectYourselfButton);
            this.Controls.Add(this.EnemyHealthLabel);
            this.Controls.Add(this.EnemyNameLabel);
            this.Controls.Add(this.HealthLabel);
            this.Controls.Add(this.PlayerNameLabel);
            this.Controls.Add(this.ShieldButton);
            this.Controls.Add(this.TankButton);
            this.Controls.Add(this.HealButton);
            this.Controls.Add(this.AttackButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OnlineGameForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI Vanquishers: First to Win";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AttackButton;
        private System.Windows.Forms.Button HealButton;
        private System.Windows.Forms.Button TankButton;
        private System.Windows.Forms.Button ShieldButton;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.Label EnemyNameLabel;
        private System.Windows.Forms.Label EnemyHealthLabel;
        private System.Windows.Forms.Button SelectYourselfButton;
        private System.Windows.Forms.Button SelectEnemyButton;
        private System.Windows.Forms.Button InfoButton;
        private System.Windows.Forms.Button EnemyInfoButton;
        private System.Windows.Forms.Label OpponnentNameLabel;
        private System.Windows.Forms.Label label2;
    }
}

