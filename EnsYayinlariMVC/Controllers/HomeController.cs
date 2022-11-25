using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnsYayinlariMVC.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Hakkimizda()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Yazarlar()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Kitaplar()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Iletisim()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}