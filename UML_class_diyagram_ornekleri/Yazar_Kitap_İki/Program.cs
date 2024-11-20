using System;
using System.Collections.Generic;

namespace Yazar_Kitap_İki
{
    class Kitap
    {
        public string Baslik { get; set; }
        public DateTime YayinTarihi { get; set; }
        public Yazar Yazar { get; private set; }

        public Kitap(string baslik, DateTime yayinTarihi)
        {
            Baslik = baslik;
            YayinTarihi = yayinTarihi;
        }

        public void YazarAtama(Yazar yazar)
        {
            Yazar = yazar;
            Console.WriteLine($"'{Baslik}' kitabı {yazar.Ad} adlı yazara atandı.");
        }
    }

    class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; private set; }

        public Yazar(string ad, string ulke)
        {
            Ad = ad;
            Ulke = ulke;
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            kitap.YazarAtama(this);  // Kitap yazar ataması yapılır
            Console.WriteLine($"{kitap.Baslik} adlı kitap {Ad} adlı yazarın listesine eklendi.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Yazar ve Kitap nesneleri oluşturuluyor
            Yazar yazar = new Yazar("Orhan Pamuk", "Türkiye");
            Kitap kitap1 = new Kitap("Kara Kitap", new DateTime(1990, 1, 1));
            Kitap kitap2 = new Kitap("Benim Adım Kırmızı", new DateTime(1998, 1, 1));

            // Kitaplar yazara ekleniyor
            yazar.KitapEkle(kitap1);
            yazar.KitapEkle(kitap2);

            // Programın bitmesini beklemek için kullanıcıdan bir tuşa basmasını istiyoruz
            Console.WriteLine("Programı kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
