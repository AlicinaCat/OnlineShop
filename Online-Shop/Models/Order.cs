using System;
using System.Collections.Generic;

namespace Online_Shop.Models
{
    public partial class Order
    {
        public Order()
        {
            FoodOrder = new HashSet<FoodOrder>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public bool Delivered { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<FoodOrder> FoodOrder { get; set; }
    }
}
