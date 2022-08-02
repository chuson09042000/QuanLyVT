using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyVT.Models;

namespace QuanLyVT.Controllers
{
    public class HOP_DONGController : Controller
    {
        private Model1 db = new Model1();

        // GET: HOP_DONG
        public ActionResult Index()
        {
            var hOP_DONG = db.HOP_DONG.Include(h => h.BENH_VIEN).Include(h => h.NGUOI_PHU_TRACH).Include(h => h.NHAN_VIEN_KY_THUAT).Include(h => h.THIET_BI);
            return View(hOP_DONG.ToList());
        }

        // GET: HOP_DONG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOP_DONG hOP_DONG = db.HOP_DONG.Find(id);
            if (hOP_DONG == null)
            {
                return HttpNotFound();
            }
            return View(hOP_DONG);
        }

        // GET: HOP_DONG/Create
        public ActionResult Create()
        {
            List<BENH_VIEN> bvs = db.BENH_VIEN.ToList();
            List<THIET_BI> tbs = db.THIET_BI.ToList();
            List<NGUOI_PHU_TRACH> npts = db.NGUOI_PHU_TRACH.ToList();
            List<NHAN_VIEN_KY_THUAT> nvs = db.NHAN_VIEN_KY_THUAT.ToList();

            // Tạo SelectList
            SelectList listBv = new SelectList(bvs, "ID_BENH_VIEN", "Ten_BV");
            SelectList listTb = new SelectList(tbs, "ID_THIET_BI", "Ten_TB");
            SelectList listNpt = new SelectList(npts, "ID_NGUOI_PHU_TRACH", "Ten_Nguoi_Phu_Trach");
            SelectList listNv = new SelectList(nvs, "ID_NHAN_VIEN_KY_THUAT", "Ten_NV_KT");

            // Set vào ViewBag
            ViewBag.BvList = listBv;
            ViewBag.TbList = listTb;
            ViewBag.NptList = listNpt;
            ViewBag.NvList = listNv;
            //ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV");
            //ViewBag.ID_NGUOI_PHU_TRACH = new SelectList(db.NGUOI_PHU_TRACH, "ID_NGUOI_PHU_TRACH", "Ten_Nguoi_Phu_Trach");
            //ViewBag.ID_NHAN_VIEN_KY_THUAT = new SelectList(db.NHAN_VIEN_KY_THUAT, "ID_NHAN_VIEN_KY_THUAT", "Ten_NV_KT");
            //ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ten_TB");
            return View();
        }

