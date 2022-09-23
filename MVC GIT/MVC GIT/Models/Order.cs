using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_GIT.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; }

        public string No { get; set; }

        public DateTime OrderDate { get; set;}

        public string OrderName { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public Customer Customer { get; set; }
    }
}