namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAO_TRI
    {
        [Key]
        public int ID_BAO_TRI { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength(maximumLength: 10, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 10 k� t?")]
        public string Ma_Bao_Tri { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngay_Bao_Tri { get; set; }

        [Required(ErrorMessage = "Th�ng tin n�y l� b?t bu?c.")]
        [StringLength(maximumLength: 500, ErrorMessage = "?? d�i kh�ng ???c v??t qu� 500 k� t?")]
        public string LK_ThayThe { get; set; }

        public int ID_THIET_BI { get; set; }

        public int ID_HOP_DONG { get; set; }

        public virtual HOP_DONG HOP_DONG { get; set; }

        public virtual THIET_BI THIET_BI { get; set; }
    }
}
