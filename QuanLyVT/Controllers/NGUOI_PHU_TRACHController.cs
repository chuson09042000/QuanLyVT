using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyVT.Models;

namespace QuanLyVT.Controllers
{
    public class NGUOI_PHU_TRACHController : Controller
    {
        private Model1 db = new Model1();

        // GET: NGUOI_PHU_TRACH
        public ActionResult Index()
        {
            var nGUOI_PHU_TRACH = db.NGUOI_PHU_TRACH.Include(h => h.BENH_VIEN);
            return View(nGUOI_PHU_TRACH.ToList());
        }

        // GET: NGUOI_PHU_TRACH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_PHU_TRACH nGUOI_PHU_TRACH = db.NGUOI_PHU_TRACH.Find(id);
            if (nGUOI_PHU_TRACH == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_PHU_TRACH);
        }

        // GET: NGUOI_PHU_TRACH/Create
        public ActionResult Create()
        {
            List<BENH_VIEN> bvs = db.BENH_VIEN.ToList();

            // Tạo SelectList
            SelectList listBv = new SelectList(bvs, "ID_BENH_VIEN", "Ten_BV");


            // Set vào ViewBag
            ViewBag.BvList = listBv;
            ViewBag.Ma_BV = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ma_BV");
            //ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV");
            return View();
        }

        // POST: NGUOI_PHU_TRACH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NGUOI_PHU_TRACH,Ma_Nguoi_Phu_Trach,Ten_Nguoi_Phu_Trach,Ma_BV,Chuc_Vu,So_Dien_Thoai,ID_BENH_VIEN")] NGUOI_PHU_TRACH nGUOI_PHU_TRACH)
        {
            List<BENH_VIEN> bvs = db.BENH_VIEN.ToList();

            // Tạo SelectList
            SelectList listBv = new SelectList(bvs, "ID_BENH_VIEN", "Ten_BV");

            // Set vào ViewBag
            ViewBag.BvList = listBv;

            var dvt = from bv in db.NGUOI_PHU_TRACH
                      select bv;

            dvt = dvt.Where(x => x.Ma_Nguoi_Phu_Trach == nGUOI_PHU_TRACH.Ma_Nguoi_Phu_Trach);
            if (dvt.Count() > 0)
            {
                ViewBag.ErrorMessage = "Mã người phụ trách không được trùng!";
                return View();
            }
            else
            {
                nGUOI_PHU_TRACH.Ma_BV = "a";
                if (ModelState.IsValid)
                {
                    db.NGUOI_PHU_TRACH.Add(nGUOI_PHU_TRACH);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //ViewBag.ID_THIET_BI = new SelectList(db.HOP_DONG, "ID_THIET_BI", "Ten_TB", nGUOI_PHU_TRACH.ID_HOP_DONG);
            //ViewBag.Ma_BV = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ma_BV", nGUOI_PHU_TRACH.ID_BENH_VIEN);
            //ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", nGUOI_PHU_TRACH.ID_BENH_VIEN);
            return View(nGUOI_PHU_TRACH);
        }

        // GET: NGUOI_PHU_TRACH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_PHU_TRACH nGUOI_PHU_TRACH = db.NGUOI_PHU_TRACH.Find(id);
            if (nGUOI_PHU_TRACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", nGUOI_PHU_TRACH.ID_BENH_VIEN);
            return View(nGUOI_PHU_TRACH);
        }

        // POST: NGUOI_PHU_TRACH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NGUOI_PHU_TRACH,Ma_Nguoi_Phu_Trach,Ten_Nguoi_Phu_Trach,Ma_BV,Chuc_Vu,So_Dien_Thoai,ID_BENH_VIEN")] NGUOI_PHU_TRACH nGUOI_PHU_TRACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOI_PHU_TRACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", nGUOI_PHU_TRACH.ID_BENH_VIEN);
            return View(nGUOI_PHU_TRACH);
        }

        // GET: NGUOI_PHU_TRACH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_PHU_TRACH nGUOI_PHU_TRACH = db.NGUOI_PHU_TRACH.Find(id);
            if (nGUOI_PHU_TRACH == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_PHU_TRACH);
        }

        // POST: NGUOI_PHU_TRACH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try { 
            NGUOI_PHU_TRACH nGUOI_PHU_TRACH = db.NGUOI_PHU_TRACH.Find(id);
            db.NGUOI_PHU_TRACH.Remove(nGUOI_PHU_TRACH);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch
            {
                TempData["ResultMessage"] = "Dữ liệu đang được sử dụng trong hệ thống không thể xóa!!";
                return RedirectToAction("Delete");
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
