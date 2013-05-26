using System;
using OpenTimeTable.Client.Models;

namespace OpenTimeTable.Client.Controllers {
    using System.Web.Mvc;
    using Orchard.Themes;

    [Themed]
    public class HomeController : Controller {
        public ActionResult Index() {
            var searchConnection = new SearchConnection {When = DateTime.Now};
            return View(searchConnection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SearchConnection searchConnection) {
            if (ModelState.IsValid) {
                return RedirectToAction("TimeTable", searchConnection);
            }

            return View();
        }

        [HttpGet]
        public ActionResult TimeTable(SearchConnection searchConnection) {
            var client = new ConnectionService.ConnectionServiceClient();

            DateTime? when = null;
            if (searchConnection.When != default(DateTime)) {
                when = searchConnection.When;
            }

            client.Open();
            var connections = client.Get(searchConnection.From, searchConnection.To, null, when, null, null, null, null, null, null);
            client.Close();

            return View(connections);
        }
    }

}