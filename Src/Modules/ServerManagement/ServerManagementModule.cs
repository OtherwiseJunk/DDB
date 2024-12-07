using DartsDiscordBots.Modules.ServerManagement.Interfaces;
using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace DartsDiscordBots.Modules.ServerManagement
{
	public class ServerManagementModule : ModuleBase
	{
		public IServerManagmentService _server;
		public ServerManagementModule(IServerManagmentService server) { _server = server; }

		[Command("rolecolor"), Summary("Creates a role with your name with the specified (in hex) color. Ex) `rolecolor #000000`"), RequireBotPermission(GuildPermission.ManageRoles)]
		public async Task RoleColorChange([Remainder, Summary("The hexcode for your desired color.")] string hexText)
		{
			if (_server.hexColorValidator.Match(hexText).Success && (hexText.Length == 7 || hexText.Length == 4))
			{
				var role = _server.ModifyUserRoleColor(hexText, this.Context.User, Context).Result;
				await (this.Context.User as IGuildUser).AddRoleAsync(role);
			}
			else
			{
				await this.Context.Channel.SendMessageAsync("Sorry, I can't recognize that hexcode. Maybe I'm an idiot, iunno.");
			}
		}

		[Command("roleemote"), Summary("Creates or updates a role with your name with the specified emoji. Ex) `roleemoji :emoji:`")]
		public async Task RoleEmojiChange([Remainder, Summary("The emoji for your desired role.")] ulong emoteId)
		{
			var serverEmote = await Context.Guild.GetEmoteAsync(emoteId);
			if (serverEmote == null)
			{
				Console.WriteLine("Sorry, the emoji should be in the server. I can't guarantee I can access it otherwise.");
				return;
			}
            var role = _server.ModifyUserRoleEmoji(serverEmote, this.Context.User, Context).Result;
            await (this.Context.User as IGuildUser).AddRoleAsync(role);
		}

		[Command("avatar"), Summary("get mentioned user's avatar")]
		public async Task Avatar([Summary("An @Mention of a user in the chat. Leave blank for your own avatar.")]IUser? MentionedUser = null)
		{
			IUser user = Context.User;
			if (MentionedUser != null)
			{
				user = MentionedUser;
			}
			EmbedBuilder eb = new EmbedBuilder();
			eb.ImageUrl = user.GetAvatarUrl();
			await Context.Channel.SendMessageAsync(embed: eb.Build());
		}
	}
}
