// Gerekli kütüphaneler
using System.Diagnostics;                            // Hata takibi için
using KaraAmbarKargoculuk.Models;                   // Model dosyalarýný kullanmak için
using Microsoft.AspNetCore.Mvc;                     // MVC yapýlarýna ulaþmak için
using Microsoft.Extensions.Logging;                 // Hata loglama sistemi

namespace KaraAmbarKargoculuk.Controllers

{
    // Anasayfa ve ücret hesaplama gibi iþlemleri yöneten controller
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Logger yapýsýný Controller’a dahil ediyoruz (hata vs. durumlar için)
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Anasayfa açýldýðýnda çalýþan metot
        public IActionResult Index()
        {
            return View(); // Views/Home/Index.cshtml sayfasýný açar
        }

        //  Gizlilik politikasý sayfasý
        public IActionResult Privacy()
        {
            return View(); // Views/Home/Privacy.cshtml açýlýr
        }

        // Kargo ücret hesaplama sayfasý ilk açýldýðýnda (boþ form gelir)
        public IActionResult UcretHesapla()
        {
            var model = new KargoUcretiViewModel(); // ViewModel’den boþ bir nesne oluþtur
            return View(model); // Bu modeli View’e gönder
        }

        // Form gönderildiðinde çalýþýr – Kargo ücretini hesaplar
        [HttpPost]
        public IActionResult UcretHesapla(KargoUcretiViewModel model)
        {
            if (ModelState.IsValid) // Formda eksik bilinmeyen bilgi yoksa
            {
                double bazUcret = 30.0;          // Her kargo için baþlangýç ücreti
                double agirlikCarpani = 2.5;     // Her kilo için ek ücret
                double mesafeCarpani = 0.25;     // Her km baþýna ek ücret

                // MesafeVerisi sýnýfýndan gerçek mesafeyi al
                double mesafe = MesafeVerisi.MesafeGetir(model.GondericiIl, model.AliciIl);

                // Toplam ücret = baz + aðýrlýk ücreti + mesafe ücreti
                double ucret = bazUcret + (agirlikCarpani * model.AgirlikKg) + (mesafeCarpani * mesafe);

                // Eðer kullanýcý "Hýzlý Kargo" seçtiyse +20 TL ekle
                if (model.KargoTipi == "Hýzlý")
                    ucret += 20;

                // Hesaplanan ücreti modele yaz
                model.HesaplananUcret = ucret;
            }

            // Ýl listesi yeniden yüklensin diye tekrar veriyoruz
            model.Iller = new KargoUcretiViewModel().Iller;

            // View'e model ile birlikte geri dön
            return View(model);
        }


        // Hata olduðunda çalýþacak özel sayfa (404, 500 gibi hatalar için)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // RequestId: hangi iþlemde hata olduysa onu göster
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
