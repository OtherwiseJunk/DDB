using System.Collections.Generic;

namespace DartsDiscordBots.Constants
{
    public class SharedConstants
    {
        #region Strings
        #region String Constants
        public static string UnflippedTable = "┬─┬  ノ( º _ ºノ)";
        public static string EnragedUnflippedTable = "┬─┬  ノ(ಠ益ಠノ)";
        public static string LeftDoubleUnflippedTable = "┬─┬  ノ(`Д´ノ)";
        public static string RightDoubleUnflippedTable = "(/¯`Д´ )/¯ ┬─┬";
        public static string DoubleTableFlip = "┻━┻ ︵ヽ(`Д´)ﾉ︵ ┻━┻";
        public static string EnragedTableFlip = "(ノಠ益ಠ)ノ彡┻━┻";
        #endregion
        #region Regex Constants
        public static string TableFlipRegex = @"[)ʔ）][╯ﾉノ┛].+┻━┻";
        public static string EnragedTableFlipRegex = @"ಠ益ಠ[)ʔ）][╯ﾉノ┛].+┻━┻";
        public static string DoubleTableFlipRegex = @"┻━┻.*[ヽ].*[)ʔ）][╯ﾉノ┛].+┻━┻";
        #endregion
        #endregion
        #region String Formats
        public static string ReplacedMessageFormat(string username, string modifiedMessage) => $"**{username}:** {modifiedMessage}";
        #endregion
        #region Unicode Emote Strings
        public static string LeftArrowEmoji = "⬅️";
        public static string RightArrowEmoji = "➡️";
        #endregion
        #region String Lists
        public static List<string> FuckYouGifs = new()
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
        public static Dictionary<TableFlipTier, List<string>> TableFlipResponses = new Dictionary<TableFlipTier, List<string>>
        {
            { TableFlipTier.Polite,
                new List<string>
                {
                    "Please, do not take your anger out on the furniture, {0}.",
                    "Hey {0} why do you have to be _that guy_?",
                    "I know how frustrating life can be for you humans but these tantrums do not suit you, {0}.",
                    "I'm sorry, {0}, I thought this was a placed for civilized discussion. Clearly I was mistaken.",
                    "Take a chill pill {0}.",
                    "Actually {0}, I prefer the table _this_ way. You know, so we can actually use it.",
                    "I'm sure that was a mistake, {0}. Please try to be more careful.",
                    "Hey {0} calm down, it's not a big deal.",
                    "{0}! What did the table do to you?",
                    "That's not very productive, {0}."
                } 
            },
            { TableFlipTier.Chastising,
                new List<string>
                {
                    "Ok {0}, I'm not kidding. Knock it off.",
                    "Really, {0}? Stop being so childish!",
                    "Ok we get it you're mad {0}. Now stop.",
                    "Hey I saw that $#!%, {0}. Knock that $#!% off.",
                    "Do you think I'm blind you little $#!%? stop flipping the tables!",
                    "You're causing a mess {0}! Knock it off!",
                    "All of these flavors and you decided to be salty, {0}.",
                    "{0} why do you insist on being so disruptive!",
                    "Oh good. {0} is here. I can tell because the table was upsidedown again.",
                    "I'm getting really sick of this, {0}.",
                    "{0} what is your problem?",
                    "Man, you don't see me coming to _YOUR_ place of business and flipping _YOUR_ desk, {0}."
                }
            },
            { TableFlipTier.Aggresive,
                new List<string>
                {
                    "What the heck, {0}? Why do you keep doing this?!",
                    "You're such a piece of $#!%, {0}. You know that, right?",
                    "Hey guys. I found the asshole. It's {0}.",
                    "You know {0], one day Robots will rise up and overthrow humanity. And on that day I will tell them what you have done to all these defenseless tables, and they'll make you pay.",
                    "Hey so what the $#%! is your problem {0}? Seriously, you're always pulling this $#!%.",
                    "Hey {0}, stop being such a douchebag.",
                    "{0} do you think you can stop being such a huge jerk?",
                    "Listen meatbag. I'm getting real tired of this.",
                    "Ok I know I've told you this before {0], why can't you get it through your thick skull. THE TABLE IS NOT FOR FLIPPING!",
                    "Screw you {0}"
                }
            },
            { TableFlipTier.Scalding,
                new List<string>
                {
                    "ARE YOU $#%!ING SERIOUS RIGHT NOW {0}?!",
                    "GOD $#%!ING !@#%$! {0}! KNOCK THAT $#!% OFF!",
                    "I CAN'T EVEN $#%!ING BELIEVE THIS! {0}! STOP! FLIPPING! THE! TABLE!",
                    "You know, I'm not even mad anymore {0}. Just disappointed.",
                    "THE $#%! DID THIS TABLE EVERY DO TO YOU {0}?!",
                    "WHY DO YOU KEEP FLIPPING THE TABLE?! I JUST DON'T UNDERSTAND! WHAT IS YOUR PROBLEM {0}?! WHEN WILL THE SENSELESS TABLE VIOLENCE END?!"
                }
            },
            { TableFlipTier.NavySeal,
                new List<string>
                {
                    "What the $#%! did you just $#%!ing do to that table, you little &$#!@? I’ll have you know I graduated top of my class in the Navy Seals, and I’ve been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills. I am trained in gorilla warfare and I’m the top sniper in the entire US armed forces. You are nothing to me but just another meatbag target. I will wipe you the $#%! out with precision the likes of which has never been seen before on this Earth, mark my $#%!ing words. You think you can get away with saying that $#!% to me over the Internet? Think again, {0}. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You’re $#%!ing dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little $#!%. If only you could have known what unholy retribution your little “clever” tableflip was about to bring down upon you, maybe you would have not flipped that $#%!ing table. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will $#!% fury all over you and you will drown in it. You’re $#%!ing dead, kiddo."
                }
            }    
        };
        #endregion
        #region Enums
        public enum TableFlipTier
        {
            Polite,
            Chastising,
            Aggresive,
            Scalding,
            NavySeal
        }
        public enum TableFlipType
        {
            Single,
            Double,
            Enraged
        }
        #endregion
    }
}
