﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyVT.Models
{
    public class modelHopDong
    {
        
        public string Ma_HD { get; set; }

       
        public string TEN_HD { get; set; }

        
        public DateTime Ngay_Hoan_Thanh { get; set; }

       
        public string Han_BH { get; set; }

        
        public string Ghi_Chu { get; set; }

        
        public string FileName { get; set; }

        public int ID_THIET_BI { get; set; }

        public int ID_BENH_VIEN { get; set; }

        public int ID_NGUOI_PHU_TRACH { get; set; }

        public int ID_NHAN_VIEN_KY_THUAT { get; set; }
        public string Ten_BV { get; set; }
        public string Ten_Nguoi_Phu_Trach { get; set; }
        public string Ten_NV_KT { get; set; }
        public string Ten_Goi_Thau { get; set; }
        public string Ten_TB { get; set; }
        public string Ten_LK { get; set; }
        public string Ten_TT_LK { get; set; }
    }
}