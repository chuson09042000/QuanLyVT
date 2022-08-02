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
    public class TINH_TRANGController : Controller
    {
        private Model1 db = new Model1();

        // GET: TINH_TRANG
        public ActionResult Index()
        {
            return View(db.TINH_TRANG.ToList());
        }

        // GET: TINH_TRANG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH_TRANG tINH_TRANG = db.TINH_TRANG.Find(id);
            if (tINH_TRANG == null)
            {
                return HttpNotFound();
            }
            return View(tINH_TRANG);
        }

        // GET: TINH_TRANG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TINH_TRANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TINHTRANG,Ma_TT_LK,Ten_TT_LK")] TINH_TRANG tINH_TRANG)
        {
            var dvt = from bv in db.TINH_TRANG
                      select bv;

            dvt = dvt.Where(x => x.Ma_TT_LK == tINH_TRANG.Ma_TT_LK);
            if (dvt.Count() > 0)
            {
                ViewBag.ErrorMessage = "Mã nhân viên không được trùng!";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.TINH_TRANG.Add(tINH_TRANG);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(tINH_TRANG);
        }

        // GET: TINH_TRANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH_TRANG tINH_TRANG = db.TINH_TRANG.Find(id);
            if (tINH_TRANG == null)
            {
                return HttpNotFound();
            }
            return View(tINH_TRANG);
        }

        // POST: TINH_TRANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TINHTRANG,Ma_TT_LK,Ten_TT_LK")] TINH_TRANG tINH_TRANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tINH_TRANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tINH_TRANG);
        }

        // GET: TINH_TRANG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH_TRANG tINH_TRANG = db.TINH_TRANG.Find(id);
            if (tINH_TRANG == null)
            {
                return HttpNotFound();
            }
            return View(tINH_TRANG);
        }

        // POST: TINH_TRANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try { 
            TINH_TRANG tINH_TRANG = db.TINH_TRANG.Find(id);
            db.TINH_TRANG.Remove(tINH_TRANG);
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
