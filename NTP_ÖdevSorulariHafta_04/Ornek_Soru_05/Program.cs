using System;
using System.Collections.Generic;

public class Kitap
{
    public string Ad { get; private set; }
    public string Yazar { get; private set; }

    // Kitap sınıfının yapıcı metodu
    public Kitap(string ad, string yazar)
    {
        Ad = ad;
        Yazar = yazar;
    }

    // Kitap bilgilerini ekrana yazdırma
    public void KitapBilgisi()
    {
        Console.WriteLine($"Kitap Adı: {Ad}, Yazar: {Yazar}");
    }
}

public class Kutuphane
{
    public List<Kitap> Kitaplar { get; private set; }

    // Yapıcı metot: Kitap listesi boş olarak başlatılır
    public Kutuphane()
    {
        Kitaplar = new List<Kitap>();
    }

    // Kitap ekleme metodu: Kitap, kütüphaneye ekleniyor
    public void KitapEkle(Kitap yeniKitap)
    {
        this.Kitaplar.Add(yeniKitap);  // this kullanarak kütüphaneye ait olduğunu belirtiyoruz
        Console.WriteLine($"{yeniKitap.Ad} adlı kitap kütüphaneye eklendi.");
    }

    // Kitapları listeleme metodu: Tüm kitaplar ekrana yazdırılır
    public void KitaplariListele()
    {
        Console.WriteLine("\nKütüphanedeki Kitaplar:");
        foreach (var kitap in Kitaplar)
        {
            kitap.KitapBilgisi();
        }
    }
}

class Program
{
    static void Main()
    {
        // Yeni bir kütüphane nesnesi oluşturuluyor
        Kutuphane kutuphane = new Kutuphane();

        // Kullanıcıdan kitap adı ve yazar bilgisi alınıyor
        Console.Write("Kitap Adı Girin: ");
        string kitapAd = Console.ReadLine();

        Console.Write("Yazar Adı Girin: ");
        string yazarAd = Console.ReadLine();

        // Yeni bir kitap nesnesi oluşturuluyor
        Kitap yeniKitap = new Kitap(kitapAd, yazarAd);

        // Kitap kütüphaneye ekleniyor
        kutuphane.KitapEkle(yeniKitap);

        // Kitapları listeleme
        kutuphane.KitaplariListele();

        // Ekranın açık kalması için
        Console.Read();
    }
}
