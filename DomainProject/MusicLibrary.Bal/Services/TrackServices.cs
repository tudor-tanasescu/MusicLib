using System;
using System.Collections.Generic;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Dal.Utils;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;
using MusicLibrary.Factories.Interfaces;

namespace MusicLibrary.Bal.Services
{
    public class TrackServices : ITrackServices
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITrackFactory _trackFactory;

        public TrackServices(ITrackRepository trackRepository, IUserRepository userRepository, ITrackFactory trackFactory)
        {
            _trackRepository = trackRepository;
            _userRepository = userRepository;
            _trackFactory = trackFactory;
        }

        public void Like(int trackId, int userId)
        {
            var user = _userRepository.GetById<User>(userId) ?? throw new Exception("No user for id " + nameof(userId) + " found");
            var track = _trackRepository.GetById<Track>(trackId) ?? throw new Exception("No track for id " + nameof(trackId) + " found");

            if (!_trackRepository.IsTrackLikedByUser(trackId, userId))
                _trackRepository.Like(track, user);
        }

        public void Unlike(int trackId, int userId)
        {
            var user = _userRepository.GetById<User>(userId) ?? throw new Exception("No user for id " + nameof(userId) + " found");
            var track = _trackRepository.GetById<Track>(trackId) ?? throw new Exception("No track for id " + nameof(trackId) + " found");

            if (_trackRepository.IsTrackLikedByUser(track.Id, user.Id))
            {
                _trackRepository.Unlike(track.Id, user.Id);
            }
        }

        public IList<TrackThumbnailDto> GetLikedTracks(int userId, PageData pageData)
        {
            return _trackRepository.GetLikedTracks(userId, pageData);
        }

        public int GetTracksLikedCount(int userId)
        {
            return _trackRepository.GetTracksLikedCount(userId);
        }

        public int GetTracksUploadedCount(int userId)
        {
            return _trackRepository.GetTracksUploadedCount(userId);
        }

        public string UploadTrack(UploadTrackDto trackDto)
        {
            var uploader = _userRepository.GetByName(trackDto.UploaderUserName);
            var track = _trackFactory.Produce(trackDto);

            track.Uploader = uploader;

            var existingUrlIds = _trackRepository.GetTrackTitles(uploader.Id);

            track.UrlId = UrlIdGenerator.Generate(track.Title, existingUrlIds);

            _trackRepository.Create(track);

            return track.UrlId;
        }

        public IList<TrackThumbnailDto> GetUploadedTracks(int userId, PageData pageData)
        {
            return _trackRepository.GetUploadedTracks(userId, pageData);
        }

        public Track FindById(int intId)
        {
            return _trackRepository.GetById<Track>(intId);
        }

        public bool IsTrackLikedByUser(int trackId, int userId)
        {
            return _trackRepository.IsTrackLikedByUser(trackId, userId);
        }

        public Track GetByUrlId(int userId, string urlId)
        {
            return _trackRepository.GetByUrlId(userId, urlId);
        }
    }
}