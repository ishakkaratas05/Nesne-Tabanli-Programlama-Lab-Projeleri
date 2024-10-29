using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekSoru_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sayilar = new List<int>();

            // Kullanıcıdan sayıları alıyoruz
            Console.WriteLine("Sayıları girin (0 ile sonlandırın):");
            while (true)
            {
                // Kullanıcıdan bir sayı al
                int sayi = int.Parse(Console.ReadLine());
                if (sayi == 0) break;  // 0 girildiğinde döngüden çıkıyoruz
                sayilar.Add(sayi);  // Sayıyı listeye ekliyoruz
            }

            List<string> gruplar = new List<string>();

            // Liste boş değilse ardışık grupları aramaya başlıyoruz
            if (sayilar.Count > 0)
            {
                // İlk grubu başlatıyoruz
                int baslangic = sayilar[0];
                int onceki = sayilar[0];

                for (int i = 1; i < sayilar.Count; i++)
                {
                    // Eğer sayı bir önceki sayıdan 1 fazlaysa, ardışık olduğunu belirliyoruz
                    if (sayilar[i] == onceki + 1)
                    {
                        // Sayı ardışık, bir şey yapmamıza gerek yok
                        onceki = sayilar[i];  // Önceki sayıyı güncelliyoruz
                    }
                    else
                    {
                        // Grup sona erdi, grubu listeye ekle
                        if (baslangic == onceki)
                            gruplar.Add(baslangic.ToString());  // Tekil sayı ise sadece sayıyı ekle
                        else
                            gruplar.Add($"{baslangic}-{onceki}");  // Ardışık grup ise aralığı ekle

                        // Yeni bir grup başlat
                        baslangic = sayilar[i];  // Yeni grup başlangıcı
                        onceki = sayilar[i];      // Önceki sayıyı güncelliyoruz
                    }
                }
                // Son grubu da listeye ekleyelim
                if (baslangic == onceki)
                    gruplar.Add(baslangic.ToString());  // Tekil sayı ise sadece sayıyı ekle
                else
                    gruplar.Add($"{baslangic}-{onceki}");  // Ardışık grup ise aralığı ekle
            }

            // Grupları ekrana yazdır
            Console.WriteLine("Ardışık sayı grupları:");
            foreach (var grup in gruplar)
            {
                Console.WriteLine(grup);  // Her bir grup için grubu ekrana yazdırıyoruz
            }

            Console.Read();
        }
    }
}
