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
    public class LINH_KIENController : Controller
    {
        private Model1 db = new Model1();

        // GET: LINH_KIEN
        public ActionResult Index()
        {
            var lINH_KIEN = db.LINH_KIEN.Include(l => l.DVT).Include(l => l.TINH_TRANG);
            return View(lINH_KIEN.ToList());
        }

        // GET: LINH_KIEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINH_KIEN lINH_KIEN = db.LINH_KIEN.Find(id);
            if (lINH_KIEN == null)
            {
                return HttpNotFound();
            }
            return View(lINH_KIEN);
        }

        // GET: LINH_KIEN/Create
        public ActionResult Create()
        {
            ViewBag.ID_DVT = new SelectList(db.DVTs, "ID_DVT", "Ten_DVT");
            ViewBag.ID_TINH_TRANG = new SelectList(db.TINH_TRANG, "ID_TINHTRANG", "Ten_TT_LK");
            return View();
        }

        // POST: LINH_KIEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LINH_KIEN,Ma_So_LK,Ten_LK,XX_TC,Nam_SX,ID_DVT,ID_TINH_TRANG")] LINH_KIEN lINH_KIEN)
        {

            var dvt = from bv in db.LINH_KIEN
                      select bv;

            dvt = dvt.Where(x => x.Ma_So_LK == lINH_KIEN.Ma_So_LK);
            if (dvt.Count() > 0)
            {
                ViewBag.ErrorMessage = "Mã linh kiện không được trùng!";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.LINH_KIEN.Add(lINH_KIEN);
                    db.SaveChanges();
                    TempData["success"] = "Thêm mới thành công!";
                    return RedirectToAction("Index");
                }
            }
            //ViewBag.ID_DVT = new SelectList(db.DVTs, "ID_DVT", "Ma_DVT", lINH_KIEN.ID_DVT);
            //ViewBag.ID_TINH_TRANG = new SelectList(db.TINH_TRANG, "ID_TINHTRANG", "Ten_TT_LK", lINH_KIEN.ID_TINH_TRANG);
            return View(lINH_KIEN);
        }

        // GET: LINH_KIEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINH_KIEN lINH_KIEN = db.LINH_KIEN.Find(id);
            if (lINH_KIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DVT = new SelectList(db.DVTs, "ID_DVT", "Ten_DVT", lINH_KIEN.ID_DVT);
            ViewBag.ID_TINH_TRANG = new SelectList(db.TINH_TRANG, "ID_TINHTRANG", "Ten_TT_LK", lINH_KIEN.ID_TINH_TRANG);
            return View(lINH_KIEN);
        }

        // POST: LINH_KIEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LINH_KIEN,Ma_So_LK,Ten_LK,XX_TC,Nam_SX,ID_DVT,ID_TINH_TRANG")] LINH_KIEN lINH_KIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lINH_KIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DVT = new SelectList(db.DVTs, "ID_DVT", "Ten_DVT", lINH_KIEN.ID_DVT);
            ViewBag.ID_TINH_TRANG = new SelectList(db.TINH_TRANG, "ID_TINHTRANG", "Ten_TT_LK", lINH_KIEN.ID_TINH_TRANG);
            return View(lINH_KIEN);
        }

        // GET: LINH_KIEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINH_KIEN lINH_KIEN = db.LINH_KIEN.Find(id);
            if (lINH_KIEN == null)
            {
                return HttpNotFound();
            }
            return View(lINH_KIEN);
        }

        // POST: LINH_KIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {

            
            LINH_KIEN lINH_KIEN = db.LINH_KIEN.Find(id);
            db.LINH_KIEN.Remove(lINH_KIEN);
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
