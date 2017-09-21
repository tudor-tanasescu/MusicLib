using System;
using System.Web.Mvc;

namespace MusicLibrary.Web.Filters
{
    public class AuthorizeOnReservedUserNameAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null) throw new ArgumentNullException(nameof(filterContext));

            if (filterContext.RequestContext.RouteData.Values["username"] as string == "you")
                base.OnAuthorization(filterContext);
        }
    }
}