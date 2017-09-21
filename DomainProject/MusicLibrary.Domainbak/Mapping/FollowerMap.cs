using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Domain.Mapping
{
    class FollowerMap : ClassMap<Follower>
    {
        public FollowerMap()
        {
            Id(f => f.Id).GeneratedBy.GuidComb();
            References(f => f.FollowingUser).Cascade.SaveUpdate();
            References(f => f.FollowedUser).Cascade.SaveUpdate();
            Map(f => f.DateFollowed);
        }
    }
}
