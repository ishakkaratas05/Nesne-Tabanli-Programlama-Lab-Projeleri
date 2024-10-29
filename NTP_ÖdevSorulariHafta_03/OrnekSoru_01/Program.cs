using System;

namespace OrnekSoru_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan kaç adet sayı gireceğini istiyoruz.
            Console.Write("Kaç adet sayı gireceksiniz?: ");
            int n = int.Parse(Console.ReadLine()); // Kullanıcının girdiği sayıyı 'n' değişkenine atıyoruz.

            // 'n' kadar tam sayı depolamak için bir dizi oluşturuyoruz.
            int[] sayilar = new int[n];

            // Kullanıcıdan 'n' kadar tam sayı girmesini sağlıyoruz.
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}. sayıyı girin: "); // Kullanıcıdan sayı girmesi isteniyor.
                sayilar[i] = int.Parse(Console.ReadLine()); // Girilen sayıyı dizinin ilgili indeksine atıyoruz.
            }

            // Diziyi sıralıyoruz. 
            Array.Sort(sayilar);
            // Sıralanmış diziyi ekrana yazdırıyoruz.
            Console.WriteLine("Sıralanmış dizi: " + string.Join(", ", sayilar));

            // Kullanıcıdan aramak istediği sayıyı alıyoruz.
            Console.Write("Aramak istediğiniz sayıyı girin: ");
            int arananSayi = int.Parse(Console.ReadLine()); // Girilen aranan sayıyı 'arananSayi' değişkenine atıyoruz.

            // İkili arama algoritmasını kullanarak sayının dizide olup olmadığını kontrol ediyoruz.
            bool bulunduMu = IkiliArama(sayilar, arananSayi);

            // Sonucu ekrana yazdırıyoruz.
            if (bulunduMu)
            {
                Console.WriteLine($"{arananSayi} sayısı dizide bulunuyor.");
            }
            else
            {
                Console.WriteLine($"{arananSayi} sayısı dizide bulunmuyor.");
            }

            Console.Read();
        }

        // İkili arama algoritmasını tanımlıyoruz. 'dizi' sıralı dizi, 'aranan' ise aramak istediğimiz sayı.
        static bool IkiliArama(int[] dizi, int aranan)
        {
            // Arama yapılacak dizinin başlangıç ve bitiş indekslerini tanımlıyoruz.
            int sol = 0; // Dizinin en solundaki indeks
            int sag = dizi.Length - 1; // Dizinin en sağındaki indeks

            // Sol indeks sağ indeksten küçük veya eşit olduğu sürece döngü devam eder.
            while (sol <= sag)
            {
                // Ortadaki indeksi buluyoruz.
                int orta = (sol + sag) / 2;

                // Eğer ortadaki değer aranan sayıya eşitse, aranan sayıyı bulmuşuz demektir.
                if (dizi[orta] == aranan)
                {
                    return true; // Sayı bulundu, true döndürüyoruz.
                }
                // Eğer ortadaki değer aranan sayıdan küçükse, aranan sayı sağ yarıda olmalı.
                else if (dizi[orta] < aranan)
                {
                    sol = orta + 1; // Sol indeksi ortanın bir sağına kaydırıyoruz.
                }
                // Eğer ortadaki değer aranan sayıdan büyükse, aranan sayı sol yarıda olmalı.
                else
                {
                    sag = orta - 1; // Sağ indeksi ortanın bir soluna kaydırıyoruz.
                }
            }
            return false; // Sayı bulunamadı, false döndürüyoruz.
        }
    }
}
