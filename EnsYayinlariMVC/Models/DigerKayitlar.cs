namespace EnsYayinlariMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DigerKayitlar")]
    public partial class DigerKayitlar
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [StringLength(50)]
        public string EPosta { get; set; }

        [StringLength(200)]
        public string Sorun { get; set; }
    }
}
