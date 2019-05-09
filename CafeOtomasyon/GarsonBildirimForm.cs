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
    public partial class GarsonBildirimForm : Form
    {
        public GarsonBildirimForm()
        {
            InitializeComponent();
        }

        public int KullaniciID = 0;
        DateTime Erisim;

        private void GarsonBildirimForm_Load(object sender, EventArgs e)
        {
            Erisim = DateTime.Now;
            BildirimYerlestir();
            BildirimGuncelle();
        }

        public void BildirimYerlestir()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Siparis> siparisler = CafeDB.Siparisler.SiparisleriYerlestir(3);
            for (int i = 0; i < siparisler.Count; i++)
            {
                Button button = new Button();
                button.Size = new Size(300, 80);
                button.Name = "Siparis" + siparisler[i].SiparisID;
                button.ContextMenuStrip = contextMenuStrip1;
                button.MouseUp += Button_MouseUp;
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button button = (Button)sender;
                contextMenuStrip1.Items[0].Text = button.Name;
            }
        }

        public void BildirimGuncelle()
        {
            List<Siparis> siparisler = CafeDB.Siparisler.SiparisleriListele(-1, 3);
            foreach (Siparis siparis in siparisler)
            {
                Button button = flowLayoutPanel1.Controls.Find("Siparis" + siparis.SiparisID, true).FirstOrDefault() as Button;
                button.Text = siparis.SiparisMasa + " numaralı masanın siparişi hazır!\nX" + siparis.SiparisAdet + " adet " + siparis.SiparisUrun.UrunAdi;
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.FromArgb(46, 139, 87);
            }
            this.Text = "Garson(" + flowLayoutPanel1.Controls.Count + ") - Restaurant/Cafe Otomasyon";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo("Cafe.accdb");
            DateTime sonErisim = info.LastWriteTime;
            if (sonErisim != Erisim)
            {
                int eskiSayi = flowLayoutPanel1.Controls.Count;
                int yeniSayi = CafeDB.Siparisler.SiparisleriListele(-1, 3).Count;
                if (eskiSayi != yeniSayi)
                {
                    flowLayoutPanel1.Controls.Clear();
                    BildirimYerlestir();
                    BildirimGuncelle();
                    Erisim = sonErisim;
                }
                else
                {
                    BildirimGuncelle();
                    Erisim = sonErisim;
                }
            }
        }

        private void teslimEdildiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(siparisNoToolStripMenuItem.Text.Replace("Siparis", ""));
            CafeDB.Siparisler.SiparisDurumDegistir(id, 4);
            CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Sipariş Teslim Edildi->" + id + " nolu sipariş teslim edildi.");
        }

        private void GarsonBildirimForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Garson Bildirim formunu kapatamazsınız!\nGarson formu kapatıldığında otomatik kapanacaktır.", "Garson Bildirim Kapatma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
