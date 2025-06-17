using Microsoft.AspNetCore.Mvc;
using KaraAmbarKargoculuk.Data;
using System.Linq;

namespace KaraAmbarKargoculuk.Controllers
{
    public class KargoTakipController : Controller
    {
        private readonly UygulamaVeritabani _context;

        public KargoTakipController(UygulamaVeritabani context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sorgula(string takipKodu)
        {
            var kargo = _context.Kargolar.FirstOrDefault(k => k.TakipKodu == takipKodu);
            return View("Sonuc", kargo);
        }
    }
}
