using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

       public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Yonetici
        public Yonetici YoneticiGiris(string Email,string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Email=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", Email);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi>0)
                {
                    cmd.CommandText = "SELECT ID,YoneticiTurID,Isim,Soyisim,EMail,Sifre,Durum FROM Yoneticiler WHERE Email=@m AND Sifre = @s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", Email);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = null;
                    while (reader.Read())
                    {
                        y = new Yonetici();
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.Soyisim = reader.GetString(3);
                        y.Email = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.Durum = reader.GetBoolean(6);
                    }
                    return y;

                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool SifreDegistir(Yonetici yon)
        {
            try
            {
                cmd.CommandText = "UPDATE Yoneticiler SET Sifre =@sifre WHERE ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sifre", yon.Sifre);
                cmd.Parameters.AddWithValue("@id", yon.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
                
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Yonetici YoneticiBilgi(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,YoneticiTurID,Isim,Soyisim,Email,Sifre,Durum FROM Yoneticiler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Yonetici y = new Yonetici();

                while (reader.Read())
                {
                    y.ID = reader.GetInt32(0);
                    y.YoneticiTurID = reader.GetInt32(1);
                    y.Isim = reader.GetString(2);
                    y.Soyisim = reader.GetString(3);
                    y.Email = reader.GetString(4);
                    y.Sifre = reader.GetString(5);
                    y.Durum = reader.GetBoolean(6);
                }
                return y;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategoriler

        public bool KategoriEkle(Kategoriler k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES (@i)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public List<Kategoriler> KategoriListele()
        {
            try
            {
                List<Kategoriler> kategori = new List<Kategoriler>();
                cmd.CommandText = "SELECT ID,Isim FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategoriler k = new Kategoriler();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    kategori.Add(k);

                }
                return kategori;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategoriler KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Isim FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Kategoriler k = new Kategoriler();

                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriGuncelle(Kategoriler k )
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @i WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                cmd.Parameters.AddWithValue("@id", k.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Makaleler
        public bool MakaleEkle(Makaleler mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(KategoriID, YoneticiID, Baslik, Ozet, Icerik, KapakResim, GoruntulenmeSayisi, EklemeTarihi, Durum) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @kapakResim, @goruntulenmeSayisi, @eklemeTarihi, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", mak.KategoriID);
                cmd.Parameters.AddWithValue("@yazarID", mak.YoneticiID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@goruntulenmeSayisi", mak.GoruntulenmeSayisi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarihi);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makaleler> MakaleListeleUye()
        {
            try
            {
                List<Makaleler> makale = new List<Makaleler>();
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YoneticiID,Y.Isim+' '+Y.Soyisim,M.Baslik,M.Ozet,M.Icerik,M.KapakResim,M.GoruntulenmeSayisi,M.EklemeTarihi,M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YoneticiID WHERE M.Durum = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makaleler m = new Makaleler();
                    m.ID = reader.GetInt32(0);
                    m.KategoriID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.YoneticiID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulenmeSayisi = reader.GetInt32(9);
                    m.EklemeTarihi = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    makale.Add(m);
                }
                return makale;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makaleler> MakaleListele()
        {
            try
            {
                List<Makaleler> makale = new List<Makaleler>();
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YoneticiID,Y.Isim+' '+Y.Soyisim,M.Baslik,M.Ozet,M.Icerik,M.KapakResim,M.GoruntulenmeSayisi,M.EklemeTarihi,M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YoneticiID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makaleler m = new Makaleler();
                    m.ID = reader.GetInt32(0);
                    m.KategoriID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.YoneticiID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulenmeSayisi = reader.GetInt32(9);
                    m.EklemeTarihi = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    makale.Add(m);
                }
                return makale;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makaleler> MakaleListele(int katid)
        {
            try
            {
                List<Makaleler> makale = new List<Makaleler>();
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YoneticiID,Y.Isim+' '+Y.Soyisim,M.Baslik,M.Ozet,M.Icerik,M.KapakResim,M.GoruntulenmeSayisi,M.EklemeTarihi,M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YoneticiID WHERE M.KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id" ,katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makaleler m = new Makaleler();
                    m.ID = reader.GetInt32(0);
                    m.KategoriID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.YoneticiID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulenmeSayisi = reader.GetInt32(9);
                    m.EklemeTarihi = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    makale.Add(m);
                }
                return makale;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Makaleler MakaleGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YoneticiID,Y.Isim+' '+Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.GoruntulenmeSayisi, M.EklemeTarihi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YoneticiID WHERE M.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makaleler m = new Makaleler();
                while (reader.Read())
                {
                    m.ID = reader.GetInt32(0);
                    m.KategoriID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.YoneticiID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulenmeSayisi = reader.GetInt32(9);
                    m.EklemeTarihi = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                }
                return m;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleGuncelle(Makaleler mak)
        {
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET KategoriID=@kategoriID, Baslık=@baslik, Ozet=@ozet, Icerik=@icerik, KapakResim=@kapakResim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", mak.ID);
                cmd.Parameters.AddWithValue("@kategoriID", mak.KategoriID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public bool MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Makaleler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleDurum(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Makaleler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Makaleler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Uyeler

        public List<Uyeler> UyeListele()
        {
            try
            {
                List<Uyeler> uye = new List<Uyeler>();
                cmd.CommandText = "SELECT ID,Isim,Soyisim,KullaniciAdi,Email,UyelikTarihi,Durum FROM Uyeler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uyeler u = new Uyeler();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.Soyisim = reader.GetString(2);
                    u.KullaniciAdi = reader.GetString(3);
                    u.Email = reader.GetString(4);
                    u.UyelikTarihi = reader.GetDateTime(5);
                    u.Durum = reader.GetBoolean(6);
                    uye.Add(u);
                }
                return uye;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeDurum(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Uyeler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Uyeler UyeGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Email=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Email, Sifre, UyelikTarihi, Durum FROM Uyeler WHERE Email=@m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uyeler u = new Uyeler();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyisim = reader.GetString(2);
                        u.KullaniciAdi = reader.GetString(3);
                        u.Email = reader.GetString(4);
                        u.Sifre = reader.GetString(5);
                        u.UyelikTarihi = reader.GetDateTime(6);
                        u.Durum = reader.GetBoolean(7);
                    }
                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeKayıt(Uyeler u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim,Soyisim,KullaniciAdi,Email,Sifre,UyelikTarihi,Durum) VALUES (@isim,@soyisim,@k,@email,@s,@t,1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", u.Isim);
                cmd.Parameters.AddWithValue("@soyisim", u.Soyisim);
                cmd.Parameters.AddWithValue("@k", u.KullaniciAdi);
                cmd.Parameters.AddWithValue("email", u.Email);
                cmd.Parameters.AddWithValue("@s", u.Sifre);
                cmd.Parameters.AddWithValue("@t",u.UyelikTarihi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Yorumlar

        public List<Yorumlar> YorumListele()
        {
            try
            {
                List<Yorumlar> yorum = new List<Yorumlar>();
                cmd.CommandText = "SELECT Y.ID,U.KullaniciAdi,M.Baslik,Y.Icerik,Y.YorumTarih,Y.OnayDurum FROM Yorum AS Y JOIN Uyeler AS U ON Y.UyeID = U.ID JOIN Makaleler AS M ON Y.MakaleID = M.ID WHERE Y.OnayDurum = 1 ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.UyeAdi = reader.GetString(1);
                    y.MakaleAdi = reader.GetString(2);
                    y.İcerik = reader.GetString(3);
                    y.YorumTarih = reader.GetDateTime(4);
                    y.OnayDurum = reader.GetBoolean(5);
                    yorum.Add(y);
                }
                return yorum;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumOnay(int id)
        {
            try
            {
                cmd.CommandText = "SELECT OnayDurum FROM Yorum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Yorum SET OnayDurum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorumlar> YorumListele(int Mid)
        {
            List<Yorumlar> yorumlar = new List<Yorumlar>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, M.Baslik, Y.Icerik, Y.YorumTarih, Y.OnayDurum FROM Yorum AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID=Y.MakaleID WHERE Y.MakaleID = @id AND Y.OnayDurum = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Mid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.UyeAdi = reader.GetString(2);
                    y.MakaleID = reader.GetInt32(3);
                    y.MakaleAdi = reader.GetString(4);
                    y.İcerik = reader.GetString(5);
                    y.YorumTarih = reader.GetDateTime(6);
                    y.OnayDurum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumEkle(Yorumlar y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorum(UyeID, MakaleID, Icerik, YorumTarih, OnayDurum) VALUES(@uyeID, @makaleID,@icerik, @yorumTarihi, @onayDurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@makaleID", y.MakaleID);
                cmd.Parameters.AddWithValue("@icerik", y.İcerik);
                cmd.Parameters.AddWithValue("@yorumTarihi", y.YorumTarih);
                cmd.Parameters.AddWithValue("@onayDurum", y.OnayDurum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }

        #endregion
    
}
