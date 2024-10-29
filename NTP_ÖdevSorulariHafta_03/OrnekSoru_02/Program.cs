using System;
using System.Collections.Generic;

namespace OrnekSoru_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sayıları saklamak için bir liste oluşturuyoruz
            List<int> sayilar = new List<int>();

            // Girilen sayıların toplamını tutacak değişken
            int toplam = 0;

            // Kullanıcıdan alınacak sayıyı tutacak geçici değişken
            int sayi;

            // Kullanıcıdan girdi alıyoruz, 0 girene kadar döngü devam ediyor
            do
            {
                Console.Write("Pozitif bir tam sayı girin (0 ile çıkış): ");
                sayi = Convert.ToInt32(Console.ReadLine());

                // Sadece pozitif sayıları işleme alıyoruz
                if (sayi > 0)
                {
                    // Pozitif sayıyı listeye ekliyoruz
                    sayilar.Add(sayi);

                    // Toplamı güncelliyoruz
                    toplam += sayi;
                }
            } while (sayi != 0); // Kullanıcı 0 girerse döngü sona eriyor

            // Liste boş değilse ortalamayı hesapla; boşsa 0 olarak ayarla
            double ortalama = sayilar.Count > 0 ? (double)toplam / sayilar.Count : 0;

            // Medyanı hesaplayacağımız değişken
            double medyan;

            // Listeyi küçükten büyüğe sıralıyoruz
            sayilar.Sort();

            // Çift veya tek eleman sayısına göre medyan hesaplama
            if (sayilar.Count % 2 == 0) // Çift sayıda eleman varsa
            {
                // Ortadaki iki değerin ortalamasını alıyoruz
                medyan = (sayilar[sayilar.Count / 2 - 1] + sayilar[sayilar.Count / 2]) / 2.0;
            }
            else // Tek sayıda eleman varsa
            {
                // Tam ortadaki elemanı medyan olarak alıyoruz
                medyan = sayilar[sayilar.Count / 2];
            }

            // Sonuçları ekrana yazdırıyoruz
            Console.WriteLine($"Ortalama: {ortalama}");
            Console.WriteLine($"Medyan: {medyan}");


            Console.Read();
        }
    }
}
