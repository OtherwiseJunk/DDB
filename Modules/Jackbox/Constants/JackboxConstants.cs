using DartsDiscordBots.Modules.Jackbox.Interfaces;
using DartsDiscordBots.Modules.Jackbox.Models;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace DartsDiscordBots.Modules.Jackbox
{
	public class JackboxConstants
	{
		int JackboxMaxVersion { get; set; } = 8;
		List<JackboxGame> DefaultGameData = new List<JackboxGame>
		{
			new JackboxGame{ID = 1, Name = "You Don't Know Jack 2015", PlayerName = "Know-It-Alls", Description = "", JackboxVersion = 1, MinPlayers = 1, MaxPlayers =4, VotingEmoji = new Emoji(":smirk:"), HasAudience = false, Ratings = new List<GameRating>()}
		};

		public List<JackboxGame> JackboxOneGames { get; set; } = new List<JackboxGame>()
			{
				new JackboxGame("You Don't Know Jack 2015", "Know-It-Alls", "", 1, 1, 4, new Emoji(":smirk:"), false),
				new JackboxGame("Fibbage XL", "$#%!ing Liars", "", 1, 2,8, new Emoji(":liar:"), false),
				new JackboxGame("Drawful", "Doodlers", "", 1, 3, 8, new Emoji(":pencil:"), false),
				new JackboxGame("Word Spud", "Potatos", "", 1, 2, 8, new Emoji(":potato:"), false),
				new JackboxGame("Lie Swatter", "Insects", "", 1, 1, 100, new Emoji(":fly:"), false),
			};
		public List<JackboxGame> JackboxTwoGames { get; set; } = new List<JackboxGame>()
			{
				new JackboxGame("Fibbage 2", "$#%!ing Liars", "", 2, 2, 8, new Emoji(":confused:"), false),
				new JackboxGame("Bidiots", "Spenders", "", 2, 3,6, new Emoji(":money_mouth:"), false),
				new JackboxGame("Bomb Corp.", "Defusers", "", 2, 1, 4, new Emoji(":bomb:"), false),
				new JackboxGame("Earwax", "Q-Tippers", "", 2, 3, 8, new Emoji(":ear:"), false),
				new JackboxGame("Quiplash XL", "EXTRA LARGE funny people", "", 2, 3, 8, new Emoji(":joy:"), false),
			};
		public List<JackboxGame> JackboxThreeGames { get; set; } = new List<JackboxGame>()
			{
				new JackboxGame("Quiplash 2", "Funny People", "", 3, 3, 8, new Emoji(":laughing:"), false),
				new JackboxGame("Triva Murder Party", "Soon-To-Be-Corpses", "", 3, 1,8, new Emoji(":scream:"), false),
				new JackboxGame("Gusspionage", "Undercover Guessers", "", 3, 2, 8, new Emoji(":spy:"), false),
				new JackboxGame("Tee K.O.", "Silk-screeners", "", 3, 3, 8, new Emoji(":shirt:"), false),
				new JackboxGame("Fakin' It", "BIG PHONIES", "", 3, 3, 6, new Emoji(":japanese_goblin:"), false),
			};
		public List<JackboxGame> JackboxFourGames { get; set; } = new List<JackboxGame>()
			{
				new JackboxGame("You Don't Know Jack 2015", "Know-It-Alls", "", 1, 1, 4, new Emoji(":smirk:"), false),
				new JackboxGame("Fibbage XL", "$#%!ing Liars", "", 1, 2,8, new Emoji(":liar:"), false),
				new JackboxGame("Drawful", "Doodlers", "", 1, 3, 8, new Emoji(":pencil:"), false),
				new JackboxGame("Word Spud", "Potatos", "", 1, 2, 8, new Emoji(":potato:"), false),
				new JackboxGame("Lie Swatter", "Insects", "", 1, 1, 100, new Emoji(":fly:"), false),

				":face_with_raised_eyebrow: Fibbage 3 (2-8 $#%!ing LIars)",
				":desktop: Survive the Internet (3-8 NEETs)",
				":purple_heart: Monster Seeking Monsters (3-7 Hot Abominations)",
				":medal: Bracketeering (3-16 Mad Marchers)",
				":paintbrush: Civic Doodle (3-8 Drawers)"
			};
		public List<JackboxGame> JackboxFiveGames { get; set; } = new List<JackboxGame>()
			{
				new JackboxGame("You Don't Know Jack 2015", "Know-It-Alls", "", 1, 1, 4, new Emoji(":smirk:"), false),
				new JackboxGame("Fibbage XL", "$#%!ing Liars", "", 1, 2,8, new Emoji(":liar:"), false),
				new JackboxGame("Drawful", "Doodlers", "", 1, 3, 8, new Emoji(":pencil:"), false),
				new JackboxGame("Word Spud", "Potatos", "", 1, 2, 8, new Emoji(":potato:"), false),
				new JackboxGame("Lie Swatter", "Insects", "", 1, 1, 100, new Emoji(":fly:"), false),

				":nerd: You Dont Know Jack: Full Stream (1-8 Know-It-Alls)",
				":cat: Split the Room (3-8 Trolls)",
				":blue_square: Patently Stupid (3-8 Idiots)",
				":microphone: Mad Verse City (3-8 Rappers)",
				":alien: Zeeple Dome (1-6 Abductees) (No Audience)"
			};
		public List<JackboxGame> JackboxSixGames { get; set; } = new List<JackboxGame>()
			{
				new JackboxGame("You Don't Know Jack 2015", "Know-It-Alls", "", 1, 1, 4, new Emoji(":smirk:"), false),
				new JackboxGame("Fibbage XL", "$#%!ing Liars", "", 1, 2,8, new Emoji(":liar:"), false),
				new JackboxGame("Drawful", "Doodlers", "", 1, 3, 8, new Emoji(":pencil:"), false),
				new JackboxGame("Word Spud", "Potatos", "", 1, 2, 8, new Emoji(":potato:"), false),
				new JackboxGame("Lie Swatter", "Insects", "", 1, 1, 100, new Emoji(":fly:"), false),

				":dagger: Trivia Murder Party 2 (1-8 Soon-To-Be-Corpses)",
				":bar_chart: Role Models (3-6 Impressionable Youths)",
				":rowboat: Joke Boat (3-8 Comedians)",
				":blue_book: Dictionarium (3-8 Wordcrafters)",
				":black_square_button: Push The Button (4-10 Button-Pushers) (No Audience)"
			};

		public List<JackboxGame> JackboxSevenGames { get; set; } = new List<JackboxGame>()
			{
				new JackboxGame("You Don't Know Jack 2015", "Know-It-Alls", "", 1, 1, 4, new Emoji(":smirk:"), false),
				new JackboxGame("Fibbage XL", "$#%!ing Liars", "", 1, 2,8, new Emoji(":liar:"), false),
				new JackboxGame("Drawful", "Doodlers", "", 1, 3, 8, new Emoji(":pencil:"), false),
				new JackboxGame("Word Spud", "Potatos", "", 1, 2, 8, new Emoji(":potato:"), false),
				new JackboxGame("Lie Swatter", "Insects", "", 1, 1, 100, new Emoji(":fly:"), false),

				":loud_sound: Talking Points (3-8 Pundits)",
				":tongue: Blather 'Round (2-6 Blathermouths)",
				":imp: The Devils and the Details (3-8 Devils)",
				":muscle: Champ'd Up (3-8 Champs)",
				":rofl: Quiplash 3 (3-8 Funny People)"
			};

		public List<JackboxGame> JackboxEightGames { get; set; } = new List<JackboxGame>()
			{
				new JackboxGame("You Don't Know Jack 2015", "Know-It-Alls", "", 1, 1, 4, new Emoji(":smirk:"), false),
				new JackboxGame("Fibbage XL", "$#%!ing Liars", "", 1, 2,8, new Emoji(":liar:"), false),
				new JackboxGame("Drawful", "Doodlers", "", 1, 3, 8, new Emoji(":pencil:"), false),
				new JackboxGame("Word Spud", "Potatos", "", 1, 2, 8, new Emoji(":potato:"), false),
				new JackboxGame("Lie Swatter", "Insects", "", 1, 1, 100, new Emoji(":fly:"), false),

				":pencil2: Drawful Animate (3-10 Underpaid Animators)",
				":pie: The Wheel of Enormous Proportions (2-8 Wonderers)",
				":moneybag: Job Job (3-10 Employees)",
				":pick: The Poll Mine (2-10 Miners)",
				":mag: Weapons Drawn (4-8 Detective/Murderers"
			};
		public Dictionary<int, List<JackboxGame>> JackboxGameListByNumber { get; set; }
		int IJackboxConstants.JackboxMaxVersion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public JackboxConstants()
		{
			JackboxGameListByNumber = new Dictionary<int, List<JackboxGame>>()
			{
				{ 1, JackboxOneGames},
				{ 2, JackboxTwoGames},
				{ 3, JackboxThreeGames},
				{ 4, JackboxFourGames},
				{ 5, JackboxFiveGames},
				{ 6, JackboxSixGames},
				{ 7, JackboxSevenGames},
				{ 8, JackboxEightGames }
			};
		}
	}
}
