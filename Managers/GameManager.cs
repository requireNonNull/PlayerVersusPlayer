using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aivftw
{
    public enum GameState
    {
        None,
        InQueue,
        Loading,
        Active,
        Loose,
        Won,
        Idle,
    }

    public enum GameMode
    {
        Offline,
        Online,
    }

    public class GameManager
    {
        public event EventHandler<GameState> GameStateChanged;
        public event EventHandler<GameMode> GameModeStateChanged;
        public event EventHandler<string> StateInfoChanged;

        public Form MainMenu { get; private set; }

        public GameState State { get; private set; }
        public GameMode Mode { get; private set; }

        public Player Player { get; private set; }
        public Player Opponent { get; private set; }

        private NetworkManager _networkManager;

        public GameManager(NetworkManager networkManager)
        {
            State = GameState.None;
            MainMenu = Form.ActiveForm;
            _networkManager = networkManager;
        }

        public void StartOfflineMatch()
        {
            Form mainMenu = Form.ActiveForm;
            OfflineGameForm offlineGameForm = new OfflineGameForm(this);
            offlineGameForm.Show();
            mainMenu.Hide();
            mainMenu.Enabled = false;
            SelectGameMode(GameMode.Offline);

        }

        public void InitPlayer(String name)
        {
            Player = new Player(name);
        }

        public void InitOpponent(String name)
        {
            Opponent = new Player(name);
        }

        public Player GetPlayer()
        {
            return Player;
        }

        public Player GetOpponent()
        {
            return Opponent;
        }

        public async Task LeaveGameQueue()
        {
            await _networkManager.LeaveQueue();
        }

        public async Task JoinGameQueue()
        {
            // Step 1: Check if server information is valid
            if (!_networkManager.ServerVersionValid ||
                !_networkManager.ServerPortValid ||
                !_networkManager.ServerAddressValid)
            {
                SendStateInfo("Data verification failed, see GitHub!");
                return;
            }

            // Step 2: Prevent duplicate queue attempts
            if (State == GameState.InQueue)
            {
                SendStateInfo("Already in queue!");
                return;
            }

            // Step 3: Set initial state and try connecting
            SelectGameMode(GameMode.Online);
            SelectGameState(GameState.InQueue);
            SendStateInfo("Joining queue...");

            bool connectionSuccess = await TryEstablishConnection();
            if (!connectionSuccess)
            {
                SendStateInfo("Failed to connect to server.");
                SelectGameState(GameState.Idle);
                return;
            }

            // Step 4: Server found, queueing up

            SendStateInfo("In queue. Online players: " + _networkManager.PlayerCount + ".");
            await _networkManager.JoinQueue();

            await Task.Delay(1000);

            // Step 5: Load online game form
            LoadOnlineGame();
        }

        private async Task<bool> TryEstablishConnection()
        {
            SendStateInfo("Checking for available servers...");

            await _networkManager.Connect(3);

            if (_networkManager.ConnectionState != ConnectionState.Connected)
            {
                return false;
            }

            SendStateInfo("Server found...");
            await Task.Delay(1000);
            return true;
        }

        private void LoadOnlineGame()
        {
            SendStateInfo("Loading online match...");

            Form mainMenu = Form.ActiveForm;
            OnlineGameForm onlineGameForm = new OnlineGameForm(this, _networkManager);
            onlineGameForm.Show();
            mainMenu.Hide();
            mainMenu.Enabled = false;

            SelectGameState(GameState.Loading);
        }

        public void SendStateInfo(string stateInfo)
        {
            StateInfoChanged?.Invoke(this, stateInfo);
        }

        public GameMode GetGameMode()
        {
            return Mode;
        }

        public void SelectGameState(GameState state)
        {
            SetState(state);
        }

        public void SelectGameMode(GameMode mode)
        {
            SetMode(mode);
        }

        private void SetState(GameState state)
        {
            State = state;
            GameStateChanged?.Invoke(this, State); // Fire event
        }

        private void SetMode(GameMode mode)
        {
            Mode = mode;
            GameModeStateChanged?.Invoke(this, Mode); // Fire event
        }
    }
}
