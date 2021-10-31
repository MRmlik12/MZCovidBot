using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace MZCovidBot.Services
{
    public class StartupService
    {
        private readonly DiscordSocketClient _client;
        
        public StartupService(DiscordSocketClient client)
        {
            _client = client;
        }
        
        public async Task Initialize()
        {
            await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("DISCORD_TOKEN"));
            await _client.StartAsync();

            await Task.Delay(-1);
        }
    }
}