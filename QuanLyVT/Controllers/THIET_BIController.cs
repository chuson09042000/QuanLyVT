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
    public class THIET_BIController : Controller
    {
        private Model1 db = new Model1();

        // GET: THIET_BI
        public ActionResult Index()
        {
            var tHIET_BI = db.THIET_BI.Include(t => t.BENH_VIEN).Include(t => t.GOI_THAU).Include(t => t.LINH_KIEN);
            return View(tHIET_BI.ToList());
        }

        // GET: THIET_BI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIET_BI tHIET_BI = db.THIET_BI.Find(id);
            if (tHIET_BI == null)
            {
                return HttpNotFound();
            }
            return View(tHIET_BI);
        }

        // GET: THIET_BI/Create
        public ActionResult Create()
        {
            ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV");
            ViewBag.ID_GOI_THAU = new SelectList(db.GOI_THAU, "ID_GOI_THAU", "Ten_Goi_Thau");
            ViewBag.ID_LINH_KIEN = new SelectList(db.LINH_KIEN, "ID_LINH_KIEN", "Ten_LK");
            return View();
        }

        // POST: THIET_BI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_THIET_BI,Ma_TB,Ten_TB,XX_TC,Nam_SX,ID_BENH_VIEN,ID_GOI_THAU,ID_LINH_KIEN")] THIET_BI tHIET_BI)
        {
            if (ModelState.IsValid)
            {
                db.THIET_BI.Add(tHIET_BI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", tHIET_BI.ID_BENH_VIEN);
            ViewBag.ID_GOI_THAU = new SelectList(db.GOI_THAU, "ID_GOI_THAU", "Ten_Goi_Thau", tHIET_BI.ID_GOI_THAU);
            ViewBag.ID_LINH_KIEN = new SelectList(db.LINH_KIEN, "ID_LINH_KIEN", "Ten_LK", tHIET_BI.ID_LINH_KIEN);
            return View(tHIET_BI);
        }

        // GET: THIET_BI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIET_BI tHIET_BI = db.THIET_BI.Find(id);
            if (tHIET_BI == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", tHIET_BI.ID_BENH_VIEN);
            ViewBag.ID_GOI_THAU = new SelectList(db.GOI_THAU, "ID_GOI_THAU", "Ten_Goi_Thau", tHIET_BI.ID_GOI_THAU);
            ViewBag.ID_LINH_KIEN = new SelectList(db.LINH_KIEN, "ID_LINH_KIEN", "Ten_LK", tHIET_BI.ID_LINH_KIEN);
            return View(tHIET_BI);
        }

        // POST: THIET_BI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_THIET_BI,Ma_TB,Ten_TB,XX_TC,Nam_SX,ID_BENH_VIEN,ID_GOI_THAU,ID_LINH_KIEN")] THIET_BI tHIET_BI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHIET_BI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_BENH_VIEN = new SelectList(db.BENH_VIEN, "ID_BENH_VIEN", "Ten_BV", tHIET_BI.ID_BENH_VIEN);
            ViewBag.ID_GOI_THAU = new SelectList(db.GOI_THAU, "ID_GOI_THAU", "Ten_Goi_Thau", tHIET_BI.ID_GOI_THAU);
            ViewBag.ID_LINH_KIEN = new SelectList(db.LINH_KIEN, "ID_LINH_KIEN", "Ten_LK", tHIET_BI.ID_LINH_KIEN);
            return View(tHIET_BI);
        }

        // GET: THIET_BI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIET_BI tHIET_BI = db.THIET_BI.Find(id);
            if (tHIET_BI == null)
            {
                return HttpNotFound();
            }
            return View(tHIET_BI);
        }

        // POST: THIET_BI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THIET_BI tHIET_BI = db.THIET_BI.Find(id);
            db.THIET_BI.Remove(tHIET_BI);
            db.SaveChanges();
            return RedirectToAction("Index");
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
