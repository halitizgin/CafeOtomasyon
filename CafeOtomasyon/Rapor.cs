using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyon
{
    class Rapor
    {
        public Rapor(Kayit kayit, Kullanici kullanici)
        {
            this.kayit = kayit;
            this.kullanici = kullanici;
        }

        private Kayit kayit;

        public Kayit Kayit
        {
            get { return kayit; }
            set { kayit = value; }
        }

        private Kullanici kullanici;

        public Kullanici Kullanici
        {
            get { return kullanici; }
            set { kullanici = value; }
        }
    }
}
