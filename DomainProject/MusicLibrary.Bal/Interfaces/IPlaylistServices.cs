using System.Collections.Generic;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Bal.Interfaces
{
    public interface IPlaylistServices
    {
        void AddTrack(int trackId, int playlistId);
        void AddTrackToNewPlaylist(int trackId, string playlistName, int userId);
        void RemoveTrack(int trackId, int playlistId);
        void Rename(int playlistId, string name);
        void Delete(int playlistId);
        PlaylistWithTracksDto GetPlaylistWithTracks(int userId, string id);
        IList<AddToPlaylistDto> GetAddToPlaylists(int userId, int trackId);
        IList<PlaylistDto> GetCreatedPlaylists(int userId, PageData pageData);
        IList<PlaylistDto> GetSavedPlaylists(int userId, PageData pageData);
        int GetCreatedPlaylistsCount(int userId);
        int GetSavedPlaylistsCount(int userId);
    }
}