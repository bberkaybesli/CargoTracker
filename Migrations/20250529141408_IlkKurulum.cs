using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable // Nullable uyarılarını kapatır

namespace KaraAmbarKargoculuk.Migrations
{
    // Migration sınıfı: Veritabanı işlemlerini buradan tanımlar
    public partial class IlkKurulum : Migration
    {
        // Veritabanına ne eklenecek? Burada tanımlanır
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // "Kargolar" adında bir tablo oluştur
            migrationBuilder.CreateTable(
                name: "Kargolar", // Tablo adı
                columns: table => new
                {
                    // Her satır = Bir sütun (kolon)

                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    // Otomatik artan birincil anahtar (1’den başla 1’er artır)

                    TakipKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gonderici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Konum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Urun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GonderiTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TahminiTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                    // Nullable true = Boş bırakılabilir (tahmini teslim zorunlu değil)
                },
                constraints: table =>
                {
                    // Id sütununu birincil anahtar yap (PK = Primary Key)
                    table.PrimaryKey("PK_Kargolar", x => x.Id);
                });
        }

        // Bu migration geri alınırsa ne olacak? (tablo silinir)
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // "Kargolar" tablosunu sil
            migrationBuilder.DropTable(
                name: "Kargolar");
        }
    }
}
