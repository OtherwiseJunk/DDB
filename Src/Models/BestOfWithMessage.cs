using Discord;

namespace DartsDiscordBots.Models;

public class BestOfWithMessage : BestOf
{
    public IMessage Message { get; set; }

    public BestOfWithMessage(BestOf bestOf, IMessage message)
    {
        BestOdIf = bestOf.BestOdIf;
        MessageId = bestOf.MessageId;
        MessageSentDate = bestOf.MessageSentDate;
        GuildId = bestOf.GuildId;
        ChannelId = bestOf.ChannelId;
        UserId = bestOf.UserId;
        TriggeringEmoji = bestOf.TriggeringEmoji;
        Message = message;
    }
}