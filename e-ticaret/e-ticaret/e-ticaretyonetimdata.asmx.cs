using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace e_ticaret
{
    /// <summary>

    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class e_ticaretyonetimdata1 : System.Web.Services.WebService
    {        
        private string sqlCmd = "Server=.;DataBase=eTicaret;UID=weblogin;PWD=S2k*12?";

        [WebMethod(EnableSession = true)]
        public string AdminGiris(string ka, string ks)
        {
            using (SqlConnection cnn = new SqlConnection(sqlCmd))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter("Select * from Kullanicilar where Aktif=1 and KullaniciAdi='" + ka + "' and KullaniciSifre='" + MD5al(ks) + "'", cnn))
                {
                    using (DataTable tbl = new DataTable())
                    {
                        adp.Fill(tbl);
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            DataRow dr = tbl.Rows[i];
                            Session["AdminID"] = dr["ID"];
                            Session["RolID"] = dr["RolID"];
                        }

                    }

                }

            }
            string a = Session["AdminID"].ToString();
            return a;
        }

        [WebMethod(EnableSession = true)]
        public string KullaniciBilgi()
        {

            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select KullaniciAdi from Kullanicilar where ID=" + Session["AdminID"].ToString()), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string logOut()
        {
            Session["AdminID"] = null;
            return "OK";
        }

        public string MD5al(string sifre)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(sifre));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        [WebMethod(EnableSession = true)]
        public bool LoginKontrol()
        {

            try
            {
                if (Session["AdminID"].ToString() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        private DataSet GetDataSet(string sqlStr)
        {
            using (SqlConnection cnn = new SqlConnection(sqlCmd))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter(sqlStr, cnn))
                {
                    using (DataSet dst = new DataSet())
                    {
                        adp.Fill(dst);
                        return dst;
                    }
                }
            }
        }

        private DataTable GetDataTable(string sqlStr)
        {
            using (SqlConnection cnn = new SqlConnection(sqlCmd))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter(sqlStr, cnn))
                {
                    using (DataTable tbl = new DataTable())
                    {
                        adp.Fill(tbl);
                        return tbl;
                    }
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public string siteBilgileri()
        {
            if (Session["AdminID"] != null)
            {
                DataTable tbl = new DataTable();
                tbl = GetDataTable("Select * From Dil where Aktif=1");
                string id, tab = "<ul class='nav nav-tabs'>", tabicerik = "<div class='tab-content panel wrapper'>";
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    DataRow dr = tbl.Rows[i];
                    id = dr["ID"].ToString();
                    DataTable tblTab = new DataTable();
                    tblTab = GetDataTable("Select * From SiteBilgileri where DilID=" + id);
                    if (i == 0)
                    {
                        tab += "<li class='active'><a href='#tab" + i + "' data-toggle='tab'>" + dr["Adi"].ToString() + "</a></li>";
                        if (tblTab.Rows.Count == 0)
                        {
                            tabicerik += "<div id='tab" + i + "' class='tab-pane fade active in'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class=' col-sm-2 control-label'>Firma Adı</label><div class='col-sm-8'><input id='firmaAdi" + id + "' class='form-control' placeholder='Firma Adı' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>E-Posta</label><div class='col-sm-8'><input id='mail" + id + "' class='form-control' placeholder='E-Posta' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Site Adresi</label><div class='col-sm-8'><input id='web" + id + "' class='form-control' placeholder='Site Adresi' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Telefon</label><div class='col-sm-8'><input id='tel" + id + "' class='form-control' placeholder='Telefon' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Faks</label><div class='col-sm-8'><input id='faks" + id + "' class='form-control' placeholder='Faks' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Mobil Tel</label><div class='col-sm-8'><input id='mobil" + id + "' class='form-control' placeholder='Mobil Tel' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Firma Adresi</label><div class='col-sm-8'><textarea id='adres" + id + "' name='' class='form-control' cols='30' rows='5' value=''></textarea></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ülke</label><div class='col-sm-8'><input id='ulke" + id + "' class='form-control' placeholder='Ülke' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Şehir</label><div class='col-sm-8'><input id='sehir" + id + "' class='form-control' placeholder='Şehir' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>İlçe</label><div class='col-sm-8'><input id='ilce" + id + "' class='form-control' placeholder='İlçe' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Anahtar Kelimeler</label><div class='col-sm-8'><input id='keywords" + id + "' class='form-control' placeholder='Anahtar Kelimeler' value='' type='text'></div></div></form></div></div></div>";
                        }
                        else
                        {
                            for (int z = 0; z < tblTab.Rows.Count; z++)
                            {
                                DataRow dr1 = tblTab.Rows[z];
                                tabicerik += "<div id='tab" + i + "' class='tab-pane fade active in'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class=' col-sm-2 control-label'>Firma Adı</label><div class='col-sm-8'><input id='firmaAdi" + id + "' class='form-control' placeholder='Firma Adı' value='" + dr1["FirmaAdi"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>E-Posta</label><div class='col-sm-8'><input id='mail" + id + "' class='form-control' placeholder='E-Posta' value='" + dr1["Mail"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Site Adresi</label><div class='col-sm-8'><input id='web" + id + "' class='form-control' placeholder='Site Adresi' value='" + dr1["URL"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Telefon</label><div class='col-sm-8'><input id='tel" + id + "' class='form-control' placeholder='Telefon' value='" + dr1["Tel"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Faks</label><div class='col-sm-8'><input id='faks" + id + "' class='form-control' placeholder='Faks' value='" + dr1["Faks"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Mobil Tel</label><div class='col-sm-8'><input id='mobil" + id + "' class='form-control' placeholder='Mobil Tel' value='" + dr1["MobilTel"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Firma Adresi</label><div class='col-sm-8'><textarea id='adres" + id + "' name='' class='form-control' cols='30' rows='5' >" + dr1["Adres"].ToString() + "</textarea></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ülke</label><div class='col-sm-8'><input id='ulke" + id + "' class='form-control' placeholder='Ülke' value='" + dr1["Ulke"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Şehir</label><div class='col-sm-8'><input id='sehir" + id + "' class='form-control' placeholder='Şehir' value='" + dr1["Sehir"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>İlçe</label><div class='col-sm-8'><input id='ilce" + id + "' class='form-control' placeholder='İlçe' value='" + dr1["Ilce"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Anahtar Kelimeler</label><div class='col-sm-8'><input id='keywords" + id + "' class='form-control' placeholder='Anahtar Kelimeler' value='" + dr1["KeyWords"].ToString() + "' type='text'></div></div></form></div></div></div>";
                            }
                        }

                    }
                    else
                    {

                        tab += "<li ><a href='#tab" + i + "' data-toggle='tab'>" + dr["Adi"].ToString() + "</a></li>";
                        if (tblTab.Rows.Count == 0)
                        {
                            tabicerik += "<div id='tab" + i + "' class='tab-pane fade'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class=' col-sm-2 control-label'>Firma Adı</label><div class='col-sm-8'><input id='firmaAdi" + id + "' class='form-control' placeholder='Firma Adı' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>E-Posta</label><div class='col-sm-8'><input id='mail" + id + "' class='form-control' placeholder='E-Posta' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Site Adresi</label><div class='col-sm-8'><input id='web" + id + "' class='form-control' placeholder='Site Adresi' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Telefon</label><div class='col-sm-8'><input id='tel" + id + "' class='form-control' placeholder='Telefon' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Faks</label><div class='col-sm-8'><input id='faks" + id + "' class='form-control' placeholder='Faks' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Mobil Tel</label><div class='col-sm-8'><input id='mobil" + id + "' class='form-control' placeholder='Mobil Tel' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Firma Adresi</label><div class='col-sm-8'><textarea id='adres" + id + "' name='' class='form-control' cols='30' rows='5' value=''></textarea></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ülke</label><div class='col-sm-8'><input id='ulke" + id + "' class='form-control' placeholder='Ülke' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Şehir</label><div class='col-sm-8'><input id='sehir" + id + "' class='form-control' placeholder='Şehir' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>İlçe</label><div class='col-sm-8'><input id='ilce" + id + "' class='form-control' placeholder='İlçe' value='' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Anahtar Kelimeler</label><div class='col-sm-8'><input id='keywords" + id + "' class='form-control' placeholder='Anahtar Kelimeler' value='' type='text'></div></div></form></div></div></div>";
                        }
                        else
                        {
                            for (int z = 0; z < tblTab.Rows.Count; z++)
                            {
                                DataRow dr1 = tblTab.Rows[z];
                                tabicerik += "<div id='tab" + i + "' class='tab-pane fade'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class=' col-sm-2 control-label'>Firma Adı</label><div class='col-sm-8'><input id='firmaAdi" + id + "' class='form-control' placeholder='Firma Adı' value='" + dr1["FirmaAdi"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>E-Posta</label><div class='col-sm-8'><input id='mail" + id + "' class='form-control' placeholder='E-Posta' value='" + dr1["Mail"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Site Adresi</label><div class='col-sm-8'><input id='web" + id + "' class='form-control' placeholder='Site Adresi' value='" + dr1["URL"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Telefon</label><div class='col-sm-8'><input id='tel" + id + "' class='form-control' placeholder='Telefon' value='" + dr1["Tel"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Faks</label><div class='col-sm-8'><input id='faks" + id + "' class='form-control' placeholder='Faks' value='" + dr1["Faks"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Mobil Tel</label><div class='col-sm-8'><input id='mobil" + id + "' class='form-control' placeholder='Mobil Tel' value='" + dr1["MobilTel"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Firma Adresi</label><div class='col-sm-8'><textarea id='adres" + id + "' name='' class='form-control' cols='30' rows='5' >" + dr1["Adres"].ToString() + "</textarea></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ülke</label><div class='col-sm-8'><input id='ulke" + id + "' class='form-control' placeholder='Ülke' value='" + dr1["Ulke"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Şehir</label><div class='col-sm-8'><input id='sehir" + id + "' class='form-control' placeholder='Şehir' value='" + dr1["Sehir"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>İlçe</label><div class='col-sm-8'><input id='ilce" + id + "' class='form-control' placeholder='İlçe' value='" + dr1["Ilce"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Anahtar Kelimeler</label><div class='col-sm-8'><input id='keywords" + id + "' class='form-control' placeholder='Anahtar Kelimeler' value='" + dr1["KeyWords"].ToString() + "' type='text'></div></div></form></div></div></div>";
                            }
                        }
                    }
                }
                tab += "</ul>";
                tabicerik += "</div>";
                return tab + tabicerik;
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string siteBilgiGuncelle(string FirmaAdi, string Adres, string Ulke, string Sehir, string Ilce, string Tel, string Faks, string MobilTel, string Mail, string URL, string KeyWords, string ID)
        {

            //FirmaAdi, Adres, Ulke, Sehir, Ilce, Tel, Faks, MobilTel, Mail, URL, KeyWords, DilID
            if (Session["AdminID"] != null)
            {
                if (CmdReturnInt("Select Count(*) From SiteBilgileri where DilID=" + ID) == 0)
                {
                    CmdIslem("Insert Into SiteBilgileri (FirmaAdi, Adres, Ulke, Sehir, Ilce, Tel, Faks, MobilTel, Mail, URL, KeyWords, DilID) values ('" + FirmaAdi + "','" + Adres + "','" + Ulke + "','" + Sehir + "','" + Ilce + "','" + Tel + "','" + Faks + "','" + MobilTel + "','" + Mail + "','" + URL + "','" + KeyWords + "'," + ID + ")");
                }
                else
                {
                    CmdIslem("update SiteBilgileri set FirmaAdi='" + FirmaAdi + "', Adres='" + Adres + "', Ulke='" + Ulke + "', Sehir='" + Sehir + "', Ilce='" + Ilce + "', Tel='" + Tel + "', Faks='" + Faks + "', MobilTel='" + MobilTel + "', Mail='" + Mail + "', URL='" + URL + "', KeyWords='" + KeyWords + "' where DilID=" + ID);
                }
                return "";
            }
            return "Login";
        }

        private int CmdReturnInt(string sqlStr)
        {
            int a = 0;
            using (SqlConnection cnn = new SqlConnection(sqlCmd))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, cnn))
                {
                    cnn.Open();
                    a = Int32.Parse(cmd.ExecuteScalar().ToString());
                    cnn.Close();
                }
            }
            return a;
        }

        private string CmdReturnString(string sqlStr)
        {
            string a = "0";
            using (SqlConnection cnn = new SqlConnection(sqlCmd))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, cnn))
                {
                    cnn.Open();
                    a = cmd.ExecuteScalar().ToString();
                    cnn.Close();
                }
            }
            return a;
        }

        private void CmdIslem(string sqlStr)
        {
            using (SqlConnection cnn = new SqlConnection(sqlCmd))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, cnn))
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }

        }

        [WebMethod(EnableSession = true)]
        public string DilEkle(string adi, string kisaad)
        {
            if (Session["AdminID"] != null)
            {
                CmdIslem("insert into Dil (Adi,KisaAdi) values ('" + adi + "','" + kisaad + "')");
                return "";
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string Diller()
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Dil"), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string SiteAyalari()
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Ayarlar"), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string SiteAyarlariGuncelle(string satisAktif, string blogAktif, string uyeliksizSatis, string uyelikZorunlu, string googleClientID, string googleClientSecret, string facebookAppID, string facebookSecret, string twitterApiID, string twitterSecret, string dilID)
        {
            string sAktif = "0", bAktif = "0", usAktif = "0", uyZ = "0";
            if (satisAktif == "true") { sAktif = "1"; } else { sAktif = "0"; }
            if (blogAktif == "true") { bAktif = "1"; } else { bAktif = "0"; }
            if (uyeliksizSatis == "true") { usAktif = "1"; } else { usAktif = "0"; }
            if (uyelikZorunlu == "true") { uyZ = "1"; } else { uyZ = "0"; }

            if (Session["AdminID"] != null)
            {

                CmdIslem("Update Ayarlar set SatisAktif=" + sAktif + ", BlogAktif=" + bAktif + ", UyeliksizSatis=" + usAktif + ", UyelikZorunlu=" + uyZ + ", GoogleClientID='" + googleClientID + "', GoogleClientSecret='" + googleClientSecret + "', FacebookAppID='" + facebookAppID + "', FacebookSecret='" + facebookSecret + "', TwitterApiID='" + twitterApiID + "', TwitterSecret='" + twitterSecret + "', DilID=" + dilID + "");
                return "";
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string DilIslem(string id, int deger)
        {
            if (Session["AdminID"] != null)
            {
                CmdIslem("Update Dil set Aktif=" + deger + " where ID=" + id);
                return "";
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string DilGuncelle(string id, string dilAdi, string kisaAdi, string durum)
        {
            if (Session["AdminID"] != null)
            {
                if (durum == "True")
                {
                }
                else
                {
                    CmdIslem("Update Dil set Adi='" + dilAdi + "',KisaAdi='" + kisaAdi + "' ,Aktif=0 where ID=" + id);
                }
                return "";
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string DilBilgi(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Dil where ID=" + id), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string UrunKategorileri()
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Kategori"), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string Kategoriler()
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Kategori"), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string KategoriDurumGuncelle(string id, string durum)
        {
            if (Session["AdminID"] != null)
            {
                if (CmdReturnInt("select COUNT(*) from Kategori k inner join KategoriL kl on kl.KID=k.ID inner  join Urunler u on u.KategoriID=k.ID inner join UrunlerL ul on ul.UrunID=u.ID where k.ID=" + id) > 0)
                {
                    CmdIslem("Update Kategori Set Aktif=" + durum + " where ID=" + id);
                    CmdIslem("Update KategoriL Set Aktif=" + durum + " where KID=" + id);
                }
                else
                {
                    File.Delete(Server.MapPath("~/Content/img/categories/" + CmdReturnString("Select Resim From kategori where ID=" + id)));
                    CmdIslem("Delete KategoriL  where KID=" + id);
                    CmdIslem("Delete Kategori  where ID=" + id);
                }

                return "";
            }
            else
            {

                return "Login";
            }
        }



        [WebMethod(EnableSession = true)]
        public string kategoriBilgi(string id, string str)
        {
            if (Session["AdminID"] != null)
            {

                return JsonConvert.SerializeObject(GetDataSet("Select * From KategoriL where KID = " + str + " and DID = " + id), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string KategoriEkleme(string adi, string aciklama)
        {
            string sonuc = "Login";
            string seo = adi.ToLower();
            seo = seo.Replace(" ", "-");
            if (Session["AdminID"] != null)
            {
                if (CmdReturnInt("select Count(*) from Kategori where Adi='" + adi + "'") == 0)
                {
                    int a = CmdReturnInt("insert into Kategori (Adi) values ('" + adi + "')select scope_identity()");
                    DataTable tbl = new DataTable();
                    tbl = GetDataTable("Select * From Dil where Aktif=1");
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow dr = tbl.Rows[i];
                        CmdIslem("insert into KategoriL (Adi,Aciklama,Seolink,KID,DID) values ('" + adi + "','" + aciklama + "','" + seo + "','" + a + "','" + dr["ID"].ToString() + "')");
                        Session["KategoriID"] = a.ToString();
                    }
                    sonuc = "İşlem Başarılı";
                }
                else
                {
                    sonuc = "Aynı İsimle İkinci Kategori Eklenemez..";
                }


            }
            return sonuc;
        }

        [WebMethod(EnableSession = true)]
        public string KategoriGuncelle(string did, string kid, string adi, string aciklama, string seolink, string siraNo, string durum)
        {
            if (Session["AdminID"] != null)
            {
                if (CmdReturnString("Select DilID from Ayarlar") == did)
                {
                    CmdIslem("Update Kategori set Adi='" + adi + "' where  ID=" + kid);
                }
                if (CmdReturnInt("Select Count(*) From KategoriL where KID=" + kid + " and DID=" + did) == 0)
                {
                    CmdIslem("insert into KategoriL (Adi,Aciklama,Seolink,KID,DID,SiraNo) values ('" + adi + "','" + aciklama + "','" + seolink + "','" + kid + "','" + did + "','" + siraNo + "')");
                }
                else
                {
                    if (durum == "true")
                    {
                        CmdIslem("Update KategoriL set Adi='" + adi + "',Aciklama='" + aciklama + "',Seolink='" + seolink + "',SiraNo=" + siraNo + ",Aktif=1 where KID=" + kid + " and  DID=" + did);
                    }
                    else
                    {
                        CmdIslem("Update KategoriL set Adi='" + adi + "',Aciklama='" + aciklama + "',Seolink='" + seolink + "',SiraNo=" + siraNo + ",Aktif=0 where KID=" + kid + " and  DID=" + did);
                    }
                }
                return "";
            }
            return "Login";
        }

        public string seoYap(string str)
        {
            string seo = str.ToLower();
            if (string.IsNullOrEmpty(seo)) return "";
            if (seo.Length > 80)

                seo = seo.Substring(0, 80);
            seo = seo.Replace("ş", "s");
            seo = seo.Replace("Ş", "S");
            seo = seo.Replace("ğ", "g");
            seo = seo.Replace("Ğ", "G");
            seo = seo.Replace("İ", "I");
            seo = seo.Replace("ı", "i");
            seo = seo.Replace("ç", "c");
            seo = seo.Replace("Ç", "C");
            seo = seo.Replace("ö", "o");
            seo = seo.Replace("Ö", "O");
            seo = seo.Replace("ü", "u");
            seo = seo.Replace("Ü", "U");
            seo = seo.Replace("'", "");
            seo = seo.Replace("\"", "");
            seo = seo.Replace("'", "-");
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            //if (r.IsMatch(s))
            seo = r.Replace(seo, "-");

            if (!string.IsNullOrEmpty(seo)) while (seo.IndexOf("--") > -1) seo = seo.Replace("--", "-");
            if (seo.StartsWith("-")) seo = seo.Substring(1);
            if (seo.EndsWith("-")) seo = seo.Substring(0, seo.Length - 1);
            return seo;
        }


        [WebMethod(EnableSession = true)]
        public string UrunTeknikDetayi(string id, string str)
        {
            if (Session["AdminID"] != null)
            {

                return JsonConvert.SerializeObject(GetDataSet("Select TeknikAciklama,TeknikAciklamaDevam,TeknikDetay From UrunlerL where UrunID = " + str + " and DilID = " + id), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string UrunDetayi(string id)
        {

            if (Session["AdminID"] != null)
            {

                DataTable tblDiller = new DataTable();
                tblDiller = GetDataTable("Select * From Dil where Aktif=1");

                string dil = CmdReturnString("Select DilID from Ayarlar"), a, tasarim = "<div class='row'><div class='col-md-12'><ul class='nav nav-tabs'>";


                for (int i = 0; i < tblDiller.Rows.Count; i++)
                {
                    DataRow dr = tblDiller.Rows[i];
                    a = dr["ID"].ToString();
                    if (dil == a)
                    {
                        tasarim += "<li class='active'><a href='#tabDil" + dr["Adi"].ToString() + "' data-toggle='tab'>" + dr["Adi"].ToString() + "</a></li>";
                    }
                    else
                    {
                        tasarim += "<li><a href='#tabDil" + dr["Adi"].ToString() + "' data-toggle='tab'>" + dr["Adi"].ToString() + "</a></li>";
                    }
                }
                tasarim += "</ul><div class='tab-content panel wrapper'>";
                for (int i = 0; i < tblDiller.Rows.Count; i++)
                {
                    DataRow dr = tblDiller.Rows[i];
                    string dilID = dr["ID"].ToString();
                    if (dil == dr["ID"].ToString())
                    {

                        DataTable tblUrunBilgiDileGore = new DataTable();
                        tblUrunBilgiDileGore = GetDataTable("Select * From UrunlerL where DilID=" + dr["ID"].ToString() + " and UrunID=" + id);

                        for (int j = 0; j < tblUrunBilgiDileGore.Rows.Count; j++)
                        {
                            DataRow drB = tblUrunBilgiDileGore.Rows[j];
                            tasarim += "<div id='tabDil" + dr["Adi"].ToString() + "' class='tab-pane fade active in'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class=' col-sm-2 control-label'>Ürün Adı<span class='text-danger'> * </span></label><div class='col-sm-10'><input class='form-control' placeholder='Ürün Adi' value='" + drB["UrunAdi"].ToString() + "' id='urunAdi" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ürün Açıklama <span class='text-danger'> * </span></label><div class='col-sm-10'><div id='summernote" + dr["ID"].ToString() + "' >" + drB["Aciklama"].ToString() + "</div></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ürün Fiyatı <span class='text-danger'> * </span></label><div class='col-sm-10'><input class='form-control' value='" + drB["Fiyat"].ToString() + "' placeholder='Ürün Fiyatı' id='urunFiyati" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>KDV<span class='text-danger'></span></label><div class='col-sm-2'><input class='form-control' value='" + drB["KDV"].ToString() + "' placeholder='KDV' id='kdv" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>SEO <span class='text-danger'> * </span></label><div class='col-sm-10'><input class='form-control' placeholder='SEO' value='" + drB["SeoLink"].ToString() + "' id='seo" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ürün Sırası <span class='text-danger'> * </span></label><div class='col-sm-2'><input class='form-control' placeholder='Ürün Sırası' value='" + drB["SiraNo"].ToString() + "' id='urunSirasi" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Meta Tag Title<span class='text-danger'> * </span></label><div class='col-sm-10'><textarea name='Meta Title' rows='5' placeholder='Meta Tag Title' id='metaTitle" + dr["ID"].ToString() + "' class='form-control'>" + drB["MetaTit"].ToString() + "</textarea></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Meta Tag Description<span class='text-danger'></span></label><div class='col-sm-10'><textarea name='Meta Description' rows='5' placeholder='Meta Tag Description' id='metaDesc" + dr["ID"].ToString() + "' class='form-control'>" + drB["MetaDes"].ToString() + "</textarea></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Meta Tag Keywords<span class='text-danger'></span></label><div class='col-sm-10'><textarea name='Meta Key' rows='5' placeholder='Meta Tag Keywords' id='metaKey" + dr["ID"].ToString() + "' class='form-control'>" + drB["MetaDes"].ToString() + "</textarea></div></div></form></div></div></div>";



                        }

                    }
                    else
                    {

                        DataTable tblUrunBilgiDileGore = new DataTable();
                        tblUrunBilgiDileGore = GetDataTable("Select * From UrunlerL where DilID=" + dr["ID"].ToString() + " and UrunID=" + id);
                        for (int j = 0; j < tblUrunBilgiDileGore.Rows.Count; j++)
                        {
                            DataRow drB = tblUrunBilgiDileGore.Rows[j];
                            tasarim += "<div id='tabDil" + dr["Adi"].ToString() + "' class='tab-pane fade'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class=' col-sm-2 control-label'>Ürün Adı<span class='text-danger'> * </span></label><div class='col-sm-10'><input class='form-control' placeholder='Ürün Adi' value='" + drB["UrunAdi"].ToString() + "' id='urunAdi" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ürün Açıklama <span class='text-danger'> * </span></label><div class='col-sm-10'><div id='summernote" + dr["ID"].ToString() + "'></div></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ürün Fiyatı <span class='text-danger'> * </span></label><div class='col-sm-10'><input class='form-control' value='" + drB["Fiyat"].ToString() + "' placeholder='Ürün Fiyatı' id='urunFiyati" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>KDV<span class='text-danger'></span></label><div class='col-sm-2'><input class='form-control' value='" + drB["KDV"].ToString() + "' placeholder='KDV' id='kdv" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>SEO <span class='text-danger'> * </span></label><div class='col-sm-10'><input class='form-control' placeholder='SEO' value='" + drB["SeoLink"].ToString() + "' id='seo" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Ürün Sırası <span class='text-danger'> * </span></label><div class='col-sm-2'><input class='form-control' placeholder='Ürün Sırası' value='" + drB["SiraNo"].ToString() + "' id='urunSirasi" + dr["ID"].ToString() + "' type='text'></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Meta Tag Title<span class='text-danger'> * </span></label><div class='col-sm-10'><textarea name='Meta Title' rows='5' placeholder='Meta Tag Title' id='metaTitle" + dr["ID"].ToString() + "' class='form-control'>" + drB["MetaTit"].ToString() + "</textarea></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Meta Tag Description<span class='text-danger'></span></label><div class='col-sm-10'><textarea name='Meta Description' rows='5' placeholder='Meta Tag Description' id='metaDesc" + dr["ID"].ToString() + "' class='form-control'>" + drB["MetaDes"].ToString() + "</textarea></div></div><div class='form-group'><label class=' col-sm-2 control-label'>Meta Tag Keywords<span class='text-danger'></span></label><div class='col-sm-10'><textarea name='Meta Key' rows='5' placeholder='Meta Tag Keywords' id='metaKey" + dr["ID"].ToString() + "' class='form-control'>" + drB["MetaDes"].ToString() + "</textarea></div></div></form></div></div></div>";
                        }
                    }

                }
                tasarim += "</div></div></div>";
                return tasarim;
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string UrunResimleriIDile(string id)
        {
            string tasarim = "";
            if (Session["AdminID"] != null)
            {
                DataTable tblResimler = new DataTable();
                tblResimler = GetDataTable("Select * From UrunResimleri where UrunID=" + id);
                for (int i = 0; i < tblResimler.Rows.Count; i++)
                {
                    DataRow dr = tblResimler.Rows[i];
                    tasarim += "<tr id='image-row" + i + "'><td class='text-left'><a id='thumb-image" + i + "' data-toggle='image' class='img-thumbnail'><img src='../../Content/img/product-img/small/" + dr["Resim"].ToString() + "' alt='' title='' data-placeholder='#'></a></td><td class='text-right'><input type='text' name='resimSiralama" + i + "' value='" + dr["SiraNo"].ToString() + "' placeholder='Sort Order' class='form-control'></td><td class='text-left'><button type='button' onclick=$('#image-row" + i + "').remove();resimSil(" + dr["ID"].ToString() + "); data-toggle='tooltip' title='' class='btn btn-danger' data-original-title='Sil'><i class='fa fa-minus-circle'></i></button></td></tr>";
                }
                return tasarim;
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string UrunGenelIDile(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("Select * From Urunler where ID=" + id), Formatting.Indented);
            }
            return "Login";
        }


        [WebMethod(EnableSession = true)]
        public string UrunBilgi(string id, string did)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select u.MarkaID,u.KategoriID,ul.Aciklama,u.Barkod,u.UrunKodu from Urunler u inner join UrunlerL ul on ul.UrunID=u.ID where u.ID=" + id + " and ul.DilID=" + did), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string UrunResimSil(string uid, string rid)
        {
            if (Session["AdminID"].ToString() != null)
            {
                string urunlerResim = CmdReturnString("Select Resim From Urunler where ID=" + uid), resimKarsilastirma = CmdReturnString("Select Resim From UrunResimleri where ID=" + rid);
                if (urunlerResim == resimKarsilastirma)
                {
                    File.Delete(Server.MapPath("~/Content/img/product-img/big/" + resimKarsilastirma));
                    File.Delete(Server.MapPath("~/Content/img/product-img/single/" + resimKarsilastirma));
                    File.Delete(Server.MapPath("~/Content/img/product-img/small/" + resimKarsilastirma));
                    CmdIslem("Update Urunler Set Resim='Yok' where ID=" + uid);
                    CmdIslem("Delete UrunResimleri where ID=" + rid);
                }
                else
                {
                    File.Delete(Server.MapPath("~/Content/img/product-img/big/" + resimKarsilastirma));
                    File.Delete(Server.MapPath("~/Content/img/product-img/single/" + resimKarsilastirma));
                    File.Delete(Server.MapPath("~/Content/img/product-img/small/" + resimKarsilastirma));
                    CmdIslem("Delete UrunResimleri where ID=" + rid);
                }
                return "";
            }
            return "Login";
        }


        [WebMethod(EnableSession = true)]
        public string UrunEkleme(string kid, string mid, string adi, string aciklama, string metatit, string metakey, string metades, string modelNo, string stokKodu, string barkod, string fiyat, string kdv, string durum, string siraNo)
        {
            string sonuc = "Login";

            if (Session["AdminID"] != null)
            {
                if (CmdReturnInt("select Count(*) from Urunler where KategoriID=" + kid + " and UrunAdi='" + adi + "'") == 0)
                {
                    int a = CmdReturnInt("insert into Urunler (KategoriID,MarkaID, UrunAdi, UrunKodu,Barkod ,Aktif) values (" + kid + "," + mid + ",'" + adi + "','" + modelNo + "','" + barkod + "',1)select scope_identity()");
                    Session["UrunID"] = a;

                    DataTable tbl = new DataTable();
                    tbl = GetDataTable("Select * From Dil where Aktif=1");
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow dr = tbl.Rows[i];
                        CmdIslem("insert into UrunlerL (UrunID,DilID, UrunAdi, Aciklama,SeoLink, MetaTit, MetaKey, MetaDes,SiraNo,Fiyat,KDV) values (" + a + ",'" + dr["ID"].ToString() + "','" + adi + "','" + aciklama + "','" + seoYap(adi) + "','" + metatit + "','" + metakey + "','" + metades + "'," + siraNo + "," + fiyat + "," + kdv + ")");
                    }
                    sonuc = "İşlem Başarılı";
                }
                else
                {
                    sonuc = "Aynı İsimle İkinci Ürün Eklenemez..";
                }


            }
            return sonuc;
        }


        [WebMethod(EnableSession = true)]
        public string UrunGuncelleUrunlerTablosu(string uid, string kid, string mid, string modelNo, string barkod, string durum)
        {
            string sonuc = "Login", a;

            if (durum == "true")
            {
                a = "1";
            }
            else
            {
                a = "0";
            }

            if (Session["AdminID"] != null)
            {
                Session["UrunID"] = uid;
                CmdIslem("Update Urunler set KategoriID=" + kid + ",MarkaID=" + mid + ",UrunKodu='" + modelNo + "',Barkod='" + barkod + "',Aktif=" + a + " where ID=" + uid);
                sonuc = "OK";
            }
            return sonuc;
        }

        [WebMethod(EnableSession = true)]
        public string UrunGuncelleUrunlerDilTablosu(string uid, string did, string adi, string aciklama, string siraNo, string seo, string fiyat, string kdv, string metaTit, string metaKey, string metaDes, string teknikAciklama, string teknikAciklamaDevam, string teknikDetay)
        {
            string sonuc = "Login";
            Session["UrunID"] = uid;

            if (Session["AdminID"] != null)
            {
                CmdIslem("Update UrunlerL set UrunAdi='" + adi + "',Aciklama='" + aciklama + "',SiraNo=" + siraNo + ",SeoLink='" + seo + "',Fiyat=" + fiyat.Replace(",", ".") + ",KDV=" + kdv + ",MetaTit='" + metaTit + "',MetaKey='" + metaKey + "',MetaDes='" + metaDes + "',TeknikAciklama='" + teknikAciklama + "',TeknikAciklamaDevam='" + teknikAciklamaDevam + "',TeknikDetay='" + teknikDetay + "'  where UrunID=" + uid + " and DilID=" + did);
                sonuc = "Başarılı";
            }
            return sonuc;
        }

        [WebMethod(EnableSession = true)]
        public string UrunlerKategoriyeGore(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select u.ID,u.UrunAdi,U.Aktif ,ul.Fiyat,u.UrunKodu,u.Resim from Urunler u  inner join UrunlerL ul on ul.UrunID=u.ID where u.KategoriID=" + id + " and ul.DilID=" + CmdReturnInt("select DilID From Ayarlar")), Formatting.Indented);
            }
            return "Login";
        }
        [WebMethod(EnableSession = true)]
        public string Urunler()
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select u.ID,u.UrunAdi,U.Aktif ,ul.Fiyat,u.UrunKodu,u.Resim from Urunler u  inner join UrunlerL ul on ul.UrunID=u.ID where  ul.DilID=" + CmdReturnInt("select DilID From Ayarlar")), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string DurumGuncelle(string id, string deger, string kolon)
        {
            if (Session["AdminID"] != null)
            {
                CmdIslem("Update " + kolon + " set Aktif=" + deger + " where ID=" + id);

                return "";
            }
            return "Login";
        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod(EnableSession = true)]
        public void resimYukleKategori()
        {
            Bitmap yeniresim = null;

            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            if (httpPostedFile != null)
            {
                string b = seoYap(CmdReturnString("Select Adi from Kategori where ID=" + Session["KategoriID"].ToString() + ""));

                yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 600, 400);
                yeniresim.Save(Server.MapPath("~/Content/img/categories/" + b + Path.GetExtension(httpPostedFile.FileName)));
                CmdIslem("update Kategori set Resim='" + b + Path.GetExtension(httpPostedFile.FileName) + "' where ID=" + Session["KategoriID"].ToString());
            }
        }

        [WebMethod(EnableSession = true)]
        public void kategoriIDAta(string id)
        {
            Session["KategoriID"] = id;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod(EnableSession = true)]
        public void kategoriResimGuncelle()
        {
            Bitmap yeniresim = null;

            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            if (httpPostedFile != null)
            {
                string b = seoYap(CmdReturnString("Select Adi from Kategori where ID=" + Session["KategoriID"].ToString() + ""));
                try
                {
                    File.Delete(Server.MapPath("~/Content/img/categories/" + CmdReturnString("Select Resim From kategori where ID=" + Session["KategoriID"].ToString())));
                }
                catch (Exception)
                {
                }

                yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 600, 400);
                yeniresim.Save(Server.MapPath("~/Content/img/categories/" + b + Path.GetExtension(httpPostedFile.FileName)));
                CmdIslem("update Kategori set Resim='" + b + Path.GetExtension(httpPostedFile.FileName) + "' where ID=" + Session["KategoriID"].ToString());
            }
        }

        private Bitmap resimBoyutlandir(Stream resim, int genislik, int yukseklik)
        {
            Bitmap orjinalresim = new Bitmap(resim);
            int yenigenislik = orjinalresim.Width;
            int yeniyukseklik = orjinalresim.Height;
            double enboyorani = Convert.ToDouble(orjinalresim.Width) / Convert.ToDouble(orjinalresim.Height);

            if (enboyorani <= 1 && orjinalresim.Width > genislik)
            {
                yenigenislik = genislik;
                yeniyukseklik = Convert.ToInt32(Math.Round(yenigenislik / enboyorani));
            }
            else if (enboyorani > 1 && orjinalresim.Height > yukseklik)
            {
                yeniyukseklik = yukseklik;
                yenigenislik = Convert.ToInt32(Math.Round(yeniyukseklik * enboyorani));
            }
            //return new Bitmap(orjinalresim, yenigenislik, yeniyukseklik);
            return new Bitmap(orjinalresim, genislik, yukseklik);

        }



        [WebMethod(EnableSession = true)]
        public string Sliderlar()
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Slider"), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string SliderBilgi(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Slider where ID=" + id), Formatting.Indented);
            }
            return "Login";
        }


        [WebMethod(EnableSession = true)]
        public string SliderEkleme(string ad, string baslikM, string baslikE, string button, string url, string durum)
        {
            string sonuc = "Login";
            if (Session["AdminID"] != null)
            {
                Session["SliderID"] = CmdReturnString("insert into Slider (Adi,BaslikIcerik,BaslikEk,ButtonName,URL,Aktif) values ('" + ad + "','" + baslikM + "','" + baslikE + "','" + button + "','" + url + "','" + durum + "') select scope_identity()");
                sonuc = "İşlem Başarılı";
            }
            return sonuc;
        }

        [WebMethod(EnableSession = true)]
        public string SliderGuncelle(string id, string ad, string baslikM, string baslikE, string button, string url, string durum)
        {
            string a = "", b = "";
            if (durum == "true") { a = "1"; } else { a = "0"; }

            if (Session["AdminID"] != null)
            {
                CmdIslem("Update Slider set Adi='" + ad + "', BaslikIcerik='" + baslikM + "', BaslikEk='" + baslikE + "', ButtonName='" + button + "', URL='" + url + "', Aktif=" + a + " where ID=" + id);
                Session["SliderID"] = id;
            }
            else
            {
                b = "Login";
            }
            return b;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod(EnableSession = true)]
        public void resimYukleSlider()
        {
            Bitmap yeniresim = null;
            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            if (httpPostedFile != null)
            {
                try
                {
                    File.Delete(Server.MapPath("~/Content/img/slide-img/" + CmdReturnString("Select Resim From Slider where ID=" + Session["SliderID"].ToString())));
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 1290, 659);
                    yeniresim.Save(Server.MapPath("~/Content/img/slide-img/" + httpPostedFile.FileName));
                    CmdIslem("update Promosyon set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["SliderID"].ToString());
                }
                catch (Exception)
                {
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 1290, 659);
                    yeniresim.Save(Server.MapPath("~/Content/img/slide-img/" + httpPostedFile.FileName));
                    CmdIslem("update Slider set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["SliderID"].ToString());
                }


            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod(EnableSession = true)]
        public void resimYukleSliderGuncelle()
        {
            Bitmap yeniresim = null;
            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            if (httpPostedFile != null)
            {
                try
                {
                    File.Delete(Server.MapPath("~/Content/img/slide-img/" + CmdReturnString("Select Resim From Slider where ID=" + Session["SliderID"].ToString())));
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 1290, 659);
                    yeniresim.Save(Server.MapPath("~/Content/img/slide-img/" + httpPostedFile.FileName));
                    CmdIslem("update Slider set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["SliderID"].ToString());
                }
                catch (Exception)
                {
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 1290, 659);
                    yeniresim.Save(Server.MapPath("~/Content/img/slide-img/" + httpPostedFile.FileName));
                    CmdIslem("update Slider set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["SliderID"].ToString());
                }


            }
        }

        [WebMethod(EnableSession = true)]
        public string Promosyonlar()
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Promosyon"), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string PromosyonBilgi(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Promosyon where ID=" + id), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string PromosyonGuncelle(string id, string adi, string url, string durum)
        {
            if (Session["AdminID"] != null)
            {
                string a = "";
                if (durum == "true")
                {
                    a = "1";
                }
                else
                {
                    a = "0";
                }
                CmdIslem("Update Promosyon set Adi='" + adi + "',URL='" + url + "',Aktif=" + a + " where ID=" + id);
                Session["PromosyonID"] = id;
                return "";
            }
            return "Login";
        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod(EnableSession = true)]
        public void resimYuklePromosyon()
        {
            Bitmap yeniresim = null;
            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            if (httpPostedFile != null)
            {
                try
                {

                    File.Delete(Server.MapPath("~/Content/img/banner/" + CmdReturnString("Select Resim From Promosyon where ID=" + Session["PromosyonID"].ToString())));
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, int.Parse(CmdReturnString("Select OlcuY From Promosyon where ID=" + Session["PromosyonID"].ToString())), int.Parse(CmdReturnString("Select OlcuX From Promosyon where ID=" + Session["PromosyonID"].ToString())));
                    yeniresim.Save(Server.MapPath("~/Content/img/banner/" + httpPostedFile.FileName));
                    CmdIslem("update Promosyon set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["PromosyonID"].ToString());
                }
                catch (Exception)
                {
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, int.Parse(CmdReturnString("Select OlcuY From Promosyon where ID=" + Session["PromosyonID"].ToString())), int.Parse(CmdReturnString("Select OlcuX From Promosyon where ID=" + Session["PromosyonID"].ToString())));
                    yeniresim.Save(Server.MapPath("~/Content/img/banner/" + httpPostedFile.FileName));
                    CmdIslem("update Promosyon set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["PromosyonID"].ToString());
                }


            }
        }


        [WebMethod(EnableSession = true)]
        public string BedenlerIDile(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("Select * From Bedenler where UrunID=" + id), Formatting.Indented);
            }
            return "Login";
        }


        [WebMethod(EnableSession = true)]
        public string BedenEkleme(string id, string bedenAdi)
        {
            string sonuc = "Login";
            if (Session["AdminID"] != null)
            {
                CmdIslem("insert into Bedenler (BedenAdi,UrunID) values ('" + bedenAdi + "','" + id + "')");
                sonuc = "İşlem Başarılı";
            }
            return sonuc;
        }

        [WebMethod(EnableSession = true)]
        public string BedenSil(string id)
        {
            if (Session["AdminID"] != null)
            {
                CmdIslem("Delete Bedenler where ID=" + id);
                return "";
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string EtiketlerIDile(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("Select e.ID,e.Adi From Etiket e inner join UrunEtiket ue on ue.EtiketID=e.ID where ue.UrunID=" + id), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string EtiketEkleme(string id, string etiket)
        {
            string sonuc = "Login";
            if (Session["AdminID"] != null)
            {
                int eti = CmdReturnInt("Insert Into Etiket (Adi) values ('" + seoYap(etiket) + "')select scope_identity()");
                CmdIslem("Insert Into UrunEtiket (EtiketID,UrunID) values (" + eti + "," + id + ")");
                sonuc = "İşlem Başarılı";
            }
            return sonuc;
        }

        [WebMethod(EnableSession = true)]
        public string EtiketSil(string uid, string eid)
        {
            if (Session["AdminID"] != null)
            {
                CmdIslem("Delete UrunEtiket where EtiketID=" + eid + " and UrunID=" + uid);
                return "";
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string RenklerIDile(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("Select * From Renkler where UrunID=" + id), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string RenkEkleme(string id, string renkAdi, string renkKodu)
        {
            string sonuc = "Login";
            if (Session["AdminID"] != null)
            {
                CmdIslem("insert into Renkler (RenkAdi,RenkKodu,UrunID) values ('" + renkAdi + "','" + renkKodu + "','" + id + "')");
                sonuc = "İşlem Başarılı";
            }
            return sonuc;
        }

        [WebMethod(EnableSession = true)]
        public string RenkSil(string id)
        {
            if (Session["AdminID"] != null)
            {
                CmdIslem("Delete Renkler where ID=" + id);
                return "";
            }
            return "Login";
        }



        [WebMethod(EnableSession = true)]
        public string Markalar()
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Markalar"), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string MarkaBilgi(string id)
        {
            if (Session["AdminID"] != null)
            {
                return JsonConvert.SerializeObject(GetDataSet("select * from Markalar where ID=" + id), Formatting.Indented);
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string MarkaGuncelle(string id, string markaAdi, string siraNo, string durum, string resim)
        {
            if (Session["AdminID"] != null)
            {
                Session["MarkaID"] = id;
                CmdIslem("Update Markalar set MarkaAdi='" + markaAdi + "',SiraNo='" + siraNo + "',Aktif=" + durum + " where ID=" + id);

                return "";
            }
            return "Login";
        }

        [WebMethod(EnableSession = true)]
        public string MarkaSil(string id)
        {
            if (Session["AdminID"] != null)
            {
                try
                {
                    File.Delete(Server.MapPath("~/Content/img/logo/kucuk/" + CmdReturnString("Select Resim From Markalar where ID=" + id)));
                    File.Delete(Server.MapPath("~/Content/img/logo/" + CmdReturnString("Select Resim From Markalar where ID=" + id)));
                    CmdIslem("Delete Markalar where ID=" + id);
                }
                catch (Exception)
                {
                    CmdIslem("Delete Markalar where ID=" + id);
                }


                return "";
            }
            return "Login";
        }


        [WebMethod(EnableSession = true)]
        public string MarkaEkleme(string markaAdi, string siraNo)
        {
            string sonuc = "Login";
            if (Session["AdminID"] != null)
            {
                Session["MarkaID"] = CmdReturnString("insert into Markalar (MarkaAdi, SiraNo) values ('" + markaAdi + "','" + siraNo + "') select scope_identity()");
                sonuc = "İşlem Başarılı";
            }
            return sonuc;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod(EnableSession = true)]
        public void resimYukleMarka()
        {
            Bitmap yeniresim = null;
            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            if (httpPostedFile != null)
            {
                try
                {
                    File.Delete(Server.MapPath("~/Content/img/logo/kucuk/" + CmdReturnString("Select Resim From Markalar where ID=" + Session["MarkaID"].ToString())));
                    File.Delete(Server.MapPath("~/Content/img/logo/" + CmdReturnString("Select Resim From Markalar where ID=" + Session["MarkaID"].ToString())));
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 40, 40);
                    yeniresim.Save(Server.MapPath("~/Content/img/logo/kucuk/" + httpPostedFile.FileName));
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 100, 100);
                    yeniresim.Save(Server.MapPath("~/Content/img/logo/" + httpPostedFile.FileName));
                    CmdIslem("update Markalar set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["MarkaID"].ToString());
                }
                catch (Exception)
                {
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 40, 40);
                    yeniresim.Save(Server.MapPath("~/Content/img/logo/kucuk/" + httpPostedFile.FileName));
                    yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 100, 100);
                    yeniresim.Save(Server.MapPath("~/Content/img/logo/" + httpPostedFile.FileName));
                    CmdIslem("update Markalar set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["MarkaID"].ToString());
                }


            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod(EnableSession = true)]
        public void resimYukleUrun()
        {
            Bitmap yeniresim = null;
            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            string resimAdi = CmdReturnString("Select SeoLink From UrunlerL where  UrunID=" + Session["UrunID"].ToString()), resimYol = CmdReturnString("Select Resim From Urunler where ID=" + Session["UrunID"].ToString());
            int resimSayi = CmdReturnInt("Select Count(*) From UrunResimleri where UrunID=" + Session["UrunID"].ToString());
            if (resimSayi == 0)
            {
                resimSayi = 1;
            }
            else
            {
                resimSayi++;
            }
            resimAdi = resimAdi + "-" + resimSayi.ToString() + System.IO.Path.GetExtension(httpPostedFile.FileName);
            if (httpPostedFile != null)
            {
                try
                {
                    if (resimYol == "Yok")
                    {

                        File.Delete(Server.MapPath("~/Content/img/product-img/big/" + CmdReturnString("Select Resim From UrunResimleri where ID=" + Session["UrunID"].ToString())));
                        File.Delete(Server.MapPath("~/Content/img/product-img/single/" + CmdReturnString("Select Resim From UrunResimleri where ID=" + Session["UrunID"].ToString())));
                        File.Delete(Server.MapPath("~/Content/img/product-img/small/" + CmdReturnString("Select Resim From UrunResimleri where ID=" + Session["UrunID"].ToString())));

                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 440, 600);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/big/" + resimAdi));
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 1025, 1400);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/single/" + resimAdi));
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 70, 95);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/small/" + resimAdi));
                        CmdIslem("Update UrunlerL set Resim='" + httpPostedFile.FileName + "' where ID=" + Session["UrunID"].ToString());
                        CmdIslem("insert into UrunResimleri (UrunID,Resim) values (" + Session["UrunID"].ToString() + ",'" + resimAdi + "')");

                    }
                    else
                    {
                        File.Delete(Server.MapPath("~/Content/img/product-img/big/" + CmdReturnString("Select Resim From UrunResimleri where ID=" + Session["UrunID"].ToString())));
                        File.Delete(Server.MapPath("~/Content/img/product-img/single/" + CmdReturnString("Select Resim From UrunResimleri where ID=" + Session["UrunID"].ToString())));
                        File.Delete(Server.MapPath("~/Content/img/product-img/small/" + CmdReturnString("Select Resim From UrunResimleri where ID=" + Session["UrunID"].ToString())));

                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 440, 600);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/big/" + resimAdi));
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 1025, 1400);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/single/" + resimAdi));
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 70, 95);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/small/" + resimAdi));
                        CmdIslem("insert into UrunResimleri (UrunID,Resim) values (" + Session["UrunID"].ToString() + ",'" + resimAdi + "')");
                    }

                }
                catch (Exception)
                {
                    if (resimYol == "Yok")
                    {
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 440, 600);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/big/" + resimAdi));
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 1025, 1400);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/single/" + resimAdi));
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 70, 95);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/small/" + resimAdi));
                        CmdIslem("insert into UrunResimleri (UrunID,Resim) values (" + Session["UrunID"].ToString() + ",'" + resimAdi + "')");
                        CmdIslem("Update Urunler set Resim='" + resimAdi + "' where ID=" + Session["UrunID"].ToString());
                        CmdIslem("Update UrunlerL set Resim='" + resimAdi + "' where UrunID=" + Session["UrunID"].ToString());

                    }
                    else
                    {
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 440, 600);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/big/" + resimAdi));
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 1025, 1400);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/single/" + resimAdi));
                        yeniresim = resimBoyutlandir(httpPostedFile.InputStream, 70, 95);
                        yeniresim.Save(Server.MapPath("~/Content/img/product-img/small/" + resimAdi));
                        CmdIslem("insert into UrunResimleri (UrunID,Resim) values (" + Session["UrunID"].ToString() + ",'" + resimAdi + "')");
                    }
                }


            }
        }

    }
}
