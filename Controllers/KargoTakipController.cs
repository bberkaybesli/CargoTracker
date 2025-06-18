// Gerekli kütüphaneler
using Microsoft.AspNetCore.Mvc;               // Controller sınıfı ve web işlemleri için
using KaraAmbarKargoculuk.Data;              // Veritabanı bağlantısı (DbContext)
using System.Linq;                            // Liste işlemleri için (FirstOrDefault vs.)

namespace KaraAmbarKargoculuk.Controllers
{
    // Bu controller, kullanıcıların kargo takip işlemlerini yapmasını sağlar
    public class KargoTakipController : Controller
    {
        private readonly UygulamaVeritabani _context;

        // Constructor: Veritabanı bağlantısını alır
        public KargoTakipController(UygulamaVeritabani context)
        {
            _context = context;
        }

        // Takip sayfasını açar (takip formu gösterilir)
        public IActionResult Index()
        {
            return View(); // Views/KargoTakip/Index.cshtml
        }

        // Kullanıcı formu doldurup "Sorgula" butonuna bastığında bu metot çalışır
        [HttpPost]
        public IActionResult Sorgula(string takipKodu)
        {
            // Veritabanında takip koduna göre ilk eşleşen kargoyu bul
            var kargo = _context.Kargolar.FirstOrDefault(k => k.TakipKodu == takipKodu);

            // Sonuç sayfasına geç ve kargo bilgilerini gönder
            return View("Sonuc", kargo); // Views/KargoTakip/Sonuc.cshtml
        }
    }
}
