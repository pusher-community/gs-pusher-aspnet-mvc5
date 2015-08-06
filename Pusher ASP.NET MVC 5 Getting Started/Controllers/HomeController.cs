using PusherServer;
using System;
using System.IO;
using System.Web.Mvc;

namespace Pusher_ASP.NET_MVC_5_Getting_Started.Controllers
{
    public class HomeController : Controller
    {
        private const string APP_ID = "YOUR_APP_ID";
        private const string APP_KEY = "YOUR_APP_KEY";
        private const string APP_SECRET = "YOUR_APP_SECRET";

        Pusher _pusher;

        public HomeController()
        {
            _pusher = new Pusher(APP_ID, APP_KEY, APP_SECRET);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public ActionResult WebHook()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string body = new StreamReader(req).ReadToEnd();

            string sentSignature = Request.Headers.Get("X-PUSHER-SIGNATURE");

            var webHookResult = _pusher.ProcessWebHook(sentSignature, body);
            if(webHookResult.IsValid)
            {
                Console.WriteLine("The WebHook has been validated");

                // Add business logic for your app
            }

            return new HttpStatusCodeResult(200);
        }
    }
}