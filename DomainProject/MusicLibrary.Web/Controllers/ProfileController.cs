using System.Web.Mvc;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Web.Filters;

namespace MusicLibrary.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserServices _userServices;

        public ProfileController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [AuthorizeOnReservedUserName]
        public ActionResult Index(string username)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "We could not find the user.";
                return View("Error");
            }

            return RedirectToAction("Tracks", "Profile");
        }
        
        [AuthorizeOnReservedUserName]
        public ActionResult Playlists(string username)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "We could not find the user.";
                return View("Error");
            }

            ViewBag.Category = nameof(Playlists);
            return View();
        }

        [AuthorizeOnReservedUserName]
        public ActionResult Saved(string username)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "We could not find the user.";
                return View("Error");
            }

            ViewBag.Category = nameof(Saved);
            return View();
        }

        [AuthorizeOnReservedUserName]
        public ActionResult Tracks(string username)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "We could not find the user.";
                return View("Error");
            }

            ViewBag.Category = nameof(Tracks);
            return View();
        }

        [AuthorizeOnReservedUserName]
        public ActionResult Likes(string username)
        {
            var user = _userServices.GetByUserName(username == "you" ? User.Identity.Name : username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "We could not find the user.";
                return View("Error");
            }

            ViewBag.Category = nameof(Likes);
            return View();
        }
    }
}