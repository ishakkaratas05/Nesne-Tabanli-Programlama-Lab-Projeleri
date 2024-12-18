using System;

namespace BankaYonetimSistemi
{
    // IBankaHesabi Arayüzü
    interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }

    // Soyut Hesap sınıfı
    abstract class Hesap : IBankaHesabi
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; protected set; }
        public DateTime HesapAcilisTarihi { get; set; }

        public Hesap(string hesapNo, decimal bakiye)
        {
            HesapNo = hesapNo;
            Bakiye = bakiye;
            HesapAcilisTarihi = DateTime.Now;
        }

        public abstract void ParaYatir(decimal miktar);
        public abstract void ParaCek(decimal miktar);

        public virtual void HesapOzeti()
        {
            Console.WriteLine($"Hesap No: {HesapNo}, Bakiye: {Bakiye} TL, Açılış Tarihi: {HesapAcilisTarihi}");
        }
    }

    // BirikimHesabi sınıfı
    class BirikimHesabi : Hesap
    {
        public decimal FaizOrani { get; set; }

        public BirikimHesabi(string hesapNo, decimal bakiye, decimal faizOrani)
            : base(hesapNo, bakiye)
        {
            FaizOrani = faizOrani;
        }

        public override void ParaYatir(decimal miktar)
        {
            decimal faiz = miktar * FaizOrani / 100;
            Bakiye += miktar + faiz;
            Console.WriteLine($"{miktar} TL yatırıldı. Eklenen faiz: {faiz} TL. Güncel bakiye: {Bakiye} TL");
        }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }
    }

    // VadesizHesap sınıfı
    class VadesizHesap : Hesap
    {
        public decimal IslemUcreti { get; set; }

        public VadesizHesap(string hesapNo, decimal bakiye, decimal islemUcreti)
            : base(hesapNo, bakiye)
        {
            IslemUcreti = islemUcreti;
        }

        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL");
        }

        public override void ParaCek(decimal miktar)
        {
            decimal toplamCekim = miktar + IslemUcreti;
            if (Bakiye >= toplamCekim)
            {
                Bakiye -= toplamCekim;
                Console.WriteLine($"{miktar} TL çekildi. Uygulanan işlem ücreti: {IslemUcreti} TL. Güncel bakiye: {Bakiye} TL");
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
            // Birikim Hesabı oluşturma
            BirikimHesabi birikimHesabi = new BirikimHesabi("BIR123", 1000m, 5m);
            birikimHesabi.ParaYatir(500m);
            birikimHesabi.ParaCek(300m);
            birikimHesabi.HesapOzeti();

            Console.WriteLine();

            // Vadesiz Hesap oluşturma
            VadesizHesap vadesizHesap = new VadesizHesap("VAD123", 2000m, 10m);
            vadesizHesap.ParaYatir(1000m);
            vadesizHesap.ParaCek(1500m);
            vadesizHesap.HesapOzeti();

            Console.ReadKey();
        }
    }
}

