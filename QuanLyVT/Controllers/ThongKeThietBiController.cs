using QuanLyVT.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVT.Controllers
{
    public class ThongKeThietBiController : Controller
    {
        private Model1 db = new Model1();
        //GET: ThongKeThietBi
        public ActionResult Index()
        {
            return View();
        }
        // à tao biêết rồi tháấy koo cái đó 


        public ActionResult ThongKeTB()
        {
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ten_TB");
            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ten_HD");
            return View();
        }
        public ActionResult ViewThongKe(int? ID_THIET_BI, int? ID_HOP_DONG)
        {
            try
            {
                if(ID_THIET_BI != null && ID_HOP_DONG == null)
                {
                    if (ID_THIET_BI != null)
                    {
                        var list = db.Database.SqlQuery<modelThongKe>("ThongKeTheoThietBi @idThietBi", new SqlParameter("@idThietBi", (int?)ID_THIET_BI)).ToList();
                        return View(list);
                    }
                }    
                else if(ID_HOP_DONG != null && ID_THIET_BI == null)
                {
                    if (ID_HOP_DONG != null)
                    {
                        var listhd = db.Database.SqlQuery<modelThongKe>("ThongKeTheoThietBi @idHopDong", new SqlParameter("@idHopDong", (int?)ID_HOP_DONG)).ToList();
                        return View(listhd);
                    }
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "Vui lòng chọn kiểu thống kê!";
                return ThongKeTB();
            }
            return View();
        }
    }
}