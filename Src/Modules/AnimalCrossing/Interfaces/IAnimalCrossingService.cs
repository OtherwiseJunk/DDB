using DartsDiscordBots.Modules.AnimalCrossing.Models;
using Discord;
using Discord.Commands;
using System.Collections.Generic;

namespace DartsDiscordBots.Modules.AnimalCrossing.Interfaces
{
	public interface IAnimalCrossingService
	{
		bool UserHasTown(ulong mayorDiscordUserId);
		string SetHemisphere(ulong mayorDiscordUserId, bool isNorthern);
		string SetNativeFruit(ulong mayorDiscordUserId, string fruitName);
		string RegisterTown(ulong mayorDiscordUserId, string townName);
		string RegisterFruit(ulong mayorDiscordUserId, string fruitName);
		string RegisterTurnipSellPrice(ulong mayorDiscordUserId, int turnipPrice);
		string RegisterTurnipBuyPrice(ulong mayorDiscordUserId, int turnipPrice);
		string RegisterWishlistItem(ulong mayorDiscordUserId, string itemName);
		string RemoveWishlistItemById(ulong mayorDiscordUserId, int itemId);
		string RemoveWishlistItemByName(ulong mayorDiscordUserId, string itemName);
		Embed GetWishlist(List<IGuildUser> users);
        Embed GetTownList(List<IGuildUser> users);
        Embed GetFruitList(List<IGuildUser> users);
		void SendTurnipPriceList(List<IGuildUser> users, ICommandContext context);
		string OpenTownBorder(ulong mayorDiscordUserId, string dodoCode);
		string CloseTownBorder(ulong mayorDiscordUserId);
		Town GetTown(int townId);
		Town GetTown(string townName);
		Town GetTown(ulong mayorDiscordUserId);
		Embed GetTurnipStats(ulong mayorDiscordUserId);
        Embed GetTurnipPricesForWeek(ulong mayorDiscordUserId);
		string SetRealName(ulong mayorDiscordUserId, string realName);
	}
}
