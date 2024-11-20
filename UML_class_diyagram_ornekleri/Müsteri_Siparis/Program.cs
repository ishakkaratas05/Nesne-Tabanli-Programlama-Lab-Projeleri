using System;

namespace Musteri_Siparis
{
    class Siparis
    {
        public DateTime Tarih { get; set; }
        public string Durum { get; set; }

        public Siparis()
        {
            Tarih = DateTime.Now; // Sipariş oluşturulduğunda tarih otomatik atanır.
            Durum = "Hazırlanıyor"; // Varsayılan durum
        }

        public void SiparisBilgisi()
        {
            Console.WriteLine($"Sipariş Tarihi: {Tarih}, Durum: {Durum}");
        }
    }

    class Musteri
    {
        public string Ad { get; set; }
        public string Telefon { get; set; }

        public Musteri(string ad, string telefon)
        {
            Ad = ad;
            Telefon = telefon;
        }

        public Siparis SiparisVer()
        {
            Siparis yeniSiparis = new Siparis();
            Console.WriteLine($"{Ad} adlı müşteri sipariş verdi.");
            return yeniSiparis;
        }
    }

    class Program
    {
        static void Main()
        {
            // Müşteri oluştur
            Musteri musteri1 = new Musteri("Ahmet Kaya", "0555 123 4567");

            // Müşteri sipariş versin
            Siparis siparis1 = musteri1.SiparisVer();

            // Sipariş bilgilerini yazdır
            siparis1.SiparisBilgisi();

            // Ekranın açık kalmasını sağla
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
