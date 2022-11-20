using DartsDiscordBots.Modules.Jackbox.Models;
using Discord;
using Discord.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartsDiscordBots.Modules.Jackbox.Interfaces
{
	public interface IJackboxService
	{
		public int[] ParseVersionList(string versionList, ICommandContext context);
		public JackboxGame GetGameDetailsForGuild(ulong discordGuildId, string gameName);
		public List<JackboxGame> GetGamelistForGuild(ulong discordGuildId, int[] versionList);
		public List<GameRating> GetPlayerGameRatings(ulong discordUserId);
		public GameRating GetPlayerGameRating(ulong discordUserId, string gameName);		
		public GameRating SetPlayerGameRating(ulong discordUserId, string gameName, int rating);
		public void SetGameVotingEmojiForGuild(ulong discordGuildId, string gameName, IEmote emote);
		public void SetGameDescriptionForGuild(ulong discordGuildId, string gameName, string description);
		public void SetGamePlayerNameForGuild(ulong discordGuildId, string gameName, string playerName);
	}
}
