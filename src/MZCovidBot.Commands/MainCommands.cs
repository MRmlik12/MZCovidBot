using System.ComponentModel;
using System.Threading.Tasks;
using Discord.Commands;

namespace MZCovidBot.Commands
{
    public class MainCommands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Description("Checks bot response time!")]
        public async Task Ping()
            => await Context.Channel.SendMessageAsync($"{Context.Message.Author.Mention} " +
                                                      $" :ping_pong: Pong in {Context.Client.Latency.ToString()}ms!");
    }
}