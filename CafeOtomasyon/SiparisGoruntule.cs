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
    public partial class SiparisGoruntule : Form
    {
        public SiparisGoruntule()
        {
            InitializeComponent();
        }

        public int MasaNo = 0;
        public bool MasalariGuncelle = false;
        public int KullaniciID = 0;

        public void SiparisleriYaz()
        {
            listView1.Items.Clear();
            List<Siparis> siparisler = CafeDB.Siparisler.SiparisleriListele(MasaNo);
            foreach (Siparis item in siparisler)
            {
                int count = listView1.Items.Count;
                listView1.Items.Add(item.SiparisID.ToString());
                listView1.Items[count].SubItems.Add(item.SiparisUrun.UrunAdi);
                listView1.Items[count].SubItems.Add((item.SiparisUrun.UrunUcret * item.SiparisAdet).ToString());
                listView1.Items[count].SubItems.Add(CafeDB.DurumToString(item.SiparisDurum));
                listView1.Items[count].SubItems.Add(item.SiparisAdet.ToString());
            }
        }

        private void SiparisGoruntule_Load(object sender, EventArgs e)
        {
            SiparisleriYaz();
            ListViewRenklendir();
        }

        private void ListViewRenklendir()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (i % 2 == 0)
                    listView1.Items[i].BackColor = Color.White;
                else
                    listView1.Items[i].BackColor = Color.FromArgb(150, 168, 168);
            }
        }

        private void iptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                List<int> ids = new List<int>();
                List<string> adlar = new List<string>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    int id = int.Parse(item.SubItems[0].Text);
                    string ad = item.SubItems[1].Text;
                    ids.Add(id);
                    adlar.Add(ad);
                }
                CafeDB.Siparisler.SiparisIptal(ids);
                string final = "";
                foreach (string ad in adlar)
                {
                    final += ad + ",";
                }
                final = final.TrimEnd(',');
                CafeDB.Log.LogEkle(KullaniciID, DateTime.Now, "Sipariş(ler) İptal Edildi->" + final + " adlı ürün(ler), " + MasaNo + " nolu masadan iptal edildi.");
                SiparisleriYaz();
                this.MasalariGuncelle = true;
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
