using System;
using System.Collections.Generic;
using System.Text;

namespace DartsDiscordBots.Constants
{
	public class SharedConstants
	{
		#region String Formats
		public static string ReplacedMessageFormat(string username, string modifiedMessage) => $"**{username}:** {modifiedMessage}";
		#endregion
		#region Unicode Emote Strings
		public static string LeftArrowEmoji = "⬅️";
		public static string RightArrowEmoji = "➡️";
		#endregion
	}
}
