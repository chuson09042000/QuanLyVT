namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHAN_VIEN_KY_THUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAN_VIEN_KY_THUAT()
        {
            HOP_DONG = new HashSet<HOP_DONG>();
        }

        [Key]
        public int ID_NHAN_VIEN_KY_THUAT { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_NV_KT { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten_NV_KT { get; set; }

        [Required]
        [StringLength(50)]
        public string Chuc_Vu { get; set; }

        [StringLength(12)]
        public string So_Dien_Thoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOP_DONG> HOP_DONG { get; set; }
    }
}
