using System;

namespace MusicLibrary.Domain.Entities
{
    public class LikedTrack : Entity
    {
        public virtual User User { get; set; }
        public virtual Track Track { get; set; }
        public virtual DateTime DateLiked { get; set; } = DateTime.UtcNow;

        public LikedTrack()
        {
        }
    }
}