using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class KasaForm : Form
    {
        public KasaForm()
        {
            InitializeComponent();
        }

        public int KullaniciID = -1;

        public void MasalariYerlestir()
        {
            int masalar = CafeDB.Masalar.MasalariYerlestir();
            for (int i = 1; i <= masalar; i++)
            {
                Button button = new Button();
                button.Size = new Size(100, 150);
                button.Name = "Masa" + i;
                button.Click += Button_Click;
                button.MouseUp += Button_MouseUp;
                button.ContextMenuStrip = contextMenuStrip1;
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            borçÖdeToolStripMenuItem.Enabled = true;
            masaTaşıToolStripMenuItem.Enabled = true;
            masayıBoşaltToolStripMenuItem.Enabled = true;
            masaÖzetiToolStripMenuItem.Enabled = true;
            if (e.Button == MouseButtons.Right)
            {
                Button button = (Button)sender;
                contextMenuStrip1.Items[0].Text = button.Name;
                if (Convert.ToInt32(button.Tag) == 0)
                {
                    borçÖdeToolStripMenuItem.Enabled = false;
                    masaÖzetiToolStripMenuItem.Enabled = false;
                }

                if (CafeDB.Masalar.MasalariYerlestir(true) == 0 || button.BackColor == Color.FromArgb(46, 139, 87))
                    masaTaşıToolStripMenuItem.Enabled = false;

                if (button.BackColor == Color.FromArgb(46, 139, 87))
                    masayıBoşaltToolStripMenuItem.Enabled = false;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            
        }
        
        DateTime Erisim;

        public void MasalariGuncelle()
        {
            List<Masa> masalar = CafeDB.Masalar.MasalariGuncelle();
            for (int i = 0; i < masalar.Count; i++)
            {
                Button button = (Button)flowLayoutPanel1.Controls[i];
                decimal masaUcret = CafeDB.Masalar.MasaBorcHesapla(masalar[i].MasaNo);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Tag = masaUcret;
                button.Cursor = Cursors.Hand;
                button.ForeColor = Color.White;
                button.Text = masalar[i].MasaNo + "\n\n" + masaUcret + " ₺";
                if (masalar[i].MasaDurum)
                    button.BackColor = Color.FromArgb(117, 1, 1);
                else
                    button.BackColor = Color.FromArgb(46, 139, 87);
            }
        }

        private void KasaForm_Load(object sender, EventArgs e)
        {
            Erisim = DateTime.Now;
            MasalariYerlestir();
            MasalariGuncelle();
        }

        private void KasaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Oturum Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GirisForm giris = new GirisForm();
                giris.Show();
            }
            else
                e.Cancel = true;
        }

        private void masaÖzetiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int masaNo = Convert.ToInt32(masaNoToolStripMenuItem.Text.Replace("Masa", ""));
            SiparisOzetForm ozet = new SiparisOzetForm();
            ozet.MasaNo = masaNo;
            ozet.ShowDialog();
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
                    MasalariGuncelle();
                    Erisim = sonErisim;
                }
                else
                {
                    MasalariGuncelle();
                    Erisim = sonErisim;
                }
            }
        }

        private void BorçÖdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int masaNo = Convert.ToInt32(masaNoToolStripMenuItem.Text.Replace("Masa", ""));
            DialogResult sonuc = MessageBox.Show("\"" + masaNo + "\" nolu masanın borcunu ödemek istediğinize emin misiniz?", "Borç Ödeme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                CafeDB.Masalar.MasaBorcOde(masaNo);
                CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Masa Ücret Ödendi->" + masaNo + " nolu masanın borcu ödendi.");
                MasalariGuncelle();
            }
        }

        private void masayıBoşaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int masaNo = Convert.ToInt32(masaNoToolStripMenuItem.Text.Replace("Masa", ""));
            DialogResult sonuc = MessageBox.Show("\"" + masaNo + "\" nolu masayı boşaltmak istediğinize emin misiniz?", "Borç Ödeme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                CafeDB.Masalar.MasayiBosalt(masaNo);
                CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Masa Ücret Ödendi->" + masaNo + " nolu masa boşaltıldı.");
                MasalariGuncelle();
            }
        }

        private void masaTaşıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int masaNo = Convert.ToInt32(masaNoToolStripMenuItem.Text.Replace("Masa", ""));
            MasaTasiForm masaTasi = new MasaTasiForm();
            masaTasi.MasaNo = masaNo;
            masaTasi.EskiMasa = masaNo;
            masaTasi.KullaniciID = KullaniciID;
            masaTasi.ShowDialog();
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
                GirisForm giris = new GirisForm();
                giris.Show();
            }
        }
    }
}
