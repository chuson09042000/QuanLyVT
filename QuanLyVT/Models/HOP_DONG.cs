namespace QuanLyVT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HOP_DONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOP_DONG()
        {
            BAO_TRI = new HashSet<BAO_TRI>();
            SUA_CHUA = new HashSet<SUA_CHUA>();
        }

        [Key]
        public int ID_HOP_DONG { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 50, ErrorMessage = "?? dài không ???c v??t quá 50 ký t?")]
        public string Ma_HD { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 200, ErrorMessage = "?? dài không ???c v??t quá 200 ký t?")]
        public string TEN_HD { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Ngay_Hoan_Thanh { get; set; }

        [Required(ErrorMessage = "Thông tin này là b?t bu?c.")]
        [StringLength(maximumLength: 20, ErrorMessage = "?? dài không ???c v??t quá 20 ký t?")]
        public string Han_BH { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "?? dài không ???c v??t quá 100 ký t?")]
        public string Ghi_Chu { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "?? dài không ???c v??t quá 500 ký t?")]
        public string FileName { get; set; }

        public int ID_THIET_BI { get; set; }

        public int ID_BENH_VIEN { get; set; }

        public int ID_NGUOI_PHU_TRACH { get; set; }

        public int ID_NHAN_VIEN_KY_THUAT { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAO_TRI> BAO_TRI { get; set; }

        public virtual BENH_VIEN BENH_VIEN { get; set; }

        public virtual NGUOI_PHU_TRACH NGUOI_PHU_TRACH { get; set; }

        public virtual NHAN_VIEN_KY_THUAT NHAN_VIEN_KY_THUAT { get; set; }

        public virtual THIET_BI THIET_BI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUA_CHUA> SUA_CHUA { get; set; }
    }
}
