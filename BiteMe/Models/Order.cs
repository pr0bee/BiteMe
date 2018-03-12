using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiteMe.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual Customer Customer { get; set; }
    }
}