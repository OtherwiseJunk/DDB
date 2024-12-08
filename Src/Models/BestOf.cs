using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Models
{
    public class BestOf
    {
        [Key]
        public int BestOfId { get; set; }
        public ulong MessageId { get; set; }
        public DateTimeOffset MessageSentDate { get; set; }
        public ulong GuildId { get; set; }
        public ulong ChannelId { get; set; }
        public ulong UserId { get; set; }
        public string TriggeringEmoji { get; set; }
        public string Content { get; set; }
        
    }
}
