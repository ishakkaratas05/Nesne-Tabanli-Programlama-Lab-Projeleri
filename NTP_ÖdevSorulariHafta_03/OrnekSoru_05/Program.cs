using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OrnekSoru_05
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("İlk polinomu girin (exit ile çıkın): ");
                string polinom1 = Console.ReadLine();
                if (polinom1.ToLower() == "exit") break;

                Console.WriteLine("İkinci polinomu girin: ");
                string polinom2 = Console.ReadLine();
                if (polinom2.ToLower() == "exit") break;

                var sonucToplama = PolinomTopla(polinom1, polinom2);
                var sonucCikarma = PolinomCikar(polinom1, polinom2);

                Console.WriteLine($"Toplam: {sonucToplama}");
                Console.WriteLine($"Çıkarma: {sonucCikarma}");
            }
        }

        static string PolinomTopla(string polinom1, string polinom2)
        {
            var terimler1 = ParsePolinom(polinom1);
            var terimler2 = ParsePolinom(polinom2);
            return Birleştir(terimler1, terimler2);
        }

        static string PolinomCikar(string polinom1, string polinom2)
        {
            var terimler1 = ParsePolinom(polinom1);
            var terimler2 = ParsePolinom(polinom2).Select(t => (-t.katsayi, t.derece)).ToList(); // İkinci polinomun terimlerinin katsayılarını negatif alıyoruz
            return Birleştir(terimler1, terimler2);
        }

        static List<(int katsayi, int derece)> ParsePolinom(string polinom)
        {
            var terimler = new List<(int katsayi, int derece)>();

            // Regex ile polinom terimlerini ayırma
            var matches = Regex.Matches(polinom.Replace(" ", ""), @"([+-]?\d*)x(?:\^(\d+))?|([+-]?\d+)");

            foreach (Match match in matches)
            {
                if (match.Groups[1].Success) // x terimi var
                {
                    int katsayi = string.IsNullOrEmpty(match.Groups[1].Value) || match.Groups[1].Value == "+" ? 1 :
                                  match.Groups[1].Value == "-" ? -1 : int.Parse(match.Groups[1].Value);
                    int derece = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) : 1;
                    terimler.Add((katsayi, derece));
                }
                else if (match.Groups[3].Success) // Sabit terim
                {
                    terimler.Add((int.Parse(match.Groups[3].Value), 0));
                }
            }

            return terimler;
        }

        static string Birleştir(List<(int katsayi, int derece)> terimler1, List<(int katsayi, int derece)> terimler2)
        {
            var birlesikTerimler = new Dictionary<int, int>();

            // İlk polinom terimlerini ekleyelim
            foreach (var terim in terimler1)
            {
                if (birlesikTerimler.ContainsKey(terim.derece))
                {
                    birlesikTerimler[terim.derece] += terim.katsayi;
                }
                else
                {
                    birlesikTerimler[terim.derece] = terim.katsayi;
                }
            }

            // İkinci polinom terimlerini ekleyelim
            foreach (var terim in terimler2)
            {
                if (birlesikTerimler.ContainsKey(terim.derece))
                {
                    birlesikTerimler[terim.derece] += terim.katsayi;
                }
                else
                {
                    birlesikTerimler[terim.derece] = terim.katsayi;
                }
            }

            // Sonucu string olarak oluşturma
            var sonuc = "";
            foreach (var terim in birlesikTerimler.OrderByDescending(t => t.Key))
            {
                if (terim.Value != 0) // Katsayı sıfır olmayan terimler
                {
                    if (sonuc != "" && terim.Value > 0) sonuc += "+";
                    sonuc += (terim.Value == 1 && terim.Key != 0) ? "" : (terim.Value == -1 && terim.Key != 0) ? "-" : terim.Value.ToString();
                    if (terim.Key > 0) sonuc += "x" + (terim.Key > 1 ? "^" + terim.Key : "");
                }
            }

            return sonuc;
        }
    }
}
