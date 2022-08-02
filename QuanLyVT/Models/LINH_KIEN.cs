namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LINH_KIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LINH_KIEN()
        {
            THIET_BI = new HashSet<THIET_BI>();
        }

        [Key]
        public int ID_LINH_KIEN { get; set; }

        //[Required]
        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 15, ErrorMessage = "?? dài không ???c v??t quá 15 ký t?")]
        public string Ma_So_LK { get; set; }
        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        //[Required]
        [StringLength(maximumLength: 200, ErrorMessage = "?? dài không ???c v??t quá 10 ký t?")]
        public string Ten_LK { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 50, ErrorMessage = "?? dài không ???c v??t quá 50 ký t?")]
        public string XX_TC { get; set; }
        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        //[Required]
        [StringLength(maximumLength: 10, ErrorMessage = "?? dài không ???c v??t quá 10 ký t?")]
        public string Nam_SX { get; set; }

        public int ID_DVT { get; set; }

        public int ID_TINH_TRANG { get; set; }

        public virtual DVT DVT { get; set; }

        public virtual TINH_TRANG TINH_TRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIET_BI> THIET_BI { get; set; }
    }
}
