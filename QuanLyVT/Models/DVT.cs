namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DVT")]
    public partial class DVT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DVT()
        {
            LINH_KIEN = new HashSet<LINH_KIEN>();
        }

        [Key]
        public int ID_DVT { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength( maximumLength:10, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 10 k� t?")]
        public string Ma_DVT { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength( maximumLength:20, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 20 k� t?")]
        public string Ten_DVT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LINH_KIEN> LINH_KIEN { get; set; }
    }
}
