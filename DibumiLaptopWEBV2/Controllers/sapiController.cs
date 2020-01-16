using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;
using DibumiLaptopWEBV2.Models;

namespace DibumiLaptopWEBV2.Controllers
{
    public class sapiController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: sapi
        public JsonResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.items, JsonRequestBehavior.AllowGet);
        }

        // GET: gudang
        public JsonResult Gudang(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;
            gudang item = db.gudangs.Find(id);
            if (item == null)
            {
                return Json(db.gudangs, JsonRequestBehavior.AllowGet);
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        [ResponseType(typeof(item))]
        // GET: gudang
        public JsonResult Item(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;
            item item = db.items.Find(id);
            if (item == null)
            {
                return Json(db.items, JsonRequestBehavior.AllowGet);
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        // GET: gudang
        public JsonResult ItemStok(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;
            item_stok item = db.item_stok.Find(id);
            if (item == null)
            {
                return Json(db.item_stok, JsonRequestBehavior.AllowGet);
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        // GET: gudang
        public JsonResult Kondisi(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;
            kondisi item = db.kondisis.Find(id);
            if (item == null)
            {
                return Json(db.kondisis, JsonRequestBehavior.AllowGet);
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }


        // GET: gudang
        public JsonResult Merek(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;
            merek item = db.mereks.Find(id);
            if (item == null)
            {
                return Json(db.mereks, JsonRequestBehavior.AllowGet);
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        // GET: gudang
        public JsonResult ReturnItem(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return_item item = db.return_item.Find(id);
            if (item == null)
            {
                return Json(db.return_item, JsonRequestBehavior.AllowGet);
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        // GET: gudang
        public JsonResult Transaksi(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;
            transaksi item = db.transaksis.Find(id);
            if (item == null)
            {
                return Json(db.transaksis, JsonRequestBehavior.AllowGet);
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        // GET: garansi
        public JsonResult Garansi(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;
            garansi item = db.garansis.Find(id);
            if (item == null)
            {
                return Json(db.garansis, JsonRequestBehavior.AllowGet);
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}