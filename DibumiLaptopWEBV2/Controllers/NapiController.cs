using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DibumiLaptopWEBV2.Models;

namespace DibumiLaptopWEBV2.Controllers
{
    public class NapiController : Controller
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: Napi
        public JsonResult Index()
        { 
            string output = "Nama saya rudi, ya panggil aja rudi.";

            return Json(output, JsonRequestBehavior.AllowGet);
        }

        // GET: Item
        public ActionResult Item(long id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;

            if (id == 0 )
            {
                return Json(id, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                PropertyINeed1 = db.items
            }, JsonRequestBehavior.AllowGet);
        }
    }
}