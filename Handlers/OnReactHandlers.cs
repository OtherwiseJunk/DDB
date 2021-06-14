using DartsDiscordBots.Constants;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Handlers
{
	public static class OnReactHandlers
	{
		public static async Task EmbedPagingHandler(SocketReaction reaction, IMessage msg, SocketSelfUser currentUser, string embedTitle, Action<IMessage,IServiceProvider,int> updateEmbedLogic, IServiceProvider serviceProvider)
		{
			//We only allow page changes for the first five minutes of a message.
			if ((DateTime.Now - msg.Timestamp.DateTime).Minutes >= 5)
			{
				return;
			}
			//We only care about messages the bot has sent.
			if (msg.Author.Id != currentUser.Id)
			{
				return;
			}
			//We only care about about messages with 1 embed.
			if (msg.Embeds.Count != 1)
			{
				return;
			}
			//We don't care about reactions that the bot added 
			if (reaction.User.Value.Id == currentUser.Id)
			{
				return;
			}
			//Finally, we only care about the embed with our specific title
			IEmbed embed = msg.Embeds.First();
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
					_ = updateEmbedLogic(msg, serviceProvider, currentPage);
				}
				_ = msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
			}
			if (reaction.Emote.Name == SharedConstants.RightArrowEmoji)
			{
				_ = updateEmbedLogic(msg,serviceProvider, currentPage);
				_ = msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
			}
		}
	}
}
