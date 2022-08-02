namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BENH_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BENH_VIEN()
        {
            HOP_DONG = new HashSet<HOP_DONG>();
            THIET_BI = new HashSet<THIET_BI>();
        }

        [Key]
        public int ID_BENH_VIEN { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength( maximumLength:10, ErrorMessage = "?? dài không ???c v??t quá 10 ký t?")]
        public string Ma_BV { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength( maximumLength:100, ErrorMessage = "?? dài không ???c v??t quá 100 ký t?")]
        public string Ten_BV { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength( maximumLength:350, ErrorMessage = "?? dài không ???c v??t quá 350 ký t?")]
        public string Dia_Chi { get; set; }

        [StringLength( maximumLength:50, ErrorMessage = "?? dài không ???c v??t quá 50 ký t?")]
        public string SDT { get; set; }

        [StringLength( maximumLength:50, ErrorMessage = "?? dài không ???c v??t quá 50 ký t?")]
        public string Fax { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOP_DONG> HOP_DONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIET_BI> THIET_BI { get; set; }
    }
}
