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
    public class DigerKayitlarController : Controller
    {
        private VeriTabaniContext db = new VeriTabaniContext();

        public ActionResult Index()
        {
            return View(db.DigerKayitlar.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DigerKayitlar digerKayitlar = db.DigerKayitlar.Find(id);
            if (digerKayitlar == null)
            {
                return HttpNotFound();
            }
            return View(digerKayitlar);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,EPosta,Sorun")] DigerKayitlar digerKayitlar)
        {
            if (ModelState.IsValid)
            {
                db.DigerKayitlar.Add(digerKayitlar);
                db.SaveChanges();
                return RedirectToAction("Oturum","Uyeler");
            }

            return View(digerKayitlar);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DigerKayitlar digerKayitlar = db.DigerKayitlar.Find(id);
            if (digerKayitlar == null)
            {
                return HttpNotFound();
            }
            return View(digerKayitlar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,EPosta,Sorun")] DigerKayitlar digerKayitlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(digerKayitlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(digerKayitlar);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DigerKayitlar digerKayitlar = db.DigerKayitlar.Find(id);
            if (digerKayitlar == null)
            {
                return HttpNotFound();
            }
            return View(digerKayitlar);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DigerKayitlar digerKayitlar = db.DigerKayitlar.Find(id);
            db.DigerKayitlar.Remove(digerKayitlar);
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
