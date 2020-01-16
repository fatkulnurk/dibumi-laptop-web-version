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
    public class mereksController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: mereks
        public ActionResult Index()
        {
            return View(db.mereks.ToList());
        }

        // GET: mereks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            merek merek = db.mereks.Find(id);
            if (merek == null)
            {
                return HttpNotFound();
            }
            return View(merek);
        }

        // GET: mereks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mereks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nama,deskripsi")] merek merek)
        {
            if (ModelState.IsValid)
            {
                db.mereks.Add(merek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(merek);
        }

        // GET: mereks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            merek merek = db.mereks.Find(id);
            if (merek == null)
            {
                return HttpNotFound();
            }
            return View(merek);
        }

        // POST: mereks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nama,deskripsi")] merek merek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(merek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(merek);
        }

        // GET: mereks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            merek merek = db.mereks.Find(id);
            if (merek == null)
            {
                return HttpNotFound();
            }
            return View(merek);
        }

        // POST: mereks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            merek merek = db.mereks.Find(id);
            db.mereks.Remove(merek);
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
