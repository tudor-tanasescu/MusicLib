using System;

namespace MusicLibrary.Domain.Entities
{
    public class PlaylistTrack : Entity
    {
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
        public virtual DateTime DateAdded { get; set; }= DateTime.UtcNow;
        
        public PlaylistTrack()
        {
        }
    }
}