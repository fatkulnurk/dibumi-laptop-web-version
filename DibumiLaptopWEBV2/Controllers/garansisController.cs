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
    public class garansisController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: garansis
        public ActionResult Index()
        {
            return View(db.garansis.ToList());
        }

        // GET: garansis/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garansi garansi = db.garansis.Find(id);
            if (garansi == null)
            {
                return HttpNotFound();
            }
            return View(garansi);
        }

        // GET: garansis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: garansis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nama,deskripsi")] garansi garansi)
        {
            if (ModelState.IsValid)
            {
                db.garansis.Add(garansi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garansi);
        }

        // GET: garansis/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garansi garansi = db.garansis.Find(id);
            if (garansi == null)
            {
                return HttpNotFound();
            }
            return View(garansi);
        }

        // POST: garansis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nama,deskripsi")] garansi garansi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garansi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garansi);
        }

        // GET: garansis/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garansi garansi = db.garansis.Find(id);
            if (garansi == null)
            {
                return HttpNotFound();
            }
            return View(garansi);
        }

        // POST: garansis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            garansi garansi = db.garansis.Find(id);
            db.garansis.Remove(garansi);
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
