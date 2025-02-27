using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace aivftwserver
{
    public partial class MainForm : Form
    {
        private NetworkManager networkManager;

        public MainForm()
        {
            InitializeComponent();
            networkManager = new NetworkManager();
            StartServerButton.Click += StartServerButton_Click;
            StopServerButton.Click += StopServerButton_Click;

            // Subscribe to events
            networkManager.PlayerConnected += OnPlayerConnected;
            networkManager.PlayerDisconnected += OnPlayerDisconnected;
        }

        private async void StartServerButton_Click(object sender, EventArgs e)
        {
            if (AllowConnectionsButton.Checked)
            {
                await networkManager.Initialize();
                await networkManager.StartServer(); // Start the server
                MessageBox.Show("Server Started Successfully");
            }
            else
            {
                MessageBox.Show("Please allow connections first.");
            }
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            networkManager.StopServer();
            MessageBox.Show("Server Stopped");
        }

        private void OnPlayerConnected(string playerName)
        {
            UpdatePlayerCount(); // Update the player count when a player connects
            UpdateConnectedPlayersList();
        }

        private void OnPlayerDisconnected(string playerName)
        {
            UpdatePlayerCount(); // Update the player count when a player disconnects
            UpdateConnectedPlayersList();
        }

        private void UpdatePlayerCount()
        {
            int playerCount = networkManager.GetConnectedPlayerCount();
            PlayerCountLabel.Text = $"Connected Players: {playerCount}";
        }

        private void UpdateConnectedPlayersList()
        {
            ConnectedListView.Items.Clear(); // Clear previous items

            // Get the connected players
            var connectedPlayers = networkManager.GetConnectedPlayers();

            // Add each player to the ListView
            foreach (var player in connectedPlayers)
            {
                // Create a ListViewItem for each player, with player name as text
                var listViewItem = new ListViewItem(player.Key); // Use player name as display text
                ConnectedListView.Items.Add(listViewItem); // Add to ListView
            }
        }

    }
}
