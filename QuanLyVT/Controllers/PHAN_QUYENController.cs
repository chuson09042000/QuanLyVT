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
    public class PHAN_QUYENController : Controller
    {
        private Model1 db = new Model1();

        // GET: PHAN_QUYEN
        public ActionResult Index()
        {
            return View(db.PHAN_QUYEN.ToList());
        }

        // GET: PHAN_QUYEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHAN_QUYEN pHAN_QUYEN = db.PHAN_QUYEN.Find(id);
            if (pHAN_QUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHAN_QUYEN);
        }

        // GET: PHAN_QUYEN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PHAN_QUYEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PHAN_QUYEN,Ma_Phan_Quyen,Ten_Quyen")] PHAN_QUYEN pHAN_QUYEN)
        {
            if (ModelState.IsValid)
            {
                db.PHAN_QUYEN.Add(pHAN_QUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHAN_QUYEN);
        }

        // GET: PHAN_QUYEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHAN_QUYEN pHAN_QUYEN = db.PHAN_QUYEN.Find(id);
            if (pHAN_QUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHAN_QUYEN);
        }

        // POST: PHAN_QUYEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PHAN_QUYEN,Ma_Phan_Quyen,Ten_Quyen")] PHAN_QUYEN pHAN_QUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHAN_QUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHAN_QUYEN);
        }

        // GET: PHAN_QUYEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHAN_QUYEN pHAN_QUYEN = db.PHAN_QUYEN.Find(id);
            if (pHAN_QUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHAN_QUYEN);
        }

        // POST: PHAN_QUYEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHAN_QUYEN pHAN_QUYEN = db.PHAN_QUYEN.Find(id);
            db.PHAN_QUYEN.Remove(pHAN_QUYEN);
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
