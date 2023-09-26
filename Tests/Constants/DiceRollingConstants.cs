using DartsDiscordBots.Modules.Indecision.Models;
using DartsDiscordBots.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Tests.Constants
{
    public class DiceRollingConstants
    {
        public static IEnumerable<TestCaseData> DiceParameterPositiveTestCases()
        {
            yield return new TestCaseData("20+12", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 20,
                Operation = Operation.Addition,
                Operand = 12
            });
            yield return new TestCaseData("20-12", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 20,
                Operation = Operation.Subtraction,
                Operand = 12
            });
            yield return new TestCaseData("20", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 20,
                Operation = Operation.None,
                Operand = -1
            });
            yield return new TestCaseData("69d20+12", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = 20,
                Operation = Operation.Addition,
                Operand = 12
            });
            yield return new TestCaseData("69d20-12", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = 20,
                Operation = Operation.Subtraction,
                Operand = 12
            });
            yield return new TestCaseData("69d20", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = 20,
                Operation = Operation.None,
                Operand = -1
            });
        }
        public static IEnumerable<TestCaseData> DiceParameterNegativeTestCases()
        {
            yield return new TestCaseData("a+12", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = -1,
                Operation = Operation.Addition,
                Operand = 12
            });
            yield return new TestCaseData("a-12", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = -1,
                Operation = Operation.Subtraction,
                Operand = 12
            });
            yield return new TestCaseData("a*12", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = -1,
                Operation = Operation.None,
                Operand = -1
            });
            yield return new TestCaseData("20+a", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 20,
                Operation = Operation.Addition,
                Operand = -1
            });
            yield return new TestCaseData("20-a", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 20,
                Operation = Operation.Subtraction,
                Operand = -1
            });
            yield return new TestCaseData("a", new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = -1,
                Operation = Operation.None,
                Operand = -1
            });
            yield return new TestCaseData("ad20+12", new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = 20,
                Operation = Operation.Addition,
                Operand = 12
            });
            yield return new TestCaseData("ad20-12", new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = 20,
                Operation = Operation.Subtraction,
                Operand = 12
            });
            yield return new TestCaseData("ad20", new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = 20,
                Operation = Operation.None,
                Operand = -1
            });
            yield return new TestCaseData("69da+12", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = -1,
                Operation = Operation.Addition,
                Operand = 12
            });
            yield return new TestCaseData("69da-12", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = -1,
                Operation = Operation.Subtraction,
                Operand = 12
            });
            yield return new TestCaseData("69da", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = -1,
                Operation = Operation.None,
                Operand = -1
            });
            yield return new TestCaseData("69d20+a", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = 20,
                Operation = Operation.Addition,
                Operand = -1
            });
            yield return new TestCaseData("69d20-a", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = 20,
                Operation = Operation.Subtraction,
                Operand = -1
            });
            yield return new TestCaseData("69d20*12", new DiceRollingParameters
            {
                NumberOfDice = 69,
                DiceFaceCount = -1,
                Operation = Operation.None,
                Operand = -1
            });
        }

        public static IEnumerable<TestCaseData> DiceResultTestCases()
        {
            yield return new TestCaseData(new DiceRollingParameters { 
                NumberOfDice = 4,
                DiceFaceCount = 4,
                Operation = Operation.None,
                Operand = -1
            }, new DiceResult { Total = 12, Rolls = new() { 3, 3, 3, 3 } }, $"Rolled `4` `d4` and got a total of `12`{Environment.NewLine}Individual Rolls: `[3,3,3,3]`");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 4,
                DiceFaceCount = 4,
                Operation = Operation.Addition,
                Operand = 1
            }, new DiceResult { Total = 12, Rolls = new() { 3, 3, 3, 3 } }, $"Rolled `4` `d4` plus `1` and got a total of `13`{Environment.NewLine}Individual Rolls: `[3,3,3,3]`");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 4,
                DiceFaceCount = 4,
                Operation = Operation.Subtraction,
                Operand = 1
            }, new DiceResult { Total = 12, Rolls = new() { 3, 3, 3, 3 } }, $"Rolled `4` `d4` minus `1` and got a total of `11`{Environment.NewLine}Individual Rolls: `[3,3,3,3]`");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 12,
                Operation = Operation.None,
                Operand = -1
            }, new DiceResult { Total = 12, Rolls = new() { 12 } }, $"Rolled `1` `d12` and got a total of `12`");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 12,
                Operation = Operation.Addition,
                Operand = 1
            }, new DiceResult { Total = 12, Rolls = new() { 12 } }, $"Rolled `1` `d12` plus `1` and got a total of `13`");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 12,
                Operation = Operation.Subtraction,
                Operand = 1
            }, new DiceResult { Total = 12, Rolls = new() { 12 } }, $"Rolled `1` `d12` minus `1` and got a total of `11`");
        }
        public static IEnumerable<TestCaseData> DiceParametersParsingFailureTestCases()
        {
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = -1,
                Operation = Operation.None,
                Operand = -1
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: Couldn't Parse. Detected Roll Count: Couldn't Parse. Detected Modifier: Couldn't Parse.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = -1,
                Operation = Operation.Subtraction,
                Operand = -1
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: Couldn't Parse. Detected Roll Count: Couldn't Parse. Detected Modifier: Couldn't Parse. Detected Modifier Operation: Subtraction.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = -1,
                Operation = Operation.Addition,
                Operand = -1
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: Couldn't Parse. Detected Roll Count: Couldn't Parse. Detected Modifier: Couldn't Parse. Detected Modifier Operation: Addition.");

            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 20,
                Operation = Operation.None,
                Operand = -1
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: 20. Detected Roll Count: 1. Detected Modifier: Couldn't Parse.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 20,
                Operation = Operation.Subtraction,
                Operand = -1
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: 20. Detected Roll Count: 1. Detected Modifier: Couldn't Parse. Detected Modifier Operation: Subtraction.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = 20,
                Operation = Operation.Addition,
                Operand = -1
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: 20. Detected Roll Count: 1. Detected Modifier: Couldn't Parse. Detected Modifier Operation: Addition.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = -1,
                Operation = Operation.None,
                Operand = 12
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: Couldn't Parse. Detected Roll Count: 1. Detected Modifier: 12.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = -1,
                Operation = Operation.Subtraction,
                Operand = 12
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: Couldn't Parse. Detected Roll Count: 1. Detected Modifier: 12. Detected Modifier Operation: Subtraction.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = 1,
                DiceFaceCount = -1,
                Operation = Operation.Addition,
                Operand = 12
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: Couldn't Parse. Detected Roll Count: 1. Detected Modifier: 12. Detected Modifier Operation: Addition.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = 20,
                Operation = Operation.None,
                Operand = 12
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: 20. Detected Roll Count: Couldn't Parse. Detected Modifier: 12.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = 20,
                Operation = Operation.Subtraction,
                Operand = 12
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: 20. Detected Roll Count: Couldn't Parse. Detected Modifier: 12. Detected Modifier Operation: Subtraction.");
            yield return new TestCaseData(new DiceRollingParameters
            {
                NumberOfDice = -1,
                DiceFaceCount = 20,
                Operation = Operation.Addition,
                Operand = 12
            }, $"Sorry, I failed to parse your dice rolls. Detected Dice Face Count: 20. Detected Roll Count: Couldn't Parse. Detected Modifier: 12. Detected Modifier Operation: Addition.");
        }
    }
}
