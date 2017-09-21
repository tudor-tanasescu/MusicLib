using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    public class TrackMap : ClassMap<Track>
    {
        public TrackMap()
        {
            Id(track => track.Id)
                .GeneratedBy.Identity();

            Map(track => track.Title)
                .Not.Nullable()
                .Length(255);

            Map(track => track.UrlId)
                .Not.Nullable()
                .UniqueKey("U_UrlId_UploaderId");

            Map(track => track.Description)
                .Nullable()
                .Length(1000);

            Map(track => track.DateUploaded)
                .Not.Nullable();

            Map(track => track.Duration)
                .Not.Nullable();

            Map(track => track.Likes)
                .Not.Nullable();

            Map(track => track.YearReleased)
                .Nullable();

            Map(track => track.Artwork)
                .Nullable();

            References(t => t.Uploader)
                .Not.Nullable()
                .UniqueKey("U_UrlId_UploaderId")
                .Cascade.SaveUpdate();

            HasMany(track => track.Comments)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasManyToMany(t => t.Genres);
        }
    }

    public class GenreMap : ClassMap<Genre>
    {
        public GenreMap()
        {
            Id(g => g.Id)
                .GeneratedBy.Identity();

            Map(g => g.Name)
                .Not.Nullable()
                .Length(30);
        }
    }
}