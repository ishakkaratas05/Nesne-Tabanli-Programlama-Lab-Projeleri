using System;
using System.Collections.Generic;

namespace Sirket_Calisan_İki
{
    class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }

        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        public void CalisanBilgisi()
        {
            Console.WriteLine($"Çalışan Adı: {Ad}, Pozisyon: {Pozisyon}");
        }

        public override string ToString()
        {
            return $"{Ad} - {Pozisyon}";
        }
    }

    class Sirket
    {
        public string Ad { get; set; }
        public List<Calisan> Calisanlar { get; private set; }

        public Sirket(string ad)
        {
            Ad = ad;
            Calisanlar = new List<Calisan>();
        }

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
            Console.WriteLine($"'{calisan.Ad}' adlı çalışan, '{Ad}' adlı şirkete eklendi.");
        }

        public void SirketBilgisi()
        {
            Console.WriteLine($"\nŞirket Adı: {Ad}");
            Console.WriteLine("Çalışanlar:");
            foreach (var calisan in Calisanlar)
            {
                calisan.CalisanBilgisi();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Şirket oluştur
            Sirket sirketim = new Sirket("Teknoloji Şirketi");

            // Çalışanlar oluştur ve şirkete ekle
            Calisan calisan1 = new Calisan("Ahmet", "Yazılım Geliştirici");
            Calisan calisan2 = new Calisan("Ayşe", "Proje Yöneticisi");
            Calisan calisan3 = new Calisan("Mehmet", "Sistem Yöneticisi");

            sirketim.CalisanEkle(calisan1);
            sirketim.CalisanEkle(calisan2);
            sirketim.CalisanEkle(calisan3);

            // Şirket bilgilerini yazdır
            sirketim.SirketBilgisi();

            // Programın açık kalması için beklet
            Console.WriteLine("\nÇıkmak için bir tuşa bas...");
            Console.ReadKey();
        }
    }
}
