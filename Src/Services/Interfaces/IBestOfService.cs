using System.Collections.Generic;
using System.Threading.Tasks;
using DartsDiscordBots.Models;
using Discord;

namespace DartsDiscordBots.Services.Interfaces
{
    public interface IBestOfService
    {
        public bool IsBestOf(ulong messageId);
        public void CreateBestOf(BestOf bestOf, IMessage message);
        public List<BestOf> GetBestOfsForGuild(ulong guildId);
        public Task<List<BestOfWithMessage>> RetrieveMessagesForBestOfs(List<BestOf> bestOfs, IGuild guild);

    }
}
