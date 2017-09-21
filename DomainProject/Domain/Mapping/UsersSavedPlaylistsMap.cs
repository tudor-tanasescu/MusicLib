using FluentNHibernate.Mapping;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Mapping
{
    public class UsersSavedPlaylistsMap : ClassMap<UserSavedPlaylist>
    {
        public UsersSavedPlaylistsMap()
        {
            Id(spl => spl.Id)
                .GeneratedBy.Identity();

            References(spl => spl.SavedPlaylist)
                .Unique();

            References(uspl => uspl.User);

            Map(spl => spl.DateSaved)
                .Not.Nullable();
        }
    }
}