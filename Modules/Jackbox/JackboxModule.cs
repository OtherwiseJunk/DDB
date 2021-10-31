﻿using DartsDiscordBots.Modules.Jackbox.Interfaces;
using DartsDiscordBots.Modules.Jackbox.Models;
using DartsDiscordBots.Services;
using DartsDiscordBots.Services.Interfaces;
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
		IJackboxService _jb { get; set; }
		IMessageReliabilityService _messenger { get; set; }
		
		const string AllVersions = "1,2,3,4,5,6,7,8";

		public JackboxModule(IJackboxService jackboxService, IMessageReliabilityService messenger)
		{
			_jb = jackboxService;
			_messenger = messenger;
		}

		[Command]
		[Summary("Gets the description of a game by name")]
		public async Task GetJackboxGameDescription(string gameName)
		{
			JackboxGame game = _jb.GetGameDetailsForGuild(Context.Guild.Id, gameName);
			await Context.Channel.SendMessageAsync(game != null ? game.ToString() : $"Sorry, unable to find a game by the name `{gameName}`");
		}

		[Command("vote"), Alias("v")]
		[Summary("Makes a jackbox poll, and will announce a winner after 5 mintues. User must provide a comma separated list of the jack.")]
		public async Task JackboxVote([Summary("A comma seperated list of the versions of jackbox to make the list for")] string versions=AllVersions)
		{
			int[] versionList = _jb.ParseVersionList(versions, Context);
			MessageReference reference = Context.Message.Reference ?? new MessageReference(Context.Message.Id);

			List<JackboxGame> pollGameList = _jb.GetGamelistForGuild(Context.Guild.Id, versionList);
			await _messenger.SendMessageToChannel(string.Join(Environment.NewLine, pollGameList), Context.Message, Environment.NewLine);		
		}

		[Group("random"), Alias("rand","r")]
		public class Random : ModuleBase
		{
			IJackboxService _jb { get; set; }
			IMessageReliabilityService _messenger { get; set; }

			public Random(IJackboxService jackbox, IMessageReliabilityService messenger)
			{
				_jb = jackbox;
				_messenger = messenger;
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
				int[] versionList = _jb.ParseVersionList(versions, Context);
				List<JackboxGame> gameList = _jb.GetGamelistForGuild(Context.Guild.Id, versionList).Where(g => g.MinPlayers <= playerCount && g.MaxPlayers >= playerCount).ToList();

				await _messenger.SendMessageToChannel(string.Join(Environment.NewLine, gameList), Context.Message, Environment.NewLine) ;
			}
		}
		

		[Group("rate"), Alias("r8")]
		public class Rate : ModuleBase
		{
			IJackboxService _jb { get; set; }
			IMessageReliabilityService _messenger { get; set; }
			public Rate(IJackboxService jackboxService, IMessageReliabilityService messenger)
			{
				_jb = jackboxService;
				_messenger = messenger;
			}

			[Command]
			public async Task RateGame([Summary("Name of the game to rate")] string gameName, [Summary("Your 1-5 point rating. Values out of range will be rounded off to either 1 or 5.")] int rating)
			{
				JackboxGame game = _jb.GetGameDetailsForGuild(Context.Guild.Id, gameName);
				if(game != null)
				{
					_jb.SetPlayerGameRating(Context.User.Id, gameName, rating);
				}
				await Context.Channel.SendMessageAsync(game != null ? $"Ok, I've stored your rating for {gameName}" : $"Sorry, unable to find a game by the name `{gameName}`");
			}
			[Command]
			public async Task GetUserRatings([Summary("A Mention of the user whose ratings you'd like to view")] IGuildUser rater)
			{
				List<GameRating> ratings = _jb.GetPlayerGameRatings(rater.Id);
				if(ratings.Count == 0)
				{
					await Context.Channel.SendMessageAsync("Sorry, that user hasn't rated any jackbox games.");
				}
				else
				{
					await _messenger.SendMessageToChannel($"{BotUtilities.GetDisplayNameForUser(rater)}'s Ratings{Environment.NewLine}{string.Join(Environment.NewLine, ratings)}", Context.Message, Environment.NewLine);
				}
			}
		}

		[Group("modify"), Alias("m"), RequireUserPermission(ChannelPermission.ManageMessages)]
		public class Modify : ModuleBase
		{
			IJackboxService _jb { get; set; }
			public Modify(IJackboxService jackboxService)
			{
				_jb = jackboxService;
			}

		[Command("emoji"), Alias("e")]
			public async Task ChangeGameVotingEmoji(string gameName, string emote)
			{
				Emoji emoji = new Emoji(emote);
				if(emoji == null)
				{
					await Context.Channel.SendMessageAsync("Sorry, I was unable to parse that emote.");
					return;
				}
				JackboxGame game = _jb.GetGameDetailsForGuild(Context.Guild.Id, gameName);
				if(game != null)
				{
					_jb.SetGameVotingEmojiForGuild(Context.Guild.Id, gameName, );
				}
				await Context.Channel.SendMessageAsync(game != null ? $"Ok, I've modified the guild's voting emoji for {gameName}" : $"Sorry, unable to find a game by the name `{gameName}`");
			}
			[Command("player"), Alias("p")]
			public async Task ChangeGamePlayerName(string gameName, string playerName)
			{
				JackboxGame game = _jb.GetGameDetailsForGuild(Context.Guild.Id, gameName);
				if (game != null)
				{
					_jb.SetGamePlayerNameForGuild(Context.Guild.Id, gameName, playerName);
				}
				await Context.Channel.SendMessageAsync(game != null ? $"Ok, I've modified the guild's player name for {gameName}" : $"Sorry, unable to find a game by the name `{gameName}`");
			}
			[Command("description"), Alias("d")]
			public async Task ChangeGameDescription(string gameName, string description)
			{
				JackboxGame game = _jb.GetGameDetailsForGuild(Context.Guild.Id, gameName);
				if (game != null)
				{
					_jb.SetGameDescriptionForGuild(Context.Guild.Id, gameName, description);
				}
				await Context.Channel.SendMessageAsync(game != null ? $"Ok, I've modified the guild's description for {gameName}" : $"Sorry, unable to find a game by the name `{gameName}`");
			}
		}
	}
}
/