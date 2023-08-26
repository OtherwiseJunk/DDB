using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartsDiscordBots.SlashCommandModules
{
    public class BaseSlashCommandModule
    {
        public List<string> ManagedCommandNames { get; set; }
        private string ModuleName { get; set; }

        public BaseSlashCommandModule(List<string> commandNames, string moduleName) {
            ManagedCommandNames = commandNames;
            ModuleName = moduleName;
        }

        public bool IsSlashCommandManager(string commandName)
        {
            return ManagedCommandNames.Contains(commandName);
        }
        internal async Task DeletePreviousCommandVersions(List<IApplicationCommand> commands)
        {
            Console.WriteLine($"Deleting previous versions of {ModuleName} commands");
            foreach (IApplicationCommand command in commands)
            {
                await command.DeleteAsync();
            }
            Console.WriteLine($"Successfully deleted previous {ModuleName} commands");
        }
    }
}
