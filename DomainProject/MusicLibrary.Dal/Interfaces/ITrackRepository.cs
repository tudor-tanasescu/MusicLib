using System.Collections.Generic;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Dal.Interfaces
{
    public interface ITrackRepository : IRepository
    {
        IList<TrackThumbnailDto> GetUploadedTracks(int userId, PageData pageData);
        IList<TrackThumbnailDto> GetLikedTracks(int userId, PageData pageData);
        bool IsTrackLikedByUser(int trackId, int userId);
        void Unlike(int trackId, int userId);
        void Like(Track track, User user);
        int GetTracksLikedCount(int userId);
        int GetTracksUploadedCount(int userId);
        Track GetByUrlId(int userId, string urlId);
        IList<string> GetTrackTitles(int uploaderId);
    }
}