// Gerekli kütüphaneler
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;                    // Controller sınıfı için
using Microsoft.AspNetCore.Mvc.Rendering;         // Dropdown listeler için (kullanılmamış ama ekli)
using Microsoft.EntityFrameworkCore;              // Veritabanı işlemleri için
using KaraAmbarKargoculuk.Data;                   // DbContext (veritabanı bağlantısı)
using KaraAmbarKargoculuk.Models;                 // Kargo model dosyası

namespace KaraAmbarKargoculuk.Controllers
{
    // Kargo işlemlerini yöneten controller (CRUD işlemleri burada)
    public class KargoController : Controller
    {
        private readonly UygulamaVeritabani _context;

        // Veritabanı bağlantısını Controller’a alıyoruz
        public KargoController(UygulamaVeritabani context)
        {
            _context = context;
        }

        // Kargo listesi – Anasayfa
        public async Task<IActionResult> Index()
        {
            // Tüm kargoları getir ve Index view'ına gönder
            return View(await _context.Kargolar.ToListAsync());
        }

        // Belirli bir kargonun detaylarını gösterir
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // ID yoksa hata döndür
            }

            var kargo = await _context.Kargolar
                .FirstOrDefaultAsync(m => m.Id == id); // İlgili kargoyu bul
            if (kargo == null)
            {
                return NotFound(); // Kargo bulunamazsa hata
            }

            return View(kargo); // Kargo bulunduysa view’a gönder
        }

        // Kargo oluşturma sayfası (formu gösterir)
        public IActionResult Create()
        {
            var kargo = new Kargo();

            // Otomatik takip kodu oluştur (örnek: KRG-20250618-ABC123)
            string kod = "IA-" + DateTime.Now.ToString("yyyyMMdd") + "-" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            kargo.TakipKodu = kod;

            return View(kargo); // Formu view’a gönder
        }

        // Kargo oluşturma işlemi (form post edildiğinde çalışır)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TakipKodu,Gonderici,Alici,Durum,Konum,Urun,GonderiTarihi,TahminiTeslimTarihi")] Kargo kargo)
        {
            if (ModelState.IsValid) // Eğer form verisi doğruysa
            {
                _context.Add(kargo);                  // Yeni kargoyu ekle
                await _context.SaveChangesAsync();    // Veritabanına kaydet
                return RedirectToAction(nameof(Index)); // Liste sayfasına dön
            }
            return View(kargo); // Hatalıysa tekrar formu göster
        }

        // Kargo düzenleme formunu gösterir
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kargo = await _context.Kargolar.FindAsync(id); // Kargoyu bul
            if (kargo == null)
            {
                return NotFound(); // Bulunamazsa hata
            }
            return View(kargo); // View’a gönder
        }

        // Kargo düzenleme işlemi (form gönderilince çalışır)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TakipKodu,Gonderici,Alici,Durum,Konum,Urun,GonderiTarihi,TahminiTeslimTarihi")] Kargo kargo)
        {
            if (id != kargo.Id)
            {
                return NotFound(); // ID uyuşmazsa hata
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kargo);              // Güncelle
                    await _context.SaveChangesAsync();   // Kaydet
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KargoExists(kargo.Id))          // Kargo veritabanında var mı?
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Hata varsa dışarı at
                    }
                }
                return RedirectToAction(nameof(Index)); // Listeye geri dön
            }
            return View(kargo); // Hatalıysa formu tekrar göster
        }

        // Silme ekranını gösterir (kargoyu önce gösterip emin misin diye sorar)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kargo = await _context.Kargolar
                .FirstOrDefaultAsync(m => m.Id == id); // Kargoyu bul
            if (kargo == null)
            {
                return NotFound();
            }

            return View(kargo); // Silme onay sayfasına gönder
        }

        // Silme işlemi (onaylandıysa çalışır)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kargo = await _context.Kargolar.FindAsync(id); // Kargoyu bul
            if (kargo != null)
            {
                _context.Kargolar.Remove(kargo); // Veritabanından sil
            }

            await _context.SaveChangesAsync(); // Kaydet
            return RedirectToAction(nameof(Index)); // Listeye dön
        }

        // Belirtilen ID’ye sahip kargo var mı kontrol eder
        private bool KargoExists(int id)
        {
            return _context.Kargolar.Any(e => e.Id == id);
        }
    }
}
