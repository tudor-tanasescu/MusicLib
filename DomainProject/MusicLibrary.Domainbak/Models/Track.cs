using System;
using System.Collections.Generic;

namespace MusicLibrary.Domain.Models
{
    public class Track : Entity
    {
        public virtual string Author { get; set; }
        public virtual User Uploader { get; set; }
        public virtual string Title { get; }
        public virtual string Description { get; set; }
        public virtual int Likes { get; set; }
        public virtual IList<Genre> Genres { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public virtual DateTime DateAdded { get; set; }
        public virtual DateTime YearReleased { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        public Track()
        {
        }

        public Track(string author, string title, TimeSpan duration)
        {
            Author = author;
            Title = title;
            Duration = duration;
            Description = "";
            Likes = 0;
            Genres = new List<Genre>();
            DateAdded = DateTime.UtcNow;
            YearReleased = DateTime.UtcNow;
            Comments = new List<Comment>(2);
        }

        public virtual void AddComment(Comment comment)
        {
            comment.Track = this;
            Comments.Add(comment);
        }

        public virtual void RemoveComment(Comment comment)
        {
            comment.Track = null;
            Comments.Remove(comment);
        }
    }

    public class Genre : Entity
    {
        public virtual string Name { get; set; }

        public Genre(string name)
        {
            Name = name;
        }

        public Genre()
        {
        }
    }
}