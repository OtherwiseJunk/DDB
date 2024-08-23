using DartsDiscordBots.Utilities;
using DDB.Tests.Constants;
using DDB.Tests.Mocks;
using Discord;
using NUnit.Framework;
using static DartsDiscordBots.Constants.SharedConstants;

namespace DDB.Tests
{
    public class BotUtilitiesTests
    {
        [Test]
        [TestCase("┻━┻ ︵ヽ(`Д´)ﾉ︵ ┻━┻")]
        [TestCase("(ノಠ益ಠ)ノ彡┻━┻")]
        [TestCase("(╯°□°）╯︵ ┻━┻")]
        [TestCase("(╯ಠ益ಠ）╯︵ ┻━┻")]
        [TestCase("(╯`Д´）╯︵ ┻━┻")]
        [TestCase("(┛ಠ_ಠ)┛彡┻━┻")]
        [TestCase("(┛◉Д◉)┛彡┻━┻")]
        [TestCase("ヽ(ຈل͜ຈ)ﾉ︵ ┻━┻")]
        [TestCase("(╯°□°)╯︵ ┻━┻")]
        [TestCase("）╯ ┻━┻")]
        public void VerifyIsUserFlippingTableReturnsTrueForMessageContainingTableflip(string msg)
        {
            TableFlipType? type;
            Assert.That(BotUtilities.isUserFlippingTable(msg, out type), Is.True);
            Assert.That(type, Is.Not.Null);
        }

        [Test]
        [TestCase("┻━┻ ︵ヽ(`Д´)ﾉ︵ ┻━┻", TableFlipType.Double)]
        [TestCase("(ノಠ益ಠ)ノ彡┻━┻", TableFlipType.Enraged)]
        [TestCase("(╯°□°）╯︵ ┻━┻", TableFlipType.Single)]
        [TestCase("(╯ಠ益ಠ）╯︵ ┻━┻", TableFlipType.Enraged)]
        [TestCase("(╯`Д´）╯︵ ┻━┻", TableFlipType.Single)]
        [TestCase("(┛ಠ_ಠ)┛彡┻━┻", TableFlipType.Single)]
        [TestCase("(┛◉Д◉)┛彡┻━┻", TableFlipType.Single)]
        [TestCase("ヽ(ຈل͜ຈ)ﾉ︵ ┻━┻", TableFlipType.Single)]
        [TestCase("(╯°□°)╯︵ ┻━┻", TableFlipType.Single)]
        [TestCase("）╯ ┻━┻", TableFlipType.Single)]
        public void VerifyIsUserFlippingTableReturnsExpectedTableFlipTypeForMessageContainingTableflip(string msg, TableFlipType expectedType)
        {
            TableFlipType? type;
            Assert.That(BotUtilities.isUserFlippingTable(msg, out type), Is.True);
            Assert.That(type == expectedType);
        }

        [Test]
        [TestCaseSource(typeof(BotUtilitiesTestConstants), "NullNicknameDisplayNameGuildUser")]
        public void VerifyGetDisplayNameForUserReturnsUsernameWhenNoNicknameIsPresent(IGuildUser user, string expectedName)
        {
            string name = BotUtilities.GetDisplayNameForUser(user);
            Assert.Equals(expectedName, name);
        }

        [Test]
        public void VerifyGetDisplayNameForUserReturnsDefaultNameWhenUserIsNull()
        {
            string name = BotUtilities.GetDisplayNameForUser(null);
            Assert.Equals(BotUtilitiesTestConstants.DefaultDisplayName, name);
        }

        [Test]
        [TestCaseSource(typeof(BotUtilitiesTestConstants), "NullNicknameDisplayNameGuildUser")]
        public void VerifyGetDisplayNameForUserReturnsNicknameWhenNicknameIsPresent(IGuildUser user, string expectedName)
        {
            string name = BotUtilities.GetDisplayNameForUser(user);
            Assert.Equals(expectedName, name);
        }

        [Test]
        [TestCase("Some Random Fucking Guy IDK")]
        public void VerifyGetDisplayNameForUserReturnsPassedInDefaultNameWhenUserIsNull(string passedInUser)
        {
            string name = BotUtilities.GetDisplayNameForUser(null, passedInUser);
            Assert.Equals(passedInUser, name);
        }

        [Test]
        [TestCaseSource(typeof(BotUtilitiesTestConstants), "NullGuildAvatarAndNullAvatarIdUsers")]
        public void VerifyGetAvatarForUserReturnsDefaultAvatarWhenGuildAndAvatarIDsAreNull(IGuildUser user, string expectedAvatarId)
        {
            string avatarId = BotUtilities.GetAvatarForUser(user, expectedAvatarId);
            Assert.Equals(avatarId, expectedAvatarId);
        }

        [Test]
        [TestCaseSource(typeof(BotUtilitiesTestConstants), "NullGuildAvatarAndProidedAvatarIdUser")]
        public void VerifyGetAvatarForUserReturnsAvatarIdWhenGuildAvatarIDIsNull(IGuildUser user, string expectedAvatarId)
        {
            string avatarId = BotUtilities.GetAvatarForUser(user, expectedAvatarId);
            Assert.Equals(avatarId, expectedAvatarId);
        }

        [Test]
        [TestCaseSource(typeof(BotUtilitiesTestConstants), "ProvidedGuildAvataUsers")]
        public void VerifyGetAvatarForUserReturnsGuildAvatarWhenGuildAvatarIDIsNotNull(IGuildUser user, string expectedAvatarId)
        {
            string avatarId = BotUtilities.GetAvatarForUser(user, expectedAvatarId);
            Assert.Equals(avatarId, expectedAvatarId);
        }
    }

}