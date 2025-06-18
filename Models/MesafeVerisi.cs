// Models/MesafeVerisi.cs

using System.Collections.Generic;

namespace KaraAmbarKargoculuk.Models
{
    public static class MesafeVerisi
    {
        // İllere göre örnek mesafe verileri
        public static Dictionary<(string, string), double> Mesafeler = new Dictionary<(string, string), double>
        {
            { ("Ankara", "İstanbul"), 450 },
            { ("İstanbul", "İzmir"), 480 },
            { ("Ankara", "İzmir"), 520 },
            { ("Bitlis", "İstanbul"), 1400 },
            { ("Bitlis", "Ankara"), 1100 },
            { ("Gaziantep", "İstanbul"), 1200 },
            { ("İzmir", "Gaziantep"), 1250 },
            // Eklenebilir...
        };

        // Mesafe hesaplama metodu
        public static double MesafeGetir(string il1, string il2)
        {
            if (il1 == il2)
                return 0;

            if (Mesafeler.TryGetValue((il1, il2), out double mesafe))
                return mesafe;

            if (Mesafeler.TryGetValue((il2, il1), out mesafe))
                return mesafe;

            return 600; // Bilinmeyen iller arası varsayılan mesafe
        }
    }
}
