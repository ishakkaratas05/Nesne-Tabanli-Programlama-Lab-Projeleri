using System;

namespace Calisan_Departman
{
    class Departman
    {
        public string Ad { get; set; }
        public string Lokasyon { get; set; }

        public Departman(string ad, string lokasyon)
        {
            Ad = ad;
            Lokasyon = lokasyon;
        }
    }

    class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Departman Departman { get; set; } // Çalışanın departmanı

        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        public void DepartmanAtama(Departman departman)
        {
            Departman = departman;
            Console.WriteLine($"{Ad} adlı çalışan {departman.Ad} departmanına atandı.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Departman oluştur
            Departman yazilimDepartmani = new Departman("Yazılım", "İstanbul");
            Departman insanKaynaklari = new Departman("İnsan Kaynakları", "Ankara");

            // Çalışan oluştur
            Calisan calisan1 = new Calisan("Ali Veli", "Yazılım Geliştirici");
            Calisan calisan2 = new Calisan("Ayşe Kaya", "İK Uzmanı");

            // Çalışanları departmanlara ata
            calisan1.DepartmanAtama(yazilimDepartmani);
            calisan2.DepartmanAtama(insanKaynaklari);

            // Çalışan bilgilerini yazdır
            Console.WriteLine($"\nÇalışan: {calisan1.Ad}, Pozisyon: {calisan1.Pozisyon}, Departman: {calisan1.Departman.Ad}, Lokasyon: {calisan1.Departman.Lokasyon}");
            Console.WriteLine($"Çalışan: {calisan2.Ad}, Pozisyon: {calisan2.Pozisyon}, Departman: {calisan2.Departman.Ad}, Lokasyon: {calisan2.Departman.Lokasyon}");

            // Ekranın açık kalmasını sağla
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
