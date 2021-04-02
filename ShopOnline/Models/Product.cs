using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Controllers
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Vendor { get; set; }
        public int Quantity { get; set; }
    }
}