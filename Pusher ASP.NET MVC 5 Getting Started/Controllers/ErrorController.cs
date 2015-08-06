using System.Web.Mvc;

namespace Pusher_ASP.NET_MVC_5_Getting_Started.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http404()
        {
            Response.StatusCode = 404;

            return View();
        }
    }
}