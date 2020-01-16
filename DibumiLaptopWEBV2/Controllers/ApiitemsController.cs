using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DibumiLaptopWEBV2.Models;

namespace DibumiLaptopWEBV2.Controllers
{
    public class ApiitemsController : ApiController
    {
        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: api/Apiitems
        public IQueryable<item> Getitems()
        {
            return db.items;
        }

        // GET: api/Apiitems/5
        [ResponseType(typeof(item))]
        public IHttpActionResult Getitem(long id)
        {
            item item = db.items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Apiitems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putitem(long id, item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.id)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Apiitems
        [ResponseType(typeof(item))]
        public IHttpActionResult Postitem(item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.items.Add(item);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = item.id }, item);
        }

        // DELETE: api/Apiitems/5
        [ResponseType(typeof(item))]
        public IHttpActionResult Deleteitem(long id)
        {
            item item = db.items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.items.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool itemExists(long id)
        {
            return db.items.Count(e => e.id == id) > 0;
        }
    }
}