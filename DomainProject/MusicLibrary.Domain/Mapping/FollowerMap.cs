using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    class FollowerMap : ClassMap<Follower>
    {
        public FollowerMap()
        {
            Id(f => f.Id)
                .GeneratedBy.Identity();

            References(f => f.FollowingUser)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .UniqueKey("U_Follower_Followed");

            References(f => f.FollowedUser)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .UniqueKey("U_Follower_Followed");

            Map(f => f.DateFollowed)
                .Not.Nullable();
        }
    }
}
