using DartsDiscordBots.Utilities;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Modules.LockedTomb
{
    internal class LockedTombModule : ModuleBase
    {
        private List<string> CowFacts = new List<string>
        {
            "Cows exhibit mourning behaviour for other cows",
            "Cows recognize each other",
            "Cows watch sunsets",
            "Cows have best friends and complex social relationships"
        };

        private List<string> JohnGaiusPictures = new List<string>
        {
            "https://64.media.tumblr.com/86af77e3b2964dd93942acac735001c2/f48efb5c33f96ef8-a6/s1280x1920/bb136a7554f17417f53cc4397e87d7d5686a1a68.jpg",
            "https://pbs.twimg.com/media/FQQcsp5X0AkUNHq?format=jpg&name=4096x4096",
            "https://static.wikia.nocookie.net/the-ninth-house-trilogy/images/9/9b/The_Emperor.jpg/revision/latest?cb=20201019230021",
            "https://preview.redd.it/sjpb29cxopl91.jpg?width=640&crop=smart&auto=webp&s=9266f4f601bc190d15ea19c5b649757c7c125592",
            "https://64.media.tumblr.com/941ad6567ac62cb07d627238f97b7fdf/5db99ec58bb71f0e-fa/s500x750/9531192854179abc08d8cfef1475cf20d7cc0abe.jpg",
            "https://64.media.tumblr.com/95479de23c071ce23964552164a4c12e/82ca864287c06b96-8c/s250x400/722a7331c5585c9b69f6d4979cb174ac24c3431e.jpg",
            "https://pbs.twimg.com/media/FnHzUarWAAIUV6L?format=jpg&name=large"
        };

        private List<string> CowPictures = new List<string>
        {
            "https://cdn.britannica.com/55/174255-050-526314B6/brown-Guernsey-cow.jpg",
            "https://vegnews.com/media/W1siZiIsIjM0NjE3L1ZlZ05ld3MuQ293c0Jlc3RGcmllbmRzLkpha0pvbmVzLlBleGVscy5qcGciXSxbInAiLCJjcm9wX3Jlc2l6ZWQiLCIxNTk3eDk0NCsxKzAiLCIxNjAweDk0Nl4iLHsiZm9ybWF0IjoianBnIn1dLFsicCIsIm9wdGltaXplIl1d/VegNews.CowsBestFriends.JakJones.Pexels.jpg",
            "https://images.ctfassets.net/ww1ie0z745y7/4nyO2E7VzBRMVBJpKQCCY8/f79691e5932d32b0eb65415fdaac6e6d/shutterstock_135944723.jpg?fm=webp&w=1280",
            "https://charitypaws.com/wp-content/uploads/2020/12/cows-best-friends.jpg",
            "https://d2zupx01utsj9r.cloudfront.net/media/filer_public/fb/ae/fbae0234-2166-4657-9207-6dc60d7e408b/pearson_cowsinpasture.jpg",
            "https://i.icanvas.com/TEJ72?d=2&sh=h&p=1&bg=g",
            "https://media.istockphoto.com/id/538027668/photo/single-cow-on-a-meadow-happy-view.jpg?s=612x612&w=0&k=20&c=mPs7UbTQQmwRX3vkPJG2_XPfsSt6KIxdg5SAl1utGpA=",
            "https://live.staticflickr.com/1945/31116055738_bda0d22d12_b.jpg",
            "https://images.squarespace-cdn.com/content/v1/5aac8c11b27e394b18225129/1577405961435-RXC7T4QQ97MPSWR5EB5B/_7R31352_2.jpg?format=2500w",
            "https://w0.peakpx.com/wallpaper/442/851/HD-wallpaper-cow-at-dark-sunset-cow-life-nature-sunset-animal.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZ0vP3LM9s52KwdRSCLhfLeBXoRehwsDJCOvWP2vQZdF66P-KkCLO83Sr4uSbw4huxac0&usqp=CAU",
            "https://64.media.tumblr.com/29d64de155f921c769a448ee06c5bdb0/tumblr_n3fvn88z501tv8ffpo2_500.jpg",
            "https://static.boredpanda.com/blog/wp-content/uploads/2017/10/59d490df85312_lpj7hm6t9zly__700.jpg",
            "https://external-preview.redd.it/Hiyig7sc66BT1R8ZjE39d6uzrW_9K2-cVGRLLaWHRL8.jpg?auto=webp&s=f536d292b9814aa22cdf6bf47751fb6a2775643c",
            "https://preview.redd.it/9b3syi90njtz.jpg?auto=webp&s=f4ec05829294d23e33d8fa0083ae176dc14a9754",
            "https://s.yimg.com/ny/api/res/1.2/NT_dcFWtZDbTz_golPQnVA--/YXBwaWQ9aGlnaGxhbmRlcjt3PTY0MA--/https://media.zenfs.com/en-US/best_life_342/857394ae0a2760064b9ace5af1bc9b2e",
            "https://www.boredpanda.com/blog/wp-content/uploads/2021/11/6188f6f406e42_io2ob4n5b0h01__700.jpg",
            "https://www.boredpanda.com/blog/wp-content/uploads/2021/11/61a5f2320f33d_37jqkelbe8351__700.jpg",
        };

        [Command("cowfacts"), Alias("meatwall")]
        public void GetRandomCowFactEmbed()
        {
            EmbedBuilder embed = new();
            embed.Title = "Did you know?";
            embed.Description = CowFacts.GetRandom();
            embed.ImageUrl = CowPictures.GetRandom();
            if (BotUtilities.PercentileCheck(1))
            {
                embed.Description = "Cows make for excellent building material.";
                embed.ImageUrl = JohnGaiusPictures.GetRandom();
            }
            Context.Message.ReplyAsync(embed: embed.Build(), allowedMentions: AllowedMentions.None);
        }
    }
}
