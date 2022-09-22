using MVC_GIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GIT.Controllers
{
    public class HomeController : Controller
    {
        List<Order> stud = new List<Order>
            {
                new Order { OrderNo=1, OrderDate=new DateTime(2021, 12, 10), CustomerName="Customer1", TotalAmount=434.65f},
                new Order { OrderNo=2, OrderDate=new DateTime(2022, 1, 02), CustomerName="Customer2", TotalAmount=543.00f},
                new Order { OrderNo=3, OrderDate=new DateTime(2022, 4, 25), CustomerName="Customer3", TotalAmount=34.65f}
            };
        public ActionResult Index()
        {
            ViewData.Model = stud;
            return View();
        }
    }
}