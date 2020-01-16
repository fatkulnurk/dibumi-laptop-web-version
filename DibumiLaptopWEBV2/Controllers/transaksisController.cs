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
    public class transaksisController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: transaksis
        public ActionResult Index()
        {
            var transaksis = db.transaksis.Include(t => t.item);
            return View(transaksis.ToList());
        }

        // GET: transaksis/Details/5
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

        // GET: transaksis/Create
        public ActionResult Create()
        {
            ViewBag.item_id = new SelectList(db.items, "id", "tipe");
            return View();
        }

        // POST: transaksis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,item_id,tanggal_transaksi,qty,harga_satuan_temp,total_harga,deskripsi")] transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                item item = db.items.Find(transaksi.item_id);
                transaksi.harga_satuan_temp = item.harga;
                transaksi.total_harga = item.harga * transaksi.qty;
                db.transaksis.Add(transaksi);

                item_stok istok = new item_stok();
                istok.item_id = transaksi.item_id;
                istok.type = "out";
                istok.stok = transaksi.qty;
                db.item_stok.Add(istok);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.item_id = new SelectList(db.items, "id", "tipe", transaksi.item_id);
            return View(transaksi);
        }

        // GET: transaksis/Edit/5
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

        // POST: transaksis/Edit/5
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

        // GET: transaksis/Delete/5
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

        // POST: transaksis/Delete/5
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
