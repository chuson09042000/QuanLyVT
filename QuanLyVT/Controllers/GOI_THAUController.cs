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
    public class GOI_THAUController : Controller
    {
        private Model1 db = new Model1();

        // GET: GOI_THAU
        public ActionResult Index()
        {
            return View(db.GOI_THAU.ToList());
        }

        // GET: GOI_THAU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOI_THAU gOI_THAU = db.GOI_THAU.Find(id);
            if (gOI_THAU == null)
            {
                return HttpNotFound();
            }
            return View(gOI_THAU);
        }

        // GET: GOI_THAU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GOI_THAU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_GOI_THAU,Ma_Goi_Thau,Ten_Goi_Thau,Du_An")] GOI_THAU gOI_THAU)
        {
            if (ModelState.IsValid)
            {
                db.GOI_THAU.Add(gOI_THAU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gOI_THAU);
        }

        // GET: GOI_THAU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOI_THAU gOI_THAU = db.GOI_THAU.Find(id);
            if (gOI_THAU == null)
            {
                return HttpNotFound();
            }
            return View(gOI_THAU);
        }

        // POST: GOI_THAU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_GOI_THAU,Ma_Goi_Thau,Ten_Goi_Thau,Du_An")] GOI_THAU gOI_THAU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gOI_THAU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gOI_THAU);
        }

        // GET: GOI_THAU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOI_THAU gOI_THAU = db.GOI_THAU.Find(id);
            if (gOI_THAU == null)
            {
                return HttpNotFound();
            }
            return View(gOI_THAU);
        }

        // POST: GOI_THAU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GOI_THAU gOI_THAU = db.GOI_THAU.Find(id);
            db.GOI_THAU.Remove(gOI_THAU);
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
