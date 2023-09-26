using DartsDiscordBots.Modules.Indecision.Models;
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
    }
}
