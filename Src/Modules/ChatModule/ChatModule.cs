using DartsDiscordBots.Services.Interfaces;
using DartsDiscordBots.Utilities;
using Discord.Commands;
using System.Threading.Tasks;
using System.Collections.Generic;
using Discord;
using DartsDiscordBots.Constants;
using System;
using System.Linq;

namespace DartsDiscordBots.Modules.Chat
{
	public class ChatModule : ModuleBase
	{
		IMessageReliabilityService _messenger;
		public ChatModule(IMessageReliabilityService messageReliability)
		{
			_messenger = messageReliability;
		}

		[Command("8ball"), Alias("magicconch","conch","8conch"), Summary("Ask the bot a true or false question.")]
		public async Task Send8BallResponse([Remainder, Summary("The question!")] string question = "")
		{
			await _messenger.SendMessageToChannel(ResponseCollections.EightBallResponses.GetRandom(), Context.Message, " ");
		}

		[Command("gifball"), Summary("Ask the bot a true or false question. Responds with a gif!")]
		public async Task SendGifBallResponse([Remainder, Summary("The question!")] string question = "")
		{
			await _messenger.SendMessageToChannel(ResponseCollections.GifBallResponses.GetRandom(), Context.Message, " ");
		}

		[Command("clap")]
		[Summary("Places a 👏 emoji in place of any spaces. Will delete the original message, but will include the triggering user's username.")]
		public async Task Clap([Summary("The message to Clapify."), Remainder] string msg)
		{
			string user = BotUtilities.GetDisplayNameForUser((IGuildUser)Context.Message.Author);

			await _messenger.SendMessageToChannel(SharedConstants.ReplacedMessageFormat(user, Clapify(msg)), Context.Message, " ");
			await Context.Message.DeleteAsync();
		}

		[Command("mock")]
		[Summary("Turns the text following the command into MoCKinG TExT lIkE THiS.")]
		public async Task Mock([Summary("The message to Mockify"), Remainder] string msg)
		{
			string user = (Context.Message.Author as IGuildUser).Nickname ?? Context.Message.Author.Username;
			string message = SharedConstants.ReplacedMessageFormat(user, Mockify(msg));

			await _messenger.SendMessageToChannel(message, Context.Message, " ");
			await Context.Message.DeleteAsync();
		}

		public string Clapify(string messageToClapify)
		{
			return $"👏 { string.Join(" 👏 ", messageToClapify.Split(' '))} 👏";
		}

		public string Mockify(string messageToMockify)
		{
			//Seed it based on the Discord Message Content length, author username length, guild name length, and channelname length
			int seed = Context.Message.Content.Length + Context.Message.Author.Username.Length + Context.Channel.Name.Length + Context.Guild.Name.Length;
			Random rand = new Random(seed);
			List<string> words = messageToMockify.ToLower().Split(' ').ToList();
			string mockifiedMessage = "";

			double oneThird = 1 / 3.0;
			double chance = oneThird;
			bool capitalize = rand.Next() % 2 == 0;

			foreach (string word in words)
			{
				foreach (char letter in word)
				{
					if (Char.IsLetter(letter))
					{
						// The new algorithm guarantees that there is never a run of greater than three characters with the same capitalization status.
						// Essentially, the chance of switching capitalization increases each time it doesn't switch.
						// Note that it doesn't increment if the current character isn't a letter. This shouldn't matter much.
						if (rand.NextDouble() < chance)
						{
							capitalize = !capitalize;
							chance = oneThird;
						}
						else
						{
							chance += oneThird;
						}
						if (capitalize)
						{
							mockifiedMessage += Char.ToUpper(letter);
						}
						else
						{
							mockifiedMessage += letter;
						}
					}
					else
					{
						mockifiedMessage += letter;
					}
				}
				mockifiedMessage += " ";
			}
			return mockifiedMessage;
		}
	}
}
