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
using Microsoft.VisualBasic;
using Bunifu.Framework.UI;

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
    public partial class YoneticiForm : Form
    {
        public YoneticiForm()
        {
            InitializeComponent();
        }

        public int KullaniciID = -1;
        CiroUserControl ciroUserControl = new CiroUserControl();
        KullanicilarUserControl kullanicilarUserControl = new KullanicilarUserControl();
        UrunlerUserControl urunlerUserControl = new UrunlerUserControl();
        MasalarUserControl masalarUserControl = new MasalarUserControl();
        OptimizasyonUserControl optimizasyonUserControl = new OptimizasyonUserControl();
        DurumlarUserControl durumlarUserControl = new DurumlarUserControl();
        CikisUserControl cikisUserControl = new CikisUserControl();

        public void OlayYoneticisi()
        {
            ciroUserControl.gunlukCiroButton.Click += gunlukCiroButton_Click;
            ciroUserControl.aylikCiroButton.Click += aylikCiroButton_Click;
            ciroUserControl.yillikCiroButton.Click += yillikCiroButton_Click;

            kullanicilarUserControl.listView1.ContextMenuStrip = contextMenuStrip1;

            urunlerUserControl.listView2.ContextMenuStrip = contextMenuStrip2;

            masalarUserControl.flowLayoutPanel1.ContextMenuStrip = contextMenuStrip3;

            optimizasyonUserControl.temizleButton.Click += temizleButton_Click;
            optimizasyonUserControl.belirliCheckBox.OnChange += belirliCheckBox_OnChange;
            optimizasyonUserControl.tamamiCheckBox.OnChange += tamamiCheckBox_OnChange;

            cikisUserControl.bunifuFlatButton1.Click += bunifuFlatButton1_Click;
        }

        public void KullanicilariGuncelle()
        {
            kullanicilarUserControl.listView1.Items.Clear();
            List<Kullanici> kullanicilar = CafeDB.Kullanicilar.KullanicilariListele();
            foreach (Kullanici kullanici in kullanicilar)
            {
                int count = kullanicilarUserControl.listView1.Items.Count;
                kullanicilarUserControl.listView1.Items.Add(kullanici.KullaniciID.ToString());
                kullanicilarUserControl.listView1.Items[count].SubItems.Add(kullanici.KullaniciAdi);
                kullanicilarUserControl.listView1.Items[count].SubItems.Add(kullanici.Sifre);
                kullanicilarUserControl.listView1.Items[count].SubItems.Add(CafeDB.YetkiToString(kullanici.Yetki));
            }

            ListViewRenklendir();
        }

        public void UrunleriGuncelle()
        {
            urunlerUserControl.listView2.Items.Clear();
            List<Urun> urunler = CafeDB.Urunler.UrunListe();
            foreach (Urun urun in urunler)
            {
                int count = urunlerUserControl.listView2.Items.Count;
                urunlerUserControl.listView2.Items.Add(urun.UrunID.ToString());
                urunlerUserControl.listView2.Items[count].SubItems.Add(urun.UrunAdi);
                urunlerUserControl.listView2.Items[count].SubItems.Add(urun.UrunUcret.ToString());
            }

            ListViewRenklendir();
        }

        public void MasalariYerlestir()
        {
            masalarUserControl.flowLayoutPanel1.Controls.Clear();
            int masalar = CafeDB.Masalar.MasalariYerlestir();
            for (int i = 1; i <= masalar; i++)
            {
                Button button = new Button();
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.Size = new Size(80, 80);
                masalarUserControl.flowLayoutPanel1.Controls.Add(button);
            }
        }

        public void MasalariGuncelle()
        {
            List<Masa> masalar = CafeDB.Masalar.MasalariGuncelle();
            for (int i = 0; i < masalar.Count; i++)
            {
                Button button = (Button)masalarUserControl.flowLayoutPanel1.Controls[i];
                button.Text = masalar[i].MasaNo.ToString();
                button.Font = new Font("Century Gothic", 20);
                button.ForeColor = Color.White;
                if (masalar[i].MasaDurum)
                {
                    button.BackColor = Color.FromArgb(117, 1, 1);
                } 
                else
                {
                    button.BackColor = Color.FromArgb(46, 139, 87);
                } 
            }
        }

        public void IstatistikGuncelle()
        {
            double toplamCiro = CafeDB.Istatistik.ToplamCiro();
            ciroUserControl.toplamCiroLabel.Text = toplamCiro + " ₺";
            double genelCiro = 0;

            if (ciroUserControl.gunlukCiroButton.BackColor == Color.FromArgb(3, 110, 198))
                genelCiro = CafeDB.Istatistik.GunlukCiro();
            else if (ciroUserControl.aylikCiroButton.BackColor == Color.FromArgb(3, 110, 198))
                genelCiro = CafeDB.Istatistik.AylikCiro();
            else if (ciroUserControl.yillikCiroButton.BackColor == Color.FromArgb(3, 110, 198))
                genelCiro = CafeDB.Istatistik.YillikCiro();

            ciroUserControl.gunlukCiroLabel.Text = genelCiro + " ₺";
            int toplamSiparis = CafeDB.Istatistik.SiparisSayisi();
            ciroUserControl.toplamSiparisSayisiLabel.Text = toplamSiparis.ToString();
            /*int gunlukSiparis = CafeDB.Istatistik.GunlukSiparisSayisi();
            ciroUserControl.gunlukSiparisSayisiLabel.Text = gunlukSiparis.ToString();*/
            int tumMasaSayisi = CafeDB.Istatistik.TumMasaSayisi();
            ciroUserControl.toplamMasaSayisiLabel.Text = tumMasaSayisi.ToString();
            int doluMasaSayisi = CafeDB.Istatistik.DoluMasaSayisi();
            ciroUserControl.doluMasaSayisiLabel.Text = doluMasaSayisi.ToString();
            
        }

        public void LogYerlestir()
        {
            durumlarUserControl.flowLayoutPanel3.Controls.Clear();
            List<Rapor> raporlar = CafeDB.Log.LogListe();
            foreach (Rapor rapor in raporlar)
            {
                Kayit log = rapor.Kayit;
                GroupBox groupBox = new GroupBox();
                groupBox.Name = "Kullanici" + log.KayitID;
                groupBox.Size = new Size(this.Size.Width - 40, groupBox.Size.Height);
                FlowLayoutPanel flow = new FlowLayoutPanel();
                flow.Name = "flow";
                flow.FlowDirection = FlowDirection.TopDown;
                Label labelZaman = new Label();
                labelZaman.AutoSize = true;
                labelZaman.Name = "labelZaman";
                Label labelIslem = new Label();
                labelIslem.AutoSize = true;
                labelIslem.Name = "labelIslem";
                flow.Controls.Add(labelZaman);
                flow.Controls.Add(labelIslem);
                groupBox.Controls.Add(flow);
                flow.Dock = DockStyle.Fill;
                durumlarUserControl.flowLayoutPanel3.Controls.Add(groupBox);
            }
        }

        public void LogGuncelle()
        {
            durumlarUserControl.flowLayoutPanel3.BackColor = Color.FromArgb(150, 168, 168);
            List<Rapor> raporlar = CafeDB.Log.LogListe();
            foreach (Rapor rapor in raporlar)
            {
                Kayit log = rapor.Kayit;
                Kullanici kullanici = rapor.Kullanici;
                GroupBox control = durumlarUserControl.flowLayoutPanel3.Controls["Kullanici" + log.KayitID] as GroupBox;
                control.Font = new Font("Century Gothic", 16, FontStyle.Bold);
                control.Text = "#" + log.KayitID + " - " + kullanici.KullaniciAdi + "(" + CafeDB.YetkiToString(kullanici.Yetki) + ")";
                control.ForeColor = Color.FromArgb(41, 55, 65);
                FlowLayoutPanel flow = control.Controls["flow"] as FlowLayoutPanel;
                flow.Font = new Font("Century Gothic", 12, FontStyle.Regular);
                Label labelZaman = flow.Controls["labelZaman"] as Label;
                Label labelIslem = flow.Controls["labelIslem"] as Label;
                labelZaman.Text = log.KayitZaman.ToString();
                labelIslem.Text = log.KayitIslem;
            }
        }

        public void calendarBugunGuncelle()
        {
            /*TarihBilgi tarihBilgi = CafeDB.Istatistik.TarihBilgiVer(DateTime.Now);
            calendarGunlukLabel.Text = "Günlük Ciro: " + tarihBilgi.GunlukCiro + " ₺";
            calendarSiparisLabel.Text = "Sipariş Sayısı: " + tarihBilgi.SiparisSayisi;*/
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullanıcıEkleForm kullanici = new KullanıcıEkleForm();
            kullanici.ShowDialog();
            if (kullanici.KullaniciGuncelle)
                KullanicilariGuncelle();
        }

        private void YoneticiForm_Load(object sender, EventArgs e)
        {
            Erisim = DateTime.Now;
            OlayYoneticisi();
            KullanicilariGuncelle();
            UrunleriGuncelle();
            MasalariYerlestir();
            MasalariGuncelle();
            IstatistikGuncelle();
            LogYerlestir();
            LogGuncelle();
            calendarBugunGuncelle();
            AnaPanelYerlestir();
            ListViewRenklendir();
        }

        private void YoneticiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void AnaPanelYerlestir()
        {
            anaPanel.Controls.Add(ciroUserControl.flowLayoutPanel5);
            ciroUserControl.flowLayoutPanel5.Visible = true;
            ciroUserControl.flowLayoutPanel5.Dock = DockStyle.Fill;
        }

        private void ListViewRenklendir()
        {
            kullanicilarUserControl.listView1.ForeColor = Color.FromArgb(41, 55, 65);
            for (int i = 0; i < kullanicilarUserControl.listView1.Items.Count; i++)
            {
                if (i % 2 == 0)
                    kullanicilarUserControl.listView1.Items[i].BackColor = Color.White;
                else
                    kullanicilarUserControl.listView1.Items[i].BackColor = Color.FromArgb(150, 168, 168);
            }
            urunlerUserControl.listView2.ForeColor = Color.FromArgb(41, 55, 65);
            for (int i = 0; i < urunlerUserControl.listView2.Items.Count; i++)
            {
                if (i % 2 == 0)
                    urunlerUserControl.listView2.Items[i].BackColor = Color.White;
                else
                    urunlerUserControl.listView2.Items[i].BackColor = Color.FromArgb(150, 168, 168);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indis = kullanicilarUserControl.listView1.SelectedIndices[0];
            int id = Convert.ToInt32(kullanicilarUserControl.listView1.Items[indis].Text);
            DialogResult sonuc = MessageBox.Show("Silmek istediğinize emin misiniz?", "Kullanıcı Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                CafeDB.Kullanicilar.KullaniciSil(id);
                KullanicilariGuncelle();
            }
        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UrunEkleForm urunEkle = new UrunEkleForm();
            urunEkle.ShowDialog();
            if (urunEkle.UrunGuncelle)
                UrunleriGuncelle();
        }

        DateTime Erisim;

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int indis = urunlerUserControl.listView2.SelectedIndices[0];
            int id = Convert.ToInt32(urunlerUserControl.listView2.Items[indis].Text);
            DialogResult sonuc = MessageBox.Show("Silmek istediğinize emin misiniz?", "Ürün Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                CafeDB.Urunler.UrunSil(id);
                UrunleriGuncelle();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            sonMasayıSilToolStripMenuItem.Enabled = true;
            if (masalarUserControl.flowLayoutPanel1.Controls[masalarUserControl.flowLayoutPanel1.Controls.Count - 1].BackColor == Color.Red)
                sonMasayıSilToolStripMenuItem.Enabled = false;
        }

        private void sonaMasaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sonMasaNo = masalarUserControl.flowLayoutPanel1.Controls.Count;
            int eklenecekMasa = sonMasaNo + 1;
            DialogResult sonuc = MessageBox.Show("Sona masa eklemek istediğinize emin misiniz?", "Masa Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                CafeDB.Masalar.MasaEkle(eklenecekMasa);
                MasalariYerlestir();
                MasalariGuncelle();
            }
        }

        private void sonMasayıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sonMasaNo = masalarUserControl.flowLayoutPanel1.Controls.Count;
            DialogResult sonuc = MessageBox.Show("Son masayı silmek istediğinize emin misiniz?", "Masa Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                CafeDB.Masalar.MasaSil(sonMasaNo);
                MasalariYerlestir();
                MasalariGuncelle();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo("Cafe.accdb");
            DateTime sonErisim = info.LastWriteTime;
            if (sonErisim != Erisim)
            {
                if (CafeDB.Log.LogListe().Count != durumlarUserControl.flowLayoutPanel3.Controls.Count)
                    LogYerlestir();
                MasalariGuncelle();
                IstatistikGuncelle();
                LogGuncelle();
                Erisim = sonErisim;
            }
        }

        private void ürünAdıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indis = urunlerUserControl.listView2.SelectedIndices[0];
            int id = Convert.ToInt32(urunlerUserControl.listView2.Items[indis].Text);
            string urunAdi = urunlerUserControl.listView2.Items[indis].SubItems[1].Text;
            string yeniAdi = Interaction.InputBox("Yeni değeri giriniz: ", "Ürün Güncelle", urunAdi);
            if (yeniAdi.Trim() != "" && yeniAdi != "CANCEL")
            {
                CafeDB.Urunler.UrunGuncelle(id, yeniAdi);
                UrunleriGuncelle();
            }
        }

        private void ürünÜcretiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indis = urunlerUserControl.listView2.SelectedIndices[0];
            int id = Convert.ToInt32(urunlerUserControl.listView2.Items[indis].Text);
            UrunGuncelleForm guncelle = new UrunGuncelleForm();
            guncelle.SiparisNo = id;
            guncelle.numericUpDown1.Value = Convert.ToDecimal(urunlerUserControl.listView2.Items[indis].SubItems[2].Text);
            guncelle.ShowDialog();
            UrunleriGuncelle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void kullanıcıAdıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indis = kullanicilarUserControl.listView1.SelectedIndices[0];
            int id = Convert.ToInt32(kullanicilarUserControl.listView1.Items[indis].Text);
            string eskiDeger = kullanicilarUserControl.listView1.SelectedItems[0].SubItems[1].Text;
            string deger = Interaction.InputBox("Yeni Kullanıcı Adı Değerini Giriniz", "Kullanıcı Güncelle", eskiDeger, 50, 50);
            if (deger.Trim() != "")
            {
                CafeDB.Kullanicilar.KullaniciGuncelle(id, deger);
                KullanicilariGuncelle();
            }
        }

        private void şifreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indis = kullanicilarUserControl.listView1.SelectedIndices[0];
            int id = Convert.ToInt32(kullanicilarUserControl.listView1.Items[indis].Text);
            string deger = Interaction.InputBox("Yeni Kullanıcı Adı Değerini Giriniz", "Kullanıcı Güncelle", "", 50, 50);
            if (deger.Trim() != "")
            {
                CafeDB.Kullanicilar.KullaniciGuncelle(id, deger, CafeDB.Kullanicilar.GuncellemeTuru.Sifre);
                KullanicilariGuncelle();
            }
        }

        private void yetkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indis = kullanicilarUserControl.listView1.SelectedIndices[0];
            int id = Convert.ToInt32(kullanicilarUserControl.listView1.Items[indis].Text);
            KullaniciGuncelleTur turForm = new KullaniciGuncelleTur();
            turForm.ShowDialog();
            byte deger = Convert.ToByte(turForm.KullaniciYetkiCombo.SelectedIndex);
            if (deger > 0)
            {
                CafeDB.Kullanicilar.KullaniciGuncelle(id, deger, CafeDB.Kullanicilar.GuncellemeTuru.Yetki);
                KullanicilariGuncelle();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void menuTiklanma(object sender, EventArgs e)
        {
            kullanicilarUserControl.listView1.Visible = false;
            urunlerUserControl.listView2.Visible = false;
            masalarUserControl.flowLayoutPanel1.Visible = false;
            durumlarUserControl.flowLayoutPanel3.Visible = false;
            ciroUserControl.flowLayoutPanel5.Visible = false;
            anaPanel.Controls.Clear();
            BunifuFlatButton gelen = (BunifuFlatButton)sender;
            genelButton.Enabled = true;
            kullanicilarButton.Enabled = true;
            urunlerButton.Enabled = true;
            masalarButton.Enabled = true;
            optimizasyonButton.Enabled = true;
            sonDurumlarButton.Enabled = true;
            cikisButton.Enabled = true;
            gelen.Enabled = false;
            bunifuTransition3.HideSync(yanPanel);
            yanPanel.Location = new Point(yanPanel.Location.X, gelen.Location.Y);
            bunifuTransition3.ShowSync(yanPanel);
            ustBaslikLabel.Text = gelen.Text;
            pictureBox3.Image = gelen.Iconimage;
            switch (gelen.Text)
            {
                case "Genel":
                    anaPanel.Controls.Add(ciroUserControl.flowLayoutPanel5);
                    ciroUserControl.flowLayoutPanel5.Visible = true;
                    ciroUserControl.flowLayoutPanel5.Dock = DockStyle.Fill;
                    ciroUserControl.YenidenBoyutlandir();
                    break;
                case "Kullanıcılar":
                    anaPanel.Controls.Add(kullanicilarUserControl.listView1);
                    kullanicilarUserControl.listView1.Visible = true;
                    kullanicilarUserControl.listView1.Dock = DockStyle.Fill;
                    break;
                case "Ürünler":
                    anaPanel.Controls.Add(urunlerUserControl.listView2);
                    urunlerUserControl.listView2.Visible = true;
                    urunlerUserControl.listView2.Dock = DockStyle.Fill;
                    break;
                case "Masalar":
                    anaPanel.Controls.Add(masalarUserControl.flowLayoutPanel1);
                    masalarUserControl.flowLayoutPanel1.Visible = true;
                    masalarUserControl.flowLayoutPanel1.Dock = DockStyle.Fill;
                    break;
                case "Optimizasyon":
                    anaPanel.Controls.Add(optimizasyonUserControl.optimizasyonPanel);
                    optimizasyonUserControl.optimizasyonPanel.Visible = true;
                    optimizasyonUserControl.optimizasyonPanel.Dock = DockStyle.Fill;
                    break;
                case "Son Durumlar":
                    anaPanel.Controls.Add(durumlarUserControl.flowLayoutPanel3);
                    durumlarUserControl.flowLayoutPanel3.Visible = true;
                    durumlarUserControl.flowLayoutPanel3.Dock = DockStyle.Fill;
                    break;
                case "Çıkış":
                    anaPanel.Controls.Add(cikisUserControl.cikisPanel);
                    cikisUserControl.cikisPanel.Visible = true;
                    cikisUserControl.cikisPanel.Dock = DockStyle.Fill;
                    break;
            }
        }

        private void sagImageButton_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(solPanel);
            bunifuTransition1.HideSync(sagImageButton);
            logoLabel.Visible = false;
            logoPanel.Visible = false;
            ortaPanel.Size = new Size(586, ortaPanel.Height);
            ortaPanel.Location = new Point(solPanel.Width, ortaPanel.Location.Y);
            anaPanel.Size = new Size(ortaPanel.Width, anaPanel.Height);
            solPanel.Width = 60;
            ciroUserControl.YenidenBoyutlandir();
            bunifuTransition1.ShowSync(solPanel);
            bunifuTransition1.ShowSync(solImageButton);
            bunifuTransition2.ShowSync(logoPanel);
        }

        private void solImageButton_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(solPanel);
            solImageButton.Visible = false;
            logoPanel.Visible = false;
            ortaPanel.Size = new Size(436, ortaPanel.Height);
            ortaPanel.Location = new Point(solPanel.Width, ortaPanel.Location.Y);
            solPanel.Width = 210;
            anaPanel.Size = new Size(430, 450);
            ciroUserControl.YenidenBoyutlandir();
            bunifuTransition1.ShowSync(solPanel);
            bunifuTransition1.ShowSync(sagImageButton);
            bunifuTransition2.ShowSync(logoLabel);
            bunifuTransition2.ShowSync(logoPanel);
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void belirliCheckBox_OnChange(object sender, EventArgs e)
        {
            optimizasyonUserControl.tamamiCheckBox.Checked = false;
            optimizasyonUserControl.numericUpDown1.Enabled = true;
            optimizasyonUserControl.comboBox1.Enabled = true;
        }

        private void tamamiCheckBox_OnChange(object sender, EventArgs e)
        {
            optimizasyonUserControl.belirliCheckBox.Checked = false;
            optimizasyonUserControl.numericUpDown1.Enabled = false;
            optimizasyonUserControl.comboBox1.Enabled = false;
        }

        private void temizleButton_Click(object sender, EventArgs e)
        {
            if (optimizasyonUserControl.belirliCheckBox.Checked)
            {
                List<Siparis> siparisler = CafeDB.Optimizasyon.SiparisListele(Convert.ToInt32(optimizasyonUserControl.numericUpDown1.Value), Convert.ToByte(optimizasyonUserControl.comboBox1.SelectedIndex));
                int toplamSiparis = siparisler.Count;
                if (toplamSiparis != 0)
                {
                    DialogResult sonuc = MessageBox.Show("\"" + toplamSiparis + "\" adet siparişi silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sonuc == DialogResult.Yes)
                    {
                        CafeDB.Optimizasyon.SiparisTemizle(Convert.ToInt32(optimizasyonUserControl.numericUpDown1.Value), Convert.ToByte(optimizasyonUserControl.comboBox1.SelectedIndex));
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek hiç sipariş bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (optimizasyonUserControl.tamamiCheckBox.Checked)
            {
                List<Siparis> siparisler = CafeDB.Optimizasyon.SiparisListele();
                int toplamSiparis = siparisler.Count;
                if (toplamSiparis != 0)
                {
                    DialogResult sonuc = MessageBox.Show("\"" + toplamSiparis + "\" adet siparişi silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sonuc == DialogResult.Yes)
                    {
                        CafeDB.Optimizasyon.SiparisTemizle();
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek hiç sipariş bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gunlukCiroButton_Click(object sender, EventArgs e)
        {
            ciroUserControl.gunlukCiroButton.BackColor = Color.FromArgb(3, 110, 198);
            ciroUserControl.aylikCiroButton.BackColor = Color.Transparent;
            ciroUserControl.yillikCiroButton.BackColor = Color.Transparent;
            ciroUserControl.label1.Text = "Günlük Ciro";
            ciroUserControl.gunlukCiroLabel.Text = CafeDB.Istatistik.GunlukCiro() + " ₺";
        }

        private void aylikCiroButton_Click(object sender, EventArgs e)
        {
            ciroUserControl.gunlukCiroButton.BackColor = Color.Transparent;
            ciroUserControl.aylikCiroButton.BackColor = Color.FromArgb(3, 110, 198);
            ciroUserControl.yillikCiroButton.BackColor = Color.Transparent;
            ciroUserControl.label1.Text = "Aylık Ciro";
            ciroUserControl.gunlukCiroLabel.Text = CafeDB.Istatistik.AylikCiro() + " ₺";
        }

        private void yillikCiroButton_Click(object sender, EventArgs e)
        {
            ciroUserControl.gunlukCiroButton.BackColor = Color.Transparent;
            ciroUserControl.aylikCiroButton.BackColor = Color.Transparent;
            ciroUserControl.yillikCiroButton.BackColor = Color.FromArgb(3, 110, 198);
            ciroUserControl.label1.Text = "Yıllık Ciro";
            ciroUserControl.gunlukCiroLabel.Text = CafeDB.Istatistik.YillikCiro() + " ₺";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Oturum Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                GirisForm giris = new GirisForm();
                giris.Show();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OptimizasyonPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AnaPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
