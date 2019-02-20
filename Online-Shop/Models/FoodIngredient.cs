using System;
using System.Collections.Generic;

namespace Online_Shop.Models
{
    public partial class FoodIngredient
    {
        public int FoodId { get; set; }
        public int IngredientId { get; set; }

        public virtual Food Food { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
