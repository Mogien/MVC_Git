using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_GIT.Models
{
    public class Order
    {
        [Display(Name = "Order No.")]
        public int OrderNo
        {
            get;
            set;
        }
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate
        {
            get;
            set;
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get;
            set;
        }
        [Display(Name = "Total Amount")]
        public float TotalAmount
        {
            get;
            set;
        }
    }
}