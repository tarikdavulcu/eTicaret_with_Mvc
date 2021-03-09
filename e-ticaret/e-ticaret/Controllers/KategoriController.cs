
using e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_ticaret.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Katagori
        eTicaretContext db = new eTicaretContext();
        public ActionResult Kategori()
        {
            using (eTicaretContext db = new eTicaretContext())
            {
                int d =int.Parse( Session["DilID"].ToString());
                return View(db.KategoriLs.Where(p => p.Kategori.Aktif==true && p.DID == d).OrderByDescending(p=>p.SiraNo).ToList());
            }

        }

        public ActionResult KategoriContent()
        {
           
                int d = int.Parse(Session["DilID"].ToString());
            ViewBag.ayarlar = db.Ayarlars.Where(p => p.DilID == d).ToList();
                return PartialView("KategoriContent", db.KategoriLs.Where(p => p.Kategori.Aktif == true && p.DID == d).ToList());
        }
    }
}