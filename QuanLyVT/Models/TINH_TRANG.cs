namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TINH_TRANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINH_TRANG()
        {
            LINH_KIEN = new HashSet<LINH_KIEN>();
        }

        [Key]
        public int ID_TINHTRANG { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 10, ErrorMessage = "?? dài không ???c v??t quá 10 ký t?")]
        public string Ma_TT_LK { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 20, ErrorMessage = "?? dài không ???c v??t quá 20 ký t?")]
        public string Ten_TT_LK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LINH_KIEN> LINH_KIEN { get; set; }
    }
}