        // POST: HOP_DONG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HOP_DONG,Ma_HD,TEN_HD,Ngay_Hoan_Thanh,Han_BH,Ghi_Chu,FileName,ID_THIET_BI,ID_BENH_VIEN,ID_NGUOI_PHU_TRACH,ID_NHAN_VIEN_KY_THUAT")] HOP_DONG hOP_DONG)
        {

            List<BENH_VIEN> bvs = db.BENH_VIEN.ToList();
            List<THIET_BI> tbs = db.THIET_BI.ToList();
            List<NGUOI_PHU_TRACH> npts = db.NGUOI_PHU_TRACH.ToList();
            List<NHAN_VIEN_KY_THUAT> nvs = db.NHAN_VIEN_KY_THUAT.ToList();

            // Tạo SelectList
            SelectList listBv = new SelectList(bvs, "ID_BENH_VIEN", "Ten_BV");
            SelectList listTb = new SelectList(tbs, "ID_THIET_BI", "Ten_TB");
            SelectList listNpt = new SelectList(npts, "ID_NGUOI_PHU_TRACH", "Ten_Nguoi_Phu_Trach");
            SelectList listNv = new SelectList(nvs, "ID_NHAN_VIEN_KY_THUAT", "Ten_NV_KT");

            // Set vào ViewBag
            ViewBag.BvList = listBv;
            ViewBag.GtList = listTb;
            ViewBag.LkList = listNpt;
            ViewBag.LkList = listNv;

            var dvt = from bv in db.HOP_DONG
                      select bv;

            dvt = dvt.Where(x => x.Ma_HD == hOP_DONG.Ma_HD);
            if (dvt.Count() > 0)
            {
                ViewBag.ErrorMessage = "Mã hợp đồng không được trùng!";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.HOP_DONG.Add(hOP_DONG);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", hOP_DONG.ID_BENH_VIEN);
            //ViewBag.ID_NGUOI_PHU_TRACH = new SelectList(db.NGUOI_PHU_TRACH, "ID_NGUOI_PHU_TRACH", "Ten_Nguoi_Phu_Trach", hOP_DONG.ID_NGUOI_PHU_TRACH);
            //ViewBag.ID_NHAN_VIEN_KY_THUAT = new SelectList(db.NHAN_VIEN_KY_THUAT, "ID_NHAN_VIEN_KY_THUAT", "Ten_NV_KT", hOP_DONG.ID_NHAN_VIEN_KY_THUAT);
            //ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ten_TB", hOP_DONG.ID_THIET_BI);
            return View(hOP_DONG);
        }

        // GET: HOP_DONG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOP_DONG hOP_DONG = db.HOP_DONG.Find(id);
            if (hOP_DONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", hOP_DONG.ID_BENH_VIEN);
            ViewBag.ID_NGUOI_PHU_TRACH = new SelectList(db.NGUOI_PHU_TRACH, "ID_NGUOI_PHU_TRACH", "Ten_Nguoi_Phu_Trach", hOP_DONG.ID_NGUOI_PHU_TRACH);
            ViewBag.ID_NHAN_VIEN_KY_THUAT = new SelectList(db.NHAN_VIEN_KY_THUAT, "ID_NHAN_VIEN_KY_THUAT", "Ten_NV_KT", hOP_DONG.ID_NHAN_VIEN_KY_THUAT);
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ten_TB", hOP_DONG.ID_THIET_BI);
            return View(hOP_DONG);
        }

        // POST: HOP_DONG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HOP_DONG,Ma_HD,TEN_HD,Ngay_Hoan_Thanh,Han_BH,Ghi_Chu,FileName,ID_THIET_BI,ID_BENH_VIEN,ID_NGUOI_PHU_TRACH,ID_NHAN_VIEN_KY_THUAT")] HOP_DONG hOP_DONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOP_DONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", hOP_DONG.ID_BENH_VIEN);
            ViewBag.ID_NGUOI_PHU_TRACH = new SelectList(db.NGUOI_PHU_TRACH, "ID_NGUOI_PHU_TRACH", "Ten_Nguoi_Phu_Trach", hOP_DONG.ID_NGUOI_PHU_TRACH);
            ViewBag.ID_NHAN_VIEN_KY_THUAT = new SelectList(db.NHAN_VIEN_KY_THUAT, "ID_NHAN_VIEN_KY_THUAT", "Ten_NV_KT", hOP_DONG.ID_NHAN_VIEN_KY_THUAT);
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ten_TB", hOP_DONG.ID_THIET_BI);
            return View(hOP_DONG);
        }

        // GET: HOP_DONG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOP_DONG hOP_DONG = db.HOP_DONG.Find(id);
            if (hOP_DONG == null)
            {
                return HttpNotFound();
            }
            return View(hOP_DONG);
        }

        // POST: HOP_DONG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HOP_DONG hOP_DONG = db.HOP_DONG.Find(id);
                db.HOP_DONG.Remove(hOP_DONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ResultMessage"] = "Dữ liệu đang được sử dụng trong hệ thống không thể xóa!!";
                return RedirectToAction("Delete");
            }
}

        [HttpGet]
        public ActionResult UploadFile(int id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOP_DONG hop_Dong = db.HOP_DONG.Find(id);
            if (hop_Dong == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa", hop_Dong.ID_Hang_Hoa);
            //ViewBag.ID_Loai_Hop_Dong = new SelectList(db.Loai_Hop_Dong, "ID_Loai_Hop_Dong", "Ten_Loai_Hop_Dong", hop_Dong.ID_Loai_Hop_Dong);
            return View(hop_Dong);
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, HOP_DONG hop_Dong)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = System.IO.Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    HOP_DONG hop_Dong2 = db.HOP_DONG.Find(hop_Dong.ID_HOP_DONG);
                    hop_Dong2.FileName = _FileName;

                    db.SaveChanges();
                }
                ViewBag.Message = "Tải tệp tin thành công!!";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Có lỗi trong quá trình tải t!!";
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
