using System;
using System.Collections.Generic;

namespace ObserverDesignPattern
{
    // IYayinci arayüzü
    public interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikar(IAbone abone);
        void BildirimGonder(string mesaj);
    }

    // IAbone arayüzü
    public interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    // Yayinci sınıfı
    public class Yayinci : IYayinci
    {
        private List<IAbone> aboneler = new List<IAbone>();

        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
            Console.WriteLine("Yeni bir abone eklendi.");
        }

        public void AboneCikar(IAbone abone)
        {
            aboneler.Remove(abone);
            Console.WriteLine("Bir abone çıkarıldı.");
        }

        public void BildirimGonder(string mesaj)
        {
            Console.WriteLine($"Yayıncı mesaj gönderiyor: {mesaj}");
            foreach (var abone in aboneler)
            {
                abone.BilgiAl(mesaj);
            }
        }
    }

    // Abone sınıfı
    public class Abone : IAbone
    {
        public string Ad { get; }

        public Abone(string ad)
        {
            Ad = ad;
        }

        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"{Ad} adlı aboneye mesaj ulaştı: {mesaj}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Yayıncı oluştur
            Yayinci yayinci = new Yayinci();

            // Aboneler oluştur
            Abone abone1 = new Abone("Ahmet");
            Abone abone2 = new Abone("Elif");
            Abone abone3 = new Abone("Mehmet");

            // Aboneleri ekle
            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.AboneEkle(abone3);

            // Yayıncıdan bildirim gönder
            yayinci.BildirimGonder("Yeni bir makale yayınlandı!");

            Console.WriteLine();

            // Bir aboneyi çıkar ve tekrar bildirim gönder
            yayinci.AboneCikar(abone2);
            yayinci.BildirimGonder("Güncelleme: Makale düzenlendi.");

            Console.ReadKey();
        }
    }
}
