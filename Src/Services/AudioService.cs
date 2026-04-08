using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Lavalink4NET;
using Lavalink4NET.Events;
using Lavalink4NET.Events.Players;

namespace DartsDiscordBots.Services
{
    public sealed class AudioService
    {
        private readonly DiscordSocketClient _socketClient;
        private readonly ILogger _logger;
        public readonly HashSet<ulong> VoteQueue;
        public readonly ConcurrentDictionary<ulong, ulong> TextChannels;

        public AudioService(
            IAudioService audioService,
            DiscordSocketClient socketClient,
            ILogger<AudioService> logger)
        {
            _socketClient = socketClient;
            _logger = logger;
            TextChannels = new ConcurrentDictionary<ulong, ulong>();
            VoteQueue = [];

            audioService.TrackStarted += OnTrackStarted;
            audioService.TrackEnded += OnTrackEnded;
        }

        private Task OnTrackStarted(object sender, TrackStartedEventArgs args)
        {
            return SendAndLogMessageAsync(args.Player.GuildId,
                $"Now playing: {args.Track.Title}");
        }

        private Task OnTrackEnded(object sender, TrackEndedEventArgs args)
        {
            return SendAndLogMessageAsync(args.Player.GuildId,
                $"{args.Track.Title} ended with reason: {args.Reason}");
        }

        private Task SendAndLogMessageAsync(ulong guildId, string message)
        {
            _logger.LogInformation(message);
            if (!TextChannels.TryGetValue(guildId, out var textChannelId))
            {
                return Task.CompletedTask;
            }

            return (_socketClient
                    .GetGuild(guildId)
                    .GetChannel(textChannelId) as ITextChannel)
                .SendMessageAsync(message);
        }
    }
}
