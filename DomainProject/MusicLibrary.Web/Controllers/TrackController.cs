using System;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Models;
using MusicLibrary.Web.Filters;
using MusicLibrary.Web.Models;
using MusicLibrary.Web.Data;

namespace MusicLibrary.Web.Controllers
{
    public class TrackController : BaseController
    {
        private readonly ITrackServices _trackServices;
        private readonly IUserServices _userServices;

        private int CurrentUserId => Convert.ToInt32(User.Identity.GetUserId());

        public TrackController(ITrackServices trackServices, IUserServices userServices)
        {
            _trackServices = trackServices;
            _userServices = userServices;
        }

        [HttpGet]
        [AuthorizeOnReservedUserName]
        public ActionResult GetLikedTracksThumbnails(string username, int page, int pageSize)
        {
            var user = _userServices.GetByUserName(username == Reserved.UserName.You ? User.Identity.Name : username);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tracks = _trackServices.GetLikedTracks(user.Id, new PageData(page, pageSize));

            return PartialView("TrackThumbnails", tracks);
        }

        [HttpGet]
        [AuthorizeOnReservedUserName]
        public ActionResult GetLikedTracksCount(string username)
        {
            var user = _userServices.GetByUserName(username == Reserved.UserName.You ? User.Identity.Name : username);
            var count = _trackServices.GetTracksLikedCount(user.Id);

            return Content(count.ToString());
        }
        
        [HttpGet]
        [AuthorizeOnReservedUserName]
        public ActionResult GetUploadedTracksThumbnails(string username, int page, int pageSize)
        {
            var user = _userServices.GetByUserName(username == Reserved.UserName.You ? User.Identity.Name : username);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tracks = _trackServices.GetUploadedTracks(user.Id, new PageData(page, pageSize));

            return PartialView("TrackThumbnails", tracks);
        }

        [HttpGet]
        [AuthorizeOnReservedUserName]
        public ActionResult GetUploadedTracksCount(string username)
        {
            var user = _userServices.GetByUserName(username == Reserved.UserName.You ? User.Identity.Name : username);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tracksCount = _trackServices.GetTracksUploadedCount(user.Id);

            return Content(tracksCount.ToString());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Upload()
        {
            return View(new UploadTrackViewModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upload(UploadTrackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var trackDto = new UploadTrackDto
            {
                Title = model.Title,
                Description = model.Description,
                Artwork = model.Artwork,
                YearReleased = model.YearReleased,
                UploaderUserName = User.Identity.Name
            };
            
            var trackId = _trackServices.UploadTrack(trackDto);

            return RedirectToAction("Track", "User", new {username = User.Identity.Name, id = trackId});
        }

        [HttpPost]
        [Authorize]
        public ActionResult Like(int trackId)
        {
            _trackServices.Like(trackId, CurrentUserId);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Unlike(int trackId)
        {
            _trackServices.Unlike(trackId, CurrentUserId);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}