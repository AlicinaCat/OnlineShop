using System;
using System.Collections.Generic;

namespace Online_Shop.Models
{
    public partial class FoodOrder
    {
        public int FoodId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Food Food { get; set; }
        public virtual Order Order { get; set; }
    }
}
