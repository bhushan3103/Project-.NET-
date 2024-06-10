using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoeWorldApp.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public DateTime CartDate { get; set; }
        public int? CustomerId { get; set; }
        public int ProductId { get; set; }
        public int? EmployeeId { get; set; }
        public int Quantity { get; set; }
    }
}