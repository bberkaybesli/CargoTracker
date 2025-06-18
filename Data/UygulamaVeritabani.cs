// Gerekli kütüphaneler
using Microsoft.EntityFrameworkCore;               // Entity Framework: Veritabanı işlemleri için
using KaraAmbarKargoculuk.Models;                 // Kargo model dosyasını çağırmak için
using System.Collections.Generic;                 // Liste işlemleri için (şu an şart değil ama kalabilir)

namespace KaraAmbarKargoculuk.Data
{
    // Veritabanı ile bağlantı kuran ana sınıf (DbContext'ten türemiştir)
    public class UygulamaVeritabani : DbContext
    {
        // Constructor: Bağlantı ayarlarını alır
        public UygulamaVeritabani(DbContextOptions<UygulamaVeritabani> options)
            : base(options) // base sınıfına gönderilir
        {
        }

        // Kargo tablosunu temsil eder
        public DbSet<Kargo> Kargolar { get; set; }

    }
}
