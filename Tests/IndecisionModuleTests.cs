using DartsDiscordBots.Modules.Indecision;
using DartsDiscordBots.Services;
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

        [Test]
        [TestCaseSource(nameof(ChoiceParsingTestCases))]
        public void VerifyChoicesCorrectlyParsed(string input, Dictionary<string,int> expectedResult)
        {
            string expectedJson = JsonSerializer.Serialize(expectedResult).Replace("\\u002B","+");
            Dictionary<string,int> result = module.CalculateChoiceWeight(input);

            Assert.That(JsonSerializer.Serialize(result).Replace("\\u002B", "+"), Is.EqualTo(expectedJson));

            ConsoleOutput.Instance.WriteLine($"{input} correctly parsed to {expectedJson}", OutputLevel.Information);
        }

        [Test]
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

        public static IEnumerable<TestCaseData> BuildWeightedListTestCases()
        {
            yield return new TestCaseData( "a,bb++++", new List<string> { "a", "bb", "bb", "bb", "bb", "bb" } );
            yield return new TestCaseData( "a,b+b+", new List<string> { "a", "b+b", "b+b" } );
            yield return new TestCaseData( "a,b,c", new List<string> { "a", "b", "c" } );
            yield return new TestCaseData( "[],+[]+", new List<string> { "[]", "+[]", "+[]" } );
        }
    }
}
