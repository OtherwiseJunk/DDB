using DartsDiscordBots.Modules.AnimalCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Modules.AnimalCrossing.Interfaces
{
    public interface IAnimalCrossingDataService
    {
        List<Town> GetAllTowns(bool includeFruitData = false, bool includeTurnipData = false);
#nullable enable
        Town? GetTownById(int townId);
        Town? GetTownByName(string townName);
        Town? GetTownByDiscordUserId(ulong mayorDiscordUserId, bool includeFruitData = false, bool includeTurnipData = false);
#nullable disable
        void RegisterTown(ulong mayorDiscordUserId, string townName);
        void RegisterFruit(ulong mayorDiscordUserId, string fruitName);
        void RegisterTurnipBuyPrice(ulong mayorDiscordUserId, int turnipPrice);
        void RegisterTurnipSellPrice(ulong mayorDiscordUserId, int turnipPrice);
        void SetHemisphere(ulong mayorDiscordUserId, bool isNorthern);
        void SetNativeFruit(ulong mayorDiscordUserId, string fruitName);
        void SetRealName(ulong mayorDiscordUserId, string realName);
        void RegisterWishListItem(ulong mayorDiscordUserId, string itemName);
        void RemoveWishLIstItemById(ulong mayorDiscordUserId, int itemId);
        void RemoveWishLIstItemByName(ulong mayorDiscordUserId, string itemName);
        void ChangeTownBorderStatus(ulong mayorDiscordUserId, bool isOpen, string dodoCode = "");
        void CloseAllOpenTowns();
    }
}
