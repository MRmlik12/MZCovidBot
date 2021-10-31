using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using MZCovidBot.Services;

namespace MZCovidBot
{
    public class Bot
    {
        public async Task Run()
        {
            var provider = GetServices();
            
            provider.GetRequiredService<LogService>();
            await provider.GetRequiredService<CommandHandlerService>().Initialize();
            await provider.GetRequiredService<StartupService>().Initialize();
        }
        
        private IServiceProvider GetServices() => new ServiceCollection()
            .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Error,
                MessageCacheSize = 1000
            }))
            .AddSingleton(new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Error
            }))
            .AddSingleton<StartupService>()
            .AddSingleton<CommandHandlerService>()
            .AddSingleton<LogService>()
            .BuildServiceProvider();
    }
}