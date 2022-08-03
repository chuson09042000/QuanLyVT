using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyVT.Models
{
    public class modelThongKe 
    {
        public string Ten_BV { get; set; }
        public string Ten_Nguoi_Phu_Trach { get; set; }
        public string Ten_NV_KT { get; set; }
        public string Ten_Goi_Thau { get; set; }
        public string TEN_HD { get; set; }
        
        public int ID_THIET_BI { get; set; }

       
        public string Ma_TB { get; set; }

        
        public string Ten_TB { get; set; }

      
        public string XX_TC { get; set; }

        public string Nam_SX { get; set; }

        public int ID_BENH_VIEN { get; set; }

        public int ID_GOI_THAU { get; set; }

        public int ID_LINH_KIEN { get; set; }
        public int So_Luong { get; set; }

        public string Ma_HD { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngay_Hoan_Thanh { get; set; }


        public string Han_BH { get; set; }


        public string Ghi_Chu { get; set; }


        public string FileName { get; set; }

       

        public int ID_NGUOI_PHU_TRACH { get; set; }

        public int ID_NHAN_VIEN_KY_THUAT { get; set; }
       
        public string Ten_LK { get; set; }
        public string Ten_TT_LK { get; set; }
    }
}