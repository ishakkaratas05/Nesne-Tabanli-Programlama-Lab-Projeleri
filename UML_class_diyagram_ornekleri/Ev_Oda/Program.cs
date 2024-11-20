using System;
using System.Collections.Generic;

namespace Ev_Oda
{
    class Oda
    {
        public string Boyut { get; set; }
        public string Tip { get; set; }

        public Oda(string boyut, string tip)
        {
            Boyut = boyut;
            Tip = tip;
        }

        public override string ToString()
        {
            return $"Oda Tipi: {Tip}, Boyutu: {Boyut}";
        }
    }

    class Ev
    {
        public string Ad { get; set; }
        public List<Oda> Odalar { get; private set; }

        public Ev(string ad)
        {
            Ad = ad;
            Odalar = new List<Oda>();
        }

        public void OdaEkle(Oda oda)
        {
            Odalar.Add(oda);
            Console.WriteLine($"'{oda.Tip}' adlı oda, '{Ad}' adlı eve eklendi.");
        }

        public void EvBilgisi()
        {
            Console.WriteLine($"\nEv Adı: {Ad}");
            Console.WriteLine("Odalar:");
            foreach (var oda in Odalar)
            {
                Console.WriteLine($"- {oda}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ev oluştur
            Ev evim = new Ev("Deniz Manzaralı Ev");

            // Odalar oluştur ve ekle
            Oda salon = new Oda("30 m²", "Salon");
            Oda yatakOdasi = new Oda("20 m²", "Yatak Odası");
            Oda mutfak = new Oda("15 m²", "Mutfak");

            evim.OdaEkle(salon);
            evim.OdaEkle(yatakOdasi);
            evim.OdaEkle(mutfak);

            // Ev bilgilerini yazdır
            evim.EvBilgisi();

            // Programın açık kalması için beklet
            Console.WriteLine("\nÇıkmak için bir tuşa bas...");
            Console.ReadKey();
        }
    }
}
