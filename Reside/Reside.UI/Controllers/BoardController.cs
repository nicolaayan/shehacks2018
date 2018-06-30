using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reside.UI.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult CreatePost()
        {
            return View();
        }

        public ActionResult Favourites()
        {
            return View();
        }
    }
}