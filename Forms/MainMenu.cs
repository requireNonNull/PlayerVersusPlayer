using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerVersusPlayer
{
    public partial class MainMenu : Form
    {
        private GameManager _gameManager;

        public MainMenu()
        {
            InitializeComponent();

            _gameManager = new GameManager();

            _gameManager.StateInfoChanged += OnQueueDataReceived;

            _ = UpdateUI();

        }

        private async Task UpdateUI()
        {
            while (true)
            {

                await Task.Delay(TimeSpan.FromSeconds(0.1));
            }
        }


        private async Task FadeIn(Button fadeInButton, string text)
        {
            fadeInButton.Text = text;

            if (fadeInButton.Visible) return;

            fadeInButton.BackColor = Color.FromArgb(0, fadeInButton.BackColor);
            fadeInButton.Visible = true;

            for (int i = 100; i < 255; i++)
            {

                fadeInButton.BackColor = Color.FromArgb(i, fadeInButton.BackColor);
                fadeInButton.ForeColor = Color.FromArgb(i, fadeInButton.ForeColor);

                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            fadeInButton.Visible = false;
        }

        private async Task FadeInAndOut(Button fadeInOutButton, string text)
        {
            fadeInOutButton.Text = text;

            if (fadeInOutButton.Visible) return;

            fadeInOutButton.BackColor = Color.FromArgb(0, fadeInOutButton.BackColor);
            fadeInOutButton.Visible = true;

            for (int i = 155; i < 255; i++)
            {

                fadeInOutButton.BackColor = Color.FromArgb(i, fadeInOutButton.BackColor);
                fadeInOutButton.ForeColor = Color.FromArgb(i, fadeInOutButton.ForeColor);

                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            await Task.Delay(TimeSpan.FromMilliseconds(250));

            for (int i = 155; i > 0; i--)
            {
                fadeInOutButton.BackColor = Color.FromArgb(i, fadeInOutButton.BackColor);
                fadeInOutButton.ForeColor = Color.FromArgb(i, fadeInOutButton.ForeColor);

                if (fadeInOutButton.Text.Length >= i)
                {
                    fadeInOutButton.Text = fadeInOutButton.Text.Remove(fadeInOutButton.Text.Length - 1);
                }
                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            fadeInOutButton.Visible = false;
        }

        public void OnQueueDataReceived(object sender, string message)
        {
            _ = FadeIn(MatchInfoButton, message);
            Console.WriteLine($"Received: {message}");
        }

        private void JoinMatchButton_Click(object sender, EventArgs e)
        {
            _ = _gameManager.JoinGameQueue(GameMode.Online);


        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void BotMatchButton_Click(object sender, EventArgs e)
        {
            BotMatchButton.Enabled = false;
            JoinMatchButton.Enabled = false;
            _gameManager.SelectGameMode(GameMode.Offline);
            GameForm gameForm = new GameForm(_gameManager);

            gameForm.Show();
            this.Close();

        }

        private void MatchInfoButton_Click(object sender, EventArgs e)
        {
        }


    }
}
