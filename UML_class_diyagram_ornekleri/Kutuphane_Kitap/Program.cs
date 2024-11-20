using System;
using System.Collections.Generic;

namespace Kutuphane_Kitap
{
    class Kitap
    {
        public string Baslik { get; set; }
        public string Yazar { get; set; }

        public Kitap(string baslik, string yazar)
        {
            Baslik = baslik;
            Yazar = yazar;
        }

        public void KitapBilgisi()
        {
            Console.WriteLine($"Kitap Başlığı: {Baslik}, Yazar: {Yazar}");
        }

        public override string ToString()
        {
            return $"{Baslik} - {Yazar}";
        }
    }

    class Kutuphane
    {
        public string Ad { get; set; }
        public List<Kitap> Kitaplar { get; private set; }

        public Kutuphane(string ad)
        {
            Ad = ad;
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            Console.WriteLine($"'{kitap.Baslik}' adlı kitap '{Ad}' kütüphanesine eklendi.");
        }

        public void KutuphaneBilgisi()
        {
            Console.WriteLine($"\nKütüphane Adı: {Ad}");
            Console.WriteLine("Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                kitap.KitapBilgisi();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Kütüphane oluştur
            Kutuphane kutuphane = new Kutuphane("Şehir Kütüphanesi");

            // Kitaplar oluştur ve kütüphaneye ekle
            Kitap kitap1 = new Kitap("Savaş ve Barış", "Lev Tolstoy");
            Kitap kitap2 = new Kitap("1984", "George Orwell");
            Kitap kitap3 = new Kitap("Suç ve Ceza", "Fyodor Dostoyevski");

            kutuphane.KitapEkle(kitap1);
            kutuphane.KitapEkle(kitap2);
            kutuphane.KitapEkle(kitap3);

            // Kütüphane bilgilerini yazdır
            kutuphane.KutuphaneBilgisi();

            // Programın açık kalması için beklet
            Console.WriteLine("\nÇıkmak için bir tuşa bas...");
            Console.ReadKey();
        }
    }
}
