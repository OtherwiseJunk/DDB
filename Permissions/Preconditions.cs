using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartsDiscordBots.Permissions
{
    public class RequireChannelAttribute : PreconditionAttribute
    {
        public ulong[] ChannelIds;
        public RequireChannelAttribute(ulong[] channelIds)
        {
            ChannelIds = channelIds;
        }

		public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
		{

			if (ChannelIds.Contains(context.Channel.Id))
			{
				return Task.FromResult(PreconditionResult.FromSuccess());
			}				
			return Task.FromResult(PreconditionResult.FromError("That command is not available on this channel."));
		}
	}

    

    public class RequireGuildAttribute : PreconditionAttribute
    {        
        public ulong[] GuildIds;
        public RequireGuildAttribute(ulong[] guildIds)
        {
            GuildIds = guildIds;
        }

		public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
		{
			if (GuildIds.Contains(context.Guild.Id)) {
				return Task.FromResult(PreconditionResult.FromSuccess());
			}				
			return Task.FromResult(PreconditionResult.FromError("That command is not available on this channel."));
		}
	}

	public class RequireRoleName : PreconditionAttribute
	{
		public string RoleName;

		public RequireRoleName(string roleName)
		{
			RoleName = roleName;
		}

		public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
		{
			IRole role = context.Guild.Roles.FirstOrDefault(r => r.Name.ToLower() == RoleName.ToLower());
			if(role != null)
			{
				List<IGuildUser> users = context.Guild.GetUsersAsync().Result.Where(u => u.RoleIds.Contains(role.Id)).ToList();
				if (users.Count > 0)
				{
					return Task.FromResult(PreconditionResult.FromSuccess());
				}
			}			
			return Task.FromResult(PreconditionResult.FromError($"I don't see any {RoleName} here. Did you create the role?"));
		}
	}
}
