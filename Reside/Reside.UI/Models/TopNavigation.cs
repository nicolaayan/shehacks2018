using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reside.UI.Models
{
    public class TopNavigation
    {
        public string CurrentPageText { get; set; }
        public string CurrentPageIcon { get; set; }
        public List<MenuItem> MenuLinks { get; set; }

        public TopNavigation()
        {
            MenuLinks = new List<MenuItem>();
        }

        public class MenuItem
        {
            public string Text { get; set; }
            public string SubText { get; set; }
            public string Link { get; set; }
            public string Icon { get; set; }
        }
    }
}