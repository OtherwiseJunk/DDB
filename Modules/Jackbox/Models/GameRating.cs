using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DartsDiscordBots.Modules.Jackbox.Models
{
	public class GameRating
	{
		int RatingId { get; set; }
		ulong DiscordUserId { get; set; }
		public int Rating { get { return Rating; } set
			{
				if(value > 5)
				{
					Rating = 5;
				}else if(value < 1)
				{
					Rating = 1;
				}
				else
				{
					Rating = value;
				}
			} }

		public int JackboxGameId { get; set; }
		public JackboxGame JackboxGame { get; set; }
		public override string ToString()
		{
			return $"{JackboxGame.Name} - {JackboxGame.Name} - User Rating: {Rating}";
		}
	}
}
