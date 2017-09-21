using System;

namespace MusicLibrary.Domain.Models
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

        public Comment(string content)
        {
            Content = content;
            DateAdded = DateTime.UtcNow;
        }
    }
}