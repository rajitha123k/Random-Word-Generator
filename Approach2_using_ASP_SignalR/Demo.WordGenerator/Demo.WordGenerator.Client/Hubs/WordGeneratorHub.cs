using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Demo.WordGenerator.Client.Hubs
{
    public class WordGeneratorHub
    {
        private const string _hubUrl = "http://localhost:5000/WordGeneratorHub";
        private readonly HubConnection _hubConnection;

        static Action<string> OnReceivedAction = OnCurrentWordSelected;

        public WordGeneratorHub()
        {
            var builder = new HubConnectionBuilder().WithUrl(_hubUrl);
            _hubConnection = builder.Build();
        }

        public async Task<bool> ConnectAsync()
        {
            try
            {
                await _hubConnection.StartAsync().ContinueWith(x => {
                    _hubConnection.On<string>("CurrentWordSelected", OnCurrentWordSelected);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection error: {ex.Message}");
                return false;
            }

            return true;
        }

        public async Task<String> AddWordAsync(String word)
        {
            return await _hubConnection.InvokeAsync<String>("AddWord", word);
        }

        public async Task<int> GetCommandTimeRemainingAsync()
        {
            return await _hubConnection.InvokeAsync<int>("GetCommandTimeRemaining");
        }

        public async Task<bool> GetCommandRunningAysnc()
        {
            return await _hubConnection.InvokeAsync<bool>("GetCommandRunning");
        }

        public async Task StartAsync()
        {
            await _hubConnection.InvokeAsync("start");
        }

        static void OnCurrentWordSelected(string word)
        {
            Console.WriteLine("Received word " + word);
        }
    }
}
