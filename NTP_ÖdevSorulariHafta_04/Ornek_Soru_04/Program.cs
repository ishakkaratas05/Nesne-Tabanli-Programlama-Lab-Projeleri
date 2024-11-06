using System;

public class Kisi
{
    public string Ad { get; private set; }
    public string Soyad { get; private set; }
    public string TelefonNumarasi { get; private set; }

    // Yapıcı metot: Ad, soyad ve telefon numarası ile başlatılır
    public Kisi(string ad, string soyad, string telefonNumarasi)
    {
        Ad = ad;
        Soyad = soyad;
        TelefonNumarasi = telefonNumarasi;
    }

    // KisiBilgisi metodu: Kişinin tam adı ve telefon numarasını döndürür
    public void KisiBilgisi()
    {
        Console.WriteLine($"Adı: {Ad} {Soyad}, Telefon Numarası: {TelefonNumarasi}");
    }
}

class Program
{
    static void Main()
    {
        // Kullanıcıdan kişinin adı, soyadı ve telefon numarasını alıyoruz
        Console.Write("Adınızı Girin: ");
        string ad = Console.ReadLine();

        Console.Write("Soyadınızı Girin: ");
        string soyad = Console.ReadLine();

        Console.Write("Telefon Numaranızı Girin: ");
        string telefon = Console.ReadLine();

        // Yeni bir Kisi nesnesi oluşturuluyor
        Kisi kisi = new Kisi(ad, soyad, telefon);

        // Kişinin bilgilerini ekrana yazdırıyoruz
        kisi.KisiBilgisi();

        // Ekranın açık kalması için
        Console.Read();
    }
}
