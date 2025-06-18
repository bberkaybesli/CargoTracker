// Gerekli kütüphaneler
using System.Collections.Generic;               // Liste işlemleri için
using System.ComponentModel.DataAnnotations;    // Form doğrulama kuralları için

namespace KaraAmbarKargoculuk.Models
{
    // Bu sınıf, kargo ücreti hesaplama ekranındaki form verilerini tutar
    public class KargoUcretiViewModel
    {
        // Gönderici ili (seçmek zorunlu)
        [Required]
        public string GondericiIl { get; set; }

        // Alıcı ili (seçmek zorunlu)
        [Required]
        public string AliciIl { get; set; }

        // Kargo ağırlığı (zorunlu ve 0.1 ile 1000 kg arası olmalı)
        [Required]
        [Range(0.1, 1000)] // Eğer 0 veya negatifse hata verir
        public double AgirlikKg { get; set; }

        // Kargo tipi (örneğin: Normal, Hızlı)
        [Required]
        public string KargoTipi { get; set; }

        // Hesaplanan ücret (isteğe bağlı - program tarafından hesaplanır)
        public double? HesaplananUcret { get; set; }

        // İller listesi (Dropdown için sabit olarak tanımlandı)
        public List<string> Iller { get; set; } = new List<string> {
            "Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
            "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
            "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane",
            "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli",
            "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla",
            "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ",
            "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt",
            "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis",
            "Osmaniye", "Düzce"
        };
    }
}
