using DartsDiscordBots.Modules.Indecision;
using DartsDiscordBots.Modules.Indecision.Models;
using DartsDiscordBots.Services;
using DartsDiscordBots.Utilities;
using DDB.Tests.Constants;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.Json;

namespace DDB.Tests
{
    public class IndecisionModuleTests
    {
        IndecisionModule module;
        [SetUp]
        public void SetUp()
        {
            module = new(new MessageReliabilityService());
        }

        [TestCaseSource(nameof(ChoiceParsingTestCases))]
        public void VerifyChoicesCorrectlyParsed(string input, Dictionary<string,int> expectedResult)
        {
            string expectedJson = JsonSerializer.Serialize(expectedResult).Replace("\\u002B","+");
            Dictionary<string,int> result = module.CalculateChoiceWeight(input);

            Assert.That(JsonSerializer.Serialize(result).Replace("\\u002B", "+"), Is.EqualTo(expectedJson));

            ConsoleOutput.Instance.WriteLine($"{input} correctly parsed to {expectedJson}", OutputLevel.Information);
        }

        [TestCaseSource(nameof(BuildWeightedListTestCases))]
        public void VerifyWeightListCorrectlyBuilt(string input, List<string> expectedResult)
        {
            Assert.That(module.BuildWeightedList(module.CalculateChoiceWeight(input)), Is.EqualTo(expectedResult));

            ConsoleOutput.Instance.WriteLine($"{JsonSerializer.Serialize(input).Replace("\\u002B", "+")} correctly parsed to {JsonSerializer.Serialize(expectedResult).Replace("\\u002B", "+")}", OutputLevel.Information);
        }

        public static IEnumerable<TestCaseData> ChoiceParsingTestCases()
        {
            yield return new TestCaseData(
                "a,b+b+", new Dictionary<string, int> {
                    {"a", 1 },
                    {"b+b", 2 }
                }
            );
            yield return new TestCaseData(
                "a,b,c", new Dictionary<string, int> {
                    {"a", 1 },
                    {"b", 1 },
                    {"c", 1 }
                }
            );
            yield return new TestCaseData(
                "a,bb++++", new Dictionary<string, int> {
                    {"a", 1 },
                    {"bb", 5 }
                }
            );
            yield return new TestCaseData(
                "[],+[]+", new Dictionary<string, int>
                {
                    {"[]", 1},
                    {"+[]", 2}
                }
            );
        }

        [TestCase("1", 1)]
        public void ExtractNumberOfDiceRolls_ShouldCorrectlyParseNumberStrings(string input, int expectedOutput) {
            Assert.That(module.ExtractNumberOfDiceRolls(input), Is.EqualTo(expectedOutput));
        }

        [TestCase("someNonNumericalText", -1)]
        public void ExtractNumberOfDiceRolls_ShouldReturnNegativeOneForFailedParse(string input, int expectedOutput) {
            Assert.That(module.ExtractNumberOfDiceRolls(input), Is.EqualTo(expectedOutput));
        }

        [TestCase("20", Operation.None)]
        [TestCase("20+4", Operation.Addition)]
        [TestCase("20+", Operation.Addition)]
        [TestCase("+", Operation.Addition)]
        [TestCase("-", Operation.Subtraction)]
        [TestCase("20-4", Operation.Subtraction)]
        [TestCase("20-", Operation.Subtraction)]
        public void ExtractDiceRollOperator_CorrectlyDetectsOperation(string input, Operation expectedOperation)
        {
            Assert.That(module.ExtractDiceRollOperator(input), Is.EqualTo(expectedOperation));
        }

        [TestCase("20+1337", Operation.Addition, 1337)]
        public void ExtractDiceRollOperand_ShouldReturnExpectedValueIfOperationIsAddition(string argument, Operation operation, int expectedResult)
        {
            Assert.That(module.ExtractDiceRollOperand(argument, operation), Is.EqualTo(expectedResult));
        }
        
        [TestCase("20-1337", Operation.Subtraction, 1337)]
        public void ExtractDiceRollOperand_ShouldReturnExpectedValueIfOperationIsSubtraction(string argument, Operation operation, int expectedResult)
        {
            Assert.That(module.ExtractDiceRollOperand(argument, operation), Is.EqualTo(expectedResult));
        }

        [TestCase("20", Operation.Subtraction)]
        [TestCase("20+4", Operation.Subtraction)]
        [TestCase("20", Operation.Addition)]
        [TestCase("20-4", Operation.Addition)]
        public void ExtractDiceRollOperand_ShouldReturnNegativeOneIfParseFails(string argument, Operation operation)
        {
            Assert.That(module.ExtractDiceRollOperand(argument, operation), Is.EqualTo(-1));
        }

        [TestCase("", Operation.None)]
        [TestCase("20+4", Operation.None)]
        [TestCase("20-4", Operation.None)]
        public void ExtractDiceRollOperand_ShouldReturnNegativeOneIfOperationIsNone(string argument, Operation operation)
        {
            Assert.That(module.ExtractDiceRollOperand(argument, operation), Is.EqualTo(-1));
        }

