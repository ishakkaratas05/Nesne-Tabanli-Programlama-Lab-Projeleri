using System;
using System.Collections.Generic;

namespace OrnekSoru_10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Örnek sayı dizisi
            List<int> sayilar = new List<int> { 4, 2, 3 };
            List<string> operatörler = new List<string> { "+", "-", "*", "/" };

            List<string> geçerliİfadeler = new List<string>();
            GenerateExpressions(sayilar, operatörler, "", 0, 0, geçerliİfadeler);

            Console.WriteLine("Geçerli İfadeler:");
            foreach (var ifade in geçerliİfadeler)
            {
                Console.WriteLine(ifade);
            }

            Console.Read();
        }

        static void GenerateExpressions(List<int> sayilar, List<string> operatörler, string currentExpression, int lastNumberIndex, int depth, List<string> geçerliİfadeler)
        {
            // İfadeyi tamamladıysak ve sonuç pozitifse ekle
            if (depth == sayilar.Count - 1)
            {
                int result = Evaluate(currentExpression + sayilar[depth]);
                if (result > 0)
                {
                    geçerliİfadeler.Add(currentExpression + sayilar[depth]);
                }
                return;
            }

            // Sayı ekleyin
            if (depth == 0)
            {
                GenerateExpressions(sayilar, operatörler, sayilar[depth].ToString(), depth, depth + 1, geçerliİfadeler);
            }
            else
            {
                foreach (var op in operatörler)
                {
                    // Son sayının ardından bir operatör eklemeden önce kontrol et
                    GenerateExpressions(sayilar, operatörler, currentExpression + sayilar[depth - 1] + op, depth, depth + 1, geçerliİfadeler);
                }
            }
        }

        static int Evaluate(string expression)
        {
            // Basit bir ifade değerlendirme işlemi (C#'ta "DataTable" kullanarak)
            var dataTable = new System.Data.DataTable();
            return Convert.ToInt32(dataTable.Compute(expression, ""));
        }
    }
}
