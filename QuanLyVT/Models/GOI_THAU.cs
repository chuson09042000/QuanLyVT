namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GOI_THAU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GOI_THAU()
        {
            THIET_BI = new HashSet<THIET_BI>();
        }

        [Key]
        public int ID_GOI_THAU { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength( maximumLength:10, ErrorMessage = "?? dài không ???c v??t quá 10 ký t?")]
        public string Ma_Goi_Thau { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength( maximumLength:50, ErrorMessage = "?? dài không ???c v??t quá 50 ký t?")]
        public string Ten_Goi_Thau { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength( maximumLength:300, ErrorMessage = "?? dài không ???c v??t quá 300 ký t?")]
        public string Du_An { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIET_BI> THIET_BI { get; set; }
    }
}
