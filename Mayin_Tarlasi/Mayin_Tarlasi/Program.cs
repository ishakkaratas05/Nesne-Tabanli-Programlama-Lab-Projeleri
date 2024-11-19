using System;
using System.Collections.Generic;

namespace Mayin_Tarlasi
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BOYUT = 20; // 20x20 oyun alanı
            const int MAYIN_SAYISI = 50; // Yerleştirilecek mayın sayısı

            char[,] alan = new char[BOYUT, BOYUT];
            bool[,] gorunenAlan = new bool[BOYUT, BOYUT];
            List<(int satir, int sutun)> secilenKonumlar = new List<(int, int)>(); // Seçilen konumları saklamak için liste

            MayinlariOlustur(alan, MAYIN_SAYISI);
            MayinSayilariniHesapla(alan);

            bool oyunDevamEdiyor = true;

            while (oyunDevamEdiyor)
            {
                Console.Clear();
                AlaniGoster(alan, gorunenAlan, secilenKonumlar); // Seçilen konumları göster
                Console.Write("Satır seç (0-19): ");
                int satir = int.Parse(Console.ReadLine());
                Console.Write("Sütun seç (0-19): ");
                int sutun = int.Parse(Console.ReadLine());

                secilenKonumlar.Add((satir, sutun)); // Yeni seçilen konumu listeye ekle

                if (alan[satir, sutun] == 'M')
                {
                    Console.Clear();
                    AlaniGoster(alan, gorunenAlan, secilenKonumlar, true); // Tüm alanı aç
                    Console.WriteLine("Mayına bastınız! Oyun bitti!");
                    oyunDevamEdiyor = false;
                }
                else
                {
                    AcikAlanlariAc(satir, sutun, alan, gorunenAlan);
                }
            }

            Console.WriteLine("Oyunu bitirmek için bir tuşa basın...");
            Console.ReadKey(); // Konsol ekranı açık kalır
        }

        static void MayinlariOlustur(char[,] alan, int mayinSayisi)
        {
            Random rand = new Random();
            int yerlestirilenMayin = 0;
            int boyut = alan.GetLength(0);

            while (yerlestirilenMayin < mayinSayisi)
            {
                int x = rand.Next(boyut);
                int y = rand.Next(boyut);

                if (alan[x, y] != 'M')
                {
                    alan[x, y] = 'M';
                    yerlestirilenMayin++;
                }
            }
        }

        static void MayinSayilariniHesapla(char[,] alan)
        {
            int boyut = alan.GetLength(0);

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (alan[i, j] != 'M')
                    {
                        int sayi = 0;
                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                int yeniX = i + x;
                                int yeniY = j + y;
                                if (yeniX >= 0 && yeniX < boyut && yeniY >= 0 && yeniY < boyut && alan[yeniX, yeniY] == 'M')
                                {
                                    sayi++;
                                }
                            }
                        }
                        alan[i, j] = sayi == 0 ? ' ' : sayi.ToString()[0];
                    }
                }
            }
        }

        static void AlaniGoster(char[,] alan, bool[,] gorunenAlan, List<(int satir, int sutun)> secilenKonumlar, bool hepsiniAc = false)
        {
            int boyut = alan.GetLength(0);

            // Sütun başlıklarını hizalı şekilde yazdır
            Console.Write("    "); // Satır başlıkları için boşluk bırak
            for (int i = 0; i < boyut; i++)
            {
                Console.Write(i.ToString("D2") + " ");
            }
            Console.WriteLine();

            Console.WriteLine("   " + new string('-', boyut * 3)); // Üst çizgi

            for (int i = 0; i < boyut; i++)
            {
                Console.Write(i.ToString("D2") + " | "); // Satır başlığı
                for (int j = 0; j < boyut; j++)
                {
                    // Seçilen konumları göster
                    if (secilenKonumlar.Contains((i, j)))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow; // Seçilen alanları vurgula
                    }

                    if (gorunenAlan[i, j] || hepsiniAc)
                    {
                        Console.Write(alan[i, j] + "  ");
                    }
                    else
                    {
                        Console.Write("#  ");
                    }

                    if (secilenKonumlar.Contains((i, j)))
                    {
                        Console.ResetColor(); // Arka plan rengini sıfırla
                    }
                }
                Console.WriteLine();
            }
        }

        static void AcikAlanlariAc(int satir, int sutun, char[,] alan, bool[,] gorunenAlan)
        {
            int boyut = alan.GetLength(0);

            if (satir < 0 || sutun < 0 || satir >= boyut || sutun >= boyut || gorunenAlan[satir, sutun])
            {
                return;
            }

            gorunenAlan[satir, sutun] = true;

            if (alan[satir, sutun] == ' ')
            {
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        AcikAlanlariAc(satir + x, sutun + y, alan, gorunenAlan);
                    }
                }
            }
        }
    }
}
