using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Tests.Mocks
{
    public class DisplayNameGuildUser : IGuildUser
    {
        public DisplayNameGuildUser(string username, string? nickName)
        {
            Username = username;
            Nickname = nickName;
        }
        public DateTimeOffset? JoinedAt => throw new NotImplementedException();
        public string DisplayName => throw new NotImplementedException();
        public string? Nickname { get; set; }
        public string DisplayAvatarId => throw new NotImplementedException();
        public string GuildAvatarId => throw new NotImplementedException();
        public string GuildBannerHash { get; }
        public GuildPermissions GuildPermissions => throw new NotImplementedException();
        public IGuild Guild => throw new NotImplementedException();
        public ulong GuildId => throw new NotImplementedException();
        public DateTimeOffset? PremiumSince => throw new NotImplementedException();
        public IReadOnlyCollection<ulong> RoleIds => throw new NotImplementedException();
        public bool? IsPending => throw new NotImplementedException();
        public int Hierarchy => throw new NotImplementedException();
        public DateTimeOffset? TimedOutUntil => throw new NotImplementedException();
        public string AvatarId => throw new NotImplementedException();
        public string Discriminator => throw new NotImplementedException();
        public ushort DiscriminatorValue => throw new NotImplementedException();
        public bool IsBot => throw new NotImplementedException();
        public bool IsWebhook => throw new NotImplementedException();
        public string Username { get; set; }
        public UserProperties? PublicFlags => throw new NotImplementedException();
        public DateTimeOffset CreatedAt => throw new NotImplementedException();
        public ulong Id => throw new NotImplementedException();
        public string Mention => throw new NotImplementedException();
        public UserStatus Status => throw new NotImplementedException();
        public IReadOnlyCollection<ClientType> ActiveClients => throw new NotImplementedException();
        public IReadOnlyCollection<IActivity> Activities => throw new NotImplementedException();
        public bool IsDeafened => throw new NotImplementedException();
        public bool IsMuted => throw new NotImplementedException();
        public bool IsSelfDeafened => throw new NotImplementedException();
        public bool IsSelfMuted => throw new NotImplementedException();
        public bool IsSuppressed => throw new NotImplementedException();
        public IVoiceChannel VoiceChannel => throw new NotImplementedException();
        public string VoiceSessionId => throw new NotImplementedException();
        public bool IsStreaming => throw new NotImplementedException();
        public bool IsVideoing => throw new NotImplementedException();
        public DateTimeOffset? RequestToSpeakTimestamp => throw new NotImplementedException();

        public GuildUserFlags Flags => throw new NotImplementedException();

        public string GlobalName => throw new NotImplementedException();

        public string AvatarDecorationHash => throw new NotImplementedException();

        public ulong? AvatarDecorationSkuId => throw new NotImplementedException();

        public Task AddRoleAsync(ulong roleId, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task AddRoleAsync(IRole role, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task AddRolesAsync(IEnumerable<ulong> roleIds, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task AddRolesAsync(IEnumerable<IRole> roles, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task<IDMChannel> CreateDMChannelAsync(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public string GetAvatarDecorationUrl()
        {
            throw new NotImplementedException();
        }

        public string GetAvatarUrl(ImageFormat format = ImageFormat.Auto, ushort size = 128)
        {
            throw new NotImplementedException();
        }
        public string GetDefaultAvatarUrl()
        {
            throw new NotImplementedException();
        }
        public string GetDisplayAvatarUrl(ImageFormat format = ImageFormat.Auto, ushort size = 128)
        {
            throw new NotImplementedException();
        }
        public string GetGuildAvatarUrl(ImageFormat format = ImageFormat.Auto, ushort size = 128)
        {
            throw new NotImplementedException();
        }

        public string GetGuildBannerUrl(ImageFormat format = ImageFormat.Auto, ushort size = 128)
        {
            throw new NotImplementedException();
        }

        public ChannelPermissions GetPermissions(IGuildChannel channel)
        {
            throw new NotImplementedException();
        }
        public Task KickAsync(string reason = null, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task ModifyAsync(Action<GuildUserProperties> func, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task RemoveRoleAsync(ulong roleId, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task RemoveRoleAsync(IRole role, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task RemoveRolesAsync(IEnumerable<ulong> roleIds, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task RemoveRolesAsync(IEnumerable<IRole> roles, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task RemoveTimeOutAsync(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public Task SetTimeOutAsync(TimeSpan span, RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
    }
}
