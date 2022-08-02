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
    public class BENH_VIENController : Controller
    {
        private Model1 db = new Model1();

        // GET: BENH_VIEN
        public ActionResult Index()
        {
            return View(db.BENH_VIEN.ToList());
        }

        // GET: BENH_VIEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENH_VIEN bENH_VIEN = db.BENH_VIEN.Find(id);
            if (bENH_VIEN == null)
            {
                return HttpNotFound();
            }
            return View(bENH_VIEN);
        }

        // GET: BENH_VIEN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BENH_VIEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BENH_VIEN,Ma_BV,Ten_BV,Dia_Chi,SDT,Fax")] BENH_VIEN bENH_VIEN)
        {
            var benhVien = from bv in db.BENH_VIEN
                                 select bv;

            benhVien = benhVien.Where(x => x.Ma_BV == bENH_VIEN.Ma_BV);
            if (benhVien.Count() > 0)
            {
                ViewBag.ErrorMessage = "Mã bệnh viện không được trùng!";
                return View();
                //RedirectToAction("Index");
                //base.ViewBag.ErrorMessage = benhVien.Count().ToString();
                ///lỗi
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.BENH_VIEN.Add(bENH_VIEN);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(bENH_VIEN);
        }

        // GET: BENH_VIEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENH_VIEN bENH_VIEN = db.BENH_VIEN.Find(id);
            if (bENH_VIEN == null)
            {
                return HttpNotFound();
            }
            return View(bENH_VIEN);
        }

        // POST: BENH_VIEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BENH_VIEN,Ma_BV,Ten_BV,Dia_Chi,SDT,Fax")] BENH_VIEN bENH_VIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bENH_VIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bENH_VIEN);
        }

        // GET: BENH_VIEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENH_VIEN bENH_VIEN = db.BENH_VIEN.Find(id);
            if (bENH_VIEN == null)
            {
                return HttpNotFound();
            }
            return View(bENH_VIEN);
        }

        // POST: BENH_VIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                BENH_VIEN bENH_VIEN = db.BENH_VIEN.Find(id);
                db.BENH_VIEN.Remove(bENH_VIEN);
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
