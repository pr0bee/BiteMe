using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiteMe.Models
{
    public enum Status
    {
        Pending,
        Delivered,
        Canceled
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Status Status { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual Customer Customer { get; set; }
    }
}