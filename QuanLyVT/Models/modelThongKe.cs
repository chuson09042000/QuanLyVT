using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyVT.Models
{
    public class modelThongKe 
    {
        //thêm trươờng nào mày cânf vào
        // có cần kiểu dữ liệu ko
        //có chưứ ý nvarrcha
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
    }
}