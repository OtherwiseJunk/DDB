using Discord;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using static DartsDiscordBots.Constants.SharedConstants;

namespace DartsDiscordBots.Utilities
{
    public static class BotUtilities
    {
        public static bool PercentileCheck(int successCheck)
        {
            return CreateSeededRandom().Next(1, 100) <= successCheck;
        }

		public static Random CreateSeededRandom()
		{
			return new Random(Guid.NewGuid().GetHashCode());
		}

        public static bool isMentioningMe(SocketMessage message, Regex identificationRegex, ulong botId)
		{
			return identificationRegex.IsMatch(message.Content) || message.MentionedUsers.FirstOrDefault(u => u.Id == botId) != null;
        }
        public static bool isUserFlippingTable(string msg, out TableFlipType? type)
        {
			type = null;
            if (Regex.IsMatch(msg, DoubleTableFlipRegex))
            {
				type = TableFlipType.Double;
                return true;
            }
            else if (Regex.IsMatch(msg, EnragedTableFlipRegex))
            {
				type = TableFlipType.Enraged;
				return true;
            }
            else if (Regex.IsMatch(msg, TableFlipRegex))
            {
				type = TableFlipType.Single;
				return true;
			}

			return false;
		}
		public static string GetDisplayNameForUser(IGuildUser user, string defaultName = "A sexy, unknowable stranger")
		{
			Console.WriteLine($"[DDB] - Received Name Lookup Request. User object null? {user == null}");
			if (user != null)
			{
				Console.WriteLine($"[DDB] - Attempting to retrieve nickname for {user.Username}. Failing that will return username.");
				return user.Nickname ?? user.Username;
			}
			return defaultName;
		}
		public static string GetAvatarForUser(IGuildUser user, string defaultAvatarURL)
		{
			if(user != null)
			{
				string avatarUrl = user.GetGuildAvatarUrl();
				if (avatarUrl != null)
				{
					return avatarUrl;
				}
				avatarUrl = user.GetAvatarUrl();
				if (avatarUrl != null)
				{
					return avatarUrl;
				}							
			}
			return defaultAvatarURL;
		}
		public static bool IsAprilFoolsDay()
        {
			DateTime now = DateTime.Now;
			return now.Month == 4 && now.Day == 1;
		}
		public static bool ShouldDoAprilFoolsShenanigans(int percentChance = 33)
        {
			Random rand = new Random(Guid.NewGuid().GetHashCode());
			return IsAprilFoolsDay() && rand.Next(101) <= percentChance;
		}
	}	
}
