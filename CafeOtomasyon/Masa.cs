using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyon
{
    class Masa
    {
        public Masa(int masano, bool masadurum)
        {
            this.MasaNo = masano;
            this.MasaDurum = masadurum;
        }

        private int masaNo = 0;
        private bool masaDurum = false;

        public int MasaNo
        {
            get
            {
                return this.masaNo;
            }
            set
            {
                this.masaNo = value;
            }
        }

        public bool MasaDurum
        {
            get
            {
                return this.masaDurum;
            }
            set
            {
                this.masaDurum = value;
            }
        }
    }
}
