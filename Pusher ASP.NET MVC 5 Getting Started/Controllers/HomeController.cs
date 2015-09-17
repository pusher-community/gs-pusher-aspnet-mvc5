using PusherServer;
using System;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Pusher_ASP.NET_MVC_5_Getting_Started.Controllers
{
    public class HomeController : Controller
    {
        Pusher _pusher;

        private readonly string appId = WebConfigurationManager.AppSettings["pusherAppId"];
        private readonly string appKey = WebConfigurationManager.AppSettings["pusherAppKey"];
        private readonly string appSecret = WebConfigurationManager.AppSettings["pusherAppSecret"];

        public HomeController()
        {
            _pusher = new Pusher(appId, appKey, appSecret);
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("private-channel-example")]
        public ActionResult PrivateChannelExample()
        {
            ViewBag.appKey = appKey;
            return View("PrivateChannelAuth");
        }

        [HttpGet]
        public ActionResult Test()
        {
            return new HttpStatusCodeResult(200);
        }

        [HttpPost, Route("pusher/auth")]
        public ActionResult Auth()
        {
            var channelName = Request.Form["channel_name"];
            var socketId = Request.Form["socket_id"];

            IAuthenticationData auth = null;

            if(channelName.StartsWith("private-"))
            {
                auth = _pusher.Authenticate(channelName, socketId);
            }
            else if(channelName.StartsWith("private-"))
            {
                auth = _pusher.Authenticate(channelName, socketId, GetUserChannelData());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return new JsonResult()
            {
                Data = auth
            };
        }

        private PresenceChannelData GetUserChannelData()
        {
            throw new NotImplementedException();
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