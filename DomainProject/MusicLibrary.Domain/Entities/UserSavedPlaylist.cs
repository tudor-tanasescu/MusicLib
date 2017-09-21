using System;

namespace MusicLibrary.Domain.Entities
{
    public class UserSavedPlaylist : Entity
    {
        public virtual Playlist SavedPlaylist { get; set; }
        public virtual DateTime DateSaved { get; set; }
        public virtual User User { get; set; }

        public UserSavedPlaylist()
        {
        }
    }
}