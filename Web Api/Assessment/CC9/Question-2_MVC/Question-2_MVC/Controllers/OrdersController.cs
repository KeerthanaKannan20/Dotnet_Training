using Newtonsoft.Json;
using Question_2_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Question_2_MVC.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult DisplayOrders()
        {
            IEnumerable<Order> orderList = null;

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44302/swagger/");
                var responsetalk = webclient.GetAsync("Orders");
                responsetalk.Wait();

                var result = responsetalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    orderList = JsonConvert.DeserializeObject<List<Order>>(resultdata);
                }
                else
                {
                    orderList = Enumerable.Empty<Order>();
                }

                return View(orderList);
            }
        }
    }
}
