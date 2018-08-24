using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerExtensibility.Models;
using System.Threading.Tasks;

namespace ControllerExtensibility.Controllers
{
    public class RemoteDataController : Controller
    {
        // GET: RemoteData
        public async Task<ActionResult> Data()
        {
            string data = await Task<string>.Factory.StartNew(() => new RemoteService().GetRemoteData());
            return View((object)data);
        }
    }
}