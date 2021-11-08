using System;
using System.Threading.Tasks;
using AutoMapper;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using MZCovidBot.Database;
using MZCovidBot.Database.Interfaces;
using MZCovidBot.Database.Repository;
using MZCovidBot.Jobs;
using MZCovidBot.Services;

namespace MZCovidBot
{
    public class Startup
    {
        public async Task Run()
        {
            var provider = GetServices();

            provider.GetRequiredService<LogService>();
            await provider.GetRequiredService<CommandHandlerService>().Initialize();
            await provider.GetRequiredService<StartupService>().Initialize();
            await provider.GetRequiredService<Scheduler>().Setup();

            await Task.Delay(-1);
        }

        private IServiceProvider GetServices()
        {
            return new ServiceCollection()
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
                .AddSingleton<Scheduler>()
                .AddSingleton<IMapper>(new Mapper(
                        AutoMapperConfiguration.GetConfiguration()
                    )
                )
                .AddSingleton<MongoDbContext>()
                .AddSingleton<ICovidDataRepository, CovidDataRepository>()
                .AddTransient<SendCovidStatJob>()
                .BuildServiceProvider();
        }
    }
}