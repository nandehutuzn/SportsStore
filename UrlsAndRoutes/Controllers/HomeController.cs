using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("Test")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ActionResult CustomVariable(string id)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id??"<no value>";
            return View();
        }

        [Route("User/Add/{user}/{id}")]
        public string Create(string user, int id)
        {
            return $"User: {user}, ID: {id}";
        }
    }
}