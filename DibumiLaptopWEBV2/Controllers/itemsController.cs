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
    public class itemsController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: items
        public ActionResult Index()
        {
            var items = db.items.Include(i => i.garansi).Include(i => i.gudang).Include(i => i.kondisi).Include(i => i.merek);
            return View(items.ToList());
        }

        // GET: items/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item item = db.items.Find(id);
            var item_Stok = db.item_stok.Where(x => x.item_id == item.id).ToList();
            ViewBag.item_stok = item_Stok;

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: items/Create
        public ActionResult Create()
        {
            ViewBag.garansi_id = new SelectList(db.garansis, "id", "nama");
            ViewBag.gudang_id = new SelectList(db.gudangs, "id", "nama");
            ViewBag.kondisi_id = new SelectList(db.kondisis, "id", "nama");
            ViewBag.merek_id = new SelectList(db.mereks, "id", "nama");
            return View();
        }

        // POST: items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,merek_id,tipe,deskripsi,processor,ram,penyimpanan,ukuran_layar,stok,gudang_id,kondisi_id,tanggal_ditambahkan,garansi_id,garansi_expired,harga")] item item)
        {
            if (ModelState.IsValid)
            {
                db.items.Add(item);

                item_stok istok = new item_stok();
                istok.item_id = item.id;
                istok.type = "in";
                istok.stok = item.stok;
                db.item_stok.Add(istok);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.garansi_id = new SelectList(db.garansis, "id", "nama", item.garansi_id);
            ViewBag.gudang_id = new SelectList(db.gudangs, "id", "nama", item.gudang_id);
            ViewBag.kondisi_id = new SelectList(db.kondisis, "id", "nama", item.kondisi_id);
            ViewBag.merek_id = new SelectList(db.mereks, "id", "nama", item.merek_id);
            return View(item);
        }

        // GET: items/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item item = db.items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.garansi_id = new SelectList(db.garansis, "id", "nama", item.garansi_id);
            ViewBag.gudang_id = new SelectList(db.gudangs, "id", "nama", item.gudang_id);
            ViewBag.kondisi_id = new SelectList(db.kondisis, "id", "nama", item.kondisi_id);
            ViewBag.merek_id = new SelectList(db.mereks, "id", "nama", item.merek_id);
            return View(item);
        }

        // POST: items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,merek_id,tipe,deskripsi,processor,ram,penyimpanan,ukuran_layar,stok,gudang_id,kondisi_id,tanggal_ditambahkan,garansi_id,garansi_expired,harga")] item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.garansi_id = new SelectList(db.garansis, "id", "nama", item.garansi_id);
            ViewBag.gudang_id = new SelectList(db.gudangs, "id", "nama", item.gudang_id);
            ViewBag.kondisi_id = new SelectList(db.kondisis, "id", "nama", item.kondisi_id);
            ViewBag.merek_id = new SelectList(db.mereks, "id", "nama", item.merek_id);
            return View(item);
        }

        // GET: items/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item item = db.items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            item item = db.items.Find(id);
            db.items.Remove(item);
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
