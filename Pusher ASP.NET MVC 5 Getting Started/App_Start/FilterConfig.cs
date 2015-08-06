using System.Web.Mvc;

namespace Pusher_ASP.NET_MVC_5_Getting_Started
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
