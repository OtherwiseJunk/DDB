using DartsDiscordBots.Utilities;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;
using DartsDiscordBots.Constants;
using Serilog;

namespace DartsDiscordBots.Handlers
{
	public static class OnMessageHandlers
	{
		public static async Task HandleCommandWithSummaryOnError(SocketMessage messageParam, CommandContext context, CommandService commandService, IServiceProvider serviceProvider, char commandPrefix)
		{
			ILogger log = (ILogger)serviceProvider.GetService(typeof(ILogger));
			log.Information("Handling command. Casting messageParam as SocketUserMessage...");
			var message = messageParam as SocketUserMessage;
			if (message == null) return;
			log.Information("Cast successful!");
			int argPos = 0;
			log.Information("Checking if we're talking to a bot...");
			if (!message.HasCharPrefix(commandPrefix, ref argPos) || messageParam.Author.IsBot) return;
			log.Information("We're not!");
			if (BotUtilities.ShouldDoAprilFoolsShenanigans())
			{
				log.Information("Aw yeah, time for some April Fools Day Pranks!");
				await message.Channel.SendMessageAsync("Oh sure let me get that for you one sec...");
				await message.Channel.SendMessageAsync(SharedConstants.FuckYouGifs.GetRandom());
			}
			else
			{
				IResult result;

				try
                {
					log.Information("Attempting to execute command");
					result = await commandService.ExecuteAsync(context, argPos, serviceProvider);
				}
                catch(Exception ex)
                {
                    log.Error(ex.Message);
					log.Information("Looping through any inner exceptions...");
                    while (ex.InnerException != null)
                    {
                        log.Error(ex.InnerException.Message);
                        ex = ex.InnerException;
                    }
					log.Information("Done looping.");
                }
                log.Information($"Command success? {result.IsSuccess}");
                if (!result.IsSuccess)
                {
                    log.Error($"Error Type: {result.Error}");
					log.Error($"Error Reason: {result.ErrorReason}");
                    log.Information("Command processing failed. Attempting to get Command Information.");
					CommandInfo commandFromModuleGroup = commandService.Commands.FirstOrDefault(c => $"{commandPrefix}{c.Module.Group}" == message.Content.ToLower());
					log.Information($"Command Info from Module Group successfully found? {commandFromModuleGroup != null}");
                    CommandInfo commandFromNameWithGroup = commandService.Commands.FirstOrDefault(c => $"{commandPrefix}{c.Module.Group} {c.Name}" == message.Content.ToLower());
					log.Information($"Command Info With Name Group successfully found? {commandFromNameWithGroup != null}");
                    CommandInfo commandFromName = commandService.Commands.FirstOrDefault(c => $"{commandPrefix}{c.Name}" == message.Content.ToLower());
					log.Information($"Command Info With Name successfully found? {commandFromName != null}");
					if (commandFromModuleGroup != null)
					{
						await context.Channel.SendMessageAsync(HelpUtilities.BuildModuleInfo(commandPrefix, commandFromModuleGroup.Module));
					}
					if (commandFromNameWithGroup != null || commandFromName != null)
					{
						await context.Channel.SendMessageAsync(HelpUtilities.BuildDetailedCommandInfo(commandPrefix, (commandFromName ?? commandFromNameWithGroup)));
						await context.Channel.SendMessageAsync(result.ErrorReason);
					}
				}
			}
		}
	}
}