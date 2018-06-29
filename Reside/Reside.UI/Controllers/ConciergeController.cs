using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult MyParcels()
        {
            return View();
        }

        public ActionResult LeaveAMessage()
        {
            return View();
        }
    }
}