using System;
using System.Collections.Generic;

namespace MagazaYonetimSistemi
{
    // Soyut Urun sınıfı
    abstract class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        protected Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        // Soyut ödeme hesaplama metodu
        public abstract decimal HesaplaOdeme();

        // Bilgi yazdırma metodu
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ürün Adı: {Ad}, Fiyat: {Fiyat:C}");
        }
    }

    // Kitap sınıfı
    class Kitap : Urun
    {
        public string Yazar { get; set; }

        public Kitap(string ad, decimal fiyat, string yazar)
            : base(ad, fiyat)
        {
            Yazar = yazar;
        }

        public override decimal HesaplaOdeme()
        {
            decimal vergi = Fiyat * 0.10m;
            return Fiyat + vergi;
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazar: {Yazar}, Ödenecek Tutar: {HesaplaOdeme():C}");
        }
    }

    // Elektronik sınıfı
    class Elektronik : Urun
    {
        public string Marka { get; set; }
        public string Model { get; set; }

        public Elektronik(string ad, decimal fiyat, string marka, string model)
            : base(ad, fiyat)
        {
            Marka = marka;
            Model = model;
        }

        public override decimal HesaplaOdeme()
        {
            decimal vergi = Fiyat * 0.25m;
            return Fiyat + vergi;
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Marka: {Marka}, Model: {Model}, Ödenecek Tutar: {HesaplaOdeme():C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ürün koleksiyonu
            List<Urun> urunler = new List<Urun>
            {
                new Kitap("Savaş ve Barış", 100m, "Lev Tolstoy"),
                new Elektronik("Akıllı Telefon", 3000m, "Samsung", "Galaxy S21"),
                new Kitap("1984", 80m, "George Orwell"),
                new Elektronik("Laptop", 5000m, "Apple", "MacBook Air")
            };

            // Ürün bilgilerini ve ödenecek tutarları yazdırma
            Console.WriteLine("Mağaza Ürünleri:\n");
            foreach (var urun in urunler)
            {
                urun.BilgiYazdir();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
