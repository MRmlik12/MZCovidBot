using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace MZCovidBot.Services
{
    public class LogService
    {
        public LogService(DiscordSocketClient client)
        {
            client.Log += Log;
        }

        private static Task Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            
            return Task.CompletedTask;
        }
    }
}