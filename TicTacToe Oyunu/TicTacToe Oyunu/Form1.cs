using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_Oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Oyuncuları temsil eden enum
        public enum oyuncular
        {
            X, O
        }

        oyuncular oyuncuX; // Şu anki oyuncuyu tutan değişken
        int oyuncu = 0; // Oyuncunun skorunu tutan değişken
        int bilgisayar = 0; // Bilgisayarın skorunu tutan değişken
        Random random = new Random(); // Rastgele sayı üretmek için random nesnesi
        List<Button> butonlar; // Oyundaki butonları tutan liste

        // Oyuncu butona tıkladığında çalışan metot
        private void button1_Click(object sender, EventArgs e)
        {
            oyuncuTikla(sender, e);
            oyunKontrol();
        }

        // Form yüklendiğinde çalışan metot
        private void Form1_Load(object sender, EventArgs e)
        {
            yenile();
        }

        // Bilgisayarın hareket süresi için çalışan metot
        private void OyuncuSüre(object sender, EventArgs e)
        {
            if (butonlar.Count > 0)
            {
                int index = random.Next(butonlar.Count); // Rastgele bir buton seç
                butonlar[index].Enabled = false;
                oyuncuX = oyuncular.O;
                butonlar[index].Text = oyuncuX.ToString();
                butonlar[index].BackColor = Color.Bisque;
                butonlar.RemoveAt(index); // Seçilen butonu listeden çıkar
                oyunKontrol();
                pcZamanlayıcı.Stop();
            }
        }

        // Yenile butonuna tıklandığında çalışan metot
        private void yenileButon(object sender, EventArgs e)
        {
            yenile();
        }

        // Oyuncu butona tıkladığında çalışan metot
        private void oyuncuTikla(object sender, EventArgs e)
        {
            var button = (Button)sender;
            oyuncuX = oyuncular.X;
            button.Text = oyuncuX.ToString();
            button.Enabled = false;
            button.BackColor = Color.SkyBlue;
            butonlar.Remove(button); // Tıklanan butonu listeden çıkar
            oyunKontrol();
            pcZamanlayıcı.Start();
        }

        // Butonları yenilemek için kullanılan metot
        private void yenile()
        {
            // Tüm butonları listeye ekle
            butonlar = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            // Her butonun özelliklerini varsayılana ayarla
            foreach (Button x in butonlar)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }

        // Oyunun kazanma durumunu kontrol eden metot
        private void oyunKontrol()
        {
            // Oyuncu kazandı mı kontrolü
            bool oyuncuKazandi = (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                                  || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                                  || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                                  || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                                  || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                                  || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                                  || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                                  || button3.Text == "X" && button5.Text == "X" && button7.Text == "X");

            // Bilgisayar kazandı mı kontrolü
            bool bilgisayarKazandi = (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                                      || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                                      || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                                      || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                                      || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                                      || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                                      || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                                      || button3.Text == "O" && button5.Text == "O" && button7.Text == "O");

            if (oyuncuKazandi)
            {
                pcZamanlayıcı.Stop();
                MessageBox.Show("Kazanan Oyuncu");
                oyuncu++;
                label1.Text = "Oyuncu : " + oyuncu;
                yenile();
            }
            else if (bilgisayarKazandi)
            {
                pcZamanlayıcı.Stop();
                MessageBox.Show("Kazanan Bilgisayar");
                bilgisayar++;
                label2.Text = "Bilgisayar : " + bilgisayar;
                yenile();
            }
        }
    }
}

