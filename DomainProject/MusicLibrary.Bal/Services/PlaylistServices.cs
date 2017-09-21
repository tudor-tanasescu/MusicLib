using System;
using System.Collections.Generic;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Bal.Services
{
    public class PlaylistServices : IPlaylistServices
    {
        private readonly IPlaylistRepository _playlistRepo;
        private readonly IUserRepository _userRepo;

        public PlaylistServices(IPlaylistRepository playlistRepo, IUserRepository userRepo)
        {
            _playlistRepo = playlistRepo;
            _userRepo = userRepo;
        }

        //public IList<ConcisePlaylistDTO> GetConcisePlaylistDtos(int userId )
        //{
        //    var playlists = _playlistRepo.GetPlaylistsCreatedByUser(userId);
        //    IList<ConcisePlaylistDTO> concisePlaylists = new List<ConcisePlaylistDTO>(playlists.Count);
        //    foreach (var playlist in playlists)
        //    {
        //        var dto = new ConcisePlaylistDTO
        //        {
        //            Name = playlist.Name,
        //            Artwork = _playlistRepo.GetArtwork(playlist.Id).Value,
        //            trackCount = playlist.PlaylistsTracks.Count
        //        };
        //        concisePlaylists.Add(dto);
        //    }
        //    return concisePlaylists;
        //}

        public void AddTrack(int trackId, int playlistId)
        {
            if (trackId <= 0) throw new ArgumentOutOfRangeException(nameof(trackId));
            if (playlistId <= 0) throw new ArgumentOutOfRangeException(nameof(playlistId));
            _playlistRepo.AddTrackTo(trackId, playlistId);
        }

        public PlaylistWithTracksDto GetPlaylistWithTracks(int userId, string id)
        {
            var playlist = _playlistRepo.GetByUrlId(userId, id);
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
            if (playlistName == null) throw new ArgumentNullException(nameof(playlistName));

            var user = _playlistRepo.GetById<User>(userId) ?? throw new ArgumentNullException(nameof(userId));

            var playlist = new Playlist{Name = playlistName, Creator = user};


            playlist.UrlId = _playlistRepo.GenerateUrlId(playlist.Name, userId);


            _playlistRepo.Create(playlist);

            AddTrack(trackId, playlist.Id);
        }

        public IList<AddToPlaylistDto> GetAddToPlaylists(int userId, int trackId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));
            if (trackId <= 0) throw new ArgumentOutOfRangeException(nameof(trackId));

            var track = _playlistRepo.GetById<Track>(trackId) ?? throw new ArgumentNullException(nameof(trackId));
            var user = _playlistRepo.GetById<User>(userId) ?? throw new ArgumentNullException(nameof(userId));

            var addToPlaylistDtos = _playlistRepo.GetAddToPlaylists(user.Id);
            foreach (var dto in addToPlaylistDtos)
            {
                dto.Artwork = _playlistRepo.GetArtwork(dto.PlaylistId).Value;
                dto.HasTrack = _playlistRepo.IsTrackInPlaylist(track.Id, dto.PlaylistId);
                dto.CreatorUserName = user.UserName;
            }

            return addToPlaylistDtos;
        }

        public void RemoveTrack(int trackId, int playlistId)
        {
            if (trackId <= 0) throw new ArgumentOutOfRangeException(nameof(trackId));
            if (playlistId <= 0) throw new ArgumentOutOfRangeException(nameof(playlistId));
            _playlistRepo.RemoveTrack(trackId, playlistId);
        }

        public IList<PlaylistDto> GetCreatedPlaylists(int userId, PageData pageData)
        {
            var playlistDtos = _playlistRepo.GetCreatedPlaylists(userId, pageData);
            foreach (var dto in playlistDtos)
            {
                dto.Artwork = _playlistRepo.GetArtwork(dto.PlaylistId).Value;
            }

            return playlistDtos;
        }

        public IList<PlaylistDto> GetSavedPlaylists(int userId, PageData pageData)
        {
            var playlistDtos = _playlistRepo.GetSavedPlaylists(userId, pageData);
            foreach (var dto in playlistDtos)
            {
                dto.Artwork = _playlistRepo.GetArtwork(dto.PlaylistId).Value;
            }

            return playlistDtos;
        }

        public void Rename(int playlistId, string name)
        {
            var playlist = _playlistRepo.GetById<Playlist>(playlistId);
            playlist.Name = name;
            _playlistRepo.Update(playlist);
        }

        public void Delete(int playlistId)
        {
            var playlist = _playlistRepo.GetById<Playlist>(playlistId);
            _playlistRepo.Delete(playlist);
        }

        public int GetCreatedPlaylistsCount(int userId)
        {
            return _playlistRepo.GetCreatedPlaylistsCount(userId);
        }

        public int GetSavedPlaylistsCount(int userId)
        {
            return _playlistRepo.GetSavedPlaylistsCount(userId);
        }

        private IList<TrackListElementDto> GetPlaylistTrackListElementDtos(int playlistId)
        {
            return _playlistRepo.GetTracks(playlistId);
        }
    }
}