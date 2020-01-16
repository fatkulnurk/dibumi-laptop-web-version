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
    public class return_itemController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: return_item
        public ActionResult Index()
        {
            var return_item = db.return_item.Include(r => r.item).Include(r => r.transaksi);
            return View(return_item.ToList());
        }

        // GET: return_item/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return_item return_item = db.return_item.Find(id);
            if (return_item == null)
            {
                return HttpNotFound();
            }
            return View(return_item);
        }

        // GET: return_item/Create
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Pending", Value = "Pending" });

            items.Add(new SelectListItem { Text = "Sukses", Value = "Sukses" });

            items.Add(new SelectListItem { Text = "Cancel", Value = "Cancel", Selected = true });

            ViewBag.item_id = new SelectList(db.items, "id", "tipe");
            ViewBag.transaksi_id = new SelectList(db.transaksis, "id", "id");
            ViewBag.Status = items;
            return View();
        }

        // POST: return_item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,transaksi_id,tanggal_return,keterangan,alasan_return,qty,total_bayar_return")] return_item return_item)
        {
            transaksi transaksi_one = db.transaksis.Find(return_item.transaksi_id);
            if (ModelState.IsValid)
            {
                return_item.item_id = transaksi_one.item_id;
                return_item.harga_satuan_temp = transaksi_one.harga_satuan_temp;
                return_item.total_harga = transaksi_one.total_harga;
                return_item.status_return = "Pending";
                db.return_item.Add(return_item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.item_id = new SelectList(db.items, "id", "tipe", return_item.item_id);
            ViewBag.transaksi_id = new SelectList(db.transaksis, "id", "deskripsi", return_item.transaksi_id);
            return View(return_item);
        }

        // GET: return_item/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return_item return_item = db.return_item.Find(id);
            if (return_item == null)
            {
                return HttpNotFound();
            }
            ViewBag.item_id = new SelectList(db.items, "id", "tipe", return_item.item_id);
            ViewBag.transaksi_id = new SelectList(db.transaksis, "id", "deskripsi", return_item.transaksi_id);
            ViewBag.return_item = return_item;
            return View(return_item);
        }

        // POST: return_item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long? id, string status_return)
        {
            return_item rItem = db.return_item.Find(id);
            if (ModelState.IsValid)
            {
                rItem.status_return = status_return;
                //db.Entry(return_item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.item_id = new SelectList(db.items, "id", "tipe", rItem.item_id);
            ViewBag.transaksi_id = new SelectList(db.transaksis, "id", "deskripsi", rItem.transaksi_id);
            return View(rItem);
        }

        // GET: return_item/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return_item return_item = db.return_item.Find(id);
            if (return_item == null)
            {
                return HttpNotFound();
            }
            return View(return_item);
        }

        // POST: return_item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            return_item return_item = db.return_item.Find(id);
            db.return_item.Remove(return_item);
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
