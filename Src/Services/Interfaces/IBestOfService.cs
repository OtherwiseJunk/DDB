using DartsDiscordBots.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Services.Interfaces
{
    public interface IBestOfService
    {
        public bool IsBestOf(ulong messageId);
        public void CreateBestOf(BestOf bestOf);

    }
}
