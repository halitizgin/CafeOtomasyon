using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyon
{
    class TarihBilgi
    {
        public TarihBilgi(int siparissayisi, double gunlukciro)
        {
            this.siparisSayisi = siparissayisi;
            this.gunlukCiro = gunlukciro;
        }

        private int siparisSayisi;

        public int SiparisSayisi
        {
            get { return siparisSayisi; }
            set { siparisSayisi = value; }
        }

        private double gunlukCiro;

        public double GunlukCiro
        {
            get { return gunlukCiro; }
            set { gunlukCiro = value; }
        }
    }
}
