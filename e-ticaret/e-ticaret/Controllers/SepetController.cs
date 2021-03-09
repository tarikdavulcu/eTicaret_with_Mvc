using e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_ticaret.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        eTicaretContext db = new eTicaretContext();
        public PartialViewResult Sepet()
        {
            string a = Request.Cookies["visitorS"].Value;
            int d = int.Parse(Session["DilID"].ToString());
            ViewBag.Sepet = db.Sepets.Where(s => s.Cookie == a && s.Aktif == true).ToList();
            return PartialView("Sepet",db.SiteBilgileris.Where(x => x.DilID == d).ToList());
        }

        
    }
}