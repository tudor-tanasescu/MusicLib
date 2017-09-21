using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Domain.Mapping
{
    public class PlaylistMap : ClassMap<Playlist>
    {
        public PlaylistMap()
        {
            Id(pl => pl.Id).GeneratedBy.GuidComb();
            Map(pl => pl.Name);
            Map(pl => pl.PlaylistOrder).CustomType<GenericEnumMapper<PlaylistOrder>>();
            Map(pl => pl.DateCreated);
            Map(pl => pl.Descrtiption);
            References(pl => pl.Creator).Cascade.SaveUpdate();
            HasMany(pl => pl.PlaylistsTracks).Cascade.AllDeleteOrphan();
            HasManyToMany(pl => pl.Genres);
        }
    }
}