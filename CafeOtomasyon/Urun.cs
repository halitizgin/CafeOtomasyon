using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyon
{
    class Urun
    {
        public Urun(int urunid, string urunadi, string urunayrinti, decimal urunucret)
        {
            this.UrunID = urunid;
            this.UrunAdi = urunadi;
            this.UrunAyrinti = urunayrinti;
            this.UrunUcret = urunucret;
        }

        private int urunId = 0;
        private string urunAdi = null;
        private string urunAyrinti = null;
        private decimal urunUcret = 0;

        public int UrunID
        {
            get
            {
                return urunId;
            }
            set
            {
                this.urunId = value;
            }
        }

        public string UrunAdi
        {
            get
            {
                return urunAdi;
            }
            set
            {
                this.urunAdi = value;
            }
        }

        public string UrunAyrinti
        {
            get
            {
                return urunAyrinti;
            }
            set
            {
                this.urunAyrinti = value;
            }
        }

        public decimal UrunUcret
        {
            get
            {
                return urunUcret;
            }
            set
            {
                this.urunUcret = value;
            }
        }
    }
}
