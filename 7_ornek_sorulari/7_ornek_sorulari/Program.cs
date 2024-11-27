using System;

namespace _7_ornek_sorulari
{
    // Overloading
    class Matematik
    {
        public int Topla(int a, int b) => a + b;

        public int Topla(int a, int b, int c) => a + b + c;

        public int Topla(int[] sayilar)
        {
            int toplam = 0;
            foreach (var sayi in sayilar)
                toplam += sayi;
            return toplam;
        }
    }

    class AlanHesaplayici
    {
        public double AlanHesapla(double kenar) => kenar * kenar;

        public double AlanHesapla(double uzunluk, double genişlik) => uzunluk * genişlik;

        public double AlanHesapla(double yaricap, bool daire) => Math.PI * yaricap * yaricap;
    }

    class ZamanHesaplayici
    {
        public double FarkGün(DateTime t1, DateTime t2) => (t2 - t1).TotalDays;

        public double FarkSaat(DateTime t1, DateTime t2) => (t2 - t1).TotalHours;

        public (int yıl, int ay, int gün) FarkDetaylı(DateTime t1, DateTime t2)
        {
            var fark = t2 - t1;
            int yıl = fark.Days / 365;
            int ay = (fark.Days % 365) / 30;
            int gün = (fark.Days % 365) % 30;
            return (yıl, ay, gün);
        }
    }

    // Tek ve Çift Boyutlu İndeksleyiciler
    class Kitaplık
    {
        private string[] kitaplar;

        public Kitaplık(int boyut)
        {
            kitaplar = new string[boyut];
        }

        public string this[int indeks]
        {
            get => indeks >= 0 && indeks < kitaplar.Length ? kitaplar[indeks] : "Geçersiz indeks!";
            set
            {
                if (indeks >= 0 && indeks < kitaplar.Length)
                    kitaplar[indeks] = value;
            }
        }
    }

    class Otopark
    {
        private string[,] katlar;

        public Otopark(int katSayisi, int parkYeriSayisi)
        {
            katlar = new string[katSayisi, parkYeriSayisi];
        }

        public string this[int kat, int parkYeri]
        {
            get
            {
                if (kat < 0 || kat >= katlar.GetLength(0) || parkYeri < 0 || parkYeri >= katlar.GetLength(1))
                    return "Geçersiz konum!";
                return katlar[kat, parkYeri] ?? "Empty";
            }
            set
            {
                if (kat >= 0 && kat < katlar.GetLength(0) && parkYeri >= 0 && parkYeri < katlar.GetLength(1))
                    katlar[kat, parkYeri] = value;
            }
        }
    }

    // Struct
    struct Zaman
    {
        public int Saat { get; private set; }
        public int Dakika { get; private set; }

        public Zaman(int saat, int dakika)
        {
            Saat = (saat >= 0 && saat < 24) ? saat : 0;
            Dakika = (dakika >= 0 && dakika < 60) ? dakika : 0;
        }

        public int ToplamDakika() => Saat * 60 + Dakika;

        public int Fark(Zaman other) => Math.Abs(this.ToplamDakika() - other.ToplamDakika());
    }

    struct KarmaşıkSayı
    {
        public double Gerçek { get; private set; }
        public double Sanal { get; private set; }

        public KarmaşıkSayı(double gerçek, double sanal)
        {
            Gerçek = gerçek;
            Sanal = sanal;
        }

        public KarmaşıkSayı Topla(KarmaşıkSayı other)
        {
            return new KarmaşıkSayı(this.Gerçek + other.Gerçek, this.Sanal + other.Sanal);
        }

        public KarmaşıkSayı Çıkar(KarmaşıkSayı other)
        {
            return new KarmaşıkSayı(this.Gerçek - other.Gerçek, this.Sanal - other.Sanal);
        }

        public override string ToString() => $"{Gerçek} + {Sanal}i";
    }

    struct GPS
    {
        public double Enlem { get; private set; }
        public double Boylam { get; private set; }

        public GPS(double enlem, double boylam)
        {
            Enlem = enlem;
            Boylam = boylam;
        }

        public double Mesafe(GPS other)
        {
            double R = 6371; // Dünya'nın yarıçapı
            double dLat = DereceyiRadyana(other.Enlem - this.Enlem);
            double dLon = DereceyiRadyana(other.Boylam - this.Boylam);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DereceyiRadyana(this.Enlem)) * Math.Cos(DereceyiRadyana(other.Enlem)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double DereceyiRadyana(double derece) => derece * Math.PI / 180;
    }

    // Enum
    enum TrafikIşığı
    {
        Red,
        Yellow,
        Green
    }

    class TrafikKontrol
    {
        public string NeYapılmalı(TrafikIşığı durum)
        {
            return durum switch
            {
                TrafikIşığı.Red => "Dur!",
                TrafikIşığı.Yellow => "Hazır ol!",
                TrafikIşığı.Green => "Geç!",
                _ => "Geçersiz durum!"
            };
        }
    }

    enum HavaDurumu
    {
        Sunny,
        Rainy,
        Cloudy,
        Stormy
    }

    class HavaDurumuTavsiyesi
    {
        public string Tavsiye(HavaDurumu durum)
        {
            return durum switch
            {
                HavaDurumu.Sunny => "Güneş gözlüğü tak!",
                HavaDurumu.Rainy => "Şemsiye almayı unutma!",
                HavaDurumu.Cloudy => "Hava serin olabilir.",
                HavaDurumu.Stormy => "Evde kal!",
                _ => "Geçersiz hava durumu!"
            };
        }
    }

    enum Rol
    {
        Manager,
        Developer,
        Designer,
        Tester
    }

    class Çalışan
    {
        public double MaaşHesapla(Rol rol)
        {
            return rol switch
            {
                Rol.Manager => 15000,
                Rol.Developer => 10000,
                Rol.Designer => 9000,
                Rol.Tester => 8000,
                _ => 0
            };
        }
    }

    // Program Main
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tüm kodlar çalışıyor!");
        }
    }
}
