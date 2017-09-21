using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(c => c.Id)
                .GeneratedBy.Identity();

            Map(c => c.Content)
                .Not.Nullable()
                .Length(1000);

            Map(c => c.DateAdded)
                .Not.Nullable();

            References(c => c.User)
                .Cascade.SaveUpdate();

            References(c => c.Track)
                .Cascade.SaveUpdate();
        }
    }
}