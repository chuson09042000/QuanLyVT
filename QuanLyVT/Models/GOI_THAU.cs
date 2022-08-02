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

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength( maximumLength:10, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 10 k� t?")]
        public string Ma_Goi_Thau { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength( maximumLength:50, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 50 k� t?")]
        public string Ten_Goi_Thau { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength( maximumLength:300, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 300 k� t?")]
        public string Du_An { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIET_BI> THIET_BI { get; set; }
    }
}
