using System;
using System.Collections.Generic;

namespace MusicLibrary.Domain.Entities
{
    public class Track : Entity
    {
        public virtual string UrlId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Artwork { get; set; }
        public virtual User Uploader { get; set; }
        public virtual int Likes { get; set; }
        public virtual IList<Genre> Genres { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public virtual DateTime DateUploaded { get; set; } = DateTime.UtcNow;
        public virtual int? YearReleased { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        public Track()
        {
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
}