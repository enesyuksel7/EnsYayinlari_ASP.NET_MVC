namespace EnsYayinlariMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uyeler")]
    public partial class Uyeler
    {
        [Key]
        public int UyeID { get; set; }

        [Required]
        [StringLength(30)]
        public string Ad { get; set; }

        [Required]
        [StringLength(30)]
        public string Soyad { get; set; }

        [Required]
        [StringLength(100)]
        public string Eposta { get; set; }

        [Required]
        [StringLength(10)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(10)]
        public string Sifre { get; set; }
    }
}
