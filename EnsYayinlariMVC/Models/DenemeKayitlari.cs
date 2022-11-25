namespace EnsYayinlariMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DenemeKayitlari")]
    public partial class DenemeKayitlari
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string AdSoyad { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string EPosta { get; set; }

        public int? Yas { get; set; }

        [StringLength(50)]
        public string Sinif { get; set; }

        [StringLength(50)]
        public string Alan { get; set; }
    }
}
