using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KaraAmbarKargoculuk.Data;
using KaraAmbarKargoculuk.Models;

namespace KaraAmbarKargoculuk.Controllers
{
    public class KargoController : Controller
    {
        private readonly UygulamaVeritabani _context;

        public KargoController(UygulamaVeritabani context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Kargolar.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kargo = await _context.Kargolar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kargo == null)
            {
                return NotFound();
            }

            return View(kargo);
        }

        // GET: Kargo/Create
        public IActionResult Create()
        {
            var kargo = new Kargo();

            string kod = "KRG-" + DateTime.Now.ToString("yyyyMMdd") + "-" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            kargo.TakipKodu = kod;

            return View(kargo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TakipKodu,Gonderici,Alici,Durum,Konum,Urun,GonderiTarihi,TahminiTeslimTarihi")] Kargo kargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kargo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kargo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kargo = await _context.Kargolar.FindAsync(id);
            if (kargo == null)
            {
                return NotFound();
            }
            return View(kargo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TakipKodu,Gonderici,Alici,Durum,Konum,Urun,GonderiTarihi,TahminiTeslimTarihi")] Kargo kargo)
        {
            if (id != kargo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KargoExists(kargo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kargo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kargo = await _context.Kargolar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kargo == null)
            {
                return NotFound();
            }

            return View(kargo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kargo = await _context.Kargolar.FindAsync(id);
            if (kargo != null)
            {
                _context.Kargolar.Remove(kargo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KargoExists(int id)
        {
            return _context.Kargolar.Any(e => e.Id == id);
        }
    }
}
