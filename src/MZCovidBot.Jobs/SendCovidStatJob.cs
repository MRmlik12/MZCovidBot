using System;
using System.Threading.Tasks;
using AutoMapper;
using Discord;
using Discord.WebSocket;
using MZCovidBot.Database.Interfaces;
using MZCovidBot.Database.Models;
using MZCovidBot.Stats.Api;
using MZCovidBot.Stats.Api.Models;
using Quartz;

namespace MZCovidBot.Jobs
{
    public class SendCovidStatJob : IJob
    {
        private readonly ICovidDataRepository _covidDataRepository;
        private readonly DiscordSocketClient _discordSocketClient;
        private readonly IMapper _mapper;

        public SendCovidStatJob(
            DiscordSocketClient discordSocketClient,
            ICovidDataRepository covidDataRepository,
            IMapper mapper
        )
        {
            _discordSocketClient = discordSocketClient;
            _covidDataRepository = covidDataRepository;
            _mapper = mapper;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var stats = await ApifyCovidApi.GetLatestCovidStats();
            var latestStat = await _covidDataRepository.GetLatest();

            if (stats.LastUpdatedAtSource <= latestStat?.LastUpdatedAtSource) return;

            await _covidDataRepository.Create(_mapper.Map<CovidData>(stats));
            var latestStatsFromWeek = await _covidDataRepository.GetWeekData(DateTimeOffset.Now);
            var infectedChartUrl = GenerateChart.GetGeneratedChartUrl(latestStatsFromWeek);

            var channel =
                (IMessageChannel)_discordSocketClient.GetChannel(
                    Convert.ToUInt64(Environment.GetEnvironmentVariable("CHANNEL_ID"))
                );

            if (channel != null) await channel.SendMessageAsync(embed: GetCovidEmbed(stats, infectedChartUrl));
        }

        private static Embed GetCovidEmbed(LatestCovidStats stats, string imageUrl)
        {
            var embed = new EmbedBuilder
            {
                Title = $"Daily covid statistics from {stats.TxtDate}",
                Color = Color.Red,
                Footer = new EmbedFooterBuilder()
                    .WithText($"Delivered at {DateTime.Now:HH:mm:ss MM/dd/yyyy}")
            };

            embed.AddField("Infected", stats.DailyInfected, true)
                .AddField("Deceased", stats.DailyDeceased, true)
                .AddField("Recovered", stats.DailyRecovered, true)
                .WithImageUrl(imageUrl);

            return embed.Build();
        }
    }
}