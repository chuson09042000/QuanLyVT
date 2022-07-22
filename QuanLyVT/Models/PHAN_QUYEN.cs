namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHAN_QUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHAN_QUYEN()
        {
            NGUOI_DUNG = new HashSet<NGUOI_DUNG>();
        }

        [Key]
        public int ID_PHAN_QUYEN { get; set; }

        [Required]
        [StringLength(5)]
        public string Ma_Phan_Quyen { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten_Quyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGUOI_DUNG> NGUOI_DUNG { get; set; }
    }
}
