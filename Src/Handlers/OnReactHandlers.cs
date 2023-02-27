using DartsDiscordBots.Constants;
using DartsDiscordBots.Models;
using DartsDiscordBots.Services.Interfaces;
using DartsDiscordBots.Utilities;
using Discord;
using Discord.WebSocket;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Handlers
{
	public static class OnReactHandlers
	{
		public static async Task BestOfChecker(IMessage message, IBestOfService service, ulong guildId, ulong announcementChannelId, int voteThreadhold, Dictionary<string, ulong> votingEmojiIdsByName)
		{
			Guard.ArgumentNotNull(service, nameof(service));
			Guard.ArgumentNotNull(message, nameof(message));
			if (service.IsBestOf(message.Id)) return;

			IGuild guild = (message.Channel as IGuildChannel).Guild;
			Guard.ArgumentNotNull(guild, nameof(guild));
			if (guild.Id != guildId) return;

			IGuildUser author = message.Author as IGuildUser;
			Guard.ArgumentNotNull(author, nameof(author));

			IMessageChannel announcementChannel = await guild.GetChannelAsync(announcementChannelId) as IMessageChannel;
			Guard.ArgumentNotNull(announcementChannel, nameof(announcementChannel));

			foreach (KeyValuePair<IEmote, ReactionMetadata> reaction in message.Reactions)
			{
				if (votingEmojiIdsByName.Keys.Contains(reaction.Key.Name) && reaction.Value.ReactionCount >= voteThreadhold)
				{
					EmbedBuilder embedBuilder = new();
					embedBuilder.Title = $"<:{reaction.Key.Name}:{votingEmojiIdsByName[reaction.Key.Name]}>: Behold {BotUtilities.GetDisplayNameForUser(author)}'s genius!";
					embedBuilder.ThumbnailUrl = BotUtilities.GetAvatarForUser(author);
					embedBuilder.Description = $"<t:{message.Timestamp.ToUniversalTime().ToUnixTimeSeconds()}:f>: {message.Content}";
					embedBuilder.Url = message.GetJumpUrl();
					embedBuilder.WithFooter($"{message.Id}");
					IMessage bestOfMessage = await announcementChannel.SendMessageAsync("", embed: embedBuilder.Build());
					BestOf bestOf = new BestOf
					{
						MessageId = message.Id,
						MessageSentDate = message.Timestamp,
						GuildId = guild.Id,
						ChannelId = message.Channel.Id,
						UserId = author.Id,
						TriggeringEmoji = reaction.Key.Name
					};
					service.CreateBestOf(bestOf);
					return;
				}
			}
		}

		public static async Task EmbedPagingHandler(SocketReaction reaction, IMessage message, SocketSelfUser currentUser, string embedTitle, Func<IMessage, IServiceProvider,int,bool,Embed> getUpdatedEmbed, IServiceProvider serviceProvider)
		{
			//We only allow page changes for the first five minutes of a message.
			if ((DateTime.Now - message.Timestamp.DateTime).Minutes >= 5)
			{
				return;
			}
			//We only care about messages the bot has sent.
			if (message.Author.Id != currentUser.Id)
			{
				return;
			}
			//We only care about about messages with 1 embed.
			if (message.Embeds.Count != 1)
			{
				return;
			}
			//We don't care about reactions that the bot added 
			if (reaction.User.Value.Id == currentUser.Id)
			{
				return;
			}
			//Finally, we only care about the embed with our specific title
			IEmbed embed = message.Embeds.First();
			if (embed.Title != embedTitle)
			{
				return;
			}

			int currentPage = Int32.Parse(embed.Footer.Value.Text);

			if (reaction.Emote.Name == SharedConstants.LeftArrowEmoji)
			{
				//Only bother if we're not on the first page.
				if (currentPage > 0)
				{
					Embed newEmbed = getUpdatedEmbed(message, serviceProvider, currentPage, false);
					_ = ((IUserMessage)message).ModifyAsync(msg =>
					{
						msg.Embed = newEmbed;
					});
				}
				_ = message.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
			}
			if (reaction.Emote.Name == SharedConstants.RightArrowEmoji)
			{
				Embed newEmbed = getUpdatedEmbed(message, serviceProvider, currentPage, true);
				_ = ((IUserMessage)message).ModifyAsync(msg =>
				{
					msg.Embed = newEmbed;
				});
				_ = message.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
			}
		}
	}
}
