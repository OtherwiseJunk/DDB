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
    public class LockedTombModule : ModuleBase
    {
        private List<string> CowFacts = new List<string>
        {
            "Cows exhibit mourning behaviour for other cows",
            "Cows recognize each other",
            "Cows watch sunsets",
            "Cows have best friends and complex social relationships",
            "Not only are cows more calm when they're around a buddy, but they're actually smarter too",
            "Cows panic when separated from their besties",
            "Cows celebratie solving complex problems by jumping, wagging their tails, and running around",
            "Cows display an ability to discriminate complex stimuli",
            "Cows can differentiate between different humans",
            "Cows can extrapolate the location of a hidden moving object",
            "Cows have excellent long-term memories",
            "Cows display emotional contagion; when one cow is stressed their packmates will also act stressed",
            "Cows display a full range of personality, including boldness, shyness, sociability, gregariousness, and being tempermental",
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
            "https://images.ctfassets.net/ww1ie0z745y7/4nyO2E7VzBRMVBJpKQCCY8/f79691e5932d32b0eb65415fdaac6e6d/shutterstock_135944723.jpg",
            "https://charitypaws.com/wp-content/uploads/2020/12/cows-best-friends.jpg",
            "https://d2zupx01utsj9r.cloudfront.net/media/filer_public/fb/ae/fbae0234-2166-4657-9207-6dc60d7e408b/pearson_cowsinpasture.jpg",
            "https://i.icanvas.com/TEJ72",
            "https://media.istockphoto.com/id/538027668/photo/single-cow-on-a-meadow-happy-view.jpg",
            "https://live.staticflickr.com/1945/31116055738_bda0d22d12_b.jpg",
            "https://images.squarespace-cdn.com/content/v1/5aac8c11b27e394b18225129/1577405961435-RXC7T4QQ97MPSWR5EB5B/_7R31352_2.jpg",
            "https://w0.peakpx.com/wallpaper/442/851/HD-wallpaper-cow-at-dark-sunset-cow-life-nature-sunset-animal.jpg",
            "https://64.media.tumblr.com/29d64de155f921c769a448ee06c5bdb0/tumblr_n3fvn88z501tv8ffpo2_500.jpg",
            "https://static.boredpanda.com/blog/wp-content/uploads/2017/10/59d490df85312_lpj7hm6t9zly__700.jpg",
            "https://external-preview.redd.it/Hiyig7sc66BT1R8ZjE39d6uzrW_9K2-cVGRLLaWHRL8.jpg",
            "https://preview.redd.it/9b3syi90njtz.jpg",
            "https://www.boredpanda.com/blog/wp-content/uploads/2021/11/6188f6f406e42_io2ob4n5b0h01__700.jpg",
            "https://www.boredpanda.com/blog/wp-content/uploads/2021/11/61a5f2320f33d_37jqkelbe8351__700.jpg",
            "https://img.atlasobscura.com/D2It7ft-b--puKuQiFyhxCIoLgD4-ANgi_HaAihxs8c/rt:fit/w:1280/q:81/sm:1/scp:1/ar:1/aHR0cHM6Ly9hdGxh/cy1kZXYuczMuYW1h/em9uYXdzLmNvbS91/cGxvYWRzL2Fzc2V0/cy84YTJmZjU1ZTEy/MWMyZGJjYTVfQ293/czEuanBn.jpg",
            "https://images.theconversation.com/files/472297/original/file-20220704-12-7zgqd5.jpg",
            "https://d.newsweek.com/en/full/1561066/holstein-cows.jpg",
            "https://scx1.b-cdn.net/csz/news/800a/2017/howdangerous.jpg",
            "https://cdn.mos.cms.futurecdn.net/S3zXzUDh4dS274tg3n9MBR-1200-80.jpg",
            "https://www.aces.edu/wp-content/uploads/2020/11/GettyImages-186501746-scaled.jpg",
            "https://assets.vogue.com/photos/5b23cca0dfb55f5d708a26ca/master/pass/00-promo-secret-life-cows.jpg",
            "https://d1whtlypfis84e.cloudfront.net/guides/wp-content/uploads/2019/08/03134242/cow-1024x809.jpeg",
            "https://nypost.com/wp-content/uploads/sites/2/2020/01/cow-feature.jpg?quality=75&strip=all",
            "https://i.guim.co.uk/img/media/ff9af395ffc13511cb83a24f5052293187e4f298/0_415_4099_2460/master/4099.jpg",
            "https://modernfarmer.com/wp-content/uploads/2014/09/innercowhero.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBhh4Rnlqu7uKN61js-MEekX6sJzpo2vSxMA&usqp=CAU",
            "https://cdn.theatlantic.com/thumbor/XIWLh2nTvoG9waDIDKEB8hheItE=/442x1:2888x2447/1080x1080/media/img/mt/2017/08/Pineywood/original.jpg",
            "https://extension.sdstate.edu/sites/default/files/2021-08/W-01188-00-Cow-Pregnant-Reproduction-Beef.jpg",
            "https://lp-cms-production.imgix.net/image_browser/Swiss%20Cow%20Festival%20-%20The%20cows%20coming%20down%20the%20mountain%20-Swiss%20Image%20Bank%20-%20Andreas%20Mueller.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/3/3b/Two_cows.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQu7l_-LKRh98X_OGgoItaO5HIYshfH_FjZeIQ6koFLX6E0n0UCLgAELmVMjqef_aQ9rQ0&usqp=CAU",
            "https://i.pinimg.com/originals/f5/43/0c/f5430cece8c53d2e5dc613339a9f3d3b.jpg"
        };

        [Command("cowfacts"), Alias("meatwall")]
        public async Task GetRandomCowFactEmbed()
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
            _ = Context.Message.ReplyAsync(embed: embed.Build(), allowedMentions: AllowedMentions.None);
        }
    }
}
