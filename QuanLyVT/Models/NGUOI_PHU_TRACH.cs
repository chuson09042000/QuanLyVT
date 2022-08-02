namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NGUOI_PHU_TRACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOI_PHU_TRACH()
        {
            HOP_DONG = new HashSet<HOP_DONG>();
        }

        [Key]
        public int ID_NGUOI_PHU_TRACH { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength(maximumLength: 10, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 10 k� t?")]
        public string Ma_Nguoi_Phu_Trach { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength(maximumLength: 50, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 50 k� t?")]
        public string Ten_Nguoi_Phu_Trach { get; set; }

        //[Required]
        [StringLength(maximumLength: 10, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 10 k� t?")]
        public string Ma_BV { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength(maximumLength: 50, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 50 k� t?")]
        public string Chuc_Vu { get; set; }

        [StringLength(maximumLength: 12, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 10 k� t?")]
        public string So_Dien_Thoai { get; set; }

        public int ID_BENH_VIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOP_DONG> HOP_DONG { get; set; }
        public virtual BENH_VIEN BENH_VIEN { get; set; }

    }
}
