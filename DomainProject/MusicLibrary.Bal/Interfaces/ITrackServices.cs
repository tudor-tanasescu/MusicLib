using System.Collections.Generic;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.Bal.Interfaces
{
    public interface ITrackServices
    {
        Track GetByUrlId(int userId, string urlId);
        string UploadTrack(UploadTrackDto trackDto);
        void Like(int trackId, int userId);
        void Unlike(int trackId, int userId);
        bool IsTrackLikedByUser(int trackId, int userId);
        IList<TrackThumbnailDto> GetLikedTracks(int userId, PageData pageData);
        IList<TrackThumbnailDto> GetUploadedTracks(int userId, PageData pageData);
        int GetTracksLikedCount(int userId);
        int GetTracksUploadedCount(int userId);
    }
}