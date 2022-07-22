namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUA_CHUA
    {
        [Key]
        public int ID_SUA_CHUA { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Sua_Chua { get; set; }

        public DateTime Ngay_Sua_Chua { get; set; }

        [Required]
        [StringLength(500)]
        public string LK_ThayThe { get; set; }

        public int ID_HOP_DONG { get; set; }

        public int ID_THIET_BI { get; set; }

        public virtual HOP_DONG HOP_DONG { get; set; }

        public virtual THIET_BI THIET_BI { get; set; }
    }
}
