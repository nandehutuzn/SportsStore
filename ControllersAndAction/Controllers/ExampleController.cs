using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndAction.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            if (TempData.ContainsKey("Message"))
            {
                string msg = (string)TempData["Message"];
            }
            return View();
        }

        public RedirectToRouteResult Redirect()
        {
            TempData["Message"] = "123456";
           
            return RedirectToRoute(new { controller = "Example", action = "Index", ID = "MyID" });
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(404, "URL cannot be serviced");
        }
    }
}