using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiteMe.Models
{
    public enum Category
    {
        Pastry,
        Cookie,
        Cake
    }
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}