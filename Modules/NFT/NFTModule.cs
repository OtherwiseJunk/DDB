using DartsDiscordBots.Services;
using Discord.Commands;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DartsDiscordBots.Modules.NFT
{
    public class NFTModule : ModuleBase
    {
		ImagingService _imaging { get; set; }
		[Command("nft")]
		[Summary("Generates an NFT for the user.")]
		public async Task MakeNFT([Remainder] string mode = "")
		{
			new Thread(async () =>
			{
				string guid = Guid.NewGuid().ToString();
				SKBitmap bmp;
				if (mode.ToLower() == "rainbow" || mode.ToLower() == "r")
				{
					bmp = _imaging.GenerateJuliaSetImage(1028, 720, _imaging.BuildRainbowPallette()).Result;
				}
				else if (mode.ToLower() == "mandelbrot" || mode.ToLower() == "m")
				{
					bmp = _imaging.GenerateMandlebrotSet(1028, 720, _imaging.BuildStandardPallette()).Result;
				}
				else if (mode.ToLower() == "mandelbrotrandom" || mode.ToLower() == "mr")
				{
					bmp = _imaging.GenerateMandlebrotSet(1028, 720, _imaging.BuildRainbowPallette()).Result;
				}
				else
				{
					bmp = _imaging.GenerateJuliaSetImage(1028, 720, _imaging.BuildStandardPallette()).Result;
				}
				Stream stream = bmp.Encode(SKEncodedImageFormat.Png, 100).AsStream();
				await Context.Channel.SendFileAsync(stream, $"{guid}.png", text: $"Here is your newly minted NFT, ID {Guid.NewGuid()}. Write it down or something, I'm not gonna track it.");
			})
			{

			}.Start();

		}
	}
}
