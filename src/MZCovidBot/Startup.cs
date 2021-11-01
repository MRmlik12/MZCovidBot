using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using MZCovidBot.Database;
using MZCovidBot.Services;
using Quartz;

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
            await provider.GetRequiredService<IScheduler>().Start();
        }

        private async Task<IScheduler> GetScheduler()
            => await SchedulerBuilder.Create()
                .UseDefaultThreadPool(x => x.MaxConcurrency = 5)
                .UsePersistentStore(x =>
                {
                    x.UseProperties = true;
                    x.UseClustering();
                    x.UsePostgres(Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? string.Empty);
                    x.UseJsonSerializer();
                })
                .BuildScheduler();

        private IContainer GetAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DatabaseModule());

            return containerBuilder.Build();
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
            .AddSingleton(GetScheduler())
            .AddSingleton<StartupService>()
            .AddSingleton<CommandHandlerService>()
            .AddSingleton<LogService>()
            .AddSingleton(new AutofacServiceProvider(GetAutofacContainer()))
            .BuildServiceProvider();
    }
}