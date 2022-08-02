namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NGUOI_DUNG
    {
        [Key]
        public int ID_NGUOI_DUNG { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength(maximumLength: 10, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 10 k� t?")]
        public string Ma_Nguoi_Dung { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength(maximumLength: 50, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 50 k� t?")]
        public string Ten_Nguoi_Dung { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength(maximumLength: 50, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 50 k� t?")]
        public string Mat_Khau { get; set; }

        public int ID_PHAN_QUYEN { get; set; }

        public virtual PHAN_QUYEN PHAN_QUYEN { get; set; }
    }
}
