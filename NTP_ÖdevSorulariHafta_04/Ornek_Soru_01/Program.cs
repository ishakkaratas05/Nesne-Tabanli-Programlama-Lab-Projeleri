using System;

public class BankaHesabi
{
    public string HesapNumarasi { get; private set; }
    private decimal Bakiye { get; set; }

    // Yapıcı metot: Hesap numarası ve başlangıç bakiyesi ile sınıf başlatılır
    public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
    {
        HesapNumarasi = hesapNumarasi; // Hesap numarası atanıyor
        Bakiye = ilkBakiye;            // Başlangıç bakiyesi atanıyor
    }

    // Para yatırma metodu: Pozitif miktar yatırıldığında bakiyeye ekleme yapılır
    public void ParaYatir(decimal miktar)
    {
        if (miktar > 0)
        {
            Bakiye += miktar; // Miktar bakiyeye ekleniyor
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni bakiye: {Bakiye} TL");
        }
        else
        {
            Console.WriteLine("Yatırılacak miktar pozitif olmalıdır."); // Hatalı giriş
        }
    }

    // Para çekme metodu: Yeterli bakiye varsa çekim yapılır, aksi takdirde hata mesajı gösterilir
    public void ParaCek(decimal miktar)
    {
        if (miktar > 0 && miktar <= Bakiye)
        {
            Bakiye -= miktar; // Miktar bakiyeden düşülüyor
            Console.WriteLine($"{miktar} TL çekildi. Yeni bakiye: {Bakiye} TL");
        }
        else if (miktar > Bakiye)
        {
            Console.WriteLine("Yetersiz bakiye."); // Bakiye yetersiz uyarısı
        }
        else
        {
            Console.WriteLine("Çekilecek miktar pozitif olmalıdır."); // Hatalı giriş
        }
    }

    // Bakiyeyi gösteren metot
    public void BakiyeGoster()
    {
        Console.WriteLine($"Hesap Numarası: {HesapNumarasi}, Bakiye: {Bakiye} TL");
    }
}

class Program
{
    static void Main()
    {
        // Kullanıcıdan hesap numarası ve başlangıç bakiyesi alınıyor
        Console.Write("Hesap Numarasını Girin: ");
        string hesapNumarasi = Console.ReadLine();

        Console.Write("Başlangıç Bakiyesini Girin: ");
        decimal ilkBakiye = decimal.Parse(Console.ReadLine()); // Kullanıcının girdiği bakiyeyi sayısal olarak alıyoruz

        // Banka hesabı oluşturuluyor
        BankaHesabi hesap = new BankaHesabi(hesapNumarasi, ilkBakiye);
        hesap.BakiyeGoster(); // Başlangıç bakiyesini ekrana yazdırıyoruz

        // Kullanıcıdan yatırılacak miktar alınıyor
        Console.Write("Yatırmak İstediğiniz Miktarı Girin: ");
        decimal yatirMiktar = decimal.Parse(Console.ReadLine()); // Kullanıcıdan yatacak miktar alınıyor
        hesap.ParaYatir(yatirMiktar); // Para yatırma işlemi yapılır

        // Kullanıcıdan çekilecek miktar alınıyor
        Console.Write("Çekmek İstediğiniz Miktarı Girin: ");
        decimal cekMiktar = decimal.Parse(Console.ReadLine()); // Kullanıcıdan çekilecek miktar alınıyor
        hesap.ParaCek(cekMiktar); // Para çekme işlemi yapılır

        // Ekranın açık kalması için
        Console.Read(); // Program sonlandığında ekranın kapanmaması için bekleme yapılır
    }
}
