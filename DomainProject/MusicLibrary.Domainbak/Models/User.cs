using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.Domain.Models
{
    public class User : Entity
    {
        public virtual string Email { get; set; }
        public virtual IList<Follower> Followers { get; set; }
        public virtual IList<Follower> Following { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Alias { get; set; }
        public virtual IList<Playlist> UserPlaylists { get; set; }
        public virtual IList<UserSavedPlaylists> SavedPlaylists { get; set; }
        public virtual IList<LikedTrack> LikedTracks { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual DateTime DateJoined { get; set; }
        public virtual bool RecievesEmailNotifications { get; set; }

        public User()
        {
        }

        public User(string userName, string alias, string email, string password)
        {
            Email = email;
            SavedPlaylists = new List<UserSavedPlaylists>();
            UserName = userName;
            Alias = alias;
            Followers = new List<Follower>();
            Following = new List<Follower>();
            UserPlaylists = new List<Playlist>();
            PasswordHash = Enumerable.Repeat(byte.MinValue, 64).ToArray();
            LikedTracks = new List<LikedTrack>();
            DateJoined = DateTime.UtcNow;
            RecievesEmailNotifications = true;
        }

        public override string ToString()
        {
            return $"{UserName} {Alias}";
        }
    }


    public class UserEmailDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
    }
}