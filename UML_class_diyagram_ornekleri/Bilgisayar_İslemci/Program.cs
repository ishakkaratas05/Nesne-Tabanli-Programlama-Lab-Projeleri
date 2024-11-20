using System;
using System.Collections.Generic;

namespace Bilgisayar_Islemci
{
    class Islemci
    {
        public int Cekirdekler { get; set; }
        public int Frekans { get; set; } // MHz cinsinden

        public Islemci(int cekirdekler, int frekans)
        {
            Cekirdekler = cekirdekler;
            Frekans = frekans;
        }

        public void IslemciBilgisi()
        {
            Console.WriteLine($"Çekirdek Sayısı: {Cekirdekler}, Frekans: {Frekans} MHz");
        }

        public override string ToString()
        {
            return $"{Cekirdekler} çekirdek - {Frekans} MHz";
        }
    }

    class Bilgisayar
    {
        public string Model { get; set; }
        public List<Islemci> Islemciler { get; private set; }

        public Bilgisayar(string model)
        {
            Model = model;
            Islemciler = new List<Islemci>();
        }

        public void IslemciOlustur(Islemci islemci)
        {
            Islemciler.Add(islemci);
            Console.WriteLine($"'{Model}' bilgisayarına işlemci eklendi: {islemci}");
        }

        public void BilgisayarBilgisi()
        {
            Console.WriteLine($"\nBilgisayar Modeli: {Model}");
            Console.WriteLine("İşlemciler:");
            foreach (var islemci in Islemciler)
            {
                islemci.IslemciBilgisi();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Bilgisayar oluştur
            Bilgisayar bilgisayar = new Bilgisayar("Asus ROG");

            // İşlemciler oluştur ve bilgisayara ekle
            Islemci islemci1 = new Islemci(8, 3200); // 8 çekirdek, 3200 MHz
            Islemci islemci2 = new Islemci(6, 2500); // 6 çekirdek, 2500 MHz

            bilgisayar.IslemciOlustur(islemci1);
            bilgisayar.IslemciOlustur(islemci2);

            // Bilgisayar bilgilerini yazdır
            bilgisayar.BilgisayarBilgisi();

            // Programın açık kalması için beklet
            Console.WriteLine("\nÇıkmak için bir tuşa bas...");
            Console.ReadKey();
        }
    }
}
