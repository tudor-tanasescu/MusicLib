using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    public class PlaylistTrackMap : ClassMap<PlaylistTrack>
    {
        public PlaylistTrackMap()
        {
            Id(pt => pt.Id)
                .GeneratedBy.Identity();

            References(pt => pt.Track)
                .Not.Nullable()
                .UniqueKey("U_Playlist_Track");

            References(pt => pt.Playlist)
                .Not.Nullable()
                .UniqueKey("U_Playlist_Track");

            Map(pt=>pt.DateAdded)
                .Not.Nullable();
        }
    }
}