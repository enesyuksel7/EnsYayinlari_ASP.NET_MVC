using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnsYayinlariMVC.Models;

namespace EnsYayinlariMVC.Controllers
{
    public class DenemeKayitlariController : Controller
    {
        private VeriTabaniContext db = new VeriTabaniContext();

        public ActionResult Index()
        {
            return View(db.DenemeKayitlari.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DenemeKayitlari denemeKayitlari = db.DenemeKayitlari.Find(id);
            if (denemeKayitlari == null)
            {
                return HttpNotFound();
            }
            return View(denemeKayitlari);
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "Id,AdSoyad,Telefon,EPosta,Yas,Sinif,Alan")] DenemeKayitlari denemeKayitlari)
        {
            if (ModelState.IsValid)
            {
                db.DenemeKayitlari.Add(denemeKayitlari);
                db.SaveChanges();
                return RedirectToAction("Oturum","Uyeler");
            }

            return View(denemeKayitlari);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DenemeKayitlari denemeKayitlari = db.DenemeKayitlari.Find(id);
            if (denemeKayitlari == null)
            {
                return HttpNotFound();
            }
            return View(denemeKayitlari);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdSoyad,Telefon,EPosta,Yas,Sinif,Alan")] DenemeKayitlari denemeKayitlari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(denemeKayitlari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(denemeKayitlari);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DenemeKayitlari denemeKayitlari = db.DenemeKayitlari.Find(id);
            if (denemeKayitlari == null)
            {
                return HttpNotFound();
            }
            return View(denemeKayitlari);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DenemeKayitlari denemeKayitlari = db.DenemeKayitlari.Find(id);
            db.DenemeKayitlari.Remove(denemeKayitlari);
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
