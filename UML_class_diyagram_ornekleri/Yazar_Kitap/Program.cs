using System;
using System.Collections.Generic;

namespace Yazar_Kitap
{
    class Kitap
    {
        public string Baslik { get; set; }
        public string ISBN { get; set; }

        public Kitap(string baslik, string isbn)
        {
            Baslik = baslik;
            ISBN = isbn;
        }
    }

    class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; } // Yazarın kitaplarını tutan liste

        public Yazar(string ad, string ulke)
        {
            Ad = ad;
            Ulke = ulke;
            Kitaplar = new List<Kitap>(); // Listeyi başlatıyoruz
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            Console.WriteLine($"'{kitap.Baslik}' adlı kitap {Ad} adlı yazara eklendi.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Yazar oluştur
            Yazar yazar = new Yazar("Orhan Pamuk", "Türkiye");

            // Kitaplar oluştur
            Kitap kitap1 = new Kitap("Masumiyet Müzesi", "9789750808077");
            Kitap kitap2 = new Kitap("Kırmızı Saçlı Kadın", "9789750840602");

            // Yazara kitap ekle
            yazar.KitapEkle(kitap1);
            yazar.KitapEkle(kitap2);

            // Yazarın bilgilerini yazdır
            Console.WriteLine($"\nYazar: {yazar.Ad}, Ülke: {yazar.Ulke}");
            Console.WriteLine("Kitapları:");
            foreach (var kitap in yazar.Kitaplar)
            {
                Console.WriteLine($"- {kitap.Baslik} (ISBN: {kitap.ISBN})");
            }

            // Ekranın açık kalmasını sağla
            
            Console.ReadKey(); 
        }
    }
}
