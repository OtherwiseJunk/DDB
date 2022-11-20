using DDB.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Tests.Constants
{
    public class BotUtilitiesTestConstants
    {
        public static string DefaultDisplayName = "A sexy, unknowable stranger";
        static string Username1 = "D4rkBr4nd0n420";
        static string Username2 = "D0n4ldTrump6969";
        static string Nickname1 = "POTUSDeezNuts"; 
        static string Nickname2 = "TheRealPOTUSYanno?";
        static string GuildAvatarId = "guild";
        static string AvatarId = "avatar";
        static string DefaultAvatarId = "default";
        public static IEnumerable<TestCaseData> NullNicknameDisplayNameGuildUser
        {
            get
            {
                yield return new TestCaseData(new DisplayNameGuildUser(Username1, null), Username1);
                yield return new TestCaseData(new DisplayNameGuildUser(Username2, null), Username2);
            }
        }
        public static IEnumerable<TestCaseData> NicknamedDisplayNameGuildUser
        {
            get
            {
                yield return new TestCaseData(new DisplayNameGuildUser(Username1, Nickname1), Nickname1);
                yield return new TestCaseData(new DisplayNameGuildUser(Username2, Nickname2), Nickname2);
            }
        }

        public static IEnumerable<TestCaseData> NullGuildAvatarAndNullAvatarIdUsers
        {
            get
            {
                yield return new TestCaseData(new AvatarGuildUser(null, null), DefaultAvatarId);
                yield return new TestCaseData(null, DefaultAvatarId);
            }
        }
        public static IEnumerable<TestCaseData> NullGuildAvatarAndProidedAvatarIdUser
        {
            get
            {
                yield return new TestCaseData(new AvatarGuildUser(AvatarId, null), AvatarId);
            }
        }
        public static IEnumerable<TestCaseData> ProvidedGuildAvataUsers
        {
            get
            {
                yield return new TestCaseData(new AvatarGuildUser(AvatarId, GuildAvatarId), GuildAvatarId);
                yield return new TestCaseData(new AvatarGuildUser(null, GuildAvatarId), GuildAvatarId);
            }
        }
    }
}
