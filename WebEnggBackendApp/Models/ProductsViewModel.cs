using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEnggBackendApp.Models
{
    public class ProductsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string FormattedPrice()
        {
            return Price.ToString("N0");
        }

    }
}