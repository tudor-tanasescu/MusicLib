using System.Collections.Generic;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Dal.Utils;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;
using NHibernate;
using NHibernate.Transform;

namespace MusicLibrary.Dal.Implementations
{
    public class PlaylistRepository : Repository, IPlaylistRepository
    {
        public PlaylistRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IFutureValue<string> GetArtwork(int playlistId)
        {
            Track track = null;
            return Session.QueryOver<PlaylistTrack>()
                .OrderBy(pt => pt.DateAdded).Desc
                .Where(pt => pt.Playlist.Id == playlistId)
                .JoinAlias(pt=>pt.Track, ()=>track)
                .SelectList(l=>l.Select(()=>track.Artwork))
                .Take(1)
                .FutureValue<string>();
        }

        public void AddTrack(int trackId, int playlistId)
        {
            var track = GetById<Track>(trackId);
            var playlist = GetById<Playlist>(playlistId);
            
            var playlistTrack = new PlaylistTrack {Playlist = playlist, Track = track};
            playlist.AddTrack(playlistTrack);
            
            Update(playlist);
        }

        public void RemoveTrack(int trackId, int playlistId)
        {
            var playlistTrack = Session.QueryOver<PlaylistTrack>()
                .Where(pt => pt.Playlist.Id == playlistId && pt.Track.Id == trackId)
                .SingleOrDefault();

            var playlist = GetById<Playlist>(playlistId);

            if (playlistTrack != null)
            {
                playlist.RemoveTrack(playlistTrack);

                Update(playlist);
            }
        }

        public IList<TrackListElementDto> GetTracks(int playlistId)
        {
            TrackListElementDto dto = null;
            Track track = null;
            User uploader = null;
            PlaylistTrack playlistTrack = null;
            return Session.QueryOver(() => playlistTrack)
                .Where(pt => pt.Playlist.Id == playlistId)
                .JoinAlias(pt => pt.Track, () => track)
                .JoinAlias(pt => pt.Track.Uploader, () => uploader)
                .OrderBy(() => playlistTrack.DateAdded).Desc
                .SelectList(l => l
                    .Select(() => track.Id).WithAlias(() => dto.Id)
                    .Select(() => track.Title).WithAlias(() => dto.Title)
                    .Select(() => track.UrlId).WithAlias(() => dto.UrlId)
                    .Select(() => track.Artwork).WithAlias(() => dto.Artwork)
                    .Select(() => track.DateUploaded).WithAlias(() => dto.DateUploaded)
                    .Select(() => track.Likes).WithAlias(() => dto.Likes)
                    .Select(() => uploader.Alias).WithAlias(() => dto.UploaderAlias)
                    .Select(() => uploader.UserName).WithAlias(() => dto.UploaderUserName))
                .TransformUsing(Transformers.AliasToBean<TrackListElementDto>())
                .List<TrackListElementDto>();
        }

        public IList<AddToPlaylistDto> GetAddToPlaylists(int userId)
        {
            AddToPlaylistDto dto = null;
            Playlist playlist = null;
            return Session.QueryOver(() => playlist)
                .Where(p => p.Creator.Id == userId)
                .OrderBy(p => p.DateCreated).Desc
                .SelectList(l => l
                    .Select(() => playlist.Name).WithAlias(() => dto.Name)
                    .Select(() => playlist.Id).WithAlias(() => dto.PlaylistId)
                    .Select(() => playlist.UrlId).WithAlias(() => dto.UrlId))
                .TransformUsing(Transformers.AliasToBean<AddToPlaylistDto>())
                .List<AddToPlaylistDto>();
        }

        public bool IsTrackInPlaylist(int trackId, int playlistId)
        {
            return Session.QueryOver<PlaylistTrack>()
                .Where(pt=>pt.Track.Id == trackId && pt.Playlist.Id == playlistId)
                .RowCount()>0;
        }

        public IList<PlaylistDto> GetCreatedPlaylists(int userId, PageData pageData)
        {
            PlaylistDto dto = null;
            Playlist playlist = null;
            User creator = null;
            return Session.QueryOver(() => playlist)
                .Where(p => p.Creator.Id == userId)
                .JoinAlias(() => playlist.Creator, () => creator)
                .OrderBy(p => p.DateCreated).Desc
                .SelectList(l => l
                    .Select(() => creator.UserName).WithAlias(() => dto.CreatorUserName)
                    .Select(() => creator.Alias).WithAlias(() => dto.CreatorAlias)
                    .Select(() => playlist.Name).WithAlias(() => dto.Name)
                    .Select(() => playlist.Id).WithAlias(() => dto.PlaylistId)
                    .Select(() => playlist.UrlId).WithAlias(() => dto.UrlId))
                .TransformUsing(Transformers.AliasToBean<PlaylistDto>())
                .Paginate(pageData)
                .List<PlaylistDto>();
        }

        public IList<PlaylistDto> GetSavedPlaylists(int userId, PageData pageData)
        {
            UserSavedPlaylist savedPlaylist = null;
            PlaylistDto dto = null;
            Playlist playlist = null;
            User creator = null;
            return Session.QueryOver(() => savedPlaylist)
                .Where(sp => sp.User.Id == userId)
                .JoinAlias(sp => sp.SavedPlaylist, () => playlist)
                .JoinAlias(() => playlist.Creator, () => creator)
                .OrderBy(p => p.DateSaved).Desc
                .SelectList(l => l
                    .Select(() => creator.UserName).WithAlias(() => dto.CreatorUserName)
                    .Select(() => creator.Alias).WithAlias(() => dto.CreatorAlias)
                    .Select(() => playlist.Name).WithAlias(() => dto.Name)
                    .Select(() => playlist.Id).WithAlias(() => dto.PlaylistId)
                    .Select(() => playlist.UrlId).WithAlias(() => dto.UrlId))
                .TransformUsing(Transformers.AliasToBean<PlaylistDto>())
                .Paginate(pageData)
                .List<PlaylistDto>();
        }

        public string GenerateUrlId(string playlistName, int userId)
        {
            string urlId;

            using (var tx = Session.BeginTransaction())
            {
                var urlIds = Session.QueryOver<Playlist>()
                    .Where(p => p.Creator.Id == userId)
                    .OrderBy(p=>p.Name).Asc
                    .Select(p => p.UrlId)
                    .List<string>();

                urlId = UrlIdGenerator.Generate(playlistName, urlIds);

                tx.Commit();
            }

            return urlId;
        }

        public Playlist GetByUrlId(int userId, string urlId)
        {
            return Session.QueryOver<Playlist>()
                .Where(p => p.UrlId == urlId && p.Creator.Id == userId)
                .SingleOrDefault<Playlist>();
        }

        public int GetCreatedPlaylistsCount(int userId)
        {
            return Session.QueryOver<Playlist>()
                .Where(p => p.Creator.Id == userId)
                .RowCount();
        }

        public int GetSavedPlaylistsCount(int userId)
        {
            return Session.QueryOver<UserSavedPlaylist>()
                .Where(sp => sp.User.Id == userId)
                .RowCount();
        }
    }
}