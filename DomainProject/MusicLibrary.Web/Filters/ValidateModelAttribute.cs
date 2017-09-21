using System.Net;
using System.Web.Mvc;

namespace MusicLibrary.Web.Filters
{
    public class ValidateAjaxRequestModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid == false)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}