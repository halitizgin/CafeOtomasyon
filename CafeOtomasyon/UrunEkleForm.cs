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
    public partial class UrunEkleForm : Form
    {
        public UrunEkleForm()
        {
            InitializeComponent();
        }

        public bool UrunGuncelle = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string urunAdi = textBox1.Text.Trim();
            double urunUcret = Convert.ToDouble(numericUpDown1.Value);
            if (urunAdi != "" && urunUcret > 0)
            {
                CafeDB.Urunler.UrunEkle(urunAdi, urunUcret);
                UrunGuncelle = true;
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
