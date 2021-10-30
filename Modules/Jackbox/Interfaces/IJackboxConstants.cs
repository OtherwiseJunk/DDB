using DartsDiscordBots.Modules.Jackbox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DartsDiscordBots.Modules.Jackbox.Interfaces
{
	public interface IJackboxConstants
	{
		public int JackboxMaxVersion { get; set; }
		public string JackboxAllGamesString { get; set; }
		public Dictionary<int, List<JackboxGame>> JackboxGameListByNumber { get; set; }
		public List<JackboxGame> JackboxOneGames { get; set; }
		public List<JackboxGame> JackboxTwoGames { get; set; }
		public List<JackboxGame> JackboxThreeGames { get; set; }
		public List<JackboxGame> JackboxFourGames { get; set; }
		public List<JackboxGame> JackboxFiveGames { get; set; }
		public List<JackboxGame> JackboxSixGames { get; set; }
		public List<JackboxGame> JackboxSevenGames { get; set; }
		public List<JackboxGame> JackboxEightGames { get; set; }
	}
}
