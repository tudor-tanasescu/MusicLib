using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id)
                .GeneratedBy.Identity();

            Map(u => u.Alias)
                .Not.Nullable()
                .Length(30);

            Map(u => u.UserName)
                .Not.Nullable()
                .Length(20);

            Map(u => u.Email)
                .Not.Nullable()
                .Length(20);

            Map(u => u.PasswordHash)
                .Not.Nullable();

            Map(u => u.DateJoined)
                .Not.Nullable();

            Map(u=>u.RecievesEmailNotifications)
                .Not.Nullable();

            HasMany(u => u.UserPlaylists)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(u => u.SavedPlaylists)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(u => u.LikedTracks)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(u => u.Followers)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(u => u.Following)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}