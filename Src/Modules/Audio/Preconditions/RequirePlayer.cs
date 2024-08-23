using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victoria;

namespace DartsDiscordBots.Modules.Audio.Preconditions
{
    public class RequirePlayer : PreconditionAttribute
    {
        public override async Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context,
                                                                             CommandInfo command,
                                                                             IServiceProvider provider)
        {
            var lavaNode = provider.GetRequiredService<LavaNode<LavaPlayer<LavaTrack>, LavaTrack>>();
            var player = await lavaNode.TryGetPlayerAsync(context.Guild.Id);
            return player == null
                ? await Task.FromResult(PreconditionResult.FromError("I'm not connected to a voice channel."))
                : await Task.FromResult(PreconditionResult.FromSuccess());
        }
    }
}
