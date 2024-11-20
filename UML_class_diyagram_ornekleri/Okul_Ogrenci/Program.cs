using System;
using System.Collections.Generic;

namespace Okul_Ogrenci
{
    class Ogrenci
    {
        public string Ad { get; set; }
        private int Yas { get; set; } // Yaş bilgisi sadece sınıf içinden erişilebilir

        public Ogrenci(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        public void OgrenciBilgisi()
        {
            Console.WriteLine($"Öğrenci Adı: {Ad}, Yaşı: {Yas}");
        }
    }

    class Okul
    {
        public string Ad { get; set; }
        public List<Ogrenci> Ogrenciler { get; private set; }

        public Okul(string ad)
        {
            Ad = ad;
            Ogrenciler = new List<Ogrenci>();
        }

        public void OgrenciOlustur(string ad, int yas)
        {
            Ogrenci yeniOgrenci = new Ogrenci(ad, yas);
            Ogrenciler.Add(yeniOgrenci);
            Console.WriteLine($"Yeni öğrenci eklendi: {ad}, {yas} yaşında.");
        }

        public void OkulBilgisi()
        {
            Console.WriteLine($"\nOkul Adı: {Ad}");
            Console.WriteLine("Öğrenci Listesi:");
            foreach (var ogrenci in Ogrenciler)
            {
                ogrenci.OgrenciBilgisi();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Okul oluştur
            Okul okul = new Okul("Atatürk Anadolu Lisesi");

            // Öğrenciler ekle
            okul.OgrenciOlustur("Ali", 16);
            okul.OgrenciOlustur("Ayşe", 15);
            okul.OgrenciOlustur("Mehmet", 17);

            // Okul bilgilerini yazdır
            okul.OkulBilgisi();

            // Programın açık kalması için beklet
            Console.WriteLine("\nÇıkmak için bir tuşa bas...");
            Console.ReadKey();
        }
    }
}
