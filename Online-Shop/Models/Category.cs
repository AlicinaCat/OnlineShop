using System;
using System.Collections.Generic;

namespace Online_Shop.Models
{
    public partial class Category
    {
        public Category()
        {
            Food = new HashSet<Food>();
        }

        public int CategoryId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Food> Food { get; set; }
    }
}
