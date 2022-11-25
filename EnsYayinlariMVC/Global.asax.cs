using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EnsYayinlariMVC.Models;

namespace EnsYayinlariMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (VeriTabaniContext db = new VeriTabaniContext())
            {
                //db.Database.CreateIfNotExists();
                //Uyeler uye = new Uyeler();
                //uye.Ad = "Enes";
                //uye.Soyad = "Yüksel";
                //uye.Eposta = "enes@ens.com";
                //uye.KullaniciAdi = "ens";
                //uye.Sifre = "123";
                //db.Uyeler.Add(uye);
                //db.SaveChanges();
            }
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
