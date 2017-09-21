using System.Collections.Generic;
using System.Linq;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Dal.Utils;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace MusicLibrary.Dal.Implementations
{
    public class TrackRepository : Repository, ITrackRepository
    {
        public TrackRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<TrackThumbnailDto> GetUploadedTracks(int userId, PageData pageData)
        {
            User uploader = null;
            TrackThumbnailDto dto = null;
            return Session.QueryOver<Track>()
                .Where(t => t.Uploader.Id == userId)
                .OrderBy(t => t.DateUploaded).Desc
                .JoinAlias(t=>t.Uploader, ()=>uploader)
                .SelectList(l=>l
                    .Select(t=>t.Id).WithAlias(()=>dto.Id)
                    .Select(t => t.Title).WithAlias(() => dto.Title)
                    .Select(t => t.UrlId).WithAlias(() => dto.UrlId)
                    .Select(t=>t.Artwork).WithAlias(()=>dto.Artwork)
                    .Select(()=>uploader.Alias).WithAlias(()=>dto.UserAlias)
                    .Select(() => uploader.UserName).WithAlias(() => dto.UserName))
                .TransformUsing(Transformers.AliasToBean<TrackThumbnailDto>())
                .Paginate(pageData)
                .List<TrackThumbnailDto>();
        }

        public IList<TrackThumbnailDto> GetLikedTracks(int userId, PageData pageData)
        {
            Track track = null;
            User user = null;
            TrackThumbnailDto dto = null;
            return Session.QueryOver<LikedTrack>()
                .JoinAlias(lt => lt.Track, () => track)
                .JoinAlias(() => track.Uploader, () => user)
                .Where(lt => lt.User.Id == userId)
                .OrderBy(lt=>lt.DateLiked).Desc
                .SelectList(l=> l
                    .Select(() => track.Id).WithAlias(() => dto.Id)
                    .Select(() => track.Title).WithAlias(() => dto.Title)
                    .Select(() => track.UrlId).WithAlias(() => dto.UrlId)
                    .Select(() => track.Artwork).WithAlias(() => dto.Artwork)
                    .Select(() => user.UserName).WithAlias(() => dto.UserName)
                    .Select(() => user.Alias).WithAlias(() => dto.UserAlias))
                .TransformUsing(Transformers.AliasToBean<TrackThumbnailDto>())
                .Paginate(pageData)
                .List<TrackThumbnailDto>();
        }

        public bool IsTrackLikedByUser(int trackId, int userId)
        {
            return Session.QueryOver<LikedTrack>()
                .Where(lt => lt.Track.Id == trackId && lt.User.Id == userId)
                .List().Any();
        }

        public void Unlike(int trackId, int userId)
        {
            var likedTrack = Session.QueryOver<LikedTrack>()
                .Where(lt => lt.Track.Id == trackId && lt.User.Id == userId)
                .SingleOrDefault();
            Delete(likedTrack);
        }

        public void Like(Track track, User user)
        {
            var lt = new LikedTrack{Track = track, User = user};
            Create(lt);
        }

        public int GetTracksLikedCount(int userId)
        {
            return Session.QueryOver<Track>()
                .WithSubquery
                .WhereProperty(t => t.Id)
                .In(QueryOver.Of<LikedTrack>()
                    .Where(lt => lt.User.Id == userId)
                    .Select(lt => lt.Track.Id))
                .RowCount();
        }

        public int GetTracksUploadedCount(int userId)
        {
            return Session.QueryOver<Track>()
                .Where(t => t.Uploader.Id == userId)
                .RowCount();
        }

        public Track GetByUrlId(int userId, string urlId)
        {
            return Session.QueryOver<Track>()
                .Where(t => t.Uploader.Id == userId && t.UrlId == urlId)
                .SingleOrDefault<Track>();
        }

        public IList<string> GetTrackTitles(int uploaderId)
        {
            return Session.QueryOver<Track>()
                .Where(t => t.Uploader.Id == uploaderId)
                .OrderBy(t=>t.UrlId).Asc
                .Select(t => t.UrlId)
                .List<string>();
        }
    }
}