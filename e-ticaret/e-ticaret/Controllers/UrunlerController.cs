using e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_ticaret.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        eTicaretContext db = new eTicaretContext();
        public ActionResult Index(string id)
        {

            int d = int.Parse(Session["DilID"].ToString());

            return View((from i in db.KategoriLs where i.Seolink == id && i.DID == d select i).ToList());

        }

        public ActionResult UrunDetay(string id)
        {
            try
            {

                int d = int.Parse(Session["DilID"].ToString());
                return View(db.UrunlerLs.Where(p => p.SeoLink == id && p.DilID == d).ToList());
            }
            catch (Exception)
            {

                return Redirect("/Shop/Index");
            }
        }


        public ActionResult UrunlerAnaSayfa()
        {
            int d = int.Parse(Session["DilID"].ToString());
            return PartialView("UrunlerAnaSayfa", db.UrunlerLs.Where(p => p.DilID == d).OrderByDescending(p => p.Urunler.ID).Take(15).ToList());

        }

        public JsonResult SepeteEkle(string uid, string fiyat, string adet, string beden, string renk)
        {
            string a = Request.Cookies["visitorS"].Value, b = System.DateTime.Now.ToString("dd-MM-yyyy");


            List<Sepet> l = db.Sepets.Where(p => p.Aktif == true && p.Cookie == a).ToList();
            foreach (var item in l)
            {

            }
            if (l.Count > 0)
            {
                Sepet_Detay sd = new Sepet_Detay();
                sd.UrunID = int.Parse(uid);
                sd.Adet = int.Parse(adet);
                sd.Fiyat = double.Parse(fiyat);
                sd.Beden = beden;
                sd.Renk = renk;
                foreach (var item in l)
                {
                    sd.SepetID = item.ID;
                }
                sd.Tarih = System.DateTime.Now.ToString("dd-MM-yyyy");
                db.Sepet_Detay.Add(sd);
                db.SaveChanges();
            }
            else
            {
                Sepet sepet = new Sepet();
                sepet.Tarih = System.DateTime.Now.ToString("dd-MM-yyyy");
                sepet.Cookie = a;
                db.Sepets.Add(sepet);
                db.SaveChanges();
                Sepet_Detay sd = new Sepet_Detay();
                sd.UrunID = int.Parse(uid);
                sd.Adet = int.Parse(adet);
                sd.Fiyat = double.Parse(fiyat);
                sd.Beden = beden;
                sd.Renk = renk;
                sd.SepetID = sepet.ID;
                sepet.Aktif = true;
                sd.Tarih = System.DateTime.Now.ToString("dd-MM-yyyy");
                db.Sepet_Detay.Add(sd);
                db.SaveChanges();
            }
            return Json("a");
        }

        public JsonResult SepetenKaldir(int sid)
        {
            Sepet_Detay sd = db.Sepet_Detay.Where(p => p.ID == sid).FirstOrDefault();
            db.Sepet_Detay.Remove(sd);
            db.SaveChanges();
            return Json("a");
        }


        public PartialViewResult Sepet()
        {
            string a = Request.Cookies["visitorS"].Value;
            int d = int.Parse(Session["DilID"].ToString());
            ViewBag.Sepet = db.Sepets.Where(s => s.Cookie == a && s.Aktif == true).ToList();
            return PartialView(db.SiteBilgileris.Where(x => x.DilID == d).ToList());
        }

    }
}