using Amazon.S3.Model;
using DartsDiscordBots.Constants;
using DartsDiscordBots.Modules.Indecision.Models;
using DartsDiscordBots.Services.Interfaces;
using DartsDiscordBots.Utilities;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DartsDiscordBots.Modules.Indecision
{
    public class IndecisionModule : ModuleBase
    {
        IMessageReliabilityService _messenger { get; set; }
        public int MAXDICEVALUE = 1000;
        public List<Emoji> DefaultUnicodePollEmotes = new()
        {
            Emoji.Parse(":one:"),
            Emoji.Parse(":two:"),
            Emoji.Parse(":three:"),
            Emoji.Parse(":four:"),
            Emoji.Parse(":five:"),
            Emoji.Parse(":six:"),
            Emoji.Parse(":seven:"),
            Emoji.Parse(":eight:"),
            Emoji.Parse(":nine:"),
            Emoji.Parse(":zero:")
        };


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
            Dictionary<string, int> choiceCountByName = new();
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

        public int ExtractDiceRollFaceCount(string argument, Operation operation)
        {
            try
            {
                switch (operation)
                {
                    case Operation.None:
                        return Int32.Parse(argument);
                    case Operation.Addition:
                        return Int32.Parse(argument.Split("+")[0]);
                    case Operation.Subtraction:
                        return Int32.Parse(argument.Split("-")[0]);
                }
            }
            catch
            {
                Console.WriteLine("[DDB Indecision Module] Failed to extract Dice Face from argument ({0}) with operation ({1})", argument, operation.ToString());
            }
            return -1;
        }

        public int ExtractDiceRollOperand(string argument, Operation operation)
        {
            try
            {
                switch (operation)
                {
                    case Operation.None:
                        return -1;
                    case Operation.Addition:
                        return Int32.Parse(argument.Split("+")[1]);
                    case Operation.Subtraction:
                        return Int32.Parse(argument.Split("-")[1]);
                }
            }
            catch
            {
                Console.WriteLine("[DDB Indecision Module] Failed to extract Operand from argument ({0}) with operation ({1})", argument, operation.ToString());
            }
            return -1;
        }

        public Operation ExtractDiceRollOperator(string argument)
        {
            Operation op = Operation.None;
            if (argument.Contains("+"))
            {
                op = Operation.Addition;
            }
            if (argument.Contains("-"))
            {
                op = Operation.Subtraction;
            }

            return op;
        }

        public int ExtractNumberOfDiceRolls(string argument)
        {
            if(int.TryParse(argument, out int result))
            {
                return result;
            }
            return -1;
        }

        public string BuildCommandParseError(DiceRollingParameters parameters)
        {
            string operationState = parameters.Operation != Operation.None ? $"Detected Modifier Operation: {parameters.Operation.ToString()}." : String.Empty;
            string modifierState = parameters.Operand != -1 ? $"Detected Modifier: {parameters.Operand}." : "Detected Modifier: Couldn't Parse.";
            string sidesState = parameters.DiceFaceCount != -1 ? $"Detected Dice Face Count: {parameters.DiceFaceCount}." : "Detected Dice Face Count: Couldn't Parse.";
            string timesState = parameters.NumberOfDice != -1 ? $"Detected Roll Count: {parameters.NumberOfDice}." : "Detected Roll Count: Couldn't Parse.";

            return $"Sorry, I failed to parse your dice rolls. {sidesState} {timesState} {modifierState} {operationState}".Trim();
        }

        public string BuildDiceResultAnnouncement(DiceRollingParameters parameters, DiceResult results)
        {
            StringBuilder builder = new();

            switch (parameters.Operation)
            {
                case Operation.None:
                    builder.Append($"Rolled `{parameters.NumberOfDice}` `d{parameters.DiceFaceCount}` and got a total of `{results.Total}`");
                    break;
                case Operation.Addition:
                    builder.Append($"Rolled `{parameters.NumberOfDice}` `d{parameters.DiceFaceCount}` plus `{parameters.Operand}` and got a total of `{results.Total + parameters.Operand}`");
                    break;
                case Operation.Subtraction:
                    builder.Append($"Rolled `{parameters.NumberOfDice}` `d{parameters.DiceFaceCount}` minus `{parameters.Operand}` and got a total of `{results.Total - parameters.Operand}`");
                    break;
            }
            if(parameters.NumberOfDice > 1)
            {
                builder.Append($"{Environment.NewLine}Individual Rolls: `[{string.Join(",", results.Rolls)}]`");
            }

            return builder.ToString();
        }

        public DiceRollingParameters BuildDiceRollingParameters(string rollString)
        {
            List<string> diceArguments = new List<string>(rollString.ToLower().Split('d'));
            DiceRollingParameters rollingParameters = null;
            Operation operation = Operation.None;

            if (diceArguments.Count == 1)
            {
                operation = ExtractDiceRollOperator(diceArguments[0]);
                rollingParameters = new()
                {
                    NumberOfDice = 1,
                    Operation = operation,
                    Operand = ExtractDiceRollOperand(diceArguments[0], operation),
                    DiceFaceCount = ExtractDiceRollFaceCount(diceArguments[0], operation)
                };
            }
            else if (diceArguments.Count == 2)
            {
                operation = ExtractDiceRollOperator(diceArguments[1]);
                rollingParameters = new()
                {
                    NumberOfDice = ExtractNumberOfDiceRolls(diceArguments[0]),
                    Operation = operation,
                    Operand = ExtractDiceRollOperand(diceArguments[1], operation),
                    DiceFaceCount = ExtractDiceRollFaceCount(diceArguments[1], operation)
                };
            }

            return rollingParameters;
        }

        [Command("roll"), Summary("Roll XdY+/-Z dice.")]
        public async Task Roll([Remainder, Summary("What to roll. Can indicate the number of dice to roll, the number of sides on those dice, and a positive or negative modifier to add to the results. 3d6+2 would roll 3 6-sided dice and add 2 to the final result.")] string rollString)
        {
            DiceRollingParameters rollingParameters = BuildDiceRollingParameters(rollString);

            if(rollingParameters != null)
            {
                if (rollingParameters.NumberOfDice == -1 || rollingParameters.DiceFaceCount == -1 || (rollingParameters.Operand == -1 && rollingParameters.Operation != Operation.None))
                {
                    await Context.Message.Channel.SendMessageAsync(BuildCommandParseError(rollingParameters));
                }
                else if (rollingParameters.DiceFaceCount > MAXDICEVALUE)
                {
                    await Context.Channel.SendMessageAsync("Sorry, I don't have a dice that big.");
                }
                else if (rollingParameters.NumberOfDice > MAXDICEVALUE)
                {
                    await Context.Channel.SendMessageAsync("Sorry, I don't have that much time to be rolling bones.");
                }
                else
                {
                    Dice dice = new Dice(rollingParameters.DiceFaceCount);
                    DiceResult result = dice.Roll(rollingParameters.NumberOfDice);
                    await Context.Message.Channel.SendMessageAsync(BuildDiceResultAnnouncement(rollingParameters, result));
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("Sorry, you sent too many d's in that message.");
            }
        }

        [Command("poll"), Summary("Allow users to run a poll. All paramters are `|` separated, with the first argument being the question. If no options are provided after teh question will be a Yes/No poll with thumbs up thumbs down.")]
        public async Task Poll([Remainder, Summary("a Pipe (`|`) separate list of arguments. First argument is a question, all subsequent paramters will be used as options.")] string questionParametersString)
        {
            string[] arguments = questionParametersString.Split("|");
            if (arguments.Length == 1)
            {
                IUserMessage reply = Context.Message.ReplyAsync(arguments[0]).Result;
                _ = reply.AddReactionAsync(Emoji.Parse("👍"));
                _ = reply.AddReactionAsync(Emoji.Parse("👎"));
                return;
            }

            string[] options = arguments.Skip(1).ToArray();
            if (options.Length >= 2 && options.Length <= DefaultUnicodePollEmotes.Count)
            {
                IEmote[] emotes = GetEmoteOptions(Context.Guild, options.Length);
                PostPoll(arguments[0], options, emotes, Context.Message);
            }
            else
            {
                _ = Context.Message.ReplyAsync("Sorry, you need to provide at least two, and no more than ten, options for this command.");
            }
        }

        public async void PostPoll(string question, string[] options, IEmote[] optionsEmotes, IUserMessage message)
        {
            IGuildUser author = message.Author as IGuildUser;
            string name = author.DisplayName == author.Username ? author.Username : $"{author.DisplayName} ({author.Username})";
            StringBuilder stringBuilder = new($"**{name}**: **{question}**{Environment.NewLine}");
            for (int i = 0; i < options.Length; i++)
            {
                stringBuilder.AppendLine($"{optionsEmotes[i]}: {options[i]}");
            }
            IMessage reply = message.ReplyAsync(stringBuilder.ToString()).Result;

            new Thread(async () =>
            {
                foreach (IEmote emote in optionsEmotes)
                {
                    await reply.AddReactionAsync(emote);
                }
            }).Start();
        }
        public IEmote[] GetEmoteOptions(IGuild guild, int optionCount)
        {
            IEmote[] availableEmotes;
            if (guild.Emotes.Count >= optionCount)
            {
                availableEmotes = guild.Emotes.ToArray();
                availableEmotes.Shuffle();
            }
            else
            {
                availableEmotes = DefaultUnicodePollEmotes.ToArray();
            }            

            return availableEmotes.Take(optionCount).ToArray();
        }
    }
}
