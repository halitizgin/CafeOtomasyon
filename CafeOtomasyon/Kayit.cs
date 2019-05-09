using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyon
{
    class Kayit
    {
        public Kayit(int kayitid, DateTime kayitzaman, string kayitislem)
        {
            this.kayitID = kayitid;
            this.kayitZaman = kayitzaman;
            this.kayitIslem = kayitislem;
        }

        private int kayitID = 0;
        private DateTime kayitZaman = DateTime.Now;
        private string kayitIslem = null;

        public int KayitID
        {
            get { return kayitID; }
            set { kayitID = value; }
        }

        public DateTime KayitZaman
        {
            get { return kayitZaman; }
            set { kayitZaman = value; }
        }

        public string KayitIslem
        {
            get { return kayitIslem; }
            set { kayitIslem = value; }
        }
    }
}
