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

        [Required]
        [StringLength(15)]
        public string Ma_So_LK { get; set; }

        [Required]
        [StringLength(200)]
        public string Ten_LK { get; set; }

        [Required]
        [StringLength(50)]
        public string XX_TC { get; set; }

        [Required]
        [StringLength(10)]
        public string Nam_SX { get; set; }

        public int ID_DVT { get; set; }

        public int ID_TINH_TRANG { get; set; }

        public virtual DVT DVT { get; set; }

        public virtual TINH_TRANG TINH_TRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIET_BI> THIET_BI { get; set; }
    }
}
