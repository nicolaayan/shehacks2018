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
                TopSecondaryNav = GetTopSecondaryNav("Concierge")
            };

            return View(model);
        }

        public ActionResult Board()
        {
            var model = new Page
            {
                TopNav = GetTopNav(),
                TopSecondaryNav = GetTopSecondaryNav("Bulletin board")
            };

            return View(model);
        }

        public ActionResult Forum()
        {
            var model = new Page
            {
                TopNav = GetTopNav(),
                TopSecondaryNav = GetTopSecondaryNav("Forum")
            };

            return View(model);
        }

        public ActionResult Security()
        {
            var model = new Page
            {
                TopNav = GetTopNav(),
                TopSecondaryNav = GetTopSecondaryNav("Security")
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

        private TopNavigation GetTopSecondaryNav(string name)
        {
            return new TopNavigation()
            {
                MenuLinks = new List<TopNavigation.MenuItem>
                {
                    new TopNavigation.MenuItem
                    {
                        Text = "Concierge",
                        Link = "/home/index",
                        Icon = "concierge-bell",
                        IsActive = "Concierge" == name,
                        BottomLinks = new List<TopNavigation.MenuItem>
                        {
                            new TopNavigation.MenuItem
                            {
                                Text = "Announcements",
                                Link = "/concierge/announcements",
                                Icon = "bullhorn",
                                IsActive = true
                            },
                            new TopNavigation.MenuItem
                            {
                                Text = "My parcels",
                                Link = "/concierge/parcels",
                                Icon = "cube"
                            },
                            new TopNavigation.MenuItem
                            {
                                Text = "Leave a message",
                                Link = "/concierge/message",
                                Icon = "comment"
                            }
                        }
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Bulletin board",
                        Link = "/home/board",
                        Icon = "clipboard-list",
                        IsActive = "Bulletin board" == name
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Security",
                        Link = "/home/security",
                        Icon = "lock",
                        IsActive = "Security" == name
                    }
                }
            };
        }
    }
}