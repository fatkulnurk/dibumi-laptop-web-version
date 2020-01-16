using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DibumiLaptopWEBV2.Models;

namespace DibumiLaptopWEBV2.Controllers.Api
{
    public class DefaultController : ApiController
    {

        private dibumilaptopAdoEntities db = new dibumilaptopAdoEntities();

        // GET: api/default
        public IQueryable<item> Getitems()
        {
            return db.items;
        }

    }
}
