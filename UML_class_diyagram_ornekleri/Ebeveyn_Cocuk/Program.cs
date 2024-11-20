using System;
using System.Collections.Generic;

namespace Ebeveyn_Cocuk
{
    class Cocuk
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public Ebeveyn Ebeveyn { get; private set; }

        public Cocuk(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        public void EbeveynAtama(Ebeveyn ebeveyn)
        {
            Ebeveyn = ebeveyn;
            Console.WriteLine($"{Ad} adlı çocuk {ebeveyn.Ad} adlı ebeveyne atandı.");
        }
    }

    class Ebeveyn
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public List<Cocuk> Cocuklar { get; private set; }

        public Ebeveyn(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
            Cocuklar = new List<Cocuk>();
        }

        public void CocukEkle(Cocuk cocuk)
        {
            Cocuklar.Add(cocuk);
            cocuk.EbeveynAtama(this);
            Console.WriteLine($"{cocuk.Ad} adlı çocuk {Ad} adlı ebeveynin listesine eklendi.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ebeveyn ve Çocuk nesneleri oluşturuluyor
            Ebeveyn ebeveyn = new Ebeveyn("Ahmet", 40);
            Cocuk cocuk1 = new Cocuk("Ali", 10);
            Cocuk cocuk2 = new Cocuk("Veli", 8);

            // Çocuklar ebeveyne atanıyor
            ebeveyn.CocukEkle(cocuk1);
            ebeveyn.CocukEkle(cocuk2);

            Console.ReadKey();
        }
    }
}
