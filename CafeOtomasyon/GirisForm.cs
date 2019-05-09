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
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void girisButton_Click(object sender, EventArgs e)
        {
            GirisVeri giris = CafeDB.Kullanicilar.Giris(passTextBox.Text.Trim(), userTextBox.Text.Trim());
            switch(giris.Yetki)
            {
                case 1:
                    GarsonForm garson = new GarsonForm();
                    garson.Show();
                    garson.KullaniciID = giris.ID;
                    break;
                case 2:
                    MutfakForm mutfak = new MutfakForm();
                    mutfak.Show();
                    mutfak.KullaniciID = giris.ID;
                    break;
                case 3:
                    KasaForm kasa = new KasaForm();
                    kasa.Show();
                    kasa.KullaniciID = giris.ID;
                    break;
                case 4:
                    YoneticiForm yonetici = new YoneticiForm();
                    yonetici.Show();
                    yonetici.KullaniciID = giris.ID;
                    break;
                default:
                    MessageBox.Show("Giriş başarısız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                    break;
            }
            this.Hide();
        }

        private void GirisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu yazılım Çukurova Üniversitesi Adana Meslek Yüksekokulu öğrencileri tarafından proje amaçlı geliştirilmiştir.\nDağıtılması, kullanılması ve geliştirilmesi ücretsizdir.\n\nGeliştirme Ekibi:\nHalit IZGIN\nBatuhan ACAR\nMuhammed DENİZOĞLU\n\nBu projede ACCESS veritabanı sistemi kullanılmıştır.", "Restaurant/Cafe Otomasyon v1.0.0.0 Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        char c = (char)0x2022;

        private void GirisForm_Load(object sender, EventArgs e)
        {
            passTextBox.PasswordChar = c;
        }

        bool gorunme = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (gorunme)
            {
                button1.BackgroundImage = Properties.Resources.visible;
                passTextBox.PasswordChar = c;
            }
            else
            {
                button1.BackgroundImage = Properties.Resources.invisible;
                passTextBox.PasswordChar = userTextBox.PasswordChar;
            }
            gorunme = !gorunme;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LogoPanel_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Bu yazılım Halit IZGIN(Ready) tarafından örnek amaçlı tasarlanmıştır.\nUygulamanın ticari amaçlı kullanılmasına izin verilmemektedir!\nDaha fazla bilgi ve iletişim için: http://www.kodevreni.com adresini ziyaret edin.\nİletişim İçin E-Posta: ready@kodevreni.com\nSiteyi ziyaret etmek ister misiniz?", "Hakkımızda", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sonuc == DialogResult.Yes)
                System.Diagnostics.Process.Start("http://www.kodevreni.com");
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Bu yazılım Halit IZGIN(Ready) tarafından örnek amaçlı tasarlanmıştır.\nUygulamanın ticari amaçlı kullanılmasına izin verilmemektedir!\nDaha fazla bilgi ve iletişim için: http://www.kodevreni.com adresini ziyaret edin.\nİletişim İçin E-Posta: ready@kodevreni.com\nSiteyi ziyaret etmek ister misiniz?", "Hakkımızda", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sonuc == DialogResult.Yes)
                System.Diagnostics.Process.Start("http://www.kodevreni.com");
        }
    }
}
