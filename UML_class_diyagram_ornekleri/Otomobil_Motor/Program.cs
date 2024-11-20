using System;

namespace Otomobil_Motor
{
    class Motor
    {
        private int Guç { get; set; } // Motor gücü (beygir gücü - HP)
        public string Tip { get; set; } // Motor tipi (örneğin benzinli, dizel)

        public Motor(int guc, string tip)
        {
            Guç = guc;
            Tip = tip;
        }

        public void MotorBilgisi()
        {
            Console.WriteLine($"Motor Gücü: {Guç} HP, Motor Tipi: {Tip}");
        }
    }

    class Otomobil
    {
        public string Marka { get; set; }
        public Motor Motor { get; private set; }

        public Otomobil(string marka)
        {
            Marka = marka;
        }

        public void MotorOlustur(int guc, string tip)
        {
            Motor = new Motor(guc, tip);
            Console.WriteLine($"'{Marka}' otomobiline motor eklendi: {guc} HP, {tip}");
        }

        public void OtomobilBilgisi()
        {
            Console.WriteLine($"\nOtomobil Markası: {Marka}");
            Console.Write("Motor Detayları: ");
            Motor.MotorBilgisi();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Otomobil oluştur
            Otomobil otomobil = new Otomobil("Toyota");

            // Motor oluştur ve otomobile ekle
            otomobil.MotorOlustur(150, "Benzinli");

            // Otomobil bilgilerini yazdır
            otomobil.OtomobilBilgisi();

            // Programın açık kalması için beklet
            Console.WriteLine("\nÇıkmak için bir tuşa bas...");
            Console.ReadKey();
        }
    }
}
