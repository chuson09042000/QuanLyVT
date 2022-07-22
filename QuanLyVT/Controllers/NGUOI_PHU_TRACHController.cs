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
            return View(db.NGUOI_PHU_TRACH.ToList());
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
            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "TEN_HD");
            return View();
        }

        // POST: NGUOI_PHU_TRACH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NGUOI_PHU_TRACH,Ma_Nguoi_Phu_Trach,Ten_Nguoi_Phu_Trach,Ma_BV,Chuc_Vu,So_Dien_Thoai,Ten_BV")] NGUOI_PHU_TRACH nGUOI_PHU_TRACH)
        {
            if (ModelState.IsValid)
            {
                db.NGUOI_PHU_TRACH.Add(nGUOI_PHU_TRACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ID_THIET_BI = new SelectList(db.HOP_DONG, "ID_THIET_BI", "Ten_TB", nGUOI_PHU_TRACH.ID_HOP_DONG);
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
            return View(nGUOI_PHU_TRACH);
        }

        // POST: NGUOI_PHU_TRACH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NGUOI_PHU_TRACH,Ma_Nguoi_Phu_Trach,Ten_Nguoi_Phu_Trach,Ma_BV,Chuc_Vu,So_Dien_Thoai,Ten_BV")] NGUOI_PHU_TRACH nGUOI_PHU_TRACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOI_PHU_TRACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
            NGUOI_PHU_TRACH nGUOI_PHU_TRACH = db.NGUOI_PHU_TRACH.Find(id);
            db.NGUOI_PHU_TRACH.Remove(nGUOI_PHU_TRACH);
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
