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
        public virtual IList<Genre> Genres { get; set; } = new List<Genre>();
        public virtual IList<PlaylistTrack> PlaylistsTracks { get; set; } = new List<PlaylistTrack>();
        
        //public virtual TimeSpan Duration => Tracks.Aggregate(new TimeSpan(0), (current, track) => current + track.Duration);

        public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public Playlist()
        {
        }

        public virtual void AddTrack(PlaylistTrack playlistTrack)
        {
            PlaylistsTracks.Add(playlistTrack);
            playlistTrack.Playlist = this;
        }

        public virtual void RemoveTrack(PlaylistTrack playlistTrack)
        {
            PlaylistsTracks.Remove(playlistTrack);
            playlistTrack.Playlist = null;
        }
    }
}