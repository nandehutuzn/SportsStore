using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientFeatures.Models;

namespace ClientFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult MakeBooking()
        {
            return View(new Appointment() { ClinetName = "Admin", TermsAccepted = true });
        }

        [HttpPost]
        public JsonResult MakeBooking(Appointment appt)
        {
            return Json(appt, JsonRequestBehavior.AllowGet);
        }
    }
}