using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_GIT.Context;
using MVC_GIT.Models;

namespace MVC_GIT.Controllers
{
    public class OrdersController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Orders
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomersDTO
            {
                Id = c.Id,
                Name = $"{c.LastName}, {c.Firstname} {c.MiddleName[0]}"
            }).ToList();

            SelectList CustomerList = new SelectList(customerModel, "Id", "Name");
            ViewData["CustomerList"] = CustomerList;
            return View();
        }
        public ActionResult OrderDetails(int id = 0)
        {
            //get all data from database
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomersDTO
            {
                Id = c.Id,
                Firstname = c.Firstname,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                Gender = c.Gender,
                Name = $"{c.LastName}, {c.Firstname} {c.MiddleName[0]}"
            }).ToList();

            var orderList = db.Orders.Where(x => x.CustomerId == id || id == 0).ToList();
            var modelOrder = orderList.Select(c => new OrdersDTO
            {
                Id = c.Id,
                No = c.No,
                OrderName = c.OrderName,
                OrderDate = c.OrderDate,
                CustomerId = c.CustomerId,
                Amount = c.Amount,
                Customer = customerModel.FirstOrDefault(x => x.Id == c.CustomerId)
            }).ToList();

            return PartialView("Details", modelOrder);
        }



        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomersDTO
            {
                Id = c.Id,
                Name = $"{c.LastName}, {c.Firstname} {c.MiddleName[0]}"
            }).ToList();

            SelectList CustomerList = new SelectList(customerModel, "Id", "Name");
            ViewData["CustomerId"] = CustomerList;
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdersDTO data)
        {
            using (var db = new EFContext())
            {
                var order = new Order
                {
                    Id = data.Id,
                    No = data.No,
                    OrderName = data.OrderName,
                    OrderDate = data.OrderDate,
                    CustomerId = data.CustomerId,
                    Amount = data.Amount
                };

                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Firstname", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,No,OrderDate,OrderName,CustomerId,Amount")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Firstname", order.CustomerId);
            return View(order);
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
