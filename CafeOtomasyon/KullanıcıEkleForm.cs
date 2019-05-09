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
    public partial class KullanıcıEkleForm : Form
    {
        public KullanıcıEkleForm()
        {
            InitializeComponent();
        }

        public bool KullaniciGuncelle = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici = textBox2.Text.Trim();
            string sifre = textBox1.Text.Trim();
            byte yetki = Convert.ToByte(comboBox1.SelectedIndex);
            if (kullanici != "" && sifre != "")
            {
                CafeDB.Kullanicilar.KullaniciEkle(kullanici, sifre, yetki);
                KullaniciGuncelle = true;
                this.Hide();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
