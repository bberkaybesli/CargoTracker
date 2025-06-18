// EF Core tarafından otomatik oluşturulmuş dosya
// Bu dosya, en son migration’a göre veritabanı nasıl görünüyor onu kaydeder

using System;
using KaraAmbarKargoculuk.Data;                        // Veritabanı sınıfı
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KaraAmbarKargoculuk.Migrations
{
    // Bu sınıf, DbContext’in veritabanı modelini temsil eder
    [DbContext(typeof(UygulamaVeritabani))]
    partial class UygulamaVeritabaniModelSnapshot : ModelSnapshot
    {
        // Model bilgisi burada tanımlanır
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            // EF sürüm bilgisi ve tanımlar
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11") // EF Core sürümü
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            // SQL Server için otomatik artan sütunları ayarla
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            // "Kargo" tablosunun nasıl olacağını tanımlar
            modelBuilder.Entity("KaraAmbarKargoculuk.Models.Kargo", b =>
            {
                // Primary Key sütunu
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                // SQL Server’a bu kolonun identity (otomatik artan) olduğunu söyle
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                // Diğer tüm sütunlar, tipleri ve zorunlu olup olmadıkları
                b.Property<string>("Alici")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Durum")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("GonderiTarihi")
                    .HasColumnType("datetime2");

                b.Property<string>("Gonderici")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Konum")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime?>("TahminiTeslimTarihi")
                    .HasColumnType("datetime2");

                b.Property<string>("TakipKodu")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Urun")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                // Primary key olarak "Id" seçildi
                b.HasKey("Id");

                // Tablo adı: "Kargolar"
                b.ToTable("Kargolar");
            });
#pragma warning restore 612, 618
        }
    }
}
