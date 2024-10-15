using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru1
{
    class ProgramSoru1
    {
        static void Main(string[] args)
        {

            // Kullanıcıdan matris boyutunu alalım
            Console.Write("Matris boyutunu giriniz (N): ");
            int n = Convert.ToInt32(Console.ReadLine());

            // NxN matrisini tanımlayalım
            int[,] matrix = new int[n, n];

            // Başlangıç değeri ve sınır değişkenlerini ayarlayalım
            int deger = 1; // Matrise yazılacak başlangıç değeri
            int ust = 0, alt = n - 1, sol = 0, sag = n - 1;

            // Spiral matris doldurma
            while (deger <= n * n) // Matris tamamen dolana kadar devam et
            {
                // Üst sırayı soldan sağa doğru doldur
                for (int i = sol; i <= sag; i++)
                {
                    matrix[ust, i] = deger++;
                }
                ust++; // Üst sınırı bir satır aşağıya kaydır

                // Sağ sütunu yukarıdan aşağıya doğru doldur
                for (int i = ust; i <= alt; i++)
                {
                    matrix[i, sag] = deger++;
                }
                sag--; // Sağ sınırı bir sütun sola kaydır

                // Alt sırayı sağdan sola doğru doldur
                for (int i = sag; i >= sol; i--)
                {
                    matrix[alt, i] = deger++;
                }
                alt--; // Alt sınırı bir satır yukarıya kaydır

                // Sol sütunu aşağıdan yukarıya doğru doldur
                for (int i = alt; i >= ust; i--)
                {
                    matrix[i, sol] = deger++;
                }
                sol++; // Sol sınırı bir sütun sağa kaydır
            }

            // Matrisin ekrana yazdırılması
            Console.WriteLine("Spiral Matris:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4)); // Elemanları düzgün hizalayarak yazdır
                }
                Console.WriteLine(); // Her satırdan sonra yeni bir satıra geç
            }

            // Kullanıcı bir tuşa bastığında programdan çık
            Console.ReadKey();

        }
    }
}
