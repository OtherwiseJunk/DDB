using Discord.Commands;
using System;
using System.Text;

namespace DartsDiscordBots.Utilities
{
    public class HelpUtilities
    {
        public static string isOptionalIndicator = "?";
        public static string isMultipleIndicator = "*";
        public static string isRemainderIndicator = "%";

		public static string BuildModuleInfo(char prefix, ModuleInfo module)
		{
			StringBuilder sb = new StringBuilder($"{module.Name} Module's commands:").AppendLine();
			foreach (CommandInfo command in module.Commands)
			{
				sb.AppendLine(BuildCommandInfo(prefix, command));
			}
			sb.AppendLine()
				.AppendLine($"`{isOptionalIndicator}` - Indicates an optional paramter")
				.AppendLine($"`{isMultipleIndicator}` - indicates a parameter which can be supplied multiple times")
				.AppendLine($"`{isRemainderIndicator}` - indicates a paramter which will look at the remainder of the entered text and will not break on whitespace");
			return sb.ToString();
		}
		public static string BuildCommandInfo(char prefix, CommandInfo command)
		{
			StringBuilder sb = new StringBuilder();
			string parameters = "";
			if (command.Parameters.Count > 0)
			{
				StringBuilder psb = new StringBuilder();
				foreach (ParameterInfo parameter in command.Parameters)
				{
					psb.Append($"<{parameter.Name}" +
						$"{(parameter.IsOptional ? isOptionalIndicator : String.Empty)}" +
						$"{(parameter.IsMultiple ? isMultipleIndicator : String.Empty)}" +
						$"{(parameter.IsRemainder ? isRemainderIndicator : String.Empty)}" +
						"> ");
				}

				parameters = psb.ToString().Trim();
			}
			sb.Append($"`{prefix}{command.Module.Group} {command.Name} {parameters}`- {command.Summary}");
			return sb.ToString();
		}
		public static string BuildDetailedCommandInfo(char prefix, CommandInfo command)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(BuildCommandInfo(prefix, command));
			sb.Append("Parameters: ");
			foreach (ParameterInfo parameter in command.Parameters)
			{
				sb.AppendLine(BuildParameterInfo(parameter));
			}
			return sb.ToString();
		}
		public static string BuildParameterInfo(ParameterInfo parameter)
		{
			return $"`{parameter.Name.ToPascalCase()} (Optional:{parameter.IsOptional}, Multiple:{parameter.IsMultiple}, Remainder of Message: {parameter.IsRemainder})` - {parameter.Summary}";
		}
	}
}
