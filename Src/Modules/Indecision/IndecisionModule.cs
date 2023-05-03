using DartsDiscordBots.Modules.AnimalCrossing.Models;
using DartsDiscordBots.Services.Interfaces;
using DartsDiscordBots.Utilities;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Modules.Indecision
{
	public class IndecisionModule : ModuleBase
	{
        IMessageReliabilityService _messenger { get; set; }
        public int MAXDICEVALUE = 1000;

        public IndecisionModule(IMessageReliabilityService messenger)
		{
            _messenger = messenger;
		}
		[Command("pick"), Summary("Picks a random value from a comma separated list. adding + to the end adds slight preference")]
		public async Task Pick([Remainder, Summary("The comma separated list of items to pick from")] string items)
		{
			
            Dictionary<string, int> choiceCountByName = CalculateChoiceWeight(items);
            List<string> choices = BuildWeightedList(choiceCountByName);

            MessageReference reference = Context.Message.Reference ?? new MessageReference(Context.Message.Id);
            await _messenger.SendMessageToChannel($"Rolling list: [`{string.Join("`,`", choices)}]`{Environment.NewLine}Winner:`{choices.GetRandom()}`", Context.Message, ",");           

        }

        public List<string> BuildWeightedList(Dictionary<string, int> choiceCountByName)
        {
            List<string> weightedChoices = new();
            foreach ((string choiceName, int choiceCount) in choiceCountByName)
            {
                for (int i = 0; i < choiceCount; i++)
                {
                    weightedChoices.Add(choiceName);
                }
            }

            return weightedChoices;
        }

        public Dictionary<string, int> CalculateChoiceWeight(string items)
        {
            List<string> choices = items.Split(',').ToList();
            Dictionary <string, int> choiceCountByName = new();
            foreach (string choice in choices)
            {
                if (choice.EndsWith('+'))
                {
                    int plusCount = 0;
                    string choiceAndWeight = choice;
                    do
                    {
                        plusCount++;
                        choiceAndWeight = choiceAndWeight.Substring(0, choiceAndWeight.Length - 1);

                    } while (choiceAndWeight.EndsWith("+"));
                    choiceCountByName.Add(choiceAndWeight, ++plusCount);
                }
                else
                {
                    choiceCountByName.Add(choice.Trim(), 1);
                }
            }

            return choiceCountByName;
        }

        [Command("roll"), Summary("Roll XdY+/-Z dice.")]
        public async Task Roll([Remainder, Summary("What to roll. Can indicate the number of dice to roll, the number of sides on those dice, and a positive or negative modifier to add to the results. 3d6+2 would roll 3 6-sided dice and add 2 to the final result.")] string rollString)
        {
            StringBuilder sb = new StringBuilder();
            List<string> arguments = new List<string>(rollString.ToLower().Split('d'));
            arguments.Remove("");
            int sides, times, modifier;

            if (arguments.Count == 1)
            {
                if (arguments[0].Contains("+"))
                {
                    arguments = new List<string>(arguments[0].Split('+'));
                    if (int.TryParse(arguments[0], out sides))
                    {
                        if(sides > MAXDICEVALUE)
						{
                            await Context.Channel.SendMessageAsync("Sorry, I don't have a dice that big.");
                            return;
						}
                        var dice = new Dice(sides);
                        var temp = dice.Roll();
                        if (int.TryParse(arguments[1], out modifier))
                        {
                            sb.AppendLine(string.Format("Rolled one `d{0}` plus `{1}` and got a total of `{2}`", sides,modifier, temp + modifier));
                        }
                        else
                        {
                            sb.AppendLine("Sorry, I don't recognize that number.");

                        }
                    }
                    else
                    {
                        sb.AppendLine("Sorry, I don't recognize that number.");

                    }
                }
                else if (arguments[0].Contains("-"))
                {
                    arguments = new List<string>(arguments[0].Split('-'));
                    if (int.TryParse(arguments[0], out sides))
                    {
                        if (sides > MAXDICEVALUE)
                        {
                            await Context.Channel.SendMessageAsync("Sorry, I don't have a dice that big.");
                            return;
                        }
                        var dice = new Dice(sides);
                        var temp = dice.Roll();
                        if (int.TryParse(arguments[1], out modifier))
                        {
                            sb.AppendLine(string.Format("Rolled one `d{0}` plus `{1}` and got a total of `{2}`", sides, modifier, temp + modifier));
                            sb.AppendLine(string.Format("Rolled one `d{0}` minus `{1}` and got a total of `{2}`", sides,modifier, temp - modifier));
                        }
                        else
                        {
                            sb.AppendLine("Sorry, I don't recognize that number.");

                        }
                    }
                    else
                    {
                        sb.AppendLine("Sorry, I don't recognize that number.");

                    }
                }
                else
                {
                    if (int.TryParse(arguments[0], out sides))
                    {
                        if (sides > MAXDICEVALUE)
                        {
                            await Context.Channel.SendMessageAsync("Sorry, I don't have a dice that big.");
                            return;
                        }
                        var dice = new Dice(sides);

                        sb.AppendLine(string.Format("Rolled one `d{0}` and got a total of `{1}`",sides, dice.Roll()));
                    }
                    else
                    {
                        sb.AppendLine("Sorry, I don't recognize that number.");

                    }
                }
            }
            else if (arguments.Count == 2)
            {
                if (int.TryParse(arguments[0], out times))
                {
                    if (arguments[1].Contains("+"))
                    {
                        arguments = new List<string>(arguments[1].Split('+'));
                        if (int.TryParse(arguments[0], out sides))
                        {
                            if (sides > MAXDICEVALUE)
                            {
                                await Context.Channel.SendMessageAsync("Sorry, I don't have a dice that big.");
                                return;
                            }
                            if(times > MAXDICEVALUE)
							{
                                await Context.Channel.SendMessageAsync("Sorry, I don't have that much time to be rolling bones.");
                                return;
                            }
                            var dice = new Dice(sides);
                            var temp = dice.Roll(times);
                            if (int.TryParse(arguments[1], out modifier))
                            {
                                sb.AppendLine(string.Format("Rolled `{0}` `d{1}` plus `{2}` and got a total of `{3}`", times, sides, modifier, temp.Total + modifier));
                                sb.AppendLine(string.Format("Individual Rolls: `[{0}]`",string.Join(",", temp.Rolls)));
                            }
                            else
                            {
                                sb.AppendLine("Sorry, I don't recognize that number.");

                            }
                        }
                        else
                        {
                            sb.AppendLine("Sorry, I don't recognize that number.");

                        }
                    }
                    else if (arguments[1].Contains("-"))
                    {
                        arguments = new List<string>(arguments[1].Split('-'));
                        if (int.TryParse(arguments[0], out sides))
                        {
                            if (sides > MAXDICEVALUE)
                            {
                                await Context.Channel.SendMessageAsync("Sorry, I don't have a dice that big.");
                                return;
                            }
                            if (times > MAXDICEVALUE)
                            {
                                await Context.Channel.SendMessageAsync("Sorry, I don't have that much time to be rolling bones.");
                                return;
                            }
                            var dice = new Dice(sides);
                            var temp = dice.Roll(times);
                            if (int.TryParse(arguments[1], out modifier))
                            {
                                sb.AppendLine(string.Format("Rolled `{0}` `d{1}` minus `{2}` and got a total of `{3}`", times, sides, modifier, temp.Total - modifier));
                                sb.AppendLine(string.Format("Individual Rolls: `[{0}]`", string.Join(",", temp.Rolls)));
                            }
                            else
                            {
                                sb.AppendLine("Sorry, I don't recognize that number.");
                            }
                        }
                        else
                        {
                            sb.AppendLine("Sorry, I don't recognize that number.");
                        }
                    }
                    else
                    {
                        if (int.TryParse(arguments[1], out sides))
                        {
                            if (sides > MAXDICEVALUE)
                            {
                                await Context.Channel.SendMessageAsync("Sorry, I don't have a dice that big.");
                                return;
                            }
                            if (times > MAXDICEVALUE)
                            {
                                await Context.Channel.SendMessageAsync("Sorry, I don't have that much time to be rolling bones.");
                                return;
                            }
                            var dice = new Dice(sides);
                            var temp = dice.Roll(times);
                            sb.AppendLine(string.Format("Rolled `{0}` `d{1}` and got a total of `{2}`", times, sides, temp.Total));
                            sb.AppendLine(string.Format("Individual Rolls: `[{0}]`",string.Join(",", temp.Rolls)));							
                        }
                        else
                        {
                            sb.AppendLine("Sorry, I don't recognize that number.");

                        }
                    }                    
                }
            }
            MessageReference reference = Context.Message.Reference ?? new MessageReference(Context.Message.Id);
            await _messenger.SendMessageToChannel(sb.ToString(), Context.Message, ",");
        }
    }
}
