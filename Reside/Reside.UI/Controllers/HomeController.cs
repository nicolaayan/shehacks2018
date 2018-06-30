using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reside.UI.Models;

namespace Reside.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new Page
            {
                TopNav = GetTopNav(),
                TopSecondaryNav = GetTopSecondaryNav()
            };

            return View(model);
        }

        private TopNavigation GetTopNav()
        {
            return new TopNavigation()
            {
                CurrentPageText = "Building 1701",
                CurrentPageIcon = "home",
                MenuLinks = new List<TopNavigation.MenuItem>
                {
                    new TopNavigation.MenuItem
                    {
                        Text = "My community",
                        SubText = "Millers Point, 2000",
                        Link = "community",
                        Icon = "users"
                    }
                }
            };
        }

        private TopNavigation GetTopSecondaryNav()
        {
            return new TopNavigation()
            {
                CurrentPageText = "Concierge",
                CurrentPageIcon = "concierge-bell",
                MenuLinks = new List<TopNavigation.MenuItem>
                {
                    new TopNavigation.MenuItem
                    {
                        Text = "Board",
                        Link = "home/board",
                        Icon = "clipboard-list"
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Forum",
                        Link = "home/forum",
                        Icon = "chalkboard-teacher"
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Security",
                        Link = "home/security",
                        Icon = "lock"
                    }
                }
            };
        }
    }
}