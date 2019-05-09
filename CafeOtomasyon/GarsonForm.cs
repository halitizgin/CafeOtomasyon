using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class GarsonForm : Form
    {
        public GarsonForm()
        {
            InitializeComponent();
        }

        public int KullaniciID = 0;

        public void MasalariYerlestir()
        {
            int masaSayisi = CafeDB.Masalar.MasalariYerlestir();
            for (int i = 1; i <= masaSayisi; i++)
            {
                Button button = new Button();
                button.Size = new Size(100, 150);
                button.Name = "Masa" + i;
                button.ContextMenuStrip = contextMenuStrip1;
                button.Click += Button_Click;
                button.MouseUp += Button_MouseUp;
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        GarsonBildirimForm garsonBildirim = new GarsonBildirimForm();

        private void GarsonForm_Load(object sender, EventArgs e)
        {
            Erisim = DateTime.Now;
            MasalariYerlestir();
            MasalariGuncelle();
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button button = (Button)sender;
                contextMenuStrip1.Items[0].Text = button.Name;
            }
        }

        public void MasalariGuncelle()
        {
            List<Masa> masalar = CafeDB.Masalar.MasalariGuncelle();
            for (int i = 0; i < masalar.Count; i++)
            {
                Button button = (Button)flowLayoutPanel1.Controls[i];
                decimal masaUcret = CafeDB.Masalar.MasaBorcHesapla(masalar[i].MasaNo);
                button.Tag = masaUcret;
                button.ForeColor = Color.White;
                button.Text = masalar[i].MasaNo + "\n\n" + masaUcret + " ₺";
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Cursor = Cursors.Hand;
                if (masalar[i].MasaDurum)
                    button.BackColor = Color.FromArgb(117, 1, 1);
                else
                    button.BackColor = Color.FromArgb(46, 139, 87);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            
        }

        private void GarsonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Oturum Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                garsonBildirim.Hide();
                GirisForm giris = new GirisForm();
                giris.Show();
            }
            else
                e.Cancel = true;
        }

        DateTime Erisim;

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }
        SiparisEkleForm ekle = new SiparisEkleForm();
        SiparisGoruntule goruntule = new SiparisGoruntule();
        private void siparişEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string isim = masaNoToolStripMenuItem.Text;
            int no = int.Parse(isim.Replace("Masa", ""));
            ekle.MasaNo = no;
            ekle.KullaniciID = KullaniciID;
            ekle.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }
        private void siparişleriGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string isim = masaNoToolStripMenuItem.Text;
            int no = int.Parse(isim.Replace("Masa", ""));
            goruntule.MasaNo = no;
            goruntule.KullaniciID = KullaniciID;
            goruntule.ShowDialog();
        }

        private void masaTaşıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int masaNo = Convert.ToInt32(masaNoToolStripMenuItem.Text.Replace("Masa", ""));
            MasaTasiForm masaTasi = new MasaTasiForm();
            masaTasi.MasaNo = masaNo;
            masaTasi.KullaniciID = KullaniciID;
            masaTasi.EskiMasa = masaNo;
            masaTasi.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo("Cafe.accdb");
            DateTime sonErisim = info.LastWriteTime;
            if (sonErisim != Erisim)
            {
                int suanMasaSayisi = flowLayoutPanel1.Controls.Count;
                int masaSayisi = CafeDB.Masalar.MasalariYerlestir();
                if (suanMasaSayisi != masaSayisi)
                {
                    flowLayoutPanel1.Controls.Clear();
                    MasalariYerlestir();
                    Erisim = sonErisim;
                }
                else
                {
                    MasalariGuncelle();
                    Erisim = sonErisim;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GarsonForm_Shown(object sender, EventArgs e)
        {
            garsonBildirim.KullaniciID = KullaniciID;
            garsonBildirim.Show();
            garsonBildirim.Location = new Point(this.Location.X + this.Size.Width - 10, this.Location.Y);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Oturum Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                garsonBildirim.Hide();
                GirisForm giris = new GirisForm();
                giris.Show();
            }
        }
    }
}
