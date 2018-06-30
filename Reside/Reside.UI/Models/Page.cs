using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reside.UI.Models
{
    public class Page
    {
        public Page()
        {
            TopNav = new TopNavigation();
            TopSecondaryNav = new TopNavigation();
        }

        public TopNavigation TopNav { get; set; }
        public TopNavigation TopSecondaryNav { get; set; }
    }
}