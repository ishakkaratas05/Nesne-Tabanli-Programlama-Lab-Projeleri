using System;
using System.Collections.Generic;

namespace Urun_Siparis
{
    class Urun
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }

        public Urun(string ad, int fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public void UrunBilgisi()
        {
            Console.WriteLine($"Ürün: {Ad}, Fiyat: {Fiyat} TL");
        }
    }

    class Siparis
    {
        public DateTime Tarih { get; set; }
        public decimal Toplam { get; set; }
        public List<Urun> Urunler { get; set; } // Siparişe eklenen ürünler

        public Siparis()
        {
            Tarih = DateTime.Now;
            Urunler = new List<Urun>();
        }

        public void UrunEkle(Urun urun)
        {
            Urunler.Add(urun);
            Toplam += urun.Fiyat;
            Console.WriteLine($"{urun.Ad} adlı ürün siparişe eklendi.");
        }

        public void SiparisBilgisi()
        {
            Console.WriteLine($"\nSipariş Tarihi: {Tarih}");
            Console.WriteLine("Sipariş İçeriği:");
            foreach (var urun in Urunler)
            {
                urun.UrunBilgisi();
            }
            Console.WriteLine($"Toplam Tutar: {Toplam} TL");
        }
    }

    class Program
    {
        static void Main()
        {
            // Ürün oluştur
            Urun urun1 = new Urun("Laptop", 15000);
            Urun urun2 = new Urun("Telefon", 10000);

            // Sipariş oluştur
            Siparis siparis = new Siparis();

            // Ürünleri siparişe ekle
            siparis.UrunEkle(urun1);
            siparis.UrunEkle(urun2);

            // Sipariş bilgilerini yazdır
            siparis.SiparisBilgisi();

            // Ekranın açık kalmasını sağla
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
