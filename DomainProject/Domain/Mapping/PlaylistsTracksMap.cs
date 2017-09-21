using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    public class PlaylistsTracksMap : ClassMap<PlaylistsTracks>
    {
        public PlaylistsTracksMap()
        {
            Id(pt => pt.Id)
                .GeneratedBy.Identity();

            References(pt => pt.Track)
                .UniqueKey("U_Playlist_Track");

            References(pt => pt.Playlist)
                .UniqueKey("U_Playlist_Track");

            Map(pt=>pt.DateAdded)
                .Not.Nullable();
        }
    }
}