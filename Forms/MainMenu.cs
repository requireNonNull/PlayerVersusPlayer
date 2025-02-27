using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static aivftw.Utils.Animations;

namespace aivftw
{
    public partial class MainMenu : Form
    {
        private GameManager _gameManager;
        private NetworkManager _networkManager;

        public MainMenu()
        {
            InitializeComponent();

            _networkManager = new NetworkManager();
            _gameManager = new GameManager(_networkManager);
            _ = _networkManager.Initialize(_gameManager);

            _networkManager.OnVersionChecked += NetworkManager_OnVersionChecked;
            _gameManager.StateInfoChanged += OnQueueDataReceived;

        }

        public void NetworkManager_OnVersionChecked(object sender, bool e)
        {
            if (e)
            {
                _ = FadeIn(MatchInfoButton, "Version check success!");
                JoinMatchButton.Enabled = true;
            }
            else
            {
                _ = FadeIn(MatchInfoButton, "Version check failed! See Github for updates!");
                JoinMatchButton.Enabled = false;
            }
        }

        public void OnQueueDataReceived(object sender, string message)
        {
            _ = FadeIn(MatchInfoButton, message);
            Console.WriteLine($"Received: {message}");
        }

        private void JoinMatchButton_Click(object sender, EventArgs e)
        {
            _ = _gameManager.JoinGameQueue();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void BotMatchButton_Click(object sender, EventArgs e)
        {
            _gameManager.StartOfflineMatch();
        }
    }
}
