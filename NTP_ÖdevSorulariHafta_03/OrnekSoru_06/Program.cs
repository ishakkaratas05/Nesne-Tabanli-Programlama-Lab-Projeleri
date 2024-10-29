using System;
using System.Collections.Generic;

namespace OrnekSoru_06
{
    class Program
    {
        static void Main(string[] args)
        {
            // Geçerli tarihleri saklamak için bir liste oluşturuyoruz
            List<string> gecerliTarihler = new List<string>();

            // 2000 ile 3000 yılları arasında döngü
            for (int yil = 2000; yil <= 3000; yil++)
            {
                // 1 ile 12 arasında ay döngüsü
                for (int ay = 1; ay <= 12; ay++)
                {
                    // O yıl ve ay için gün sayısını alıyoruz
                    int ayınGunSayisi = DateTime.DaysInMonth(yil, ay);

                    // Gün döngüsü
                    for (int gun = 1; gun <= ayınGunSayisi; gun++)
                    {
                        // Gün, ay ve yıl koşullarını kontrol ediyoruz
                        if (AsalMi(gun) && AyGecerliliği(ay) && YilGecerliliği(yil))
                        {
                            // Uygun tarihi listeye ekliyoruz
                            gecerliTarihler.Add($"{gun:00}/{ay:00}/{yil}");
                        }
                    }
                }
            }

            // Şu andan sonraki geçerli tarihleri yazdırma
            DateTime simdi = DateTime.Now;
            foreach (var tarih in gecerliTarihler)
            {
                DateTime gecerliTarih = DateTime.Parse(tarih);
                // Geçerli tarih şu andan büyükse yazdırıyoruz
                if (gecerliTarih > simdi)
                {
                    Console.WriteLine(gecerliTarih.ToString("dd/MM/yyyy"));
                }
            }

            // Konsolun hemen kapanmaması için kullanıcıdan bir girdi bekliyoruz
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadLine();
        }

        // Asal sayı kontrol fonksiyonu
        static bool AsalMi(int sayi)
        {
            if (sayi <= 1) return false; // 1 ve daha küçük sayılar asal değildir
            for (int i = 2; i <= Math.Sqrt(sayi); i++)
            {
                if (sayi % i == 0) return false; // Tam bölen varsa asal değildir
            }
            return true; // Asal sayıdır
        }

        // Ayın basamak toplamının çift olup olmadığını kontrol eden fonksiyon
        static bool AyGecerliliği(int ay)
        {
            int toplam = 0;
            while (ay > 0)
            {
                toplam += ay % 10; // Ayın basamaklarını topluyoruz
                ay /= 10; // Bir basamağı çıkarıyoruz
            }
            return toplam % 2 == 0; // Toplam çift mi?
        }

        // Yılın rakamları toplamının yılın dörtte birinden küçük olup olmadığını kontrol eden fonksiyon
        static bool YilGecerliliği(int yil)
        {
            int toplam = 0;
            int geçiciYil = yil;
            while (geçiciYil > 0)
            {
                toplam += geçiciYil % 10; // Yılın basamaklarını topluyoruz
                geçiciYil /= 10; // Bir basamağı çıkarıyoruz
            }
            return toplam < (yil / 4); // Toplam, yılın dörtte birinden küçük mü?
        }
    }
}
