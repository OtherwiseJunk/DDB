using System;
using System.Linq;
using System.Threading.Tasks;
using DartsDiscordBots.Services;
using Discord;
using Discord.Commands;
using Lavalink4NET;
using Lavalink4NET.DiscordNet;
using Lavalink4NET.Players;
using Lavalink4NET.Players.Queued;
using Lavalink4NET.Rest.Entities.Tracks;
using Microsoft.Extensions.Options;

namespace DartsDiscordBots.Modules;

public sealed class AudioModule(
    IAudioService audioService,
    DartsDiscordBots.Services.AudioService botAudioService)
    : ModuleBase<SocketCommandContext>
{
    private async ValueTask<QueuedLavalinkPlayer?> GetPlayerAsync(bool connectToVoiceChannel = true)
    {
        var channelBehavior = connectToVoiceChannel
            ? PlayerChannelBehavior.Join
            : PlayerChannelBehavior.None;

        var retrieveOptions = new PlayerRetrieveOptions(ChannelBehavior: channelBehavior);

        var playerOptions = new QueuedLavalinkPlayerOptions
        {
            SelfDeaf = true,
        };

        var voiceState = Context.User as IVoiceState;

        var result = await audioService.Players
            .RetrieveAsync(
                Context.Guild.Id,
                voiceState?.VoiceChannel?.Id,
                PlayerFactory.Queued,
                Microsoft.Extensions.Options.Options.Create(playerOptions),
                retrieveOptions)
            .ConfigureAwait(false);

        if (!result.IsSuccess)
        {
            var errorMessage = result.Status switch
            {
                PlayerRetrieveStatus.UserNotInVoiceChannel => "You must be connected to a voice channel!",
                PlayerRetrieveStatus.BotNotConnected => "I'm not connected to a voice channel.",
                _ => "An unknown error occurred.",
            };

            await ReplyAsync(errorMessage);
            return null;
        }

        return result.Player;
    }

    [Command("Join")]
    public async Task JoinAsync()
    {
        var player = await GetPlayerAsync(connectToVoiceChannel: true);
        if (player == null) return;

        var voiceState = Context.User as IVoiceState;
        await ReplyAsync($"Joined {voiceState?.VoiceChannel?.Name}!");
        botAudioService.TextChannels.TryAdd(Context.Guild.Id, Context.Channel.Id);
    }

    [Command("Leave")]
    public async Task LeaveAsync()
    {
        var player = await GetPlayerAsync(connectToVoiceChannel: false);
        if (player == null)
        {
            await ReplyAsync("Not sure which voice channel to disconnect from.");
            return;
        }

        var channelName = (Context.User as IVoiceState)?.VoiceChannel?.Name ?? "the channel";

        try
        {
            await player.DisconnectAsync();
            await ReplyAsync($"I've left {channelName}!");
        }
        catch (Exception exception)
        {
            await ReplyAsync(exception.Message);
        }
    }

    [Command("Play")]
    public async Task PlayAsync([Remainder] string searchQuery)
    {
        if (string.IsNullOrWhiteSpace(searchQuery))
        {
            await ReplyAsync("Please provide search terms.");
            return;
        }

        var player = await GetPlayerAsync(connectToVoiceChannel: true);
        if (player == null) return;

        botAudioService.TextChannels.TryAdd(Context.Guild.Id, Context.Channel.Id);

        var track = await audioService.Tracks
            .LoadTrackAsync(searchQuery, TrackSearchMode.YouTube)
            .ConfigureAwait(false);

        if (track == null)
        {
            await ReplyAsync($"I wasn't able to find anything for `{searchQuery}`.");
            return;
        }

        var position = await player.PlayAsync(track).ConfigureAwait(false);

        if (position is 0)
        {
            await ReplyAsync($"Now playing: {track.Title}");
        }
        else
        {
            await ReplyAsync($"Added {track.Title} to queue.");
        }
    }

    [Command("Pause")]
    public async Task PauseAsync()
    {
        var player = await GetPlayerAsync(connectToVoiceChannel: false);
        if (player == null) return;

        if (player.CurrentTrack == null)
        {
            await ReplyAsync("I cannot pause when I'm not playing anything!");
            return;
        }

        if (player.State is PlayerState.Paused)
        {
            await ReplyAsync("Already paused.");
            return;
        }

        await player.PauseAsync().ConfigureAwait(false);
        await ReplyAsync($"Paused: {player.CurrentTrack?.Title}");
    }

    [Command("Resume")]
    public async Task ResumeAsync()
    {
        var player = await GetPlayerAsync(connectToVoiceChannel: false);
        if (player == null) return;

        if (player.State is not PlayerState.Paused)
        {
            await ReplyAsync("I'm not paused.");
            return;
        }

        await player.ResumeAsync().ConfigureAwait(false);
        await ReplyAsync($"Resumed: {player.CurrentTrack?.Title}");
    }

    [Command("Stop")]
    public async Task StopAsync()
    {
        var player = await GetPlayerAsync(connectToVoiceChannel: false);
        if (player == null) return;

        if (player.CurrentTrack == null)
        {
            await ReplyAsync("Woah, can't stop won't stop.");
            return;
        }

        await player.StopAsync().ConfigureAwait(false);
        await ReplyAsync("No longer playing anything.");
    }

    [Command("Skip")]
    public async Task SkipAsync()
    {
        var player = await GetPlayerAsync(connectToVoiceChannel: false);
        if (player == null) return;

        if (player.CurrentTrack == null)
        {
            await ReplyAsync("Woaaah there, I can't skip when nothing is playing.");
            return;
        }

        var voiceChannelUsers = Context.Guild.CurrentUser.VoiceChannel
            .Users
            .Where(x => !x.IsBot)
            .ToArray();

        if (!botAudioService.VoteQueue.Add(Context.User.Id))
        {
            await ReplyAsync("You can't vote again.");
            return;
        }

        var percentage = (double)botAudioService.VoteQueue.Count / voiceChannelUsers.Length * 100;
        if (percentage < 85)
        {
            await ReplyAsync("You need more than 85% votes to skip this song.");
            return;
        }

        var skippedTrack = player.CurrentTrack;
        await player.SkipAsync().ConfigureAwait(false);
        botAudioService.VoteQueue.Clear();

        var nextTrack = player.CurrentTrack;
        if (nextTrack != null)
        {
            await ReplyAsync($"Skipped: {skippedTrack?.Title}\nNow Playing: {nextTrack.Title}");
        }
        else
        {
            await ReplyAsync($"Skipped: {skippedTrack?.Title}\nQueue is empty.");
        }
    }
}
