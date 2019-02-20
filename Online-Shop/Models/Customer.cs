using System;
using System.Collections.Generic;

namespace Online_Shop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public int? Points { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
