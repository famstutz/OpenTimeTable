using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTimeTable.Controllers
{
    using System.Web.Mvc;

    using Orchard.Themes;

    [Themed]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("HelloWorld");
        }
    }

}