using Microsoft.EntityFrameworkCore;
using KaraAmbarKargoculuk.Models;
using System.Collections.Generic;

namespace KaraAmbarKargoculuk.Data
{
    public class UygulamaVeritabani : DbContext
    {
        public UygulamaVeritabani(DbContextOptions<UygulamaVeritabani> options) : base(options)
        {
        }

        public DbSet<Kargo> Kargolar { get; set; }
    }
}
