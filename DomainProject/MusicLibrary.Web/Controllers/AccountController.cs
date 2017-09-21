using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Web.Models.Identity;

namespace MusicLibrary.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = HttpContext.GetOwinContext().Get<SignInManager>()
                .PasswordSignIn(model.UserName, model.Password, false, false);
            if (result == SignInStatus.Success)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userServices.Create(new UserRegisterDto
            {
                Alias = model.Alias,
                UserName = model.UserName,
                Email = model.Email,
                RecievesEmailNotifications = model.RecievesEmailNotifications
            });

            var result = HttpContext.GetOwinContext().GetUserManager<UserManager>().Create(user, model.Password);
            if (result.Succeeded)
            {
                HttpContext.GetOwinContext().Get<SignInManager>().SignIn(user, false, false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Get<SignInManager>().SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}