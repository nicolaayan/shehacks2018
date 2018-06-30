using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reside.UI.Models;

namespace Reside.UI.Controllers
{
    public class BuildingController : Controller
    {
        // GET: Building
        public ActionResult Index()
        {
            var model = new TopNavigation()
            {
                CurrentPageText = "Building 1701",
                MenuLinks = new List<TopNavigation.MenuItem>
                {
                    new TopNavigation.MenuItem
                    {
                        Text = "My community",
                        Link = "~/community",
                        Icon = "users"
                    }
                }
            };

            return View(model);
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