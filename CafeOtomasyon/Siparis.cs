using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyon
{
    class Siparis
    {
        public Siparis(int siparisID, Urun siparisUrun, int siparisAdet, DateTime siparisZaman, byte siparisDurum, bool siparisOdenme, int siparisMasa = 0)
        {
            this.SiparisID = siparisID;
            this.siparisUrun = siparisUrun;
            this.siparisAdet = siparisAdet;
            this.siparisZaman = siparisZaman;
            this.siparisDurum = siparisDurum;
            this.siparisOdenme = siparisOdenme;
            this.siparisMasa = siparisMasa;
        }

        private int siparisID;
        private Urun siparisUrun;
        private int siparisAdet;
        private DateTime siparisZaman;
        private byte siparisDurum;
        private bool siparisOdenme;
        private int siparisMasa;

        public int SiparisID
        {
            get
            {
                return siparisID;
            }
            set
            {
                siparisID = value;
            }
        }

        public Urun SiparisUrun
        {
            get
            {
                return siparisUrun;
            }
            set
            {
                siparisUrun = value;
            }
        }

        public int SiparisAdet
        {
            get
            {
                return siparisAdet;
            }
            set
            {
                siparisAdet = value;
            }
        }

        public DateTime SiparisZaman
        {
            get
            {
                return siparisZaman;
            }
            set
            {
                siparisZaman = value;
            }
        }

        public byte SiparisDurum
        {
            get
            {
                return siparisDurum;
            }
            set
            {
                siparisDurum = value;
            }
        }

        public bool SiparisOdenme
        {
            get
            {
                return siparisOdenme;
            }
            set
            {
                siparisOdenme = value;
            }
        }

        public int SiparisMasa
        {
            get
            {
                return siparisMasa;
            }
            set
            {
                siparisMasa = value;
            }
        }
    }
}
