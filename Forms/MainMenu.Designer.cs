namespace PlayerVersusPlayer
{
    partial class MainMenu
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
            this.SettingsButton = new System.Windows.Forms.Button();
            this.JoinMatchButton = new System.Windows.Forms.Button();
            this.AppInfoButton = new System.Windows.Forms.Button();
            this.MatchInfoButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.BotMatchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.AutoSize = true;
            this.SettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Location = new System.Drawing.Point(12, 412);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(91, 26);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // JoinMatchButton
            // 
            this.JoinMatchButton.AutoSize = true;
            this.JoinMatchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.JoinMatchButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.JoinMatchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinMatchButton.ForeColor = System.Drawing.Color.Black;
            this.JoinMatchButton.Location = new System.Drawing.Point(12, 32);
            this.JoinMatchButton.Name = "JoinMatchButton";
            this.JoinMatchButton.Size = new System.Drawing.Size(226, 40);
            this.JoinMatchButton.TabIndex = 8;
            this.JoinMatchButton.Text = "Join Match";
            this.JoinMatchButton.UseVisualStyleBackColor = false;
            this.JoinMatchButton.Click += new System.EventHandler(this.JoinMatchButton_Click);
            // 
            // AppInfoButton
            // 
            this.AppInfoButton.AutoSize = true;
            this.AppInfoButton.BackColor = System.Drawing.Color.White;
            this.AppInfoButton.Enabled = false;
            this.AppInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AppInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppInfoButton.ForeColor = System.Drawing.Color.Black;
            this.AppInfoButton.Location = new System.Drawing.Point(509, 44);
            this.AppInfoButton.Name = "AppInfoButton";
            this.AppInfoButton.Size = new System.Drawing.Size(126, 28);
            this.AppInfoButton.TabIndex = 10;
            this.AppInfoButton.UseVisualStyleBackColor = false;
            this.AppInfoButton.Visible = false;
            // 
            // MatchInfoButton
            // 
            this.MatchInfoButton.AutoSize = true;
            this.MatchInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MatchInfoButton.Enabled = false;
            this.MatchInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MatchInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatchInfoButton.ForeColor = System.Drawing.Color.Black;
            this.MatchInfoButton.Location = new System.Drawing.Point(112, 78);
            this.MatchInfoButton.Name = "MatchInfoButton";
            this.MatchInfoButton.Size = new System.Drawing.Size(126, 37);
            this.MatchInfoButton.TabIndex = 11;
            this.MatchInfoButton.UseVisualStyleBackColor = false;
            this.MatchInfoButton.Visible = false;
            this.MatchInfoButton.Click += new System.EventHandler(this.MatchInfoButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(255, 29);
            this.NameLabel.TabIndex = 12;
            this.NameLabel.Text = "Player Versus Player";
            // 
            // BotMatchButton
            // 
            this.BotMatchButton.AutoSize = true;
            this.BotMatchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BotMatchButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BotMatchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotMatchButton.ForeColor = System.Drawing.Color.Black;
            this.BotMatchButton.Location = new System.Drawing.Point(244, 32);
            this.BotMatchButton.Name = "BotMatchButton";
            this.BotMatchButton.Size = new System.Drawing.Size(259, 40);
            this.BotMatchButton.TabIndex = 13;
            this.BotMatchButton.Text = "Bot Match";
            this.BotMatchButton.UseVisualStyleBackColor = false;
            this.BotMatchButton.Click += new System.EventHandler(this.BotMatchButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BotMatchButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.MatchInfoButton);
            this.Controls.Add(this.AppInfoButton);
            this.Controls.Add(this.JoinMatchButton);
            this.Controls.Add(this.SettingsButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Versus Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button JoinMatchButton;
        private System.Windows.Forms.Button AppInfoButton;
        private System.Windows.Forms.Button MatchInfoButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button BotMatchButton;
    }
}

