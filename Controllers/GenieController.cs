using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace InTheBag.Controllers
{
    public class GenieController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        /*[HttpPost]
        public IActionResult Create(string GenieName, int Age, int WishesGranted)
        {
            if (WishesGranted > 5000 || Age > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }*/
        [HttpPost]
        public IActionResult Create(String GenieName)
        {
            int numGranted = Int32.Parse(Request.Form["WishesGranted"]);
            int Years = Int32.Parse(Request.Form["Age"]);

            if (numGranted > 5000 || Years > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");

        }
        public IActionResult Create2()
        {
            var name = RouteData.Values["GenieName"];
            var Years = Int32.Parse((string)RouteData.Values["Age"]);
            var numGranted = Int32.Parse((string)RouteData.Values["WishesGranted"]);

            if (numGranted > 5000 || Years > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }
        public IActionResult Perks()
        {
            ViewBag.Posted = false;
            return View();
        }
        [HttpPost]
        public IActionResult Perks(string[] perk)
        {
            ViewBag.Posted = true;
            ViewBag.Perks = perk;
            return View();
        }
    }
}
