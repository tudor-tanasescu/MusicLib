using System;

namespace MusicLibrary.Domain.Entities
{
    public class Comment : Entity
    {
        public virtual string Content { get; set; }
        public virtual DateTime DateAdded { get; set; }
        public virtual User User { get; set; }
        public virtual Track Track { get; set; }

        public Comment()
        {
        }
    }
}