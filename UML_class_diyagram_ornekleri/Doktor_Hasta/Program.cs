using System;
using System.Collections.Generic;

namespace Doktor_Hasta
{
    class Hasta
    {
        public string Ad { get; set; }
        public string TCNo { get; set; }
        public Doktor Doktor { get; private set; } // Hasta, kendisine atanmış doktoru tutar.

        public Hasta(string ad, string tcNo)
        {
            Ad = ad;
            TCNo = tcNo;
        }

        public void DoktorAtama(Doktor doktor)
        {
            Doktor = doktor;
            Console.WriteLine($"{Ad} adlı hasta {doktor.Ad} adlı doktora atandı.");
        }
    }

    class Doktor
    {
        public string Ad { get; set; }
        public string Brans { get; set; }
        public List<Hasta> Hastalar { get; private set; } // Doktorun hastalarını tutar.

        public Doktor(string ad, string brans)
        {
            Ad = ad;
            Brans = brans;
            Hastalar = new List<Hasta>();
        }

        public void HastaEkle(Hasta hasta)
        {
            Hastalar.Add(hasta);
            hasta.DoktorAtama(this); // Hastaya bu doktor atanır.
            Console.WriteLine($"{hasta.Ad} adlı hasta {Ad} adlı doktorun listesine eklendi.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Doktor oluştur
            Doktor doktor1 = new Doktor("Dr. Ayşe Yılmaz", "Kardiyoloji");

            // Hasta oluştur
            Hasta hasta1 = new Hasta("Ali Vural", "12345678901");
            Hasta hasta2 = new Hasta("Zeynep Demir", "98765432100");

            // Hastaları doktora ekle
            doktor1.HastaEkle(hasta1);
            doktor1.HastaEkle(hasta2);

            // Doktorun hastalarını listele
            Console.WriteLine($"\n{doktor1.Ad} adlı doktorun hastaları:");
            foreach (var hasta in doktor1.Hastalar)
            {
                Console.WriteLine($"- {hasta.Ad} (TC: {hasta.TCNo})");
            }

            // Ekranın açık kalmasını sağla
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
