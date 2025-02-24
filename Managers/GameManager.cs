using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PlayerVersusPlayer
{

    public enum GameState
    {
        None,
        InQueue,
        Loading,
        Active,
        Idle,
    }

    public enum GameMode
    {
        Offline,
        Online
    }

    public class GameManager
    {
        public event EventHandler<GameState> GameStateChanged;
        public event EventHandler<GameMode> GameModeStateChanged;
        public event EventHandler<string> StateInfoChanged;

        public GameState State { get; private set; }
        public GameMode Mode { get; private set; }

        public GameManager()
        {
            State = GameState.None;
        }

        public async Task JoinGameQueue(GameMode mode)
        {
            if (State == GameState.InQueue) { SendStateInfo("Already QUEUED!"); }
            State = GameState.InQueue;
            SelectGameMode(mode);

            while (true)
            {
                {
                    if (Mode == GameMode.Offline)
                    {
                        SendStateInfo("Preparing Offline Match...");
                    }

                    if (Mode == GameMode.Online)
                    {
                        //Connect methods to server etc...
                        SendStateInfo("Checking for available Servers...");
                    }
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
        }

        public void SendStateInfo(string stateInfo)
        {
            StateInfoChanged?.Invoke(this, stateInfo);
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
