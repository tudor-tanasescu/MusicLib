using System;
using System.Collections.Generic;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;
using MusicLibrary.Factories.Implementations;

namespace MusicLibrary.Bal.Services
{
    public class PlaylistServices : IPlaylistServices
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IPlaylistFactory _playlistFactory;

        public PlaylistServices(IPlaylistRepository playlistRepository, IPlaylistFactory playlistFactory)
        {
            _playlistRepository = playlistRepository;
            _playlistFactory = playlistFactory;
        }

        public void AddTrack(int trackId, int playlistId)
        {
            if (trackId <= 0) throw new ArgumentOutOfRangeException(nameof(trackId));
            if (playlistId <= 0) throw new ArgumentOutOfRangeException(nameof(playlistId));
            _playlistRepository.AddTrack(trackId, playlistId);
        }

        public PlaylistWithTracksDto GetPlaylistWithTracks(int userId, string id)
        {
            var playlist = _playlistRepository.GetByUrlId(userId, id);
            if (playlist == null) return null;

            var playlistDto = new PlaylistWithTracksDto
            {
                Name = playlist.Name,
                PlaylistId = playlist.Id,
                CreatorId = playlist.Creator.UserName,
                CreatorAlias = playlist.Creator.Alias,
                Tracks = GetPlaylistTrackListElementDtos(playlist.Id)
            };
            return playlistDto;
        }

        public void AddTrackToNewPlaylist(int trackId, string playlistName, int userId)
        {
            var user = _playlistRepository.GetById<User>(userId);
            
            var playlist = _playlistFactory.Produce(playlistName, user);

            playlist.UrlId = _playlistRepository.GenerateUrlId(playlist.Name, userId);

            _playlistRepository.Create(playlist);

            AddTrack(trackId, playlist.Id);
        }

        public IList<AddToPlaylistDto> GetAddToPlaylists(int userId, int trackId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));
            if (trackId <= 0) throw new ArgumentOutOfRangeException(nameof(trackId));

            var track = _playlistRepository.GetById<Track>(trackId) ?? throw new ArgumentNullException(nameof(trackId));
            var user = _playlistRepository.GetById<User>(userId) ?? throw new ArgumentNullException(nameof(userId));

            var addToPlaylistDtos = _playlistRepository.GetAddToPlaylists(user.Id);
            foreach (var dto in addToPlaylistDtos)
            {
                dto.Artwork = _playlistRepository.GetArtwork(dto.PlaylistId).Value;
                dto.HasTrack = _playlistRepository.IsTrackInPlaylist(track.Id, dto.PlaylistId);
                dto.CreatorUserName = user.UserName;
            }

            return addToPlaylistDtos;
        }

        public void RemoveTrack(int trackId, int playlistId)
        {
            if (trackId <= 0) throw new ArgumentOutOfRangeException(nameof(trackId));
            if (playlistId <= 0) throw new ArgumentOutOfRangeException(nameof(playlistId));
            _playlistRepository.RemoveTrack(trackId, playlistId);
        }

        public IList<PlaylistDto> GetCreatedPlaylists(int userId, PageData pageData)
        {
            var playlistDtos = _playlistRepository.GetCreatedPlaylists(userId, pageData);
            foreach (var dto in playlistDtos)
            {
                dto.Artwork = _playlistRepository.GetArtwork(dto.PlaylistId).Value;
            }

            return playlistDtos;
        }

        public IList<PlaylistDto> GetSavedPlaylists(int userId, PageData pageData)
        {
            var playlistDtos = _playlistRepository.GetSavedPlaylists(userId, pageData);
            foreach (var dto in playlistDtos)
            {
                dto.Artwork = _playlistRepository.GetArtwork(dto.PlaylistId).Value;
            }

            return playlistDtos;
        }

        public void Rename(int playlistId, string name)
        {
            var playlist = _playlistRepository.GetById<Playlist>(playlistId);
            playlist.Name = name;
            _playlistRepository.Update(playlist);
        }

        public void Delete(int playlistId)
        {
            var playlist = _playlistRepository.GetById<Playlist>(playlistId);
            _playlistRepository.Delete(playlist);
        }

        public int GetCreatedPlaylistsCount(int userId)
        {
            return _playlistRepository.GetCreatedPlaylistsCount(userId);
        }

        public int GetSavedPlaylistsCount(int userId)
        {
            return _playlistRepository.GetSavedPlaylistsCount(userId);
        }

        private IList<TrackListElementDto> GetPlaylistTrackListElementDtos(int playlistId)
        {
            return _playlistRepository.GetTracks(playlistId);
        }
    }
}