using System;
using System.Collections;
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
    public partial class SiparisEkleForm : Form
    {
        public SiparisEkleForm()
        {
            InitializeComponent();
        }

        public int MasaNo = 0;
        public bool MasalariGuncelle = false;
        public int KullaniciID = 0;

        private void SiparisEkleForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            label3.Text = "\"" + MasaNo + "\" Nolu Masa Sipariş Ekleme";
            List<Urun> urunler = CafeDB.Urunler.UrunListe();
            foreach (Urun item in urunler)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.DataSource = urunler;
            comboBox1.ValueMember = "UrunID";
            comboBox1.DisplayMember = "UrunAdi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int siparisUrun = Convert.ToInt32(comboBox1.SelectedValue);
            int siparisAdet = Convert.ToInt32(numericUpDown1.Value);
            CafeDB.Siparisler.SiparisEkle(siparisUrun, siparisAdet, MasaNo);
            CafeDB.Masalar.MasaDurumDegistir(MasaNo, true);
            MasalariGuncelle = true;
            CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Sipariş Eklendi->" + comboBox1.Text + ", " + MasaNo + " nolu masaya, " + numericUpDown1.Value + " adet.");
            this.Hide();
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
