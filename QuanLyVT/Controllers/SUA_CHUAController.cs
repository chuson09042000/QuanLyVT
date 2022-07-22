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
    public class SUA_CHUAController : Controller
    {
        private Model1 db = new Model1();

        // GET: SUA_CHUA
        public ActionResult Index()
        {
            var sUA_CHUA = db.SUA_CHUA.Include(s => s.HOP_DONG).Include(s => s.THIET_BI);
            return View(sUA_CHUA.ToList());
        }

        // GET: SUA_CHUA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUA_CHUA sUA_CHUA = db.SUA_CHUA.Find(id);
            if (sUA_CHUA == null)
            {
                return HttpNotFound();
            }
            return View(sUA_CHUA);
        }

        // GET: SUA_CHUA/Create
        public ActionResult Create()
        {
            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ma_HD");
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ma_TB");
            return View();
        }

        // POST: SUA_CHUA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUA_CHUA,Ma_Sua_Chua,Ngay_Sua_Chua,LK_ThayThe,ID_HOP_DONG,ID_THIET_BI")] SUA_CHUA sUA_CHUA)
        {
            if (ModelState.IsValid)
            {
                db.SUA_CHUA.Add(sUA_CHUA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ma_HD", sUA_CHUA.ID_HOP_DONG);
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ma_TB", sUA_CHUA.ID_THIET_BI);
            return View(sUA_CHUA);
        }

        // GET: SUA_CHUA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUA_CHUA sUA_CHUA = db.SUA_CHUA.Find(id);
            if (sUA_CHUA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ma_HD", sUA_CHUA.ID_HOP_DONG);
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ma_TB", sUA_CHUA.ID_THIET_BI);
            return View(sUA_CHUA);
        }

        // POST: SUA_CHUA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SUA_CHUA,Ma_Sua_Chua,Ngay_Sua_Chua,LK_ThayThe,ID_HOP_DONG,ID_THIET_BI")] SUA_CHUA sUA_CHUA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUA_CHUA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HOP_DONG = new SelectList(db.HOP_DONG, "ID_HOP_DONG", "Ma_HD", sUA_CHUA.ID_HOP_DONG);
            ViewBag.ID_THIET_BI = new SelectList(db.THIET_BI, "ID_THIET_BI", "Ma_TB", sUA_CHUA.ID_THIET_BI);
            return View(sUA_CHUA);
        }

        // GET: SUA_CHUA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUA_CHUA sUA_CHUA = db.SUA_CHUA.Find(id);
            if (sUA_CHUA == null)
            {
                return HttpNotFound();
            }
            return View(sUA_CHUA);
        }

        // POST: SUA_CHUA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUA_CHUA sUA_CHUA = db.SUA_CHUA.Find(id);
            db.SUA_CHUA.Remove(sUA_CHUA);
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
