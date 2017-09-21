using System.Collections.Generic;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;
using NHibernate;

namespace MusicLibrary.Dal.Interfaces
{
    public interface IPlaylistRepository: IRepository
    {
        IFutureValue<string> GetArtwork(int playlistId);
        bool IsTrackInPlaylist(int trackId, int playlistId);
        void AddTrackTo(int trackId, int playlistId);
        void RemoveTrack(int trackId, int playlistId);
        IList<TrackListElementDto> GetTracks(int playlistId);
        IList<AddToPlaylistDto> GetAddToPlaylists(int userId);
        IList<PlaylistDto> GetCreatedPlaylists(int userId, PageData pageData);
        IList<PlaylistDto> GetSavedPlaylists(int userId, PageData pageData);
        string GenerateUrlId(string playlistName, int userId);
        Playlist GetByUrlId(int userId, string urlId);
        int GetCreatedPlaylistsCount(int userId);
        int GetSavedPlaylistsCount(int userId);
    }
}