using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using MZCovidBot.Commands;

namespace MZCovidBot.Services
{
    public class CommandHandlerService
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _provider;
        
        public CommandHandlerService(DiscordSocketClient client, CommandService commands, IServiceProvider provider)
        {
            _client = client;
            _commands = commands;
            _provider = provider;
        }

        public async Task Initialize()
        {
            _client.MessageReceived += HandleCommands;
            
            await _commands.AddModulesAsync(assembly: Assembly.GetAssembly(typeof(MainCommands)), 
                services: _provider);
        }

        //See: https://docs.stillu.cc/guides/commands/intro.html
        private async Task HandleCommands(SocketMessage arg)
        {
            if (arg is not SocketUserMessage message) return;

            var argPos = 0;
            
            if (!(message.HasCharPrefix(Convert.ToChar(Environment.GetEnvironmentVariable("PREFIX") ?? "$"), ref argPos) || 
                  message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;
            
            var context = new SocketCommandContext(_client, message);
            
            await _commands.ExecuteAsync(
                context: context, 
                argPos: argPos,
                services: _provider);
        }
    }
}