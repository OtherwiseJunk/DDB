using Discord.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DartsDiscordBots.Permissions
{
    public class RequireChannelAttribute(ulong[] channelIds) : PreconditionAttribute
    {
	    public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
		{
			return Task.FromResult(channelIds.Contains(context.Channel.Id) ? PreconditionResult.FromSuccess() : PreconditionResult.FromError("That command is not available on this channel."));
		}
	}

    

    public class RequireGuildAttribute(ulong[] guildIds) : PreconditionAttribute
    {
	    public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
		{
			return Task.FromResult(guildIds.Contains(context.Guild.Id) ? PreconditionResult.FromSuccess() : PreconditionResult.FromError("That command is not available on this channel."));
		}
	}

	public class RequireRoleName(string roleName) : PreconditionAttribute
	{
		public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
		{
			var role = context.Guild.Roles.FirstOrDefault(r => string.Equals(r.Name, roleName, StringComparison.CurrentCultureIgnoreCase));
			return Task.FromResult(role != null ? PreconditionResult.FromSuccess() : PreconditionResult.FromError($"I don't see any {roleName} here. Did you create the role?"));
		}
	}

	public class RequireSudoer : PreconditionAttribute
	{
		readonly ulong[] _sudoers = [94545463906144256];
		
		public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
		{
			return Task.FromResult(_sudoers.Contains(context.User.Id) ? PreconditionResult.FromSuccess() : PreconditionResult.FromError(""));
		}
	}
	public class RequireRoleMembership(string roleName) : PreconditionAttribute
	{
		readonly string _roleName = roleName;

		public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
		{
			var role = context.Guild.Roles.FirstOrDefault(r => r.Name.ToLower() == _roleName.ToLower());
			if (role == null)
				return Task.FromResult(
					PreconditionResult.FromError($"I don't see any {_roleName} here. Did you create the role?"));
			
			var users = context.Guild.GetUsersAsync().Result.Where(u => u.RoleIds.Contains(role.Id)).ToList();
			return Task.FromResult(users.Count > 0 ? PreconditionResult.FromSuccess() : PreconditionResult.FromError($"I don't see any {_roleName} here. Did you create the role?"));
		}
	}
}
