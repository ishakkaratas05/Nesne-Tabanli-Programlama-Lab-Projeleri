using System;
using System.Collections.Generic;

namespace Sirket_Calisan
{
    class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Sirket Sirket { get; private set; }

        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        public void SirketAtama(Sirket sirket)
        {
            Sirket = sirket;
            Console.WriteLine($"{Ad} adlı çalışan {sirket.Ad} adlı şirkete atandı.");
        }
    }

    class Sirket
    {
        public string Ad { get; set; }
        public string Konum { get; set; }
        public List<Calisan> Calisanlar { get; private set; }

        public Sirket(string ad, string konum)
        {
            Ad = ad;
            Konum = konum;
            Calisanlar = new List<Calisan>();
        }

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
            calisan.SirketAtama(this);
            Console.WriteLine($"{calisan.Ad} adlı çalışan {Ad} adlı şirkete eklendi.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Şirket ve Çalışan nesneleri oluşturuluyor
            Sirket sirket = new Sirket("TechCo", "İstanbul");
            Calisan calisan1 = new Calisan("Ahmet", "Yazılım Geliştirici");
            Calisan calisan2 = new Calisan("Ayşe", "Veri Analisti");

            // Çalışanlar şirkete ekleniyor
            sirket.CalisanEkle(calisan1);
            sirket.CalisanEkle(calisan2);

            // Programın bitmesini beklemek için kullanıcıdan bir tuşa basmasını istiyoruz
            Console.WriteLine("Programı kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
