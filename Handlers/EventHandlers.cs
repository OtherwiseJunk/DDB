using DartsDiscordBots.Utilities;
using Discord;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Handlers
{
    public class EventHandlers
    {
        public static string EventUrlFormat = @"https://discord.com/events/{0}/{1}";
        public static void AnnounceNewEvent(SocketGuildEvent arg)
        {
            ITextChannel announcementChnl = (ITextChannel) arg.Guild.Channels.FirstOrDefault(c => c.Name.ToLower() == "announcements");
            if(announcementChnl != null)
            {                
                string eventMessage = $"{BotUtilities.GetDisplayNameForUser(arg.Creator)} has created a new event!{Environment.NewLine}{Environment.NewLine}{String.Format(EventUrlFormat, arg.Guild.Id, arg.Id)}";
                announcementChnl.SendMessageAsync(eventMessage);
            }
        }
        public static async void AnnounceNewEventStarted(SocketGuildEvent arg)
        {
            ITextChannel announcementChnl = (ITextChannel)arg.Guild.Channels.FirstOrDefault(c => c.Name.ToLower() == "announcements");            
            if (announcementChnl != null)
            {
                string channelNameString = arg.Channel != null ? $" Join {arg.Channel.Name} now!" : String.Empty;
                string mentionString = "";
                foreach (RestUser user in arg.GetUsersAsync(RequestOptions.Default).ToListAsync().Result)
                {
                    mentionString += user.Mention;
                }
                string eventMessage = $"{arg.Name} event has started!{channelNameString}{mentionString}";
                _ = announcementChnl.SendMessageAsync(eventMessage);
            }
        }
    }
}
