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
                TopSecondaryNav = GetTopSecondaryNav("Concierge", "Announcements")
            };

            return View(model);
        }

        public ActionResult Board()
        {
            var model = new Page
            {
                TopNav = GetTopNav(),
                TopSecondaryNav = GetTopSecondaryNav("Bulletin board", "Feed")
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

        public static TopNavigation GetTopNav()
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

        public static TopNavigation GetTopSecondaryNav(string name, string bottomLink = "")
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
                        BottomLinks = GetConciergeBottomLinks(bottomLink)
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Bulletin board",
                        Link = "/home/board",
                        Icon = "clipboard-list",
                        IsActive = "Bulletin board" == name,
                        BottomLinks = GetBoardBottomLinks(bottomLink)
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Security",
                        Link = "/home/security",
                        Icon = "lock",
                        IsActive = "Security" == name,
                        //BottomLinks = GetConciergeBottomLinks("Leave a message")
                    }
                }
            };
        }

        public static List<TopNavigation.MenuItem> GetConciergeBottomLinks(string activeItem)
        {
            if (string.IsNullOrEmpty(activeItem))
            {
                return new List<TopNavigation.MenuItem>();
            }
            else
            {
                return new List<TopNavigation.MenuItem>
                {
                    new TopNavigation.MenuItem
                    {
                        Text = "Announcements",
                        Link = "/home/index",
                        Icon = "bullhorn",
                        IsActive = "Announcements" == activeItem
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "My parcels",
                        Link = "/concierge/parcels",
                        Icon = "cube",
                        IsActive = "My parcels" == activeItem
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Leave a message",
                        Link = "/concierge/message",
                        Icon = "comment",
                        IsActive = "Leave a message" == activeItem
                    }
                };
            }
        }

        public static List<TopNavigation.MenuItem> GetBoardBottomLinks(string activeItem)
        {
            if (string.IsNullOrEmpty(activeItem))
            {
                return new List<TopNavigation.MenuItem>();
            }
            else
            {
                return new List<TopNavigation.MenuItem>
                {
                    new TopNavigation.MenuItem
                    {
                        Text = "Feed",
                        Link = "/home/index",
                        Icon = "comments",
                        IsActive = "Feed" == activeItem
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Create post",
                        Link = "/board/createpost",
                        Icon = "pen",
                        IsActive = "Create post" == activeItem
                    },
                    new TopNavigation.MenuItem
                    {
                        Text = "Favourites",
                        Link = "/board/favourites",
                        Icon = "heart",
                        IsActive = "Favourites" == activeItem
                    }
                };
            }
        }
    }
}