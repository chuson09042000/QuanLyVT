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
    public class NGUOI_DUNGController : Controller
    {
        private Model1 db = new Model1();

        // GET: NGUOI_DUNG
        public ActionResult Index()
        {
            var nGUOI_DUNG = db.NGUOI_DUNG.Include(n => n.PHAN_QUYEN);
            return View(nGUOI_DUNG.ToList());
        }

        // GET: NGUOI_DUNG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_DUNG);
        }

        // GET: NGUOI_DUNG/Create
        public ActionResult Create()
        {
            ViewBag.ID_PHAN_QUYEN = new SelectList(db.PHAN_QUYEN, "ID_PHAN_QUYEN", "Ten_Quyen");
            return View();
        }

        // POST: NGUOI_DUNG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NGUOI_DUNG,Ma_Nguoi_Dung,Ten_Nguoi_Dung,Mat_Khau,ID_PHAN_QUYEN")] NGUOI_DUNG nGUOI_DUNG)
        {
            if (ModelState.IsValid)
            {
                db.NGUOI_DUNG.Add(nGUOI_DUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PHAN_QUYEN = new SelectList(db.PHAN_QUYEN, "ID_PHAN_QUYEN", "Ten_Quyen", nGUOI_DUNG.ID_PHAN_QUYEN);
            return View(nGUOI_DUNG);
        }

        // GET: NGUOI_DUNG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PHAN_QUYEN = new SelectList(db.PHAN_QUYEN, "ID_PHAN_QUYEN", "Ten_Quyen", nGUOI_DUNG.ID_PHAN_QUYEN);
            return View(nGUOI_DUNG);
        }

        // POST: NGUOI_DUNG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NGUOI_DUNG,Ma_Nguoi_Dung,Ten_Nguoi_Dung,Mat_Khau,ID_PHAN_QUYEN")] NGUOI_DUNG nGUOI_DUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOI_DUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PHAN_QUYEN = new SelectList(db.PHAN_QUYEN, "ID_PHAN_QUYEN", "Ten_Quyen", nGUOI_DUNG.ID_PHAN_QUYEN);
            return View(nGUOI_DUNG);
        }

        // GET: NGUOI_DUNG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_DUNG);
        }

        // POST: NGUOI_DUNG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            db.NGUOI_DUNG.Remove(nGUOI_DUNG);
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
