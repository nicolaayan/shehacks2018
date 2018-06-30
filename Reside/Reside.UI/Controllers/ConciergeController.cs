using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reside.UI.Models;

namespace Reside.UI.Controllers
{
    public class ConciergeController : Controller
    {
        // GET: Concierge
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Announcements()
        {
            return View();
        }

        public ActionResult Parcels()
        {
            var model = new Page
            {
                TopNav = HomeController.GetTopNav(),
                TopSecondaryNav = HomeController.GetTopSecondaryNav("Concierge", "My parcels")
            };

            return View(model);
        }

        public ActionResult LeaveAMessage()
        {
            return View();
        }
    }
}