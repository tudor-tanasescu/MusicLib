using System;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Factories.Implementations
{
    public class PlaylistFactory : IPlaylistFactory
    {
        public Playlist Produce(string playlistName, User creator)
        {
            if (string.IsNullOrEmpty(playlistName))
            {
                throw new ArgumentException(nameof(playlistName));
            }
            if (creator == null) throw new ArgumentNullException(nameof(creator));

            return new Playlist
            {
                Creator = creator,
                Name = playlistName
            };
        }
    }
}
