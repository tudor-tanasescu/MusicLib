using System;

namespace MusicLibrary.Domain.Models
{
    public class LikedTrack : Entity
    {
        public virtual User User { get; set; }
        public virtual Track Track { get; set; }
        public virtual DateTime DateLiked { get; set; }

        public LikedTrack()
        {
        }

        public LikedTrack(User user, Track track)
        {
            User = user;
            Track = track;
            DateLiked = DateTime.UtcNow;
        }
    }
}