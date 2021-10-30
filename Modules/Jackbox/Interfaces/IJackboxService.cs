using DartsDiscordBots.Modules.Jackbox.Models;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DartsDiscordBots.Modules.Jackbox.Interfaces
{
	public interface IJackboxService
	{
		public int[] ParseVersionList(string versionList, ICommandContext context);
		public JackboxGame? GetGameDescriptionForGuild(ulong discordServerId, string gameName);
		public List<JackboxGame> GetGamelistForGuild(ulong discordServerId, int[] versionList);
	}
}
