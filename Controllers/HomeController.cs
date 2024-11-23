using InTheBag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace InTheBag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult IndexViewBag()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Peace");
            WishList.Add("Health");
            WishList.Add("Happiness");
            ViewBag.WishList = WishList;
            return View();
        }
        public IActionResult IndexViewData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Quies");
            WishList.Add("Salutem");
            WishList.Add("Beatitudinem");
            ViewData["WishList"] = WishList;
            return View();
        }
        public IActionResult IndexTempData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("La Paz");
            WishList.Add("La Salud");
            WishList.Add("La Felicicdad");
            TempData["WishList"] = WishList;
            return View();
        }
        public IActionResult WishIndex()
        {
            Wishes myWishes = new Wishes { ID = 1, Wish1 = "Healthy", Wish2 = "Wealthy", Wish3 = "Wise"  };
            string jsonWishes = JsonSerializer.Serialize(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View();
        }
        [HttpGet]
        public IActionResult NewWishIndex()
        {
            return View();
        }
        /*  [HttpPost]
          public IActionResult NewWishIndex(Wishes model)
          {
              Wishes myWishes = new Wishes { ID = 2, Wish1 = model.Wish1, Wish2 = model.Wish2, Wish3 = model.Wish3 };
              string jsonWishes = JsonSerializer.Serialize(myWishes);
              HttpContext.Session.SetString("wish", jsonWishes);
              return View("WishIndex");
          }*/
        [HttpPost]
        public IActionResult NewWishIndex(Wishes model)
        {
            string wish1 = Request.Form["Wish1"];
            string wish2 = Request.Form["Wish2"];
            string wish3 = Request.Form["Wish3"];

            Wishes myWishes = new Wishes
            {
                ID = 2,
                Wish1 = wish1,
                Wish2 = wish2,
                Wish3 = wish3
            };
            string jsonWishes = JsonSerializer.Serialize(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View("WishIndex");

        }
    }
}