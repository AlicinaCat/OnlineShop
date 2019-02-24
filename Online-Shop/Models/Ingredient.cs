using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shop.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            FoodIngredient = new HashSet<FoodIngredient>();
        }

        public int IngredientId { get; set; }
        [Required(ErrorMessage = "Please fill in name.")]
        [StringLength(50, ErrorMessage = "Max 50 characters.")]
        public string IngredientName { get; set; }

        [NotMapped]
        public bool Selected { get; set; }

        public virtual ICollection<FoodIngredient> FoodIngredient { get; set; }
    }
}
