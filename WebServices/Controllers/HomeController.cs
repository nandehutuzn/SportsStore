using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        private ReservationRepository _repo = ReservationRepository.Current;

        // GET: Home
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public ActionResult Add(Reservation item)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(item);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Remove(int id)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(Reservation item)
        {
            if (ModelState.IsValid && _repo.Update(item))
            {
                return RedirectToAction("Index");
            }
            else
                return View("Index");
        }
    }
}