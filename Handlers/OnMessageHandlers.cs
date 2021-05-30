using DartsDiscordBots.Utilities;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DartsDiscordBots.Handlers
{
	public static class OnMessageHandlers
	{
		public static async Task HandleCommandWithSummaryOnError(SocketMessage messageParam, CommandContext context, CommandService commandService, IServiceProvider serviceProvider, char commandPrefix)
		{
			var message = messageParam as SocketUserMessage;
			if (message == null) return;
			int argPos = 0;
			if (!message.HasCharPrefix(commandPrefix, ref argPos) && !false) return;
			var result = await commandService.ExecuteAsync(context, argPos, serviceProvider);
			if (!result.IsSuccess)
			{
				CommandInfo commandFromModuleGroup = commandService.Commands.FirstOrDefault(c => $"{commandPrefix}{c.Module.Group}" == message.Content.ToLower());
				CommandInfo commandFromNameWithGroup = commandService.Commands.FirstOrDefault(c => $"{commandPrefix}{c.Module.Group} {c.Name}" == message.Content.ToLower());
				CommandInfo commandFromName = commandService.Commands.FirstOrDefault(c => $"{commandPrefix}{c.Name}" == message.Content.ToLower());
				if (commandFromModuleGroup != null)
				{
					await context.Channel.SendMessageAsync(BotUtilities.BuildModuleInfo(commandPrefix, commandFromModuleGroup.Module));
				}
				if (commandFromNameWithGroup != null || commandFromName != null)
				{
					await context.Channel.SendMessageAsync(BotUtilities.BuildDetailedCommandInfo(commandPrefix, (commandFromName ?? commandFromNameWithGroup)));
				}
			}
		}
	}
}