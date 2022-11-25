using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using EnsYayinlariMVC.Models;

namespace EnsYayinlariMVC.Controllers
{
    public class UyelerController : Controller
    {
        private VeriTabaniContext db = new VeriTabaniContext();

        [AllowAnonymous]
        public ActionResult Giris()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Giris(Uyeler GelenUye)
        {
            Uyeler uye = db.Uyeler.Where(s => s.KullaniciAdi == GelenUye.KullaniciAdi && s.Sifre == GelenUye.Sifre).FirstOrDefault();
            Uyeler admin = db.Uyeler.Where(s => "admin" == GelenUye.KullaniciAdi && s.Sifre == GelenUye.Sifre).FirstOrDefault();

            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(GelenUye.KullaniciAdi, false);
                return RedirectToAction("Admin");
            }
            else if (uye != null)
            {
                FormsAuthentication.SetAuthCookie(GelenUye.KullaniciAdi, false);
                return RedirectToAction("Oturum");
            }
            else
            {
                ViewBag.hata = "Bilgiler hatalıdır, tekrar deneyiniz.";
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult Oturum()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            List<Uyeler> uye = db.Uyeler.Where(s => s.KullaniciAdi == GirenUye).ToList();
            return View(uye);
        }

        [AllowAnonymous]
        [HttpPost, ActionName("Oturum")]
        public ActionResult OturumOK()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris");
        }

        public ActionResult Admin()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            List<Uyeler> uye = db.Uyeler.Where(s => "ens" == GirenUye).ToList();
            return View(uye);
        }

        [HttpPost, ActionName("Admin")]
        public ActionResult AdminOK()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris");
        }

        [AllowAnonymous]
        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(db.Uyeler.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uyeler uyeler = db.Uyeler.Find(id);
            if (uyeler == null)
            {
                return HttpNotFound();
            }
            return View(uyeler);
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UyeID,Ad,Soyad,Eposta,KullaniciAdi,Sifre")] Uyeler uyeler)
        {
            if (ModelState.IsValid)
            {
                db.Uyeler.Add(uyeler);
                db.SaveChanges();
                return RedirectToAction("Giris");
            }

            return View(uyeler);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uyeler uyeler = db.Uyeler.Find(id);
            if (uyeler == null)
            {
                return HttpNotFound();
            }
            return View(uyeler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UyeID,Ad,Soyad,Eposta,KullaniciAdi,Sifre")] Uyeler uyeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uyeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uyeler);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uyeler uyeler = db.Uyeler.Find(id);
            if (uyeler == null)
            {
                return HttpNotFound();
            }
            return View(uyeler);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uyeler uyeler = db.Uyeler.Find(id);
            db.Uyeler.Remove(uyeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
