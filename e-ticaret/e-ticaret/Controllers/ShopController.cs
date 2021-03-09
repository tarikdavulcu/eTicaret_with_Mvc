using e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_ticaret.Controllers
{
    public class ShopController : Controller
    {
        eTicaretContext db = new eTicaretContext();
        public ActionResult Index()
        {

            Session["DilID"] = "1";

            return View();

        }

        public ActionResult Contact()
        {
            using (eTicaretContext db = new eTicaretContext())
            {
                int d = int.Parse(Session["DilID"].ToString());
                return View(db.SiteBilgileris.Where(p => p.DilID == d).ToList());
            }

        }

        public ActionResult About()
        {
            using (eTicaretContext db = new eTicaretContext())
            {
                int d = int.Parse(Session["DilID"].ToString());
                return View(db.Metinlers.Where(p => p.DilID == d).ToList());
            }

        }

        public ActionResult Slider()
        {
            using (eTicaretContext db = new eTicaretContext())
            {
                List<e_ticaret.Models.Slider> slider = db.Sliders.ToList();
                return PartialView("Slider", slider);
            }
        }

        public ActionResult Sepetim()
        {
            string a = Request.Cookies["visitorS"].Value;
            int d = int.Parse(Session["DilID"].ToString());
            ViewBag.Sepet = db.Sepets.Where(s => s.Cookie == a && s.Aktif == true).ToList();
            return View(db.SiteBilgileris.Where(x => x.DilID == d).ToList());
           
        }
        public ActionResult Blog()
        {
            int d = int.Parse(Session["DilID"].ToString());
            return PartialView(db.BlogHaberLs.Where(x => x.DilID == d).ToList());
           
        }
        public ActionResult InstagramList()
        {
            int d = int.Parse(Session["DilID"].ToString());
            return PartialView();

        }
        public ActionResult PromosyonBanner()
        {

            return PartialView("PromosyonBanner");
        }

        public ActionResult PromosyonBannerDortlu()
        {

            using (eTicaretContext db = new eTicaretContext())
            {
                List<e_ticaret.Models.Promosyon> promosyonDortlu = db.Promosyons.ToList();
                return PartialView("PromosyonBannerDortlu", promosyonDortlu);
            }

        }

        private string GetClientIp()
        {
            var ip = string.Empty;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null && System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].Length != 0)
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
            }
            else if (System.Web.HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                ip = System.Web.HttpContext.Current.Request.UserHostName;
            }
            return ip;
        }

        public ActionResult HeaderTopBar()
        {

            HttpCookie cokie;
            cokie = Request.Cookies["visitorS"];
            if (cokie == null)
            {
                cokie = new HttpCookie("visitorS", GetClientIp());
                Response.Cookies.Add(cokie);
            }
            string a = Request.Cookies["visitorS"].Value;
            int d = int.Parse(Session["DilID"].ToString());
            ViewBag.Sepet = db.Sepets.Where(s=> s.Cookie==a && s.Aktif==true).ToList();
            ViewBag.Diller = db.Dils.Where(x => x.Aktif == true).ToList();
            return PartialView("HeaderTopBar", db.SiteBilgileris.Where(x => x.DilID == d).ToList());

        }

        public ActionResult Fotter()
        {
            int d = int.Parse(Session["DilID"].ToString());
            return PartialView("Fotter", db.SiteBilgileris.Where(x => x.DilID == d).ToList());
        }

        public ActionResult DilDegistir(string DilID, string url)
        {
            Session["DilID"] = DilID;
            if (url == null)
            {
                return View();
            }
            else
            {
                return Redirect(url);
            }
        }
    }
}