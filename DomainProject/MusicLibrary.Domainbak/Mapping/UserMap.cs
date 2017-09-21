using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Domain.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id).GeneratedBy.GuidComb();
            Map(u => u.Alias);
            Map(u => u.UserName);
            Map(u => u.Email);
            Map(u => u.PasswordHash);
            Map(u => u.DateJoined);
            Map(u=>u.RecievesEmailNotifications);
            HasMany(u => u.UserPlaylists).Cascade.AllDeleteOrphan();
            HasMany(u => u.SavedPlaylists).Cascade.AllDeleteOrphan();
            HasMany(u => u.LikedTracks).Cascade.AllDeleteOrphan();
            HasMany(u => u.Followers).Cascade.AllDeleteOrphan();
            HasMany(u => u.Following).Cascade.AllDeleteOrphan();
        }
    }

    public class UsersSavedPlaylistsMap : ClassMap<UsersSavedPlaylists>
    {
        public UsersSavedPlaylistsMap()
        {
            Id(spl => spl.Id).GeneratedBy.GuidComb();
            References(spl => spl.SavedPlaylist).Unique();
            References(uspl => uspl.User);
            Map(spl => spl.DateSaved);
        }
    }

    public class LikedTrackMap : ClassMap<LikedTrack>
    {
        public LikedTrackMap()
        {
            Id(lt => lt.Id).GeneratedBy.GuidComb();
            References(lt => lt.User);
            References(lt => lt.Track);
            Map(lt => lt.DateLiked);
        }
    }
}