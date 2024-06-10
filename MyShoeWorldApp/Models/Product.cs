using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoeWorldApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public string MadeIn { get; set; }
        public string Gender { get; set; }
        public string WarrantyPeriod { get; set; }
        public string ReturnPolicy { get; set; }
        public int ProductQuantity { get; set; }
        public int Discount { get; set; }
        public string Picture { get; set; }
    }
}