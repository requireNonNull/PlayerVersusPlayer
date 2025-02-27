using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace aivftwserver
{
    public class NetworkManager
    {
        public event Action<string> PlayerConnected;
        public event Action<string> PlayerDisconnected;

        private TcpListener _tcpListener;
        private List<TcpClient> _connectedClients = new List<TcpClient>();
        private Dictionary<string, TcpClient> _players = new Dictionary<string, TcpClient>(); // Store players by name

        public int Port { get; private set; }
        public IPAddress IPAddress { get; private set; }

        public NetworkManager()
        {
        }

        public async Task Initialize()
        {
            IPAddress = GetGameServerAddress();
            await GetGameServerPort();

            //_tcpListener = new TcpListener(IPAddress, Port);
            _tcpListener = new TcpListener(IPAddress, Port);
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
                        }
                        else
                        {
                            Debug.WriteLine("Port not valid!");
                        }

                    }
                    else
                    {
                        Debug.WriteLine("Port url invalid or offline?");
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }

        public IPAddress GetGameServerAddress()
        {
            try
            {
                string Domain = AppInfo.gameServerDomain;

                IPAddress[] iPAddresses;

                iPAddresses = Dns.GetHostAddresses(Domain);

                return iPAddresses.FirstOrDefault();

            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return null;
            }
        }

        public async Task StartServer()
        {
            _tcpListener.Start();
            Console.WriteLine($"Server started on {IPAddress}:{Port}... Waiting for connections.");

            while (true)
            {
                var tcpClient = await _tcpListener.AcceptTcpClientAsync();
                await Task.Run(() => HandleClient(tcpClient)); // Handle each client asynchronously
            }
        }

        private async Task HandleClient(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];
            string playerName = Guid.NewGuid().ToString(); // Generate a temporary name for the player

            _players[playerName] = tcpClient;
            _connectedClients.Add(tcpClient);
            Console.WriteLine($"{playerName} connected.");

            PlayerConnected?.Invoke(playerName);

            try
            {
                while (tcpClient.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client disconnected

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received from {playerName}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                tcpClient.Close();
                _connectedClients.Remove(tcpClient);
                _players.Remove(playerName);
                PlayerDisconnected?.Invoke(playerName);
                Console.WriteLine($"{playerName} disconnected.");
            }
        }

        public void StopServer()
        {
            _tcpListener.Stop();
            Console.WriteLine("Server stopped.");
        }

        public int GetConnectedPlayerCount()
        {
            return _connectedClients.Count;
        }

        public Dictionary<string, TcpClient> GetConnectedPlayers()
        {
            // Create a dictionary to hold player names and their corresponding TcpClient
            var connectedPlayersDict = _players;

            // Loop through the connected clients and add to the dictionary
            foreach (var player in _players)
            {
                connectedPlayersDict.Add(player.Key, player.Value);
            }

            return connectedPlayersDict;
        }

    }
}
