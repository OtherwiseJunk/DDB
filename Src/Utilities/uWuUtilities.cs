using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Utilities
{
    public static class uWuUtilities
    {
        public static List<string> UWUFaces = new() { "uWu", "UwU", "ÚwÚ", "Uwu", "(。U⁄ ⁄ω⁄ ⁄ U。)", "( ͡o ꒳ ͡o )", "( ˶˘ ³˘(ᵕ꒳ᵕ)*₊˚♡", "(*ฅ́˘ฅ̀*)", "( ᵘ ꒳ ᵘ ✼)", "🆄🆆🆄", "પฝપ", "🅄🅆🅄", "ＵｗＵ", "𝕌𝕨𝕌", "𝓤𝔀𝓤", "ሁሠሁ", "ᵾwᵾ", "☆w☆", "♥w♥", "uw ︠u", "( ᴜ ω ᴜ )", "(❀˘꒳˘)♡(˘꒳˘❀)", "[̲̅$̲̅(̲̅ ᵕ꒳ᵕ)̲̅$̲̅]", "( ͡U ω ͡U )", "*:･ﾟ✧(ꈍᴗꈍ)✧･ﾟ:*" };
        public static List<string> OtherCutesyFacies = new() {">:3", "(づ｡◕‿‿◕｡)づ", "(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧", "(●´ω｀●)", "⁀⊙෴☉⁀", "٩꒰ʘʚʘ๑꒱۶", "༼ ༎ຶ ᆺ ༎ຶ༽", "⌗(́◉◞౪◟◉‵⌗)", "(⋋°̧̧̧ω°̧̧̧⋌)", "凸(⊙▂⊙✖ )", "彡໒(⊙ᴗ⊙)७彡", "Ⴚტ⊙▂⊙ტჂ", "◝(๑꒪່౪̮꒪່๑)◜", "(●´⌓`●)", "=͟͟͞͞ =͟͟͞͞ ﾍ ( ´ Д `)ﾉ " };
        public static string Uwuify(this string str)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            if (str.ToLower().Contains("you") && random.Next(1,100) <= 10)
            {
                str = str.Replace("y", "y-y")
                         .Replace("Y", "Y-Y");
            }
            if(random.Next(1,100) <= 3)
            {
                string temp = "";
                foreach(string word in str.Split(' '))
                {
                    temp += word + " ";
                    if(random.Next(1,100) <= 35)
                    {
                        temp += OtherCutesyFacies.GetRandom() + " ";
                    }
                }
                str = temp.Trim();
                
            }
            return str.Replace("l", "w")
                      .Replace("r", "w")
                      .Replace("L", "W")
                      .Replace("R", "W")
                      .Replace("WW", "W")
                      .Replace("Ww", "W")
                      .Replace("wW", "w")
                      .Replace("ww", "w") + " " + UWUFaces.GetRandom();

        }
    }
}
