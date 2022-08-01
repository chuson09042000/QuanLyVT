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


        public ActionResult ThongKeTB(int? ID_THIET_BI)
        {
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ten_TB");

            if (ID_THIET_BI != null)
            {
                var list = db.Database.SqlQuery<THIET_BI>("ThongKeTheoThietBi @idThietBi", new SqlParameter("@idThietBi", (int?)ID_THIET_BI)).ToList();
                return View(list);
            }
            return View();
        }
    }
}