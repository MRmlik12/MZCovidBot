using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Quartz;

namespace MZCovidBot.Jobs
{
    public class DownloadCovidStatJob : IJob
    {
        private readonly DiscordSocketClient _discordSocketClient;

        public DownloadCovidStatJob(DiscordSocketClient discordSocketClient)
        {
            _discordSocketClient = discordSocketClient;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var channel =
                _discordSocketClient.GetChannel(Convert.ToUInt64(Environment.GetEnvironmentVariable("CHANNEL_ID"))) as
                    IMessageChannel;
            if (channel != null) await channel.SendMessageAsync("Hello!");
        }
    }
}