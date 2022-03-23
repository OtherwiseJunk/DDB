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
		#region String Lists
		public static List<String> FuckYouGifs = new()
		{
			"https://images-ext-2.discordapp.net/external/wjfypiPJyBZX9iRXg0CJnePlTJzz61zEJZOvMGAS6jc/%3Fcid%3D73b8f7b16ae7523f0c81a978553172da2e47c9e336aea690%26rid%3Dgiphy.mp4%26ct%3Dg/https/media4.giphy.com/media/XozypzpGakVuX2ciZJ/giphy.mp4",
			"https://giphy.com/gifs/middle-finger-mister-rogers-fred-44Eq3Ab5LPYn6",
			"https://giphy.com/gifs/gq-kim-kardashian-fuck-you-middle-finger-xT0GqgBS0IdI3rFXHy",
			"https://tenor.com/view/april-fool-april-fools-spongebob-spongebob-april-fools-april-fools-spongebob-gif-13844032",
			"https://tenor.com/view/touching-grass-touch-gif-21219969",
			"https://tenor.com/view/jerk-off-the-hangover-ken-jeong-jerk-off-motion-screw-you-gif-5953847",
			"https://tenor.com/view/you-freaking-suck-kevin-hart-cold-as-balls-youre-no-good-youre-trash-gif-18321224",
			"https://tenor.com/view/cedric-xmen-gif-21396093",
			"https://tenor.com/view/homer-simpson-middle-finger-fuck-peace-out-gif-12375457",
			"https://tenor.com/view/mickey-mouse-middle-finger-dirty-finger-fuck-you-flip-off-gif-15416854",
			"https://tenor.com/view/middle-finger-umbrella-to-my-haters-gif-5679654",
			"https://tenor.com/view/middle-finger-dirty-finger-fuck-you-flip-off-gif-4904551",
			"https://tenor.com/view/middle-finger-veronica-mars-kristen-bell-fuck-you-fuck-off-gif-4576746",
			"https://tenor.com/view/middle-finger-fuck-jack-nicholson-the-finger-fuck-off-gif-15549395",
			"https://tenor.com/view/funny-kids-middle-finger-finger-gun-gif-14266608",
			"https://tenor.com/view/kid-middle-finger-fu-flip-off-flipping-off-gif-16219575",
			"https://tenor.com/view/middle-finger-ryan-stiles-pocket-dirty-finger-fuck-you-gif-4672090",
			"https://tenor.com/view/middle-finger-fuck-off-fuck-you-flip-off-screw-you-gif-4275997",
			"https://tenor.com/view/spongebob-fuck-you-rainbow-gif-10696976",
			"https://tenor.com/view/cut-beans-punch-in-the-throat-mixing-stirring-gif-16715704",
			"https://tenor.com/view/no-fuck-you-mad-mean-angry-gif-5685671",
			"https://tenor.com/view/hangover-ken-jeong-mr-chow-hahaha-fuck-you-gif-4887628",
			"https://tenor.com/view/flipping-off-flip-off-middle-finger-smile-happy-gif-4746862",
			"https://tenor.com/view/baby-girl-middle-finger-mood-screw-you-leave-me-alone-gif-10174031",
			"https://giphy.com/gifs/workaholics-comedy-central-season-4-3ofT5VKbcCMGMoHULm",
			"https://giphy.com/gifs/3oEjI2JdQPkmLxMcrm",
			"https://giphy.com/gifs/XHr6LfW6SmFa0",
			"https://giphy.com/gifs/tpain-3o7btYc0vx0tTPYVLa",
			"https://tenor.com/view/obama-fuckit-fuck-this-im-out-fuck-it-im-out-im-done-gif-13701118",
			"https://tenor.com/view/you-wanna-play-games-try-me-come-on-im-ready-samuel-l-jackson-gif-16248260",
			"https://tenor.com/view/nope-danny-de-vito-no-gif-8123780",
			"https://tenor.com/view/i-give-a-fuck-none-of-that-shit-idgaf-run-the-jewels-run-the-jewels-gifs-gif-11848065",
			"https://tenor.com/view/chris-tucker-hell-no-friday-no-fuck-that-gif-10096547",
			"https://tenor.com/view/chris-rock-huh-what-confused-wtf-gif-18025317",
			"https://tenor.com/view/joe-biden-gif-18249938",
			"https://tenor.com/view/fuck-that-nah-ice-cube-gif-9513452",
			"https://tenor.com/view/that70s-show-kitty-drinks-drinking-day-chill-gif-16669162",
			"https://tenor.com/view/naw-mike-epps-nah-hell-hell-naw-gif-14557582",
			"https://tenor.com/view/no-absolutely-not-gif-13012986",
			"https://tenor.com/view/pete-davidson-advice-fuck-that-shit-homie-fuck-that-gif-14270327",
			"https://tenor.com/view/ceelo-green-shit-forget-you-fuck-you-gif-4276316",
			"https://tenor.com/view/screw-you-nikki-minaj-snl-snl-gifs-saturday-night-live-gif-11870311",
			"https://tenor.com/view/talking-boy-mic-what-the-fuck-are-you-doing-gif-16697464",
			"https://tenor.com/view/yeah-yeah-go-away-bernie-sanders-saturday-night-live-go-away-stay-away-gif-17199593",
			"https://tenor.com/view/flipping-off-flip-off-teich-middle-finger-fuck-off-fuck-you-gif-15587868",
			"https://tenor.com/view/snoop-dogg-rapper-raper-angry-anger-gif-17002797",
			"https://tenor.com/view/buh-bye-shoo-go-away-gif-15313860",
			"https://tenor.com/view/benedict-cumberbatch-go-away-bye-leave-gif-5875554",
			"https://tenor.com/view/mad-angry-angry-girl-angry-little-girl-get-out-gif-14317590",
			"https://tenor.com/view/bender-futurama-kill-all-humans-robot-gif-17343915",
			"https://tenor.com/view/cute-black-boy-fuck-you-cute-black-boy-fuck-you-loswr-loser-gif-24719293",
		};
		#endregion
	}
}
