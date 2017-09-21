using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    public class PlaylistMap : ClassMap<Playlist>
    {
        public PlaylistMap()
        {
            Id(pl => pl.Id)
                .GeneratedBy.Identity();

            Map(pl => pl.Name)
                .Not.Nullable()
                .Length(20);

            Map(pl => pl.UrlId)
                .Not.Nullable()
                .UniqueKey("U_UrlId_CreatorId");

            Map(pl => pl.PlaylistOrder)
                .Not.Nullable()
                .CustomType<GenericEnumMapper<PlaylistOrder>>();

            Map(pl => pl.DateCreated)
                .Not.Nullable();

            Map(pl => pl.Descrtiption)
                .Nullable()
                .Length(1000);

            References(pl => pl.Creator)
                .UniqueKey("U_UrlId_CreatorId")
                .Cascade.SaveUpdate();

            HasMany(pl => pl.PlaylistsTracks)
                .Cascade.AllDeleteOrphan();

            HasManyToMany(pl => pl.Genres);
        }
    }
}