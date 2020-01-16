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
    public class item_stokController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: item_stok
        public ActionResult Index()
        {
            var item_stok = db.item_stok.Include(i => i.item);
            return View(item_stok.ToList());
        }

        // GET: item_stok/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item_stok item_stok = db.item_stok.Find(id);
            if (item_stok == null)
            {
                return HttpNotFound();
            }
            return View(item_stok);
        }

        // GET: item_stok/Create
        public ActionResult Create()
        {
            ViewBag.item_id = new SelectList(db.items, "id", "tipe");
            return View();
        }

        // POST: item_stok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,item_id,type,stok")] item_stok item_stok)
        {
            if (ModelState.IsValid)
            {
                db.item_stok.Add(item_stok);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.item_id = new SelectList(db.items, "id", "tipe", item_stok.item_id);
            return View(item_stok);
        }

        // GET: item_stok/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item_stok item_stok = db.item_stok.Find(id);
            if (item_stok == null)
            {
                return HttpNotFound();
            }
            ViewBag.item_id = new SelectList(db.items, "id", "tipe", item_stok.item_id);
            return View(item_stok);
        }

        // POST: item_stok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,item_id,type,stok")] item_stok item_stok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_stok).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.item_id = new SelectList(db.items, "id", "tipe", item_stok.item_id);
            return View(item_stok);
        }

        // GET: item_stok/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item_stok item_stok = db.item_stok.Find(id);
            if (item_stok == null)
            {
                return HttpNotFound();
            }
            return View(item_stok);
        }

        // POST: item_stok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            item_stok item_stok = db.item_stok.Find(id);
            db.item_stok.Remove(item_stok);
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
