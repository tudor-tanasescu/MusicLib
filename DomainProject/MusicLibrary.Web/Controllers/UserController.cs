﻿using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicLibrary.Bal.Interfaces;

namespace MusicLibrary.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IPlaylistServices _playlistServices;
        private readonly ITrackServices _trackServices;
        private readonly IUserServices _userServices;

        private int CurrentUserId => Convert.ToInt32(User.Identity.GetUserId());

        public UserController(IUserServices userServices, ITrackServices trackServices,
            IPlaylistServices playlistServices)
        {
            _userServices = userServices;
            _trackServices = trackServices;
            _playlistServices = playlistServices;
        }

        // GET: User
        public ActionResult Index(string username)
        {
            var user = _userServices.GetByUserName(username);
            return View(user);
        }

        public ActionResult Playlist(string username, string id)
        {
            var user = _userServices.GetByUserName(username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "We could not find the user.";
                return View("Error");
            }

            var playlist = _playlistServices.GetPlaylistWithTracks(user.Id, id);
            if (playlist == null)
            {
                ViewBag.ErrorMessage = "We could not find the playlist.";
                return View("Error");
            }

            return View(playlist);
        }

        public ActionResult Track(string username, string id)
        {
            var user = _userServices.GetByUserName(username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "We could not find the user.";
                return View("Error");
            }

            var track = _trackServices.GetByUrlId(user.Id, id);
            if (track == null)
            {
                ViewBag.ErrorMessage = "We could not find the track.";
                return View("Error");
            }

            if (Request.IsAuthenticated)
            {
                ViewBag.IsLiked = _trackServices.IsTrackLikedByUser(track.Id, CurrentUserId);
            }

            return View(track);
        }
    }
}