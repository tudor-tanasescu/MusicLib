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
        private readonly ITrackRepository _trackRepo;
        private readonly IUserRepository _userRepo;
        private readonly ITrackFactory _trackFactory;

        public TrackServices(ITrackRepository trackRepo, IUserRepository userRepo, ITrackFactory trackFactory)
        {
            _trackRepo = trackRepo;
            _userRepo = userRepo;
            _trackFactory = trackFactory;
        }

        public void Like(int trackId, int userId)
        {
            var user = _userRepo.GetById<User>(userId) ?? throw new Exception("No user for id " + nameof(userId) + " found");
            var track = _trackRepo.GetById<Track>(trackId) ?? throw new Exception("No track for id " + nameof(trackId) + " found");

            if (!_trackRepo.IsTrackLikedByUser(trackId, userId))
                _trackRepo.Like(track, user);
        }

        public void Unlike(int trackId, int userId)
        {
            var user = _userRepo.GetById<User>(userId) ?? throw new Exception("No user for id " + nameof(userId) + " found");
            var track = _trackRepo.GetById<Track>(trackId) ?? throw new Exception("No track for id " + nameof(trackId) + " found");

            if (_trackRepo.IsTrackLikedByUser(track.Id, user.Id))
            {
                _trackRepo.Unlike(track.Id, user.Id);
            }
        }

        public IList<TrackThumbnailDto> GetLikedTracks(int userId, PageData pageData)
        {
            return _trackRepo.GetLikedTracks(userId, pageData);
        }

        public int GetTracksLikedCount(int userId)
        {
            return _trackRepo.GetTracksLikedCount(userId);
        }

        public int GetTracksUploadedCount(int userId)
        {
            return _trackRepo.GetTracksUploadedCount(userId);
        }

        public string UploadTrack(UploadTrackDto trackDto)
        {
            var uploader = _userRepo.GetByName(trackDto.UploaderUserName);
            var track = _trackFactory.Produce(trackDto);

            track.Uploader = uploader;

            var existingUrlIds = _trackRepo.GetTrackTitles(uploader.Id);

            track.UrlId = UrlIdGenerator.Generate(track.Title, existingUrlIds);

            _trackRepo.Create(track);

            return track.UrlId;
        }

        public IList<TrackThumbnailDto> GetUploadedTracks(int userId, PageData pageData)
        {
            return _trackRepo.GetUploadedTracks(userId, pageData);
        }

        public Track FindById(int intId)
        {
            return _trackRepo.GetById<Track>(intId);
        }

        public bool IsTrackLikedByUser(int trackId, int userId)
        {
            return _trackRepo.IsTrackLikedByUser(trackId, userId);
        }

        public Track GetByUrlId(int userId, string urlId)
        {
            return _trackRepo.GetByUrlId(userId, urlId);
        }
    }
}