using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Web.Models.Identity;
using Owin;

namespace MusicLibrary.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var userStore = (IUserStore<User, int>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserStore<User, int>));
            
            app.CreatePerOwinContext(() => new UserManager(userStore));
            app.CreatePerOwinContext<SignInManager>(
                (options, context) => new SignInManager(context.GetUserManager<UserManager>(), context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider()
            });
        }
    }
}