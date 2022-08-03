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
            if(ID_THIET_BI != null || ID_HOP_DONG != null)
            {
                if(ID_THIET_BI != null && ID_HOP_DONG == null)
                {
                    if (ID_THIET_BI != null)
                    {
                        ViewBag.checkTBorHD = "ThietBi";
                        var list = db.Database.SqlQuery<modelThongKe>("ThongKeTheoThietBi @idThietBi", new SqlParameter("@idThietBi", (int?)ID_THIET_BI)).ToList();
                        return View(list);
                    }
                }    
                else if(ID_HOP_DONG != null && ID_THIET_BI == null)
                {
                    if (ID_HOP_DONG != null)
                    {
                        ViewBag.checkTBorHD = "HopDong";
                        var listhd = db.Database.SqlQuery<modelThongKe>("ThongKeTheoHopDong @idHopDong", new SqlParameter("@idHopDong", (int?)ID_HOP_DONG)).ToList();
                        return View(listhd);
                    }
                }
                else if (ID_THIET_BI != null && ID_HOP_DONG != null)
                {
                    TempData["ResultMessage"] = "Vui lòng chọn thống kê theo thiết bị hoặc thống kê theo hợp đồng!";
                    return RedirectToAction("ThongKeTB");
                }
                else
                {
                    TempData["ResultMessage"] = "Có lỗi trong quá trình thống kê. Vui lòng thử lại sau!";
                    return RedirectToAction("ThongKeTB");
                }
            } 
            else
            {
                TempData["ResultMessage"] = "Vui lòng chọn kiểu thống kê!";
                return RedirectToAction("ThongKeTB");
            }
            return View();
        }
    }
}