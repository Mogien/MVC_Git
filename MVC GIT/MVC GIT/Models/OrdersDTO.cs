using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_GIT.Models
{
    public class OrdersDTO
    {
        public int Id { get; set; }

        public string No { get; set; }
        public DateTime OrderDate{ get; set; }
        public string OrderName { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public CustomersDTO Customer { get; set; }
    }
}