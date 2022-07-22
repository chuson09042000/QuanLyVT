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
    public class NHAN_VIEN_KY_THUATController : Controller
    {
        private Model1 db = new Model1();

        // GET: NHAN_VIEN_KY_THUAT
        public ActionResult Index()
        {
            return View(db.NHAN_VIEN_KY_THUAT.ToList());
        }

        // GET: NHAN_VIEN_KY_THUAT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAN_VIEN_KY_THUAT nHAN_VIEN_KY_THUAT = db.NHAN_VIEN_KY_THUAT.Find(id);
            if (nHAN_VIEN_KY_THUAT == null)
            {
                return HttpNotFound();
            }
            return View(nHAN_VIEN_KY_THUAT);
        }

        // GET: NHAN_VIEN_KY_THUAT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHAN_VIEN_KY_THUAT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NHAN_VIEN_KY_THUAT,Ma_NV_KT,Ten_NV_KT,Chuc_Vu,So_Dien_Thoai")] NHAN_VIEN_KY_THUAT nHAN_VIEN_KY_THUAT)
        {
            if (ModelState.IsValid)
            {
                db.NHAN_VIEN_KY_THUAT.Add(nHAN_VIEN_KY_THUAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHAN_VIEN_KY_THUAT);
        }

        // GET: NHAN_VIEN_KY_THUAT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAN_VIEN_KY_THUAT nHAN_VIEN_KY_THUAT = db.NHAN_VIEN_KY_THUAT.Find(id);
            if (nHAN_VIEN_KY_THUAT == null)
            {
                return HttpNotFound();
            }
            return View(nHAN_VIEN_KY_THUAT);
        }

        // POST: NHAN_VIEN_KY_THUAT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NHAN_VIEN_KY_THUAT,Ma_NV_KT,Ten_NV_KT,Chuc_Vu,So_Dien_Thoai")] NHAN_VIEN_KY_THUAT nHAN_VIEN_KY_THUAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHAN_VIEN_KY_THUAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHAN_VIEN_KY_THUAT);
        }

        // GET: NHAN_VIEN_KY_THUAT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAN_VIEN_KY_THUAT nHAN_VIEN_KY_THUAT = db.NHAN_VIEN_KY_THUAT.Find(id);
            if (nHAN_VIEN_KY_THUAT == null)
            {
                return HttpNotFound();
            }
            return View(nHAN_VIEN_KY_THUAT);
        }

        // POST: NHAN_VIEN_KY_THUAT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHAN_VIEN_KY_THUAT nHAN_VIEN_KY_THUAT = db.NHAN_VIEN_KY_THUAT.Find(id);
            db.NHAN_VIEN_KY_THUAT.Remove(nHAN_VIEN_KY_THUAT);
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
