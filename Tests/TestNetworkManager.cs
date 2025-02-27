using System;
using System.Threading.Tasks;

namespace aivftw
{
    public class TestNetworkManager
    {
        public static async Task RunTests()
        {
            Console.WriteLine("Starting NetworkManager Test...");

            NetworkManager networkManager = new NetworkManager();
            GameManager gameManager = new GameManager(networkManager); // Mock or actual GameManager

            // Subscribe to events
            networkManager.OnConnectionStateChanged += (sender, state) =>
                Console.WriteLine($"[Event] Connection State: {state}");
            networkManager.OnQueueJoined += (sender, e) =>
                Console.WriteLine("[Event] Queue joined!");
            networkManager.OnQueueLeft += (sender, e) =>
                Console.WriteLine("[Event] Queue left!");
            networkManager.OnMatchFound += async (sender, e) =>
            {
                Console.WriteLine("[Event] Match found! Requesting opponent health...");
                await networkManager.SendMessage(NetworkRequest.REQUEST_OPPONENT_HEALTH);
            };

            // Initialize and connect
            await networkManager.Initialize(gameManager);

            if (networkManager.ConnectionState == ConnectionState.Connected)
            {
                Console.WriteLine("Connected successfully!");

                // Run test cases
                Console.WriteLine("\n--- [TEST CASE 1: SUCCESSFUL MATCH] ---");
                await TestSuccessfulMatch(networkManager);

                Console.WriteLine("\n--- [TEST CASE 2: LEAVING QUEUE] ---");
                await TestLeavingQueue(networkManager);
            }
            else
            {
                Console.WriteLine("Failed to connect.");
            }

            Console.WriteLine("Test complete.");
        }

        static async Task TestSuccessfulMatch(NetworkManager networkManager)
        {
            Console.WriteLine("Joining matchmaking queue...");
            await networkManager.JoinQueue();
            await Task.Delay(5000); // Simulate waiting for match

            Console.WriteLine("Requesting opponent health...");
            await networkManager.SendMessage(NetworkRequest.REQUEST_OPPONENT_HEALTH);
            await Task.Delay(1000);

            Console.WriteLine("Sending player health update...");
            await networkManager.SendMessage(NetworkRequest.SEND_PLAYER_HEALTH, "80");
            await Task.Delay(1000);
        }

        static async Task TestLeavingQueue(NetworkManager networkManager)
        {
            Console.WriteLine("Joining matchmaking queue...");
            await networkManager.JoinQueue();
            await Task.Delay(2000); // Simulate waiting but no match found

            Console.WriteLine("Leaving queue before match is found...");
            await networkManager.LeaveQueue();
            await Task.Delay(1000);

            Console.WriteLine("Trying to request opponent health (should fail or return nothing)...");
            await networkManager.SendMessage(NetworkRequest.REQUEST_OPPONENT_HEALTH);
            await Task.Delay(1000);

            Console.WriteLine("Disconnecting from server...");
            await networkManager.QuitConnection();
        }
    }
}
