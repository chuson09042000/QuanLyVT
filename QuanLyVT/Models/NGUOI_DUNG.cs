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

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 10, ErrorMessage = "?? dài không ???c v??t quá 10 ký t?")]
        public string Ma_Nguoi_Dung { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 50, ErrorMessage = "?? dài không ???c v??t quá 50 ký t?")]
        public string Ten_Nguoi_Dung { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 50, ErrorMessage = "?? dài không ???c v??t quá 50 ký t?")]
        public string Mat_Khau { get; set; }

        public int ID_PHAN_QUYEN { get; set; }

        public virtual PHAN_QUYEN PHAN_QUYEN { get; set; }
    }
}
