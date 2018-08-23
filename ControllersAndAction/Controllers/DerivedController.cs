using ControllersAndAction.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersAndAction.Controllers
{
    public class DerivedController : Controller
    {
        // GET: Derived
        public ActionResult Index()
        {
            var rq = Request;
            var data = RouteData;
            var context = HttpContext;
            var user = User;
            var temp = TempData;
            ViewBag.Message = "Hello from the DerivedController Index Method";
            return View("MyView");
        }

        public ActionResult ProduceOutput()
        {
            if (Server.MachineName == "DESKTOP-RPMIV02")
            {
                return new CustomRedirectResult { Url = "/Basic/Index" };
            }
            else {
                Response.Write("Controller: Derived, Action: ProduceOutput");
                return null;
            }
        }
    }
}