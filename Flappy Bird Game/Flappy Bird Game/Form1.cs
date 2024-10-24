using System;
using System.Windows.Forms;

namespace Flappy_Bird_Game
{
    public partial class Form1 : Form
    {
        // Oyunla ilgili değişkenler
        int boruHizi = 8; // Boruların başlangıç hızı
        int yerCekimi = 10; // Kuşa yer çekimi etkisi
        int oyunSkoru = 0; // Oyuncunun skoru
        public Form1()
        {
            InitializeComponent();// Form elemanlarını başlatır
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Oyun zamanlayıcısının olaylarını yönetir
        private void oyunSayaciOlaylari(object sender, EventArgs e)
        {
            ucanKus.Top += yerCekimi; // Kuşun dikey hareketini yer çekimine göre ayarla
            alttakiBoru.Left -= boruHizi; // Alt borunun sola doğru hareketi
            üsttekiBoru.Left -= boruHizi; // Üst borunun sola doğru hareketi
            // Skoru günceller
            skorMetni.Text = "Oyun Skoru : " + oyunSkoru;
            // Alt boru ekrandan çıktığında yerini sıfırla ve skor artır
            if (alttakiBoru.Left < -150)
            {
                alttakiBoru.Left = 800;
                oyunSkoru++;
            }
            // Üst boru ekrandan çıktığında yerini sıfırla
            if (üsttekiBoru.Left < -180)
            {
                üsttekiBoru.Left = 950;
            }
            // Kuşun borulara veya zemine çarpıp çarpmadığını kontrol et

            if (ucanKus.Bounds.IntersectsWith(alttakiBoru.Bounds)|| ucanKus.Bounds.IntersectsWith(üsttekiBoru.Bounds)|| ucanKus.Bounds.IntersectsWith(Zemin.Bounds))
            {
                oyunBitir();// Çarpışma varsa oyunu bitir
            }
            // Skor 5'i geçince boru hızını artır
            if (oyunSkoru > 5)
            {
                boruHizi = 15;// Boruların hızını artır
            }
        }
        // Space tuşuna basıldığında kuşu yukarı hareket ettirir
        private void asagiOyunTusu(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                yerCekimi = -10;// Kuşu yukarı hareket ettir
            }
        }
        // Space tuşu bırakıldığında kuş aşağı hareket eder
        private void yukariOyunTusu(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                yerCekimi = 10;// Kuşu aşağı doğru çek
            }

        }
        // Oyun bittiğinde yapılacak işlemler
        private void oyunBitir()
        {
            oyunSayaci.Stop(); // Oyun sayaçını durduruyoruz
            skorMetni.Text = "Oyunu Kaybettiniz. Skorunuz: " + oyunSkoru; // Skoru gösteriyoruz

            // Oyun kaybedildiğinde bir mesaj kutusu çıkarıyoruz
            MessageBox.Show("Oyunu Kaybettiniz. Skorunuz: " + oyunSkoru, "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Zemin_Click(object sender, EventArgs e)
        {

        }

        private void üsttekiBoru_Click(object sender, EventArgs e)
        {

        }
    }
}
