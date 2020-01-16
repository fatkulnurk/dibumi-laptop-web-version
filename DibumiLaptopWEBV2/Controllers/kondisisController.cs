using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DibumiLaptopWEBV2.Models;

namespace DibumiLaptopWEBV2.Controllers
{
    public class kondisisController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: kondisis
        public ActionResult Index()
        {
            return View(db.kondisis.ToList());
        }

        // GET: kondisis/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kondisi kondisi = db.kondisis.Find(id);
            if (kondisi == null)
            {
                return HttpNotFound();
            }
            return View(kondisi);
        }

        // GET: kondisis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kondisis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nama,deskripsi")] kondisi kondisi)
        {
            if (ModelState.IsValid)
            {
                db.kondisis.Add(kondisi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kondisi);
        }

        // GET: kondisis/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kondisi kondisi = db.kondisis.Find(id);
            if (kondisi == null)
            {
                return HttpNotFound();
            }
            return View(kondisi);
        }

        // POST: kondisis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nama,deskripsi")] kondisi kondisi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kondisi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kondisi);
        }

        // GET: kondisis/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kondisi kondisi = db.kondisis.Find(id);
            if (kondisi == null)
            {
                return HttpNotFound();
            }
            return View(kondisi);
        }

        // POST: kondisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            kondisi kondisi = db.kondisis.Find(id);
            db.kondisis.Remove(kondisi);
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
