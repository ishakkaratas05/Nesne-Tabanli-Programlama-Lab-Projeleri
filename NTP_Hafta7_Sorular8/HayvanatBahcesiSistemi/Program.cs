using System;

namespace HayvanatBahcesiSistemi
{
    // Temel Hayvan sınıfı
    class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Tür: {Tur}, Yaş: {Yas}");
        }
    }

    // Memeli sınıfı
    class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Tüy Rengi: {TuyRengi}");
        }
    }

    // Kus sınıfı
    class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Kanat Genişliği: {KanatGenisligi} cm");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hayvan türünü seçin (1: Memeli, 2: Kuş): ");
            int secim = int.Parse(Console.ReadLine());

            Hayvan hayvan;

            if (secim == 1)
            {
                hayvan = new Memeli();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Tüy Rengi: ");
                ((Memeli)hayvan).TuyRengi = Console.ReadLine();
            }
            else if (secim == 2)
            {
                hayvan = new Kus();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Kanat Genişliği (cm): ");
                ((Kus)hayvan).KanatGenisligi = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Program sonlandırılıyor.");
                return;
            }

            Console.WriteLine("\nHayvan Bilgileri:");
            hayvan.BilgiYazdir();

            Console.Read();

        }
    }
}

