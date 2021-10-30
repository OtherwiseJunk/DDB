using DartsDiscordBots.Modules.Jackbox.Interfaces;
using DartsDiscordBots.Modules.Jackbox.Models;
using DartsDiscordBots.Services;
using DartsDiscordBots.Utilities;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Modules.Jackbox
{
	[Group("jackbox"), Alias("jb"), Name("Jackbox Module")]
	public class JackboxModule : ModuleBase
	{
		IJackboxConstants _jackboxConstants { get; set; }
		IJackboxService _jb { get; set; }
		MessageReliabilityService _reliabiity { get; set; }

		static string ParsingIntError = "Sorry, I was unable to parse one of those Jackbox Version numbers.";
		const string AllVersions = "1,2,3,4,5,6,7,8";

		public JackboxModule(IJackboxConstants jackboxConstants)
		{
			_jackboxConstants = jackboxConstants;			
		}

		[Command]
		[Summary("Gets the description of a game by name")]
		public async Task GetJackboxGameDescription(string gameName)
		{
			JackboxGame game = _jb.GetGameDescriptionForGuild(Context.Guild.Id, gameName);
			await Context.Channel.SendMessageAsync(game != null ? game.ToString() : $"Sorry, unable to find a game by the name `{gameName}`");
		}

		[Command("vote"), Alias("v")]
		[Summary("Makes a jackbox poll, and will announce a winner after 5 mintues. User must provide a comma separated list of the jack.")]
		public async Task JackboxVote([Summary("A comma seperated list of the versions of jackbox to make the list for")] string versions)
		{
			int[] versionList = _jb.ParseVersionList(versions, Context);
			MessageReference reference = Context.Message.Reference ?? new MessageReference(Context.Message.Id);

			List<JackboxGame> pollGameList = _jb.GetGamelistForGuild(Context.Guild.Id, versionList);
			await _reliabiity.SendMessageToChannel(string.Join(Environment.NewLine, pollGameList), Context.Channel, reference, new List<ulong>(Context.Message.MentionedUserIds), Environment.NewLine)			
		}

		[Group("random"), Alias("rand","r")]
		public class Random : ModuleBase
		{
			IJackboxService _jb { get; set; }
			public Random(IJackboxService jackbox)
			{
				_jb = jackbox;
			}

			[Command, Summary("Get a random game. By default will search all available games, but a version list can be provided.")]
			public async Task JackboxRandom([Summary("A comma seperated list of the versions of jackbox to make the list for")] string versions = AllVersions)
			{				
				int[] versionList = _jb.ParseVersionList(versions, Context);

				await Context.Channel.SendMessageAsync(_jb.GetGamelistForGuild(Context.Guild.Id, versionList).GetRandom().ToString());
			}

			[Command("players"), Alias("playercount", "pc"), Name("Random Jackbox Game by Player Count")]
			public async Task JackboxPlayerRandom(int playerCount, [Summary("A comma seperated list of the versions of jackbox to make the list for")] string versions = AllVersions)
			{
				List<JackboxGame> fullGameList = new List<JackboxGame>();
				List<int> versionList;
				try
				{
					versionList = versions.Split(',').ToList().ConvertAll(int.Parse);
				}
				catch
				{
					await Context.Channel.SendMessageAsync(ParsingIntError);
					return;
				}
				foreach (int versionNum in versionList)
				{
					fullGameList.AddRange(_jackboxConstants.JackboxGameListByNumber[versionNum].Where(g => g.MinPlayers <= playerCount && g.MaxPlayers >= playerCount));
				}
				await Context.Channel.SendMessageAsync(fullGameList.GetRandom().ToString());
			}
		}
		

		[Group("rate"), Alias("r8")]
		public class Rate : ModuleBase
		{
			[Command]
			public async Task RateGame([Summary("Name of the game to rate")] string gameName, [Summary("Your 1-5 point rating. Values out of range will be rounded off to either 1 or 5.")] int rating)
			{

			}
			[Command]
			public async Task GetUserRatings([Summary("A Mention of the user whose ratings you'd like to view")] IUser rater)
			{

			}
		}

		[Group("modify"), Alias("m"), RequireUserPermission(ChannelPermission.ManageMessages)]
		public class Modify : ModuleBase
		{
			[Command("emoji"), Alias("e")]
			public async Task ChangeGameVotingEmoji(string gameName, IEmote emote)
			{

			}
			[Command("player"), Alias("p")]
			public async Task ChangeGamePlayerName(string gameName, string playerName)
			{

			}
			[Command("description"), Alias("d")]
			public async Task ChangeGameDescription(string gameName, string description)
			{

			}
		}
	}
}
