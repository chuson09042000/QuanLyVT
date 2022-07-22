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

        [Required]
        [StringLength(10)]
        public string Ma_Nguoi_Dung { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten_Nguoi_Dung { get; set; }

        [Required]
        [StringLength(50)]
        public string Mat_Khau { get; set; }

        public int ID_PHAN_QUYEN { get; set; }

        public virtual PHAN_QUYEN PHAN_QUYEN { get; set; }
    }
}
