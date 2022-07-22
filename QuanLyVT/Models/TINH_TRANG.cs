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

        [Required]
        [StringLength(10)]
        public string Ma_TT_LK { get; set; }

        [Required]
        [StringLength(20)]
        public string Ten_TT_LK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LINH_KIEN> LINH_KIEN { get; set; }
    }
}
