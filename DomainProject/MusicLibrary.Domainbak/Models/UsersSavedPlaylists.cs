using System;

namespace MusicLibrary.Domain.Models
{
    public class UserSavedPlaylists : Entity
    {
        public virtual Playlist SavedPlaylist { get; set; }
        public virtual DateTime DateSaved { get; set; }
        public virtual User User { get; set; }

        public UserSavedPlaylists()
        {
        }

        public UserSavedPlaylists(User user, Playlist savedPlaylist)
        {
            User = user;
            SavedPlaylist = savedPlaylist;
            DateSaved = DateTime.UtcNow;
        }
    }
}