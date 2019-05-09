using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 
Geliştiren: Halit IZGIN(Ready)
Web Site: http://www.kodevreni.com
İletişim: ready@kodevreni.com
Not: Bu uygulama ön lisans projesi olarak tasarlanmıştır. Access veritabanı kullanıldığından
dolayı pratik kullanıma uzak yapıdadır. Uygulama ticari amaçlı tasarlanmamıştır. Ticari amaçlı
olarak kullanılması yasaktır. Yalnızca öğrenmek amaçlı geliştirilmeye ve yayınlamaya(kaynak belirterek)
açıktır.

*/

namespace CafeOtomasyon
{
    public partial class SiparisOzetForm : Form
    {
        public SiparisOzetForm()
        {
            InitializeComponent();
        }

        public int MasaNo = 0;

        public string BoslukKoy(int boslukSayisi, string metin)
        {
            string onEk = "";
            for (int i = 0; i < boslukSayisi + 12; i++)
            {
                onEk += " ";
            }
            return onEk + metin;
        }

        private void SiparisOzetForm_Load(object sender, EventArgs e)
        {
            decimal toplam = 0;
            int enBuyuk = 0;
            List<Siparis> siparisler = CafeDB.Masalar.MasaOzetiCikar(MasaNo);
            foreach (Siparis siparis in siparisler)
            {
                string metin = siparis.SiparisAdet + " adet " + siparis.SiparisUrun.UrunAdi + " ürün ücreti = " + (siparis.SiparisAdet * siparis.SiparisUrun.UrunUcret) + "(" + siparis.SiparisUrun.UrunUcret + ") ₺";
                if (metin.Length > enBuyuk)
                    enBuyuk = metin.Length;
                textBox1.Text += metin + "\r\n";
                toplam += (siparis.SiparisAdet * siparis.SiparisUrun.UrunUcret);
            }
            textBox1.Text += "\r\n";
            string son = "Toplam = " + toplam + " ₺";
            textBox1.Text += BoslukKoy(enBuyuk, son);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
