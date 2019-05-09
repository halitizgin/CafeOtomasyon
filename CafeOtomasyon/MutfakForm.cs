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
    public partial class MutfakForm : Form
    {
        public MutfakForm()
        {
            InitializeComponent();
        }

        public int KullaniciID = -1;

        public void SiparisleriYerlestir()
        {
            toolTip1.ShowAlways = true;
            List<Siparis> siparisler = CafeDB.Siparisler.SiparisleriYerlestir();
            foreach (Siparis siparis in siparisler)
            {
                Button button = new Button();
                button.Size = new Size(150, 180);
                button.Name = "Siparis" + siparis.SiparisID;
                switch (siparis.SiparisDurum)
                {
                    case 0:
                        CafeDB.Siparisler.SiparisDurumDegistir(siparis.SiparisID, 1);
                        break;
                }
                button.Click += Button_Click;
                button.MouseUp += Button_MouseUp;
                button.ContextMenuStrip = contextMenuStrip1;
                toolTip1.SetToolTip(button, siparis.SiparisUrun.UrunAdi + "\n\n" + "Masa " + siparis.SiparisMasa + "\n\n" + CafeDB.DurumToString(siparis.SiparisDurum) + "\n\n" + "X" + siparis.SiparisAdet);
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        DateTime Erisim;

        private void MutfakForm_Load(object sender, EventArgs e)
        {
            Erisim = DateTime.Now;
            SiparisleriYerlestir();
            SiparisleriGuncelle();
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button button = (Button)sender;
                contextMenuStrip1.Items[0].Text = button.Name;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            
        }

        public void SiparisleriGuncelle()
        {
            List<Siparis> siparisler = CafeDB.Siparisler.SiparisleriYerlestir();
            foreach (Siparis siparis in siparisler)
            {
                string siparisFiltered = siparis.SiparisUrun.UrunAdi;
                if (siparisFiltered.Length > 8)
                {
                    siparisFiltered = siparisFiltered.Substring(0, 8) + "...";
                }
                Button button = flowLayoutPanel1.Controls.Find("Siparis" + siparis.SiparisID, true).FirstOrDefault() as Button;
                button.Cursor = Cursors.Hand;
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                switch (siparis.SiparisDurum)
                {
                    case 1:
                        button.BackColor = Color.FromArgb(145, 80, 39);
                        break;
                    case 2:
                        button.BackColor = Color.FromArgb(147, 59, 4);
                        break;
                    case 3:
                        button.BackColor = Color.FromArgb(117, 1, 1);
                        break;
                }
                button.Text = siparisFiltered + "\n\n" + "Masa " + siparis.SiparisMasa + "\n\n" + CafeDB.DurumToString(siparis.SiparisDurum) + "\n\n" + "X" + siparis.SiparisAdet;
            }
        }

        private void MutfakForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Oturum Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GirisForm giris = new GirisForm();
                giris.Show();
            }
            else
                e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo("Cafe.accdb");
            DateTime sonErisim = info.LastWriteTime;
            if (sonErisim != Erisim)
            {
                bool oldumu = CafeDB.Siparisler.SiparisDegisiklikOlduMu(flowLayoutPanel1.Controls.Count);
                if (oldumu)
                {
                    flowLayoutPanel1.Controls.Clear();
                    SiparisleriYerlestir();
                    SiparisleriGuncelle();
                    Erisim = sonErisim;
                }
                else
                {
                    SiparisleriGuncelle();
                    Erisim = sonErisim;
                }
            }
        }

        private void siparisİptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int siparisNo = Convert.ToInt32(siparişNoToolStripMenuItem.Text.Replace("Siparis", ""));
            DialogResult sonuc = MessageBox.Show(siparisNo + " nolu siparişi iptal etmek istediğinize emin misiniz?", "İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                List<int> iptal = new List<int>();
                iptal.Add(siparisNo);
                CafeDB.Siparisler.SiparisIptal(iptal);
            }
        }

        private void hazırlanıyorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int siparisNo = Convert.ToInt32(siparişNoToolStripMenuItem.Text.Replace("Siparis", ""));
            CafeDB.Siparisler.SiparisDurumDegistir(siparisNo, 1);
            CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Alındı->" + siparisNo + " nolu sipariş alındı.");
            SiparisleriGuncelle();
        }

        private void hazılanıyorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int siparisNo = Convert.ToInt32(siparişNoToolStripMenuItem.Text.Replace("Siparis", ""));
            CafeDB.Siparisler.SiparisDurumDegistir(siparisNo, 2);
            CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Hazırlanıyor->" + siparisNo + " nolu sipariş hazırlanıyor.");
            SiparisleriGuncelle();
        }

        private void gönderildiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int siparisNo = Convert.ToInt32(siparişNoToolStripMenuItem.Text.Replace("Siparis", ""));
            CafeDB.Siparisler.SiparisDurumDegistir(siparisNo, 3);
            CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Gönderildi->" + siparisNo + " nolu sipariş gönderildi.");
            SiparisleriGuncelle();
        }

        private void teslimEdildiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int siparisNo = Convert.ToInt32(siparişNoToolStripMenuItem.Text.Replace("Siparis", ""));
            CafeDB.Siparisler.SiparisDurumDegistir(siparisNo, 4);
            CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Teslim Edildi->" + siparisNo + " nolu sipariş teslim edildi.");
            SiparisleriGuncelle();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siparişİptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int siparisNo = Convert.ToInt32(siparişNoToolStripMenuItem.Text.Replace("Siparis", ""));
            DialogResult sonuc = MessageBox.Show("\"" + siparisNo + "\" nolu siparişi iptal etmek istediğinize emin misiniz?", "Borç Ödeme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                List<int> id = new List<int>();
                id.Add(siparisNo);
                CafeDB.Siparisler.SiparisIptal(id);
                CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "İptal Edildi->" + siparisNo + " nolu sipariş iptal edildi.");
                SiparisleriGuncelle();
            }
        }

        private void siparişDurumToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
