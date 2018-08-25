using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] _personData = {
            new Person{ FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person{ FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person{ FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person{ FirstName = "Anne", LastName = "Jones", Role = Role.Guest},
        };

        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            IEnumerable<Person> data = _personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = _personData.Where(m => m.Role == selected);
            }
            System.Threading.Thread.Sleep(5000);
            return PartialView(data);
        }

        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }

        private IEnumerable<Person> GetData(string selectedRole)
        {
            IEnumerable<Person> data = _personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = _personData.Where(m => m.Role == selected);
            }

            return data;
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            var data = GetData(selectedRole).Select(p => new
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Role = Enum.GetName(typeof(Role), p.Role),
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}