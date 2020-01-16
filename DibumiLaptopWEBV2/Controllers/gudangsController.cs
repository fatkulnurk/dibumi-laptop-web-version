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
    public class gudangsController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: gudangs
        public ActionResult Index()
        {
            return View(db.gudangs.ToList());
        }

        // GET: gudangs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gudang gudang = db.gudangs.Find(id);
            if (gudang == null)
            {
                return HttpNotFound();
            }
            return View(gudang);
        }

        // GET: gudangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gudangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nama,deskripsi")] gudang gudang)
        {
            if (ModelState.IsValid)
            {
                db.gudangs.Add(gudang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gudang);
        }

        // GET: gudangs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gudang gudang = db.gudangs.Find(id);
            if (gudang == null)
            {
                return HttpNotFound();
            }
            return View(gudang);
        }

        // POST: gudangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nama,deskripsi")] gudang gudang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gudang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gudang);
        }

        // GET: gudangs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gudang gudang = db.gudangs.Find(id);
            if (gudang == null)
            {
                return HttpNotFound();
            }
            return View(gudang);
        }

        // POST: gudangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            gudang gudang = db.gudangs.Find(id);
            db.gudangs.Remove(gudang);
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
