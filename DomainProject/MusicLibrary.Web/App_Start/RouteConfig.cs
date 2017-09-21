using System.Web.Mvc;
using System.Web.Routing;

namespace MusicLibrary.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.AppendTrailingSlash = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                constraints: new {controller = @"(Home|Account|Track|Playlist)"}
            );

            routes.MapRoute(
                name: "Profiles",
                url: "{username}/{action}/",
                defaults: new {controller = "Profile", action = "Index", username = "you"},
                constraints: new {
                    action = @"(Playlists|Tracks|Likes|Saved|Settings|Index)",
                    controller = "Profile"
                }
            );

            routes.MapRoute(
                name: "ProfilePages",
                url: "{username}/",
                defaults: new {controller = "Profile", action = "Index", username = "you"},
                constraints: new {action = @"(Index)", controller = "Profile"}
            );

            routes.MapRoute(
                name: "Users",
                url: "{username}/{action}/{id}",
                defaults: new {controller = "User", id = UrlParameter.Optional},
                constraints: new {controller = "User"}
            );
        }
    }
}
