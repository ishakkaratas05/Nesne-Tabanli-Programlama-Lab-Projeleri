using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru3
{
    class ProgramSoru3
    {
        // Bir sayının asal olup olmadığını kontrol eden fonksiyon
        static bool AsalMi(int sayi)
        {
            if (sayi <= 1) return false; // 1 ve daha küçük sayılar asal değildir
            for (int i = 2; i <= Math.Sqrt(sayi); i++)
            {
                if (sayi % i == 0) // Eğer sayı i'ye tam bölünüyorsa asal değildir
                {
                    return false; // Sayı asal değil
                }
            }
            return true; // Sayı asal
        }

        static void Main(string[] args)
        {
            // Kullanıcıdan N değerini al
            Console.Write("N sayısını giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int toplam = 0; // Asal sayıların toplamını tutacak değişken

            // 2'den N'e kadar olan sayıları kontrol et
            for (int i = 2; i <= n; i++)
            {
                if (AsalMi(i)) // Eğer i asal ise
                {
                    toplam += i; // Toplama ekle
                }
            }

            // Sonucu ekrana yazdır
            Console.WriteLine("0 ile " + n + " arasındaki asal sayıların toplamı: " + toplam);

            Console.ReadKey(); // Programın bitişinde bir tuşa basmayı bekle
        }
    }
}
