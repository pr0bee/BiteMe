using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiteMe.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}