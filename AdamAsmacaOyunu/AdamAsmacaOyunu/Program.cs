using System;

namespace AdamAsmacaOyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Oyun için kelime havuzu
            string[] kelimelerimiz = { "ANKARA", "ELAZIĞ", "ARTVİN", "MUĞLA", "BURSA", "İSTANBUL", "AFYON", "İZMİR" };

            // Rastgele kelime seçimi için Random nesnesi oluşturuyoruz
            Random rastgeleSec = new Random();
            string secilenKelime = kelimelerimiz[rastgeleSec.Next(0, kelimelerimiz.Length)]; // Kelime listesinden rastgele bir kelime seç

            // Oyunda kullanılacak değişkenler
            int denemeHakki = 5; // Kullanıcının yanlış tahmin yapabileceği deneme hakkı sayısı
            bool oyunBitti = false; // Oyunun bitip bitmediğini kontrol eden bayrak

            // Seçilen kelimenin uzunluğu kadar boşluk oluşturma
            char[] karakter = new char[secilenKelime.Length]; // Harflerin yerleştirileceği karakter dizisi
            for (int i = 0; i < karakter.Length; i++)
            {
                karakter[i] = '_'; // Başlangıçta tüm harflerin yerine alt çizgi (_) koyar
            }

            // Oyunun ana döngüsü
            do
            {
                bool harfDogru = false; // Kullanıcının girdiği harfin kelimede bulunup bulunmadığını kontrol etmek için

                // Mevcut durumdaki kelimeyi ekrana yazdır
                Console.WriteLine("Kelimeyi tahmin et : ");
                foreach (var eleman in karakter)
                {
                    Console.Write(eleman + " "); // Kelimenin bilinmeyen harflerini alt çizgi ile göster
                }

                // Kullanıcıdan bir harf girmesini iste
                Console.WriteLine();
                Console.WriteLine("Lütfen bir harf giriniz: ");
                char harf = Convert.ToChar(Console.ReadLine().ToUpper()); // Kullanıcıdan alınan harfi büyük harfe dönüştür

                // Girilen harfin seçilen kelimede olup olmadığını kontrol et
                for (int i = 0; i < secilenKelime.Length; i++)
                {
                    if (harf == secilenKelime[i]) // Harf kelimede bulunuyorsa
                    {
                        karakter[i] = harf; // Doğru tahmin edilen harfi yerleştir
                        harfDogru = true; // Doğru harf bulunduğunu işaretle
                    }
                }

                // Eğer harf doğru tahmin edilmediyse deneme hakkını azalt
                if (!harfDogru)
                {
                    denemeHakki--; // Yanlış tahmin yapıldığı için kalan hak azalır
                    Console.WriteLine("Yanlış tahmin! Kalan deneme hakkınız: " + denemeHakki);
                }

                // Kelimenin tamamının doğru tahmin edilip edilmediğini kontrol et
                if (!Array.Exists(karakter, element => element == '_')) // Alt çizgi kalmadıysa
                {
                    oyunBitti = true; // Oyun bitti olarak işaretle
                    Console.WriteLine("\nTebrikler! Kelimeyi doğru tahmin ettiniz: " + secilenKelime);
                }

                // Kullanıcının deneme hakları tükendiğinde oyunu sona erdir
                if (denemeHakki == 0)
                {
                    oyunBitti = true; // Oyun bitti olarak işaretle
                    Console.WriteLine("\nKaybettiniz! Doğru kelime: " + secilenKelime);
                }

            } while (!oyunBitti); // Oyun bitene kadar döngü devam eder

            Console.WriteLine("Oyun bitti. Tekrar oynamak için programı yeniden başlatın."); // Oyun sona erdi mesajı
            Console.ReadKey(); // Program kapanmadan önce bir tuşa basılmasını bekle
        }
    }
}
