using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zhangjp.WxFri.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "shownews",
               url: "{controller}/{action}/{newsid}",
               defaults: new { controller = "wview", action = "shownews", id = UrlParameter.Optional }
           );
 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "WView", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}