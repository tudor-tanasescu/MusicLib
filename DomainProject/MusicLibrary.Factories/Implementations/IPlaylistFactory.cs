using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Factories.Implementations
{
    public interface IPlaylistFactory
    {
        Playlist Produce(string playlistName, User creator);
    }
}