using System.Diagnostics;
using KaraAmbarKargoculuk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KaraAmbarKargoculuk.Controllers
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

        public IActionResult UcretHesapla()
        {
            var model = new KargoUcretiViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult UcretHesapla(KargoUcretiViewModel model)
        {
            if (ModelState.IsValid)
            {
                double bazUcret = 30.0;
                double agirlikCarpani = 2.5;

                double ucret = bazUcret + (agirlikCarpani * model.AgirlikKg);

                if (model.KargoTipi == "Hýzlý")
                    ucret += 20;

                model.HesaplananUcret = ucret;
            }

            
            model.Iller = new KargoUcretiViewModel().Iller;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
