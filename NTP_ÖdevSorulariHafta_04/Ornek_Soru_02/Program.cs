using System;

public class Urun
{
    public string Ad { get; private set; }
    public decimal Fiyat { get; private set; }

    private decimal _indirim;

    // İndirim için get ve set metotları
    public decimal Indirim
    {
        get { return _indirim; }
        set
        {
            // İndirim %0 ile %50 arasında olmalı
            if (value >= 0 && value <= 50)
            {
                _indirim = value; // Geçerli indirim değeri atanıyor
            }
            else
            {
                Console.WriteLine("İndirim %0 ile %50 arasında olmalıdır.");
            }
        }
    }

    // Yapıcı metot: Ürün adı ve fiyatı ile başlatılır
    public Urun(string ad, decimal fiyat)
    {
        Ad = ad;
        Fiyat = fiyat;
        _indirim = 0; // Başlangıçta indirim 0
    }

    // İndirimli fiyatı döndüren metot
    public decimal IndirimliFiyat()
    {
        return Fiyat - (Fiyat * _indirim / 100); // İndirimli fiyat hesaplanıyor
    }
}

class Program
{
    static void Main()
    {
        // Kullanıcıdan ürün adı ve fiyatı alınıyor
        Console.Write("Ürün Adını Girin: ");
        string urunAd = Console.ReadLine();

        Console.Write("Ürün Fiyatını Girin: ");
        decimal urunFiyat = decimal.Parse(Console.ReadLine());

        // Yeni bir ürün oluşturuluyor
        Urun urun = new Urun(urunAd, urunFiyat);

        // Kullanıcıdan indirim oranı alınıyor
        Console.Write("İndirim Oranını Girin (0-50): ");
        decimal indirimOrani = decimal.Parse(Console.ReadLine());

        // İndirim oranı ayarlanıyor
        urun.Indirim = indirimOrani;

        // İndirimli fiyat hesaplanıp gösteriliyor
        decimal indirimliFiyat = urun.IndirimliFiyat();
        Console.WriteLine($"İndirimli Fiyat: {indirimliFiyat} TL");

        // Ekranın açık kalması için
        Console.Read();
    }
}
