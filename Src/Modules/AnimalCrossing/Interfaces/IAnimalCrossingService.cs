using DartsDiscordBots.Modules.AnimalCrossing.Models;
using Discord;
using Discord.Commands;
using System.Collections.Generic;

namespace DartsDiscordBots.Modules.AnimalCrossing.Interfaces
{
	public interface IAnimalCrossingService
	{
		bool UserHasTown(ulong userId);
		string SetHemisphere(ulong userId, bool isNorthern);
		string SetNativeFruit(ulong userId, string fruitName);
		string RegisterTown(ulong userId, string townName);
		string RegisterFruit(ulong userId, string fruitName);
		string RegisterTurnipSellPrice(ulong userId, int turnipPrice);
		string RegisterTurnipBuyPrice(ulong userId, int turnipPrice);
		string RegisterWishlistItem(ulong userId, string itemName);
		string RemoveWishlistItemById(ulong userId, int itemId);
		string RemoveWishlistItemByName(ulong userId, string itemName);
		Embed GetWishlist(List<IGuildUser> users);
        Embed GetTownList(List<IGuildUser> users);
        Embed GetFruitList(List<IGuildUser> users);
		void SendTurnipPriceList(List<IGuildUser> users, ICommandContext context);
		string OpenTownBorder(ulong userId, string dodoCode);
		string CloseTownBorder(ulong userId);
		Town GetTown(int townId);
		Town GetTown(string townName);
		Town GetTown(ulong mayorId);
		string GetTurnipStats(ulong id);
		string GetTurnipPricesForWeek(ulong id);
		string SetRealName(ulong userId, string realName);
	}
}
