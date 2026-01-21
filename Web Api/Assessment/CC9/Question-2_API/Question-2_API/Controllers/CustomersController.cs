using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Question_2_API.Models;
namespace Question_2_API.Controllers
{
    public class CustomersController : ApiController
    {
        NorthwindEntities1 db = new NorthwindEntities1();

        [HttpGet]
        [Route("api/customers/bycountry/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country);
            return Ok(customers);
        }
    }
}
