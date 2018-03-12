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

    public enum Unit
    {
        kg,
        pcs
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Unit Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}