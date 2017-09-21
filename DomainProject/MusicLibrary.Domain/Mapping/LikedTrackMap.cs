using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    public class LikedTrackMap : ClassMap<LikedTrack>
    {
        public LikedTrackMap()
        {
            Id(lt => lt.Id)
                .GeneratedBy.Identity();

            References(lt => lt.User)
                .Not.Nullable();

            References(lt => lt.Track)
                .Not.Nullable();

            Map(lt => lt.DateLiked)
                .Not.Nullable();
        }
    }
}