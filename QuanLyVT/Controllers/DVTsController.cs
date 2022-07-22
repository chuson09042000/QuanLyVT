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
    public class DVTsController : Controller
    {
        //private QLVT db = new QLVT();
        private Model1 db = new Model1();

        // GET: DVTs
        public ActionResult Index()
        {
            return View(db.DVTs.ToList());
        }

        // GET: DVTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVT dVT = db.DVTs.Find(id);
            if (dVT == null)
            {
                return HttpNotFound();
            }
            return View(dVT);
        }

        // GET: DVTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DVTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DVT,Ma_DVT,Ten_DVT")] DVT dVT)
        {
            if (ModelState.IsValid)
            {
                db.DVTs.Add(dVT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dVT);
        }

        // GET: DVTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVT dVT = db.DVTs.Find(id);
            if (dVT == null)
            {
                return HttpNotFound();
            }
            return View(dVT);
        }

        // POST: DVTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DVT,Ma_DVT,Ten_DVT")] DVT dVT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dVT);
        }

        // GET: DVTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVT dVT = db.DVTs.Find(id);
            if (dVT == null)
            {
                return HttpNotFound();
            }
            return View(dVT);
        }

        // POST: DVTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DVT dVT = db.DVTs.Find(id);
            db.DVTs.Remove(dVT);
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
