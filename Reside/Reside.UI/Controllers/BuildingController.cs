using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reside.UI.Controllers
{
    public class BuildingController : Controller
    {
        // GET: Building
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConciergeServices()
        {
            return View();
        }

        public ActionResult Forum()
        {
            return View();
        }
    }
}