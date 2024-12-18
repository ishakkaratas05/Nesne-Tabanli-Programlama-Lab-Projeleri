using System;

namespace BankaSistemi
{
    // Temel Hesap sınıfı
    class Hesap
    {
        public string HesapNo { get; set; }
        public string HesapSahibi { get; set; }
        public double Bakiye { get; set; }

        public virtual void ParaYatir(double miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL hesaba yatırıldı. Güncel bakiye: {Bakiye} TL");
        }

        public virtual void ParaCek(double miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL hesaptan çekildi. Güncel bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap No: {HesapNo}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye} TL");
        }
    }

    // VadesizHesap sınıfı
    class VadesizHesap : Hesap
    {
        public double EkHesapLimiti { get; set; }

        public override void ParaCek(double miktar)
        {
            if (Bakiye + EkHesapLimiti >= miktar)
            {
                if (Bakiye >= miktar)
                {
                    Bakiye -= miktar;
                }
                else
                {
                    double kalanMiktar = miktar - Bakiye;
                    Bakiye = 0;
                    EkHesapLimiti -= kalanMiktar;
                }
                Console.WriteLine($"{miktar} TL hesaptan çekildi. Güncel bakiye: {Bakiye} TL, Kalan ek hesap limiti: {EkHesapLimiti} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti!");
            }
        }
    }

    // VadeliHesap sınıfı
    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; }
        public double FaizOrani { get; set; }

        public override void ParaCek(double miktar)
        {
            if (VadeSuresi > 0)
            {
                Console.WriteLine("Vade dolmadan para çekemezsiniz!");
            }
            else if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL hesaptan çekildi. Güncel bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap türünü seçin (1: Vadesiz Hesap, 2: Vadeli Hesap): ");
            int secim = int.Parse(Console.ReadLine());
            Hesap hesap;

            if (secim == 1)
            {
                hesap = new VadesizHesap();
                Console.Write("Hesap No: ");
                hesap.HesapNo = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                hesap.Bakiye = double.Parse(Console.ReadLine());
                Console.Write("Ek Hesap Limiti: ");
                ((VadesizHesap)hesap).EkHesapLimiti = double.Parse(Console.ReadLine());
            }
            else if (secim == 2)
            {
                hesap = new VadeliHesap();
                Console.Write("Hesap No: ");
                hesap.HesapNo = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                hesap.Bakiye = double.Parse(Console.ReadLine());
                Console.Write("Vade Süresi (gün): ");
                ((VadeliHesap)hesap).VadeSuresi = int.Parse(Console.ReadLine());
                Console.Write("Faiz Oranı (%): ");
                ((VadeliHesap)hesap).FaizOrani = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Program sonlandırılıyor.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nİşlem seçin: (1: Para Yatır, 2: Para Çek, 3: Bilgi Yazdır, 4: Çıkış)");
                int islem = int.Parse(Console.ReadLine());

                if (islem == 1)
                {
                    Console.Write("Yatırılacak miktar: ");
                    double miktar = double.Parse(Console.ReadLine());
                    hesap.ParaYatir(miktar);
                }
                else if (islem == 2)
                {
                    Console.Write("Çekilecek miktar: ");
                    double miktar = double.Parse(Console.ReadLine());
                    hesap.ParaCek(miktar);
                }
                else if (islem == 3)
                {
                    hesap.BilgiYazdir();
                }
                else if (islem == 4)
                {
                    Console.WriteLine("Program sonlandırılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz işlem!");
                }
            }
            Console.Read();
        }
    }
}
