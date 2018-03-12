﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiteMe.Models
{
    public class ProductOrder
    {
        public int ProductOrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}