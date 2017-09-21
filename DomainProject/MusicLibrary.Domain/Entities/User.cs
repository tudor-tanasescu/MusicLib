using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace MusicLibrary.Domain.Entities
{
    public class User : Entity, IUser<int>
    {
        public virtual string Email { get; set; }
        public virtual IList<Follower> Followers { get; set; }
        public virtual IList<Follower> Following { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Alias { get; set; }
        public virtual IList<Playlist> UserPlaylists { get; set; }
        public virtual IList<UserSavedPlaylist> SavedPlaylists { get; set; }
        public virtual IList<LikedTrack> LikedTracks { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual DateTime DateJoined { get; set; } = DateTime.UtcNow;
        public virtual bool RecievesEmailNotifications { get; set; }

        public User()
        {
        }
    }
}