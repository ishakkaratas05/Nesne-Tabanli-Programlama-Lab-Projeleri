using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru2
{
    class ProgramSoru2
    {
        static void Main(string[] args)
        {

            // Kullanıcıdan matrisin boyutunu al
            Console.Write("Matrisin boyutunu giriniz (N): ");
            int n = Convert.ToInt32(Console.ReadLine());

            // NxN boyutunda iki matris tanımla
            int[,] A = new int[n, n];
            int[,] B = new int[n, n];

            // İlk matrisin elemanlarını kullanıcıdan al
            Console.WriteLine("1. Matrisin elemanlarını giriniz:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"A[{i},{j}]: "); // Eleman için konumu belirt
                    A[i, j] = Convert.ToInt32(Console.ReadLine()); // Kullanıcıdan eleman al
                }
            }

            // İkinci matrisin elemanlarını kullanıcıdan al
            Console.WriteLine("2. Matrisin elemanlarını giriniz:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"B[{i},{j}]: "); // Eleman için konumu belirt
                    B[i, j] = Convert.ToInt32(Console.ReadLine()); // Kullanıcıdan eleman al
                }
            }

            // Çarpım matrisini tanımla
            int[,] C = new int[n, n];

            // Matris çarpımını hesapla
            for (int i = 0; i < n; i++) // A matrisinin satırları için döngü
            {
                for (int j = 0; j < n; j++) // B matrisinin sütunları için döngü
                {
                    C[i, j] = 0; // Başlangıçta çarpım sonucunu sıfırla
                    for (int k = 0; k < n; k++) // A[i][k] ve B[k][j] çarpımını topla
                    {
                        C[i, j] += A[i, k] * B[k, j]; // Çarpım işlemi
                    }
                }
            }

            // Çarpım sonucunu ekrana yazdır
            Console.WriteLine("Çarpım Matrisinin Sonucu:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(C[i, j] + "\t"); // Elemanları aralarına tab koyarak yazdır
                }
                Console.WriteLine(); // Her satırdan sonra yeni satıra geç
            }

            Console.ReadKey(); // Programın bitişinde bir tuşa basmayı bekle

        }
    }
}
