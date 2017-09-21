using System;

namespace MusicLibrary.Domain.Models
{
    public class Follower : Entity
    {
        public virtual User FollowingUser { get; set; }
        public virtual User FollowedUser { get; set; }
        public virtual DateTime DateFollowed { get; set; } = DateTime.UtcNow;

        public Follower()
        {
        }
    }
}