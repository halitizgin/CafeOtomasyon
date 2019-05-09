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
    public partial class MasaTasiForm : Form
    {
        public MasaTasiForm()
        {
            InitializeComponent();
        }

        public int MasaNo = 0;
        public int KullaniciID = 0;
        public int EskiMasa = 0;

        public void MasalariListele()
        {
            comboBox1.Items.Clear();
            List<Masa> bosMasalar = CafeDB.Masalar.BosMasaListele();
            foreach (Masa masa in bosMasalar)
            {
                comboBox1.Items.Add("Masa " + masa.MasaNo);
            }
        }

        private void MasaTasiForm_Load(object sender, EventArgs e)
        {
            MasalariListele();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int sayi = comboBox1.Items.Count;
            int yeniSayi = CafeDB.Masalar.MasalariYerlestir(true);
            if (sayi != yeniSayi)
                MasalariListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int yeniMasa = Convert.ToInt32(comboBox1.Text.Replace("Masa ", ""));
            CafeDB.Masalar.MasaTasi(MasaNo, yeniMasa);
            CafeDB.Masalar.MasaDurumDegistir(MasaNo, false);
            CafeDB.Masalar.MasaDurumDegistir(yeniMasa, true);
            CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Masa Taşındı->" + EskiMasa + " nolu masadan " + yeniMasa + " nolu masaya taşındı.");
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
