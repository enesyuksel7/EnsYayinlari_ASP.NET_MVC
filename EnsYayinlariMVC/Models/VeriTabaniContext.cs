namespace EnsYayinlariMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Data.Entity;
    using System.Web.Routing;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EnsYayinlariMVC.Models;

    public partial class VeriTabaniContext : DbContext
    {
        public VeriTabaniContext()
            : base("name=VeriTabaniContext")
        {
        }

        public virtual DbSet<DenemeKayitlari> DenemeKayitlari { get; set; }
        public virtual DbSet<DigerKayitlar> DigerKayitlar { get; set; }
        public virtual DbSet<Uyeler> Uyeler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
