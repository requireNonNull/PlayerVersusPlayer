using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace aivftw
{
    public enum ConnectionState
    {
        Connected,
        Disconnected,
        PacketLoss,
        EstablishingConnection,
        Failed,
    }

    public enum NetworkRequest
    {
        REQUEST_SERVER_STATUS,      // Check if server is online
        REQUEST_CONNECT,            // Try to connect to server
        REQUEST_QUEUE_CONNECT,      // Try to join matchmaking queue
        REQUEST_QUEUE_LEAVE,        // Leave matchmaking queue
        REQUEST_QUEUE_STATUS,       // Check queue status (position, estimated time)

        REQUEST_PLAYER_COUNT,       // Get total number of players online
        REQUEST_OPPONENT_NAME,      // Get opponent's name
        REQUEST_OPPONENT_HEALTH,    // Get opponent's current health
        REQUEST_GAME_STATE,         // Get current game state

        SEND_PLAYER_HEALTH,         // Send updated player health
        SEND_GAME_STATE,            // Send updated game state

        REQUEST_DISCONNECT,         // Fully disconnect from server (not just queue)
    }

    public enum NetworkResponse
    {
        PLAYER_COUNT,
        SERVER_STATUS,
        CONNECT_FAILED,
        CONNECT_SUCCESS,
        DISCONNECT,
        QUEUE_JOIN_SUCCESS,
        QUEUE_MATCH_FOUND,
        QUEUE_LEFT,
    }

    public class NetworkManager
    {
        public event EventHandler<bool> OnVersionChecked;
        public event EventHandler<bool> OnServerPortChecked;
        public event EventHandler<bool> OnServerAddressChecked;

        public event EventHandler<double> OnPlayerHealthChanged;
        public event EventHandler<double> OnOpponnentHealthChanged;
        public event EventHandler<int> OnPlayerCountChanged;
        public event EventHandler<ConnectionState> OnConnectionStateChanged;
        public event EventHandler OnQueueJoined;
        public event EventHandler OnQueueLeft;
        public event EventHandler OnMatchFound;


        public bool ServerVersionValid { get; private set; }
        public bool ServerPortValid { get; private set; }
        public bool ServerAddressValid { get; private set; }
        public ConnectionState ConnectionState { get; private set; }

        public int Port { get; private set; }
        public IPAddress IPAddress { get; private set; }

        private TcpClient TcpClient;
        private IPEndPoint EndPoint;
        private GameManager GameManager;

        // Server managed variables
        public int ConnectionID { get; private set; } // Get from server
        public int PlayerCount { get; private set; } // Get from server
        public double OpponentHealth { get; private set; } // Get from server
        public double PlayerHealth { get; private set; } // Send and Get from server

        public NetworkManager()
        {
            TcpClient = new TcpClient();
        }

        public async Task Initialize(GameManager gameManager)
        {
            IPAddress = GetGameServerAddress();
            await GetGameServerPort();
            await CheckVersion();

            GameManager = gameManager;
            EndPoint = new IPEndPoint(IPAddress, Port);

            await (Connect(5));
            _ = Task.Run(ListenForData);
        }

        public async Task CheckVersion()
        {
            Uri versionUrl = new Uri(AppInfo.versionCheckURL);

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(versionUrl);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    if (responseContent.Trim() == AppInfo.version)
                    {
                        OnVersionChecked?.Invoke(this, true);
                        ServerVersionValid = true;
                    }
                    else
                    {
                        OnVersionChecked?.Invoke(this, false);
                        ServerVersionValid = false;
                    }

                }
                else
                {
                    OnVersionChecked?.Invoke(this, false);
                    ServerVersionValid = false;
                }
            }
        }

        public async Task GetGameServerPort()
        {
            try
            {
                Uri portURL = new Uri(AppInfo.portCheckURL);

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await httpClient.GetAsync(portURL);

                    string responseContext = await responseMessage.Content.ReadAsStringAsync();

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        if (int.TryParse(responseContext, out int parsedPort))
                        {
                            Port = parsedPort;
                            OnServerPortChecked?.Invoke(this, true);
                            ServerPortValid = true;
                        }
                        else
                        {
                            Debug.WriteLine("Port not valid!");
                            OnServerPortChecked?.Invoke(this, false);
                            ServerPortValid = false;
                        }

                    }
                    else
                    {
                        Debug.WriteLine("Port url invalid or offline?");
                        OnServerPortChecked?.Invoke(this, false);
                        ServerPortValid = false;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                OnServerPortChecked?.Invoke(this, false);
                ServerPortValid = false;
            }
        }

        public IPAddress GetGameServerAddress()
        {
            try
            {
                string Domain = AppInfo.gameServerDomain;

                IPAddress[] iPAddresses;

                iPAddresses = Dns.GetHostAddresses(Domain);

                OnServerAddressChecked?.Invoke(this, true);
                ServerAddressValid = true;

                return iPAddresses.FirstOrDefault();

            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                OnServerAddressChecked?.Invoke(this, false);
                ServerAddressValid = false;

                return null;
            }
        }

        public async Task QuitConnection()
        {
            if (TcpClient == null || !TcpClient.Connected) return;

            await SendMessage(NetworkRequest.REQUEST_DISCONNECT);
            Console.WriteLine("Disconnecting from server...");

            TcpClient.Close();
            TcpClient.Dispose();
            TcpClient = null;

            ConnectionState = ConnectionState.Disconnected;
            OnConnectionStateChanged?.Invoke(this, ConnectionState);
        }


        public async Task LeaveQueue()
        {
            if (TcpClient == null || !TcpClient.Connected) return;

            await SendMessage(NetworkRequest.REQUEST_QUEUE_LEAVE);
            Console.WriteLine("Leaving matchmaking queue...");
        }


        public async Task JoinQueue()
        {
            if (TcpClient == null || !TcpClient.Connected) return;

            await SendMessage(NetworkRequest.REQUEST_QUEUE_CONNECT);
            Console.WriteLine("Joining matchmaking queue...");
        }

        public async Task Connect(int maxRetries)
        {
            ConnectionState = ConnectionState.EstablishingConnection;
            OnConnectionStateChanged?.Invoke(this, ConnectionState);

            for (int i = 0; i <= maxRetries; i++)
            {
                try
                {
                    if (TcpClient != null && TcpClient.Connected)
                    {
                        Debug.WriteLine("Already connected.");
                        return;
                    }

                    TcpClient?.Dispose();

                    TcpClient = new TcpClient();

                    await TcpClient.ConnectAsync(EndPoint.Address, EndPoint.Port);

                    if (TcpClient.Connected)
                    {
                        ConnectionState = ConnectionState.Connected;
                        OnConnectionStateChanged?.Invoke(this, ConnectionState);
                        Debug.WriteLine($"Connected to {IPAddress}:{Port}");
                        return;
                    }
                }
                catch (SocketException ex)
                {
                    Debug.WriteLine($"Connection attempt {i + 1} failed: {ex.Message}");
                }

                await Task.Delay(1000);
            }

            ConnectionState = ConnectionState.Disconnected;
            OnConnectionStateChanged?.Invoke(this, ConnectionState);
        }

        public async Task SyncServerState()
        {

            Player player = GameManager.GetPlayer();

            while (ConnectionState.Equals(ConnectionState.Connected))
            {
                string playerHealth = Convert.ToString(player.Health);

                await SendMessage(NetworkRequest.SEND_PLAYER_HEALTH, playerHealth);
                await SendMessage(NetworkRequest.REQUEST_GAME_STATE);
                await SendMessage(NetworkRequest.SEND_GAME_STATE);

                await Task.Delay(500);
            }
        }

        public async Task SendMessage(NetworkRequest requestType, string data = "")
        {
            if (TcpClient == null || !TcpClient.Connected) return;

            string message = requestType.ToString();
            if (!string.IsNullOrEmpty(data))
                message += $":{data}";

            byte[] buffer = Encoding.UTF8.GetBytes(message + "\n"); // Add newline for separation
            await TcpClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
            Console.WriteLine($"Sent: {message}");
        }


        private async Task ListenForData()
        {
            NetworkStream stream = TcpClient.GetStream();
            byte[] buffer = new byte[1024];

            while (TcpClient.Connected)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) break; // Connection closed

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {message}");

                // Process the message
                ProcessServerMessage(message);
            }

            Console.WriteLine("Disconnected from server.");
        }

        private void ProcessServerMessage(string message)
        {
            string[] parts = message.Split(':');
            if (parts.Length == 0) return;

            if (Enum.TryParse(parts[0], out NetworkResponse responseType))
            {
                string data = parts.Length > 1 ? parts[1] : null;

                switch (responseType)
                {
                    case NetworkResponse.SERVER_STATUS:
                        Console.WriteLine($"Server Status: {data}");
                        //EventHandler Server Status
                        break;

                    case NetworkResponse.CONNECT_SUCCESS:
                        Console.WriteLine("Connected successfully.");
                        OnConnectionStateChanged?.Invoke(this, ConnectionState.Connected);
                        break;

                    case NetworkResponse.CONNECT_FAILED:
                        Console.WriteLine("Failed to connect.");
                        OnConnectionStateChanged?.Invoke(this, ConnectionState.Failed);
                        break;

                    case NetworkResponse.DISCONNECT:
                        Console.WriteLine("Disconnected from server.");
                        OnConnectionStateChanged?.Invoke(this, ConnectionState.Disconnected);
                        break;

                    case NetworkResponse.PLAYER_COUNT:
                        if (int.TryParse(data, out int playerCount))
                        {
                            Console.WriteLine($"Online Players: {playerCount}");
                        }
                        break;

                    case NetworkResponse.QUEUE_JOIN_SUCCESS:
                        Console.WriteLine("Joined matchmaking queue.");
                        OnQueueJoined?.Invoke(this, EventArgs.Empty);
                        break;

                    case NetworkResponse.QUEUE_MATCH_FOUND:
                        Console.WriteLine("Match found!");
                        OnMatchFound?.Invoke(this, EventArgs.Empty);
                        break;

                    case NetworkResponse.QUEUE_LEFT:
                        Console.WriteLine("Left the queue.");
                        OnQueueLeft?.Invoke(this, EventArgs.Empty);
                        break;

                    default:
                        Console.WriteLine($"Unknown response: {message}");
                        break;
                }
            }
        }

    }
}