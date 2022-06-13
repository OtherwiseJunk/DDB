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
            SocketGuildUser user = arg.Creator;
            Console.WriteLine($"[DDB] - An event has been created! Announcement Channel null? {announcementChnl == null}. Creating user null? {user == null}");
            if(announcementChnl != null)
            {                
                string eventMessage = $"{BotUtilities.GetDisplayNameForUser(user)} has created a new event!{Environment.NewLine}{Environment.NewLine}{String.Format(EventUrlFormat, arg.Guild.Id, arg.Id)}";
                announcementChnl.SendMessageAsync(eventMessage);
            }
        }
        public static async void AnnounceNewEventStarted(SocketGuildEvent arg)
        {
            ITextChannel announcementChnl = (ITextChannel)arg.Guild.Channels.FirstOrDefault(c => c.Name.ToLower() == "announcements");
            Console.WriteLine($"[DDB] - An event has started! Announcement Channel null? {announcementChnl == null}.");
            if (announcementChnl != null)
            {
                string channelNameString = arg.Channel != null ? $" Join {arg.Channel.Name} now!" : String.Empty;
                string mentionString = "";
                List<RestUser> users = (List<RestUser>)arg.GetUsersAsync(RequestOptions.Default);
                Console.WriteLine($"[DDB] - Users list null? {users == null}. Users list empty? {users.Count == 0}");
                foreach (var user in users)
                {
                    mentionString += user.Mention;
                }
                string eventMessage = $"{arg.Name} event has started!{channelNameString}{mentionString}";
                _ = announcementChnl.SendMessageAsync(eventMessage);
            }
        }
    }
}
