using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DartsDiscordBots.SlashCommandModules
{
    public interface ISlashCommandModule
    {
        public Task InstallModuleSlashCommands(IGuild? guild, DiscordSocketClient client);
        public Task HandleSocketSlashCommand(SocketSlashCommand command);
    }
}
