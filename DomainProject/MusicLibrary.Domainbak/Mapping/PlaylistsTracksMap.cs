using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Domain.Mapping
{
    public class PlaylistsTracksMap : ClassMap<PlaylistsTracks>
    {
        public PlaylistsTracksMap()
        {
            Id(pt => pt.Id);
            References(pt => pt.Track);
            References(pt => pt.Playlist);
            Map(pt=>pt.DateAdded);
        }
    }
}