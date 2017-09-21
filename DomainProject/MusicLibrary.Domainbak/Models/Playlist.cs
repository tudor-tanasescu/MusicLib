using System;
using System.Collections.Generic;

namespace MusicLibrary.Domain.Models
{
    public class Playlist : Entity // : Playlist
    {
        public virtual User Creator { get; set; }
        public virtual string Name { get; set; }
        public virtual PlaylistOrder PlaylistOrder { get; set; }
        public virtual IList<Genre> Genres { get; set; }
        public virtual IList<PlaylistsTracks> PlaylistsTracks { get; set; }


        //public virtual TimeSpan Duration => Tracks.Aggregate(new TimeSpan(0), (current, track) => current + track.Duration);

        public virtual DateTime DateCreated { get; set; }
        public virtual string Descrtiption { get; set; }

        public Playlist()
        {
        }

        public Playlist(string title)
        {
            Name = title;
            Descrtiption = "";
            PlaylistOrder = PlaylistOrder.DateAdded;
            DateCreated = DateTime.UtcNow;
        }

        public virtual void AddTrack(PlaylistsTracks playlistsTracks)
        {
            PlaylistsTracks.Add(playlistsTracks);
        }

        public virtual void RemoveTrack(PlaylistsTracks playlistsTracks)
        {
            PlaylistsTracks.Remove(playlistsTracks);
        }
    }


    public class PlaylistsTracks : Entity
    {
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
        public virtual DateTime DateAdded { get; set; }

        public PlaylistsTracks(Playlist playlist, Track track)
        {
            Playlist = playlist;
            Track = track;
            DateAdded = DateTime.UtcNow;
        }

        public PlaylistsTracks()
        {
        }
    }

    public class PlayistDTO
    {
        public Playlist Playlist { get; set; }
        public DateTime DateSaved { get; set; }

        public PlayistDTO()
        {
        }

    }




}