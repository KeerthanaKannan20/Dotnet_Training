using Question_2_API.Models;
using System.Linq;
using System.Web.Http;

namespace Question_2_API.Controllers
{
    public class OrdersController : ApiController
    {
        NorthwindEntities1 db = new NorthwindEntities1();

        public IHttpActionResult GetOrdersByEmployee()
        {
            var orders = db.Orders.Where(o => o.EmployeeID == 5).Select(o => new { o.OrderID, o.OrderDate, o.ShipCountry }).ToList();
            return Ok(orders);
        }
    }
}
