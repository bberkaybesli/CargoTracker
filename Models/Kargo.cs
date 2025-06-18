// Gerekli kütüphaneler
using System;
using System.ComponentModel.DataAnnotations; // Gerekli olan [Required], [Display], [Key] gibi notlar için

namespace KaraAmbarKargoculuk.Models
{
    // Kargo sınıfı: her bir kargo gönderisini temsil eder
    public class Kargo
    {
        // Her kargo kaydının bir ID’si olur (birincil anahtar - Primary Key)
        [Key]
        public int Id { get; set; }

        // Takip kodu boş bırakılamaz ve formda "Takip Kodu" olarak görünür
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Takip Kodu")]
        public string TakipKodu { get; set; }

        // Gönderici adı
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Gönderici")]
        public string Gonderici { get; set; }

        // Alıcı adı
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Alıcı")]
        public string Alici { get; set; }

        // Kargonun mevcut durumu (örn. “Yolda”, “Teslim Edildi” vs.)
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Durum")]
        public string Durum { get; set; }

        // Kargonun en son görüldüğü konum
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Konum")]
        public string Konum { get; set; }

        // Kargoda ne olduğu bilgisi
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Ürün Bilgisi")]
        public string Urun { get; set; }

        // Kargonun gönderildiği tarih (boş bırakılamaz)
        [Display(Name = "Gönderi Tarihi")]
        public DateTime GonderiTarihi { get; set; }

        // Kargonun tahmini teslim tarihi (isteğe bağlı olabilir)
        [Display(Name = "Tahmini Teslim Tarihi")]
        public DateTime? TahminiTeslimTarihi { get; set; }
    }
}
