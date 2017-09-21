using System;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Domain.Models;
using MusicLibrary.Web.Filters;
using MusicLibrary.Web.Models;

namespace MusicLibrary.Web.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistServices _playlistServices;
        private readonly IUserServices _userServices;
        private int CurrentUserId => Convert.ToInt32(User.Identity.GetUserId());

        public PlaylistController(IPlaylistServices playlistServices, IUserServices userServices)
        {
            _playlistServices = playlistServices;
            _userServices = userServices;
        }
        
        [HttpGet]
        [AuthorizeOnReservedUserName]
        public ActionResult GetCreatedPlaylistsThumbnails(string username, int page, int pageSize)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var playlists = _playlistServices.GetCreatedPlaylists(user.Id, new PageData(page, pageSize));

            return PartialView("PlaylistThumbnails", playlists);
        }

        [HttpGet]
        [AuthorizeOnReservedUserName]
        public ActionResult GetCreatedPlaylistsCount(string username)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var playlistCount = _playlistServices.GetCreatedPlaylistsCount(user.Id);

            return Content(playlistCount.ToString());
        }

        [HttpGet]
        [AuthorizeOnReservedUserName]
        public ActionResult GetSavedPlaylistThumbnails(string username, int page, int pageSize)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var playlists = _playlistServices.GetSavedPlaylists(user.Id, new PageData(page, pageSize));

            return PartialView("PlaylistThumbnails", playlists);
        }

        [HttpGet]
        [AuthorizeOnReservedUserName]
        public ActionResult GetSavedPlaylistsCount(string username)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var playlistCount = _playlistServices.GetSavedPlaylistsCount(user.Id);

            return Content(playlistCount.ToString());
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddToPlaylists(int trackId)
        {
            var playlists = _playlistServices.GetAddToPlaylists(CurrentUserId, trackId);

            return PartialView(playlists);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddToNewPlaylist(AddTrackToNewPlaylistViewModel model)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _playlistServices.AddTrackToNewPlaylist(model.TrackId, model.NewPlaylistName, CurrentUserId);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddToExistingPlaylist(AddTrackToExistingPlaylistViewModel model)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _playlistServices.AddTrack(model.TrackId, model.ExistingPlaylistId);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveFromPlaylist(AddTrackToExistingPlaylistViewModel model)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _playlistServices.RemoveTrack(model.TrackId, model.ExistingPlaylistId);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RenamePlaylist(RenamePlaylistViewModel viewModel)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _playlistServices.Rename(viewModel.PlaylistId, viewModel.Name);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeletePlaylist(DeletePlaylistViewModel model)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _playlistServices.Delete(model.PlaylistId);

            return RedirectToAction("Playlists", "Profile");
        }
    }
}