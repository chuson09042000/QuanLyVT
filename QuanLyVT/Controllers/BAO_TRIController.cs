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
    public class BAO_TRIController : Controller
    {
        private Model1 db = new Model1();

        // GET: BAO_TRI
        public ActionResult Index()
        {
            var bAO_TRI = db.BAO_TRI.Include(b => b.HOP_DONG).Include(b => b.THIET_BI);
            return View(bAO_TRI.ToList());
        }

        // GET: BAO_TRI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAO_TRI bAO_TRI = db.BAO_TRI.Find(id);
            if (bAO_TRI == null)
            {
                return HttpNotFound();
            }
            return View(bAO_TRI);
        }

        // GET: BAO_TRI/Create
        public ActionResult Create()
        {
            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ma_HD");
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ma_TB");
            return View();
        }

        // POST: BAO_TRI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BAO_TRI,Ma_Bao_Tri,Ngay_Bao_Tri,LK_ThayThe,ID_THIET_BI,ID_HOP_DONG")] BAO_TRI bAO_TRI)
        {
            if (ModelState.IsValid)
            {
                db.BAO_TRI.Add(bAO_TRI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ma_HD", bAO_TRI.ID_HOP_DONG);
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ma_TB", bAO_TRI.ID_THIET_BI);
            return View(bAO_TRI);
        }

        // GET: BAO_TRI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAO_TRI bAO_TRI = db.BAO_TRI.Find(id);
            if (bAO_TRI == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ma_HD", bAO_TRI.ID_HOP_DONG);
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ma_TB", bAO_TRI.ID_THIET_BI);
            return View(bAO_TRI);
        }

        // POST: BAO_TRI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BAO_TRI,Ma_Bao_Tri,Ngay_Bao_Tri,LK_ThayThe,ID_THIET_BI,ID_HOP_DONG")] BAO_TRI bAO_TRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAO_TRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ma_HD", bAO_TRI.ID_HOP_DONG);
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ma_TB", bAO_TRI.ID_THIET_BI);
            return View(bAO_TRI);
        }

        // GET: BAO_TRI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAO_TRI bAO_TRI = db.BAO_TRI.Find(id);
            if (bAO_TRI == null)
            {
                return HttpNotFound();
            }
            return View(bAO_TRI);
        }

        // POST: BAO_TRI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAO_TRI bAO_TRI = db.BAO_TRI.Find(id);
            db.BAO_TRI.Remove(bAO_TRI);
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
