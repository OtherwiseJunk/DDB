using DartsDiscordBots.Modules.Bot.Interfaces;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using DartsDiscordBots.Permissions;

namespace DartsDiscordBots.Modules.Bot
{
	public class BotModule : ModuleBase
	{
		public const string PrivilegedUserGroup = "Privileged";
		public IBotInformation _info { get; set; }
		[Command("listchnl"), RequireSudoer]
		public async Task ListChannels()
		{
			string msg = "I'm in these guilds/channels:" + Environment.NewLine + Environment.NewLine;
			foreach (var guild in Context.Client.GetGuildsAsync().Result)
			{
				msg += "**" + guild.Name + "**" + Environment.NewLine;
				foreach (var chnl in guild.GetChannelsAsync().Result)
				{
					if (msg.Length > 1900)
					{
						await Context.Channel.SendMessageAsync(msg);
						msg = "";
					}
					msg += chnl.Name + Environment.NewLine;
				}
			}
			await Context.Channel.SendMessageAsync(msg);
		}

		[Command("playing"), RequireSudoer]
		public async Task SetPlaying([Remainder] string playing)
		{
			var client = Context.Client as DiscordSocketClient;
			await client!.SetGameAsync(playing);
		}

		[Command("say"), Discord.Commands.Summary("Echos a message.")]
		[RequireSudoer(Group = PrivilegedUserGroup), Discord.Commands.RequireUserPermission(Discord.GuildPermission.Administrator, Group = PrivilegedUserGroup)]
		public async Task Say([Remainder, Discord.Commands.Summary("The text to echo")] string echo)
		{
			// ReplyAsync is a method on ModuleBase
			await ReplyAsync(echo);
			await Context.Message.DeleteAsync();
		}

		[Command("link"), Alias("install"), Discord.Commands.Summary("Provides a link for installing the bot on other servers. You must be an admin of the target server to use the provided link.")]
		public async Task ProvideInstallLink()
		{
			await Context.Channel.SendMessageAsync(_info.InstallationLink);
		}

		[Command("repo"), Alias("github"), Discord.Commands.Summary("Provides a link for the bot's.")]
		public async Task ProvideRepoLink()
		{
			await Context.Channel.SendMessageAsync(_info.GithubRepo);
		}
		[Command("renick"), Discord.Commands.Summary("Renames the bot")]
		public async Task ChangeNickname([Remainder, Discord.Commands.Summary("what to rename the bot")] string newNick)
		{
			await Context.Guild.GetCurrentUserAsync().Result.ModifyAsync(b => b.Nickname = newNick);
		}
	}
}
