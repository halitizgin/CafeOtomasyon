using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
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
    class CafeDB
    {
        public static OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Cafe.accdb");

        public static void baglanti()
        {
            if (con.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    con.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void bitir()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    con.Close();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        
        public static string DurumToString(int durum)
        {
            string donus = null;
            switch (durum)
            {
                case 0:
                    donus = "Gönderildi";
                    break;
                case 1:
                    donus = "Alındı";
                    break;
                case 2:
                    donus = "Hazırlanıyor";
                    break;
                case 3:
                    donus = "Hazır";
                    break;
                case 4:
                    donus = "Teslim Edildi";
                    break;
            }
            return donus;
        }

        public static string YetkiToString(byte yetki)
        {
            string donus = null;
            switch(yetki)
            {
                case 0:
                    donus = "Normal";
                    break;
                case 1:
                    donus = "Garson";
                    break;
                case 2:
                    donus = "Mutfak";
                    break;
                case 3:
                    donus = "Kasa";
                    break;
            }
            return donus;
        }

        public static decimal ToplamUcretAl()
        {
            decimal toplamUcret = 0;
            baglanti();
            int adet = 0;
            decimal ucret = 0;
            OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun = U.Urun_ID WHERE S.Siparis_Masa>0 AND S.Siparis_Odenme=false", con);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ucret = Convert.ToDecimal(oku["Urun_Ucret"]);
                adet = Convert.ToInt32(oku["Siparis_Adet"]);
                toplamUcret += (ucret * adet);
            }
            bitir();
            return toplamUcret;
        }

        public class Siparisler
        {
            public static void SiparisEkle(int siparisUrun, int siparisAdet, int siparisMasa)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("INSERT INTO Siparisler (Siparis_Urun, Siparis_Adet, Siparis_Zaman, Siparis_Masa) VALUES (@urun, @adet, NOW(), @masa)", con);
                komut.Parameters.AddWithValue("@urun", siparisUrun);
                komut.Parameters.AddWithValue("@adet", siparisAdet);
                komut.Parameters.AddWithValue("@masa", siparisMasa);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static List<Siparis> SiparisleriListele(int masaNo = -1, short masaDurum = -1)
            {
                bool where = false;
                List<Siparis> siparisler = new List<Siparis>();
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID", con);
                if (masaNo != -1)
                {
                    where = true;
                    komut.CommandText += " WHERE S.Siparis_Masa=@masa AND S.Siparis_Odenme=false";
                    komut.Parameters.AddWithValue("@masa", masaNo);
                }
                if (masaDurum != -1)
                {
                    if (where)
                        komut.CommandText += " AND S.Siparis_Durum=@durum AND S.Siparis_Odenme=false";
                    else
                        komut.CommandText += " WHERE S.Siparis_Durum=@durum AND S.Siparis_Odenme=false";
                    komut.Parameters.AddWithValue("@durum", masaDurum);
                }
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    int siparisID = Convert.ToInt32(oku["Siparis_ID"]);
                    Urun urun = new Urun(0, "", "", 0);
                    urun.UrunID = Convert.ToInt32(oku["Siparis_Urun"]);
                    urun.UrunAdi = oku["Urun_Adi"].ToString();
                    urun.UrunAyrinti = oku["Urun_Ayrinti"].ToString();
                    urun.UrunUcret = Convert.ToDecimal(oku["Urun_Ucret"]);
                    Siparis siparis = new Siparis(siparisID, urun, Convert.ToInt32(oku["Siparis_Adet"]), Convert.ToDateTime(oku["Siparis_Zaman"]), Convert.ToByte(oku["Siparis_Durum"]), Convert.ToBoolean(oku["Siparis_Odenme"]), Convert.ToInt32(oku["Siparis_Masa"]));
                    siparisler.Add(siparis);
                }
                bitir();
                return siparisler;
            }

            public static void SiparisIptal(List<int> ids)
            {
                if (ids.Count > 0)
                {
                    baglanti();
                    foreach (int id in ids)
                    {
                        OleDbCommand komut = new OleDbCommand("DELETE FROM Siparisler WHERE Siparis_ID=@id", con);
                        komut.Parameters.AddWithValue("@id", id);
                        komut.ExecuteNonQuery();
                    }
                    bitir();
                }
            }

            public static List<Siparis> SiparisleriYerlestir(short siparisDurum = -1)
            {
                baglanti();
                List<Siparis> siparisler = new List<Siparis>();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = con;
                if (siparisDurum == -1)
                    komut.CommandText = "SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun = U.Urun_ID WHERE S.Siparis_Odenme=false AND S.Siparis_Durum<4 ORDER BY S.Siparis_Zaman DESC";
                else
                {
                    komut.CommandText = "SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun = U.Urun_ID WHERE S.Siparis_Odenme=false AND S.Siparis_Durum=@durum ORDER BY S.Siparis_Zaman DESC";
                    komut.Parameters.AddWithValue("@durum", siparisDurum);
                }
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    int id = Convert.ToInt32(oku["Siparis_Urun"]);
                    Urun urun = new Urun(0, "", "", 0);
                    urun.UrunID = id;
                    urun.UrunAdi = oku["Urun_Adi"].ToString();
                    urun.UrunAyrinti = oku["Urun_Ayrinti"].ToString();
                    urun.UrunUcret = Convert.ToDecimal(oku["Urun_Ucret"]);
                    Siparis siparis = new Siparis(Convert.ToInt32(oku["Siparis_ID"]), urun, Convert.ToInt32(oku["Siparis_Adet"]), Convert.ToDateTime(oku["Siparis_Zaman"]), Convert.ToByte(oku["Siparis_Durum"]), Convert.ToBoolean(oku["Siparis_Odenme"]), Convert.ToInt32(oku["Siparis_Masa"]));
                    siparisler.Add(siparis);
                }
                bitir();
                return siparisler;
            }

            public static bool SiparisDegisiklikOlduMu(int eskiSiparisSayisi)
            {
                bool degisiklik = false;
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT COUNT(*) FROM Siparisler WHERE Siparis_Odenme=false AND Siparis_Durum<4", con);
                int sonuc = Convert.ToInt32(komut.ExecuteScalar());
                if (sonuc != eskiSiparisSayisi)
                    degisiklik = true;
                bitir();
                return degisiklik;
            }

            public static void SiparisDurumDegistir(int siparisNo, int durum)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("UPDATE Siparisler SET Siparis_Durum=@durum WHERE Siparis_ID=@id", con);
                komut.Parameters.AddWithValue("@durum", durum);
                komut.Parameters.AddWithValue("@id", siparisNo);
                komut.ExecuteNonQuery();
                bitir();
            }
        }

        public class Masalar
        {
            public static int MasalariYerlestir(bool sadeceBosMasalar = false)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT Count(*) FROM Masalar", con);
                if (sadeceBosMasalar)
                    komut.CommandText += " WHERE Masa_Durum=false";
                int count = (int)komut.ExecuteScalar();
                bitir();
                return count;
            }

            public static List<Masa> MasalariGuncelle()
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Masalar", con);
                OleDbDataReader oku = komut.ExecuteReader();
                List<Masa> masalar = new List<Masa>();
                while (oku.Read())
                {
                    Masa masa = new Masa(Convert.ToInt32(oku["Masa_No"]), Convert.ToBoolean(oku["Masa_Durum"]));
                    masalar.Add(masa);
                }
                bitir();
                return masalar;
            }

            public static decimal MasaBorcHesapla(int masaNo)
            {
                decimal toplamUcret = 0;
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun = U.Urun_ID WHERE S.Siparis_Odenme=false AND S.Siparis_Masa=@masa", con);
                komut.Parameters.AddWithValue("@masa", masaNo);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    int urunId = Convert.ToInt32(oku["Siparis_Urun"]);
                    int adet = Convert.ToInt32(oku["Siparis_Adet"]);
                    decimal ucret = Convert.ToDecimal(oku["Urun_Ucret"]);
                    decimal toplam = ucret * adet;
                    toplamUcret += toplam;
                }
                bitir();
                return toplamUcret;
            }

            public static void MasaDurumDegistir(int masaNo, bool yeniDurum)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("UPDATE Masalar SET Masa_Durum=@durum WHERE Masa_No=@no", con);
                komut.Parameters.AddWithValue("@durum", yeniDurum);
                komut.Parameters.AddWithValue("@no", masaNo);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static Masa MasaAl(int masaNo)
            {
                Masa masa = new Masa(0, false);
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Masalar WHERE Masa_No=@no", con);
                komut.Parameters.AddWithValue("@no", masaNo);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    masa.MasaNo = Convert.ToInt32(oku["Masa_No"]);
                    masa.MasaDurum = Convert.ToBoolean(oku["Masa_Durum"]);
                }
                bitir();
                return masa;
            }

            public static void MasaBorcOde(int masaNo)
            {
                baglanti();
                OleDbCommand komut2 = new OleDbCommand("UPDATE Siparisler SET Siparis_Odenme=true WHERE Siparis_Masa=@masa", con);
                komut2.Parameters.AddWithValue("@masa", masaNo);
                komut2.ExecuteNonQuery();
                OleDbCommand komut = new OleDbCommand("UPDATE Masalar SET Masa_Durum=false WHERE Masa_No=@no", con);
                komut.Parameters.AddWithValue("@no", masaNo);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static List<Siparis> MasaOzetiCikar(int masaNo)
            {
                List<Siparis> siparisler = new List<Siparis>();
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun = U.Urun_ID WHERE S.Siparis_Masa=@masa AND S.Siparis_Odenme=false ORDER BY S.Siparis_Zaman", con);
                komut.Parameters.AddWithValue("@masa", masaNo);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    Urun urun = new Urun(0, "", "", 0);
                    urun.UrunID = Convert.ToInt32(oku["Urun_ID"]);
                    urun.UrunAdi = oku["Urun_Adi"].ToString();
                    urun.UrunAyrinti = oku["Urun_Ayrinti"].ToString();
                    urun.UrunUcret = Convert.ToDecimal(oku["Urun_Ucret"]);
                    Siparis siparis = new Siparis(Convert.ToInt32(oku["Siparis_ID"]), urun, Convert.ToInt32(oku["Siparis_Adet"]), Convert.ToDateTime(oku["Siparis_Zaman"]), Convert.ToByte(oku["Siparis_Durum"]), Convert.ToBoolean(oku["Siparis_Odenme"]), Convert.ToInt32(oku["Siparis_Masa"]));
                    siparisler.Add(siparis);
                }
                bitir();
                return siparisler;
            }

            public static void MasayiBosalt(int masaNo)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("DELETE FROM Siparisler WHERE Siparis_Masa=@masa", con);
                komut.Parameters.AddWithValue("@masa", masaNo);
                komut.ExecuteNonQuery();
                komut.Dispose();
                OleDbCommand komut2 = new OleDbCommand("UPDATE Masalar SET Masa_Durum=false WHERE Masa_No=@no", con);
                komut2.Parameters.AddWithValue("@no", masaNo);
                komut2.ExecuteNonQuery();
                bitir();
            }

            public static List<Masa> BosMasaListele()
            {
                List<Masa> bosMasalar = new List<Masa>();
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Masalar WHERE Masa_Durum=false", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    Masa masa = new Masa(Convert.ToInt32(oku["Masa_No"]), Convert.ToBoolean(oku["Masa_Durum"]));
                    bosMasalar.Add(masa);
                }
                bitir();
                return bosMasalar;
            }

            public static void MasaTasi(int eskiMasaNo, int yeniMasaNo)
            {
                List<int> siparisler = new List<int>();
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler WHERE Siparis_Masa=@masa", con);
                komut.Parameters.AddWithValue("@masa", eskiMasaNo);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    siparisler.Add(Convert.ToInt32(oku["Siparis_ID"]));
                }

                foreach (int siparis in siparisler)
                {
                    OleDbCommand komut2 = new OleDbCommand("UPDATE Siparisler SET Siparis_Masa=@masa WHERE Siparis_ID=@id", con);
                    komut2.Parameters.AddWithValue("@masa", yeniMasaNo);
                    komut2.Parameters.AddWithValue("@id", siparis);
                    komut2.ExecuteNonQuery();
                }
                bitir();
            }

            public static void MasaEkle(int masaNo)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("INSERT INTO Masalar (Masa_No) VALUES (@masa)", con);
                komut.Parameters.AddWithValue("@masa", masaNo);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static void MasaSil(int masaNo)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("DELETE FROM Masalar WHERE Masa_No=@no", con);
                komut.Parameters.AddWithValue("@no", masaNo);
                komut.ExecuteNonQuery();
                bitir();
            }
        }

        public class Urunler
        {
            public enum UrunAlan
            {
                UrunAdi,
                UrunUcret
            }

            public static List<Urun> UrunListe(int urunId = -1)
            {
                List<Urun> urunler = new List<Urun>();
                baglanti();
                OleDbCommand komut = new OleDbCommand();
                if (urunId == -1)
                {
                    komut.CommandText = "SELECT * FROM Urunler";
                    komut.Connection = con;
                }
                else
                {
                    komut.CommandText = "SELECT * FROM Urunler WHERE Urun_ID=@id";
                    komut.Connection = con;
                    komut.Parameters.AddWithValue("@id", urunId);
                }
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    Urun urun = new Urun(Convert.ToInt32(oku["Urun_ID"]), oku["Urun_Adi"].ToString(), oku["Urun_Ayrinti"].ToString(), Convert.ToDecimal(oku["Urun_Ucret"]));
                    urunler.Add(urun);
                }
                bitir();
                return urunler;
            }

            public static void UrunEkle(string urunAdi, double urunUcret)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("INSERT INTO Urunler (Urun_Adi, Urun_Ucret) VALUES (@adi, @ucret)", con);
                komut.Parameters.AddWithValue("@adi", urunAdi);
                komut.Parameters.AddWithValue("@ucret", urunUcret);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static void UrunSil(int urunId)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("DELETE FROM Urunler WHERE Urun_ID=@id", con);
                komut.Parameters.AddWithValue("@id", urunId);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static void UrunGuncelle(int urunId, string yeniAdi)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("UPDATE Urunler SET Urun_Adi=@adi WHERE Urun_ID=@id", con);
                komut.Parameters.AddWithValue("@adi", yeniAdi);
                komut.Parameters.AddWithValue("@id", urunId);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static void UrunGuncelle(int id, double urunUcret)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("UPDATE Urunler SET Urun_Ucret=@ucret WHERE Urun_ID=@id", con);
                komut.Parameters.AddWithValue("@ucret", Convert.ToDouble(urunUcret));
                komut.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                komut.ExecuteNonQuery();
                bitir();
            }
        }

        public class Kullanicilar
        {
            public enum GuncellemeTuru
            {
                Adi,
                Sifre,
                Yetki
            }

            public static GirisVeri Giris(string kullanici, string sifre)
            {
                baglanti();
                GirisVeri giris = new GirisVeri();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Kullanicilar WHERE Kullanici_Adi=@user AND Kullanici_Sifre=@pass", con);
                komut.Parameters.AddWithValue("@user", kullanici);
                komut.Parameters.AddWithValue("@pass", sifre);
                OleDbDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    giris.Yetki = Convert.ToByte(oku["Kullanici_Yetki"]);
                    giris.ID = Convert.ToInt32(oku["Kullanici_ID"]);
                }
                bitir();
                return giris;
            }

            public static void KullaniciGuncelle(int id, object yeniDeger, GuncellemeTuru tur = GuncellemeTuru.Adi)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = con;
                switch (tur)
                {
                    case GuncellemeTuru.Adi:
                        komut.CommandText = "UPDATE Kullanicilar SET Kullanici_Adi=@kullanici";
                        komut.Parameters.AddWithValue("@kullanici", yeniDeger.ToString());
                        break;
                    case GuncellemeTuru.Sifre:
                        komut.CommandText = "UPDATE Kullanicilar SET Kullanici_Sifre=@sifre";
                        komut.Parameters.AddWithValue("@sifre", yeniDeger.ToString());
                        break;
                    case GuncellemeTuru.Yetki:
                        komut.CommandText = "UPDATE Kullanicilar SET Kullanici_Yetki=@yetki";
                        komut.Parameters.AddWithValue("@yetki", Convert.ToByte(yeniDeger));
                        break;
                }
                komut.CommandText += " WHERE Kullanici_ID=@id";
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static void KullaniciEkle(string kullanici, string sifre, byte yetki)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("INSERT INTO Kullanicilar (Kullanici_Adi, Kullanici_Sifre, Kullanici_Yetki) VALUES (@user, @pass, @yetki)", con);
                komut.Parameters.AddWithValue("@user", kullanici);
                komut.Parameters.AddWithValue("@pass", sifre);
                komut.Parameters.AddWithValue("@yetki", yetki);
                komut.ExecuteNonQuery();
                bitir();
            }

            public static List<Kullanici> KullanicilariListele()
            {
                List<Kullanici> kullanicilar = new List<Kullanici>();
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Kullanicilar WHERE Kullanici_Yetki<4 ORDER BY Kullanici_Yetki DESC", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    Kullanici kullanici = new Kullanici(Convert.ToInt32(oku["Kullanici_ID"]), oku["Kullanici_Adi"].ToString(), oku["Kullanici_Sifre"].ToString(), Convert.ToByte(oku["Kullanici_Yetki"]));
                    kullanicilar.Add(kullanici);
                }
                bitir();
                return kullanicilar;
            }

            public static void KullaniciSil(int kullaniciId)
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("DELETE FROM Kullanicilar WHERE Kullanici_ID=@id", con);
                komut.Parameters.AddWithValue("@id", kullaniciId);
                komut.ExecuteNonQuery();
                bitir();
            }
        }

        public class Istatistik
        {
            public static double ToplamCiro()
            {
                baglanti();
                double toplamCiro = 0;
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID WHERE S.Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    toplamCiro += (Convert.ToInt32(oku["Siparis_Adet"]) * Convert.ToDouble(oku["Urun_Ucret"]));
                }
                bitir();
                return toplamCiro;
            }

            public static double GunlukCiro()
            {
                baglanti();
                double gunlukCiro = 0;
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID WHERE S.Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    DateTime zaman = Convert.ToDateTime(oku["Siparis_Zaman"]);
                    DateTime suan = DateTime.Now;
                    if (suan.ToShortDateString() == zaman.ToShortDateString())
                        gunlukCiro += Convert.ToInt32(oku["Siparis_Adet"]) * Convert.ToDouble(oku["Urun_Ucret"]);
                }
                bitir();
                return gunlukCiro;
            }

            public static double AylikCiro()
            {
                baglanti();
                double aylikCiro = 0;
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID WHERE S.Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    DateTime zaman = Convert.ToDateTime(oku["Siparis_Zaman"]);
                    DateTime suan = DateTime.Now;
                    if (zaman.Year == suan.Year && zaman.Month == suan.Month)
                        aylikCiro += Convert.ToInt32(oku["Siparis_Adet"]) * Convert.ToDouble(oku["Urun_Ucret"]);
                }
                bitir();
                return aylikCiro;
            }

            public static double YillikCiro()
            {
                baglanti();
                double yillikCiro = 0;
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID WHERE S.Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    DateTime zaman = Convert.ToDateTime(oku["Siparis_Zaman"]);
                    DateTime suan = DateTime.Now;
                    if (zaman.Year == suan.Year)
                        yillikCiro += Convert.ToInt32(oku["Siparis_Adet"]) * Convert.ToDouble(oku["Urun_Ucret"]);
                }
                bitir();
                return yillikCiro;
            }

            public static int SiparisSayisi()
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT COUNT(*) FROM Siparisler", con);
                int sayisi = Convert.ToInt32(komut.ExecuteScalar());
                bitir();
                return sayisi;
            }

            public static int GunlukSiparisSayisi()
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler", con);
                OleDbDataReader oku = komut.ExecuteReader();
                int sayisi = 0;
                while (oku.Read())
                {
                    DateTime zaman = Convert.ToDateTime(oku["Siparis_Zaman"]);
                    if (zaman.Year == DateTime.Now.Year && zaman.Month == DateTime.Now.Month && zaman.Day == DateTime.Now.Day)
                        sayisi++;
                }
                bitir();
                return sayisi;
            }

            public static int OdenmemisSiparisSayisi()
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT COUNT(*) FROM Siparisler WHERE Siparis_Odenme=false", con);
                int sayisi = Convert.ToInt32(komut.ExecuteScalar());
                bitir();
                return sayisi;
            }

            public static double OdenmemisUcretToplam()
            {
                baglanti();
                double toplamCiro = 0;
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID WHERE S.Siparis_Odenme=false", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    toplamCiro += Convert.ToInt32(oku["Siparis_Adet"]) * Convert.ToDouble(oku["Urun_Ucret"]);
                }
                bitir();
                return toplamCiro;
            }

            public static int TumMasaSayisi()
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT COUNT(*) FROM Masalar", con);
                int sayisi = Convert.ToInt32(komut.ExecuteScalar());
                bitir();
                return sayisi;
            }

            public static int DoluMasaSayisi()
            {
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT COUNT(*) FROM Masalar WHERE Masa_Durum=true", con);
                int sayisi = Convert.ToInt32(komut.ExecuteScalar());
                bitir();
                return sayisi;
            }

            public static TarihBilgi TarihBilgiVer(DateTime tarih)
            {
                TarihBilgi tarihBilgi = new TarihBilgi(0, 0);
                baglanti();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID WHERE S.Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                int siparisSayisi = 0;
                double gunlukCiro = 0d;
                while (oku.Read())
                {
                    DateTime siparisTarih = Convert.ToDateTime(oku["Siparis_Zaman"]);
                    if (tarih.Year == siparisTarih.Year && tarih.Month == siparisTarih.Month && tarih.Day == siparisTarih.Day)
                    {
                        gunlukCiro += (Convert.ToInt32(oku["Siparis_Adet"]) * Convert.ToDouble(oku["Urun_Ucret"]));
                        siparisSayisi++;
                    }
                }
                tarihBilgi.SiparisSayisi = siparisSayisi;
                tarihBilgi.GunlukCiro = gunlukCiro;
                bitir();
                return tarihBilgi;
            }
        }

        public class Optimizasyon
        {
            public static List<Siparis> SiparisListele(int sayi, byte tur)
            {
                baglanti();
                List<Siparis> siparisler = new List<Siparis>();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID WHERE Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    DateTime zaman = Convert.ToDateTime(oku["Siparis_Zaman"]);
                    DateTime suan = DateTime.Now;
                    switch(tur)
                    {
                        case 0:
                            suan = suan.AddDays(-sayi);
                            break;
                        case 1:
                            suan = suan.AddMonths(-sayi);
                            break;
                        case 2:
                            suan = suan.AddYears(-sayi);
                            break;
                    }
                    int karsilastirma = DateTime.Compare(suan, zaman);
                    if (karsilastirma > 0)
                    {
                        Urun urun = new Urun(Convert.ToInt32(oku["Urun_ID"]), oku["Urun_Adi"].ToString(), oku["Urun_Ayrinti"].ToString(), Convert.ToDecimal(oku["Urun_Ucret"]));
                        Siparis siparis = new Siparis(Convert.ToInt32(oku["Siparis_ID"]), urun, Convert.ToInt32(oku["Siparis_Adet"]), Convert.ToDateTime(oku["Siparis_Zaman"]), Convert.ToByte(oku["Siparis_Durum"]), Convert.ToBoolean(oku["Siparis_Odenme"]), Convert.ToInt32(oku["Siparis_Masa"]));
                        siparisler.Add(siparis);
                    }
                }
                bitir();
                return siparisler;
            }

            public static List<Siparis> SiparisListele()
            {
                baglanti();
                List<Siparis> siparisler = new List<Siparis>();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler AS S INNER JOIN Urunler AS U ON S.Siparis_Urun=U.Urun_ID WHERE Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    Urun urun = new Urun(Convert.ToInt32(oku["Urun_ID"]), oku["Urun_Adi"].ToString(), oku["Urun_Ayrinti"].ToString(), Convert.ToDecimal(oku["Urun_Ucret"]));
                    Siparis siparis = new Siparis(Convert.ToInt32(oku["Siparis_ID"]), urun, Convert.ToInt32(oku["Siparis_Adet"]), Convert.ToDateTime(oku["Siparis_Zaman"]), Convert.ToByte(oku["Siparis_Durum"]), Convert.ToBoolean(oku["Siparis_Odenme"]), Convert.ToInt32(oku["Siparis_Masa"]));
                    siparisler.Add(siparis);
                }
                bitir();
                return siparisler;
            }

            public static void SiparisTemizle(int sayi, byte tur)
            {
                baglanti();
                List<int> ids = new List<int>();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler WHERE Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    DateTime zaman = Convert.ToDateTime(oku["Siparis_Zaman"]);
                    DateTime suan = DateTime.Now;
                    switch (tur)
                    {
                        case 0:
                            suan = suan.AddDays(-sayi);
                            break;
                        case 1:
                            suan = suan.AddMonths(-sayi);
                            break;
                        case 2:
                            suan = suan.AddYears(-sayi);
                            break;
                    }
                    int karsilastirma = DateTime.Compare(suan, zaman);
                    if (karsilastirma > 0)
                    {
                        ids.Add(Convert.ToInt32(oku["Siparis_ID"]));
                    }
                }

                foreach (int item in ids)
                {
                    OleDbCommand komut2 = new OleDbCommand("DELETE FROM Siparisler WHERE Siparis_ID=@id", con);
                    komut2.Parameters.AddWithValue("@id", item);
                    komut2.ExecuteNonQuery();
                }
                bitir();
            }

            public static void SiparisTemizle()
            {
                baglanti();
                List<int> ids = new List<int>();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Siparisler WHERE Siparis_Odenme=true", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ids.Add(Convert.ToInt32(oku["Siparis_ID"]));
                }

                foreach (int item in ids)
                {
                    OleDbCommand komut2 = new OleDbCommand("DELETE FROM Siparisler WHERE Siparis_ID=@id", con);
                    komut2.Parameters.AddWithValue("@id", item);
                    komut2.ExecuteNonQuery();
                }
                bitir();
            }
        }

        public class Log
        {
            public static bool Log_Kontrol(int kullaniciId)
            {
                baglanti();
                bool donus = false;
                OleDbCommand komut = new OleDbCommand("SELECT COUNT(*) FROM Kayitlar WHERE Log_ID=@id", con);
                komut.Parameters.AddWithValue("@id", kullaniciId);
                int sonuc = Convert.ToInt32(komut.ExecuteScalar());
                if (sonuc == 1)
                {
                    donus = true;
                }
                bitir();
                return donus;
            }

            public static void LogEkle(int kullaniciId, DateTime zaman, string islem)
            {
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = con;
                bool kontrol = Log_Kontrol(kullaniciId);
                if (kontrol)
                {
                    komut.CommandText = "UPDATE Kayitlar SET Log_Zaman=NOW(), Log_Islem=@islem WHERE Log_ID=@id";
                    komut.Parameters.AddWithValue("@islem", islem);
                    komut.Parameters.AddWithValue("@id", kullaniciId);
                }
                else
                {
                    komut.CommandText = "INSERT INTO Kayitlar (Log_Id, Log_Zaman, Log_Islem) VALUES(@id, NOW(), @islem)";
                    komut.Parameters.AddWithValue("@id", kullaniciId);
                    komut.Parameters.AddWithValue("@islem", islem);
                }
                con.Open();
                komut.ExecuteNonQuery();
                bitir();
            }

            public static List<Rapor> LogListe()
            {
                baglanti();
                List<Rapor> loglar = new List<Rapor>();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Kayitlar AS KA INNER JOIN Kullanicilar AS KU ON KA.Log_ID=KU.Kullanici_ID", con);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    Kayit log = new Kayit(Convert.ToInt32(oku["Log_ID"]), Convert.ToDateTime(oku["Log_Zaman"]), oku["Log_Islem"].ToString());
                    Kullanici kullanici = new Kullanici(Convert.ToInt32(oku["Kullanici_ID"]), oku["Kullanici_Adi"].ToString(), oku["Kullanici_Sifre"].ToString(), Convert.ToByte(oku["Kullanici_Yetki"]));
                    Rapor rapor = new Rapor(log, kullanici);
                    loglar.Add(rapor);
                }
                bitir();
                return loglar;
            }
        }
    }
}
