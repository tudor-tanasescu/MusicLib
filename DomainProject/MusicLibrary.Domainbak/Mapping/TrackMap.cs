using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Domain.Mapping
{
    public class TrackMap : ClassMap<Track>
    {
        public TrackMap()
        {
            Id(track => track.Id).GeneratedBy.GuidComb();
            Map(track => track.Title).Not.Nullable();
            Map(track => track.Author).Not.Nullable();
            Map(track => track.Description).Nullable();
            Map(track => track.DateAdded).Not.Nullable();
            Map(track => track.Duration).Not.Nullable();
            Map(track => track.Likes).Not.Nullable();
            Map(track => track.YearReleased).Not.Nullable();
            References(t => t.Uploader).Cascade.SaveUpdate();
            HasMany(track => track.Comments)
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasManyToMany(t => t.Genres)
                //.ParentKeyColumns.Add("TrackId")
                //.ChildKeyColumns.Add("GenreId").Table("TracksGenres")
                ;
        }
    }

    public class GenreMap : ClassMap<Genre>
    {
        public GenreMap()
        {
            Id(g => g.Id).GeneratedBy.GuidComb();
            Map(g => g.Name);
        }
    }
}