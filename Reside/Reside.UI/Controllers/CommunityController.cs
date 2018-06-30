using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reside.UI.Models;

namespace Reside.UI.Controllers
{
    public class CommunityController : Controller
    {
        // GET: Community
        public ActionResult Index()
        {
            var topNav = new TopNavigation()
            {
                CurrentPageText = "My neighbourhood",
                CurrentPageIcon = "users",
                MenuLinks = new List<TopNavigation.MenuItem>
                {
                    new TopNavigation.MenuItem
                    {
                        Text = "My home",
                        SubText = "Building 1701",
                        Link = "",
                        Icon = "home"
                    }
                }
            };

            var model = new Page()
            {
                TopNav = topNav
            };

            return View(model);
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }
    }
}