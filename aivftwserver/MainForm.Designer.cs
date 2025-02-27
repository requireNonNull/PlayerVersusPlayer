namespace aivftwserver
{
    partial class MainForm
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
            this.AllowConnectionsButton = new System.Windows.Forms.RadioButton();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.StopServerButton = new System.Windows.Forms.Button();
            this.ConnectedListView = new System.Windows.Forms.ListView();
            this.ConnectedPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AllowConnectionsButton
            // 
            this.AllowConnectionsButton.AutoSize = true;
            this.AllowConnectionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllowConnectionsButton.Location = new System.Drawing.Point(12, 418);
            this.AllowConnectionsButton.Name = "AllowConnectionsButton";
            this.AllowConnectionsButton.Size = new System.Drawing.Size(151, 20);
            this.AllowConnectionsButton.TabIndex = 0;
            this.AllowConnectionsButton.TabStop = true;
            this.AllowConnectionsButton.Text = "Allow Connections";
            this.AllowConnectionsButton.UseVisualStyleBackColor = true;
            // 
            // StartServerButton
            // 
            this.StartServerButton.AutoSize = true;
            this.StartServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.StartServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartServerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartServerButton.ForeColor = System.Drawing.Color.White;
            this.StartServerButton.Location = new System.Drawing.Point(12, 12);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(99, 26);
            this.StartServerButton.TabIndex = 1;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = false;
            // 
            // StopServerButton
            // 
            this.StopServerButton.AutoSize = true;
            this.StopServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StopServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StopServerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopServerButton.ForeColor = System.Drawing.Color.White;
            this.StopServerButton.Location = new System.Drawing.Point(12, 44);
            this.StopServerButton.Name = "StopServerButton";
            this.StopServerButton.Size = new System.Drawing.Size(99, 26);
            this.StopServerButton.TabIndex = 2;
            this.StopServerButton.Text = "Stop Server";
            this.StopServerButton.UseVisualStyleBackColor = false;
            // 
            // ConnectedListView
            // 
            this.ConnectedListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ConnectedListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.ConnectedListView.AllowColumnReorder = true;
            this.ConnectedListView.BackColor = System.Drawing.SystemColors.Desktop;
            this.ConnectedListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConnectedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ConnectedPlayers});
            this.ConnectedListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectedListView.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ConnectedListView.GridLines = true;
            this.ConnectedListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ConnectedListView.HideSelection = false;
            this.ConnectedListView.LabelWrap = false;
            this.ConnectedListView.Location = new System.Drawing.Point(588, 9);
            this.ConnectedListView.MultiSelect = false;
            this.ConnectedListView.Name = "ConnectedListView";
            this.ConnectedListView.Size = new System.Drawing.Size(200, 429);
            this.ConnectedListView.TabIndex = 4;
            this.ConnectedListView.UseCompatibleStateImageBehavior = false;
            this.ConnectedListView.View = System.Windows.Forms.View.Details;
            this.ConnectedListView.VirtualListSize = 9;
            // 
            // ConnectedPlayers
            // 
            this.ConnectedPlayers.Text = "Connected Players";
            this.ConnectedPlayers.Width = 1000;
            // 
            // PlayerCountLabel
            // 
            this.PlayerCountLabel.AutoSize = true;
            this.PlayerCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerCountLabel.Location = new System.Drawing.Point(453, 9);
            this.PlayerCountLabel.Name = "PlayerCountLabel";
            this.PlayerCountLabel.Size = new System.Drawing.Size(129, 24);
            this.PlayerCountLabel.TabIndex = 5;
            this.PlayerCountLabel.Text = "Player Count";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlayerCountLabel);
            this.Controls.Add(this.ConnectedListView);
            this.Controls.Add(this.StopServerButton);
            this.Controls.Add(this.StartServerButton);
            this.Controls.Add(this.AllowConnectionsButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.Text = "AI Vanquishers: First to Win Server";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton AllowConnectionsButton;
        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.Button StopServerButton;
        private System.Windows.Forms.ListView ConnectedListView;
        private System.Windows.Forms.ColumnHeader ConnectedPlayers;
        private System.Windows.Forms.Label PlayerCountLabel;
    }
}

