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

        [Required]
        [StringLength(10)]
        public string Ma_Goi_Thau { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten_Goi_Thau { get; set; }

        [Required]
        [StringLength(300)]
        public string Du_An { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIET_BI> THIET_BI { get; set; }
    }
}
