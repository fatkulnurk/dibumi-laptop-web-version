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
    public class reporttransaksisController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: reporttransaksis
        public ActionResult Index(DateTime? from=null, DateTime? to=null)
        {
            if (from == null && to == null)
            {
                var transaksis = db.transaksis.Include(t => t.item);
                return View(transaksis.ToList());
            }

            ViewBag.dateFrom = from;
            ViewBag.dateTo = to;

            // var transaksisWithQuery = db.transaksis.Include(t => t.item);
            var transaksisWithQuery = db.transaksis.Include(t => t.item);

            return View(
                transaksisWithQuery
                .Where(m => m.tanggal_transaksi >= from)
                .Where(m => m.tanggal_transaksi <= to)
                .ToList()
            );
        }

        // GET: reporttransaksis/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaksi transaksi = db.transaksis.Find(id);
            if (transaksi == null)
            {
                return HttpNotFound();
            }
            return View(transaksi);
        }

        // GET: reporttransaksis/Create
        public ActionResult Create()
        {
            ViewBag.item_id = new SelectList(db.items, "id", "tipe");
            return View();
        }

        // POST: reporttransaksis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,item_id,tanggal_transaksi,qty,harga_satuan_temp,total_harga,deskripsi")] transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                db.transaksis.Add(transaksi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.item_id = new SelectList(db.items, "id", "tipe", transaksi.item_id);
            return View(transaksi);
        }

        // GET: reporttransaksis/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaksi transaksi = db.transaksis.Find(id);
            if (transaksi == null)
            {
                return HttpNotFound();
            }
            ViewBag.item_id = new SelectList(db.items, "id", "tipe", transaksi.item_id);
            return View(transaksi);
        }

        // POST: reporttransaksis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,item_id,tanggal_transaksi,qty,harga_satuan_temp,total_harga,deskripsi")] transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaksi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.item_id = new SelectList(db.items, "id", "tipe", transaksi.item_id);
            return View(transaksi);
        }

        // GET: reporttransaksis/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaksi transaksi = db.transaksis.Find(id);
            if (transaksi == null)
            {
                return HttpNotFound();
            }
            return View(transaksi);
        }

        // POST: reporttransaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            transaksi transaksi = db.transaksis.Find(id);
            db.transaksis.Remove(transaksi);
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
