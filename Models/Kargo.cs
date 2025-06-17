using System;
using System.ComponentModel.DataAnnotations;

namespace KaraAmbarKargoculuk.Models
{
    public class Kargo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Takip Kodu")]
        public string TakipKodu { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Gönderici")]
        public string Gonderici { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Alıcı")]
        public string Alici { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Durum")]
        public string Durum { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Konum")]
        public string Konum { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Ürün Bilgisi")]
        public string Urun { get; set; }

        [Display(Name = "Gönderi Tarihi")]
        public DateTime GonderiTarihi { get; set; }

        [Display(Name = "Tahmini Teslim Tarihi")]
        public DateTime? TahminiTeslimTarihi { get; set; }
    }
}
