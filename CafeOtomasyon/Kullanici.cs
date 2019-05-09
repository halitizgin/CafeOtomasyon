namespace CafeOtomasyon
{
    public class Kullanici
    {
        public Kullanici(int kullaniciId, string kullaniciAdi, string sifre, byte yetki)
        {
            this.kullaniciId = kullaniciId;
            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;
            this.yetki = yetki;
        }

        private int kullaniciId;
        private string kullaniciAdi;
        private string sifre;
        private byte yetki;

        public int KullaniciID
        {
            get
            {
                return kullaniciId;
            }
            set
            {
                kullaniciId = value;
            }
        }

        public string KullaniciAdi
        {
            get
            {
                return kullaniciAdi;
            }
            set
            {
                kullaniciAdi = value;
            }
        }

        public string Sifre
        {
            get
            {
                return sifre;
            }
            set
            {
                sifre = value;
            }
        }

        public byte Yetki
        {
            get
            {
                return yetki;
            }
            set
            {
                yetki = value;
            }
        }
    }
}