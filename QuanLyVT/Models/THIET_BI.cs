namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class THIET_BI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THIET_BI()
        {
            BAO_TRI = new HashSet<BAO_TRI>();
            HOP_DONG = new HashSet<HOP_DONG>();
            SUA_CHUA = new HashSet<SUA_CHUA>();
        }

        [Key]
        public int ID_THIET_BI { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_TB { get; set; }

        [Required]
        [StringLength(200)]
        public string Ten_TB { get; set; }

        [Required]
        [StringLength(50)]
        public string XX_TC { get; set; }

        [Required]
        [StringLength(4)]
        public string Nam_SX { get; set; }

        public int ID_BENH_VIEN { get; set; }

        public int ID_GOI_THAU { get; set; }

        public int ID_LINH_KIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAO_TRI> BAO_TRI { get; set; }

        public virtual BENH_VIEN BENH_VIEN { get; set; }

        public virtual GOI_THAU GOI_THAU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOP_DONG> HOP_DONG { get; set; }

        public virtual LINH_KIEN LINH_KIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUA_CHUA> SUA_CHUA { get; set; }
    }
}
