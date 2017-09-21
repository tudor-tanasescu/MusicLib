using System;
using System.Collections.Generic;

namespace MusicLibrary.Domain.Entities
{
    public class Playlist : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Descrtiption { get; set; }
        public virtual string UrlId { get; set; }
        public virtual User Creator { get; set; }
        public virtual PlaylistOrder PlaylistOrder { get; set; }
        public virtual IList<Genre> Genres { get; set; }
        public virtual IList<PlaylistsTracks> PlaylistsTracks { get; set; }
        
        //public virtual TimeSpan Duration => Tracks.Aggregate(new TimeSpan(0), (current, track) => current + track.Duration);

        public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public Playlist()
        {
        }
    }


    public class PlaylistsTracks : Entity
    {
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
        public virtual DateTime DateAdded { get; set; }= DateTime.UtcNow;
        
        public PlaylistsTracks()
        {
        }
    }
}