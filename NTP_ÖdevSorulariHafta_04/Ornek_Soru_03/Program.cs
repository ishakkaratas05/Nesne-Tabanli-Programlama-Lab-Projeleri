using System;

public class KiralikArac
{
    public string Plaka { get; private set; }
    public decimal GunlukUcret { get; private set; }
    public bool MusaitMi { get; private set; }

    // Yapıcı metot: Plaka ve günlük ücretle başlatılır, MusaitMi varsayılan olarak true olmalı
    public KiralikArac(string plaka, decimal gunlukUcret)
    {
        Plaka = plaka;
        GunlukUcret = gunlukUcret;
        MusaitMi = true; // Başlangıçta araç müsait
    }

    // Aracı kiralama metodu: Araç müsaitse kiralanabilir, değilse işlem yapılmaz
    public void AraciKirala()
    {
        if (MusaitMi)
        {
            MusaitMi = false; // Araç kiralandı, müsait değil
            Console.WriteLine($"{Plaka} plakalı araç kiralandı.");
        }
        else
        {
            Console.WriteLine($"{Plaka} plakalı araç şu anda müsait değil.");
        }
    }

    // Aracı teslim etme metodu: Araç teslim edildiğinde müsait duruma geçer
    public void AraciTeslimEt()
    {
        if (!MusaitMi)
        {
            MusaitMi = true; // Araç teslim edildi, müsait duruma geçiyor
            Console.WriteLine($"{Plaka} plakalı araç teslim alındı ve tekrar müsait.");
        }
        else
        {
            Console.WriteLine($"{Plaka} plakalı araç zaten müsait durumda.");
        }
    }

    // Günlük ücretin gösterilmesi
    public void UcretGoster()
    {
        Console.WriteLine($"Araç: {Plaka}, Günlük Ücret: {GunlukUcret} TL");
    }
}

class Program
{
    static void Main()
    {
        // Kullanıcıdan araç plakası ve günlük ücret bilgisi alınıyor
        Console.Write("Araç Plakasını Girin: ");
        string plaka = Console.ReadLine();

        Console.Write("Günlük Kiralama Ücretini Girin: ");
        decimal gunlukUcret = decimal.Parse(Console.ReadLine());

        // Yeni bir araç nesnesi oluşturuluyor
        KiralikArac arac = new KiralikArac(plaka, gunlukUcret);

        // Araç bilgileri gösteriliyor
        arac.UcretGoster();

        // Araç kiralama işlemi
        arac.AraciKirala();

        // Araç teslim etme işlemi
        arac.AraciTeslimEt();

        // Ekranın açık kalması için
        Console.Read();
    }
}