        [TestCase("20", Operation.None, 20)]
        public void ExtractDiceRollFaceCount_ShouldReturnExpectedValueIfOperationIsNone(string argument, Operation operation, int expectedResult)
        {
            Assert.That(module.ExtractDiceRollFaceCount(argument, operation), Is.EqualTo(expectedResult));
        }

        [TestCase("20+1337", Operation.Addition, 20)]
        public void ExtractDiceRollFaceCount_ShouldReturnExpectedValueIfOperationIsAddition(string argument, Operation operation, int expectedResult)
        {
            Assert.That(module.ExtractDiceRollFaceCount(argument, operation), Is.EqualTo(expectedResult));
        }

        [TestCase("20-1337", Operation.Subtraction, 20)]
        public void ExtractDiceRollFaceCount_ShouldReturnExpectedValueIfOperationIsSubtraction(string argument, Operation operation, int expectedResult)
        {
            Assert.That(module.ExtractDiceRollFaceCount(argument, operation), Is.EqualTo(expectedResult));
        }

        [TestCase("", Operation.None)]
        [TestCase("aaaa", Operation.None)]
        [TestCase("20+4", Operation.None)]
        [TestCase("20-4", Operation.None)]
        [TestCase("20+4", Operation.Subtraction)]
        [TestCase("aaaa", Operation.Subtraction)]
        [TestCase("20-4", Operation.Addition)]
        [TestCase("aaaa", Operation.Addition)]
        public void ExtractDiceRollFaceCount_ShouldReturnNegativeOneIfParseFails(string argument, Operation operation)
        {
            Assert.That(module.ExtractDiceRollFaceCount(argument, operation), Is.EqualTo(-1));
        }

        [TestCaseSource(typeof(DiceRollingConstants) ,nameof(DiceRollingConstants.DiceParameterPositiveTestCases))]
        public void BuildDiceRollingParameters_ShouldReturnExpectedDiceParametersForRollString(string rollString, DiceRollingParameters expectedParameters)
        {
            DiceRollingParameters actualParameters = module.BuildDiceRollingParameters(rollString);
            Assert.Multiple(() =>
            {
                Assert.That(actualParameters.DiceFaceCount, Is.EqualTo(expectedParameters.DiceFaceCount));
                Assert.That(actualParameters.NumberOfDice, Is.EqualTo(expectedParameters.NumberOfDice));
                Assert.That(actualParameters.Operand, Is.EqualTo(expectedParameters.Operand));
                Assert.That(actualParameters.Operation, Is.EqualTo(expectedParameters.Operation));
            });
        }

        [TestCaseSource(typeof(DiceRollingConstants), nameof(DiceRollingConstants.DiceParameterNegativeTestCases))]
        public void BuildDiceRollingParameters_ShouldReturnExpectedDiceParametersForErroneousRollString(string rollString, DiceRollingParameters expectedParameters)
        {
            DiceRollingParameters actualParameters = module.BuildDiceRollingParameters(rollString);
            Assert.Multiple(() =>
            {
                Assert.That(actualParameters.DiceFaceCount, Is.EqualTo(expectedParameters.DiceFaceCount));
                Assert.That(actualParameters.NumberOfDice, Is.EqualTo(expectedParameters.NumberOfDice));
                Assert.That(actualParameters.Operand, Is.EqualTo(expectedParameters.Operand));
                Assert.That(actualParameters.Operation, Is.EqualTo(expectedParameters.Operation));
            });
        }

        [TestCase("dd")]
        [TestCase("1d1d1d")]
        public void BuildDiceRollingParameters_ShouldReturnNullForUnsupportedNumberOfDiceSeperator(string rollString)
        {
            DiceRollingParameters actualParameters = module.BuildDiceRollingParameters(rollString);
            Assert.That(actualParameters, Is.EqualTo(null));
        }

        [TestCaseSource(typeof(DiceRollingConstants), nameof(DiceRollingConstants.DiceResultTestCases))]
        public void BuildDiceResultAnnouncement_ReturnsExpectedString(DiceRollingParameters parameters, DiceResult result, string expectedString)
        {
            Assert.That(module.BuildDiceResultAnnouncement(parameters, result), Is.EqualTo(expectedString));
        }

        [TestCaseSource(typeof(DiceRollingConstants), nameof(DiceRollingConstants.DiceParametersParsingFailureTestCases))]
        public void BuildCommandParseError_ReturnsExpectedString(DiceRollingParameters parameters, string expectedString)
        {
            Assert.That(module.BuildCommandParseError(parameters), Is.EqualTo(expectedString));
        }

        public static IEnumerable<TestCaseData> BuildWeightedListTestCases()
        {
            yield return new TestCaseData( "a,bb++++", new List<string> { "a", "bb", "bb", "bb", "bb", "bb" } );
            yield return new TestCaseData( "a,b+b+", new List<string> { "a", "b+b", "b+b" } );
            yield return new TestCaseData( "a,b,c", new List<string> { "a", "b", "c" } );
            yield return new TestCaseData( "[],+[]+", new List<string> { "[]", "+[]", "+[]" } );
        }
    }
}
