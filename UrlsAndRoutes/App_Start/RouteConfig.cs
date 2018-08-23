using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // 1 自己注册路由
            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute", myRoute);

            // 2 下面等效于1 
            //routes.MapRoute("MyRoute", "{controller}/{action}");

            //3 提供默认值
            //routes.MapRoute("MyRoute", "{controller}/{action}", new { action = "Index" });

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //混用静态URL片段和默认值  对Shop控制器上的动作会被转换成对Home控制器的请求
            //routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });

            //routes.MapRoute("", "X{controller}/{action}");

            //调用该方法导致路由系统检查应用程序中的控制器类，并寻找配置路由的属性，最重要的属性是Route
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute("NewRoute", "App/Do{action}", new { controller = "Home" });

            //注册新路由
            routes.Add(new Route("SayHello", new CustomRouteHandler()));
            routes.Add(new LegacyRoute("~/articles/Windows31Overview", "~/old/NET10ClassLibrary"));

            routes.MapRoute("MyRoute", "{controller}/{action}");
            routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            ////4 静态URL片段
            //routes.MapRoute("", "Public/{controller}/{action}", new { controller = "Home", action = "Index" }); 

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "DefaultId" });

            //全匹配路由
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
