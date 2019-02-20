using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Shop.Models;

namespace Online_Shop.ViewModels
{
    public class ViewModelFood
    {
        public List<Food> AllFoods { get; set; }
        public List<FoodIngredient> AllFoodIngredients { get; set; }
        public List<Ingredient> AllIngredients { get; set; }
        public List<SelectListItem> AllCategories { get; set; }
        public List<Food> CartList { get; set; }
        public List<Order> AllOrders { get; set; }
        public List<FoodOrder> AllFoodOrders { get; set; }
        public Customer CurrentCustomer { get; set; }
        public RegisterUser RegisterUser { get; set; }
        public Food CurrentFood { get; set; }
        public Ingredient CurrentIngredient { get; set; }
        public Order CurrentOrder { get; set; }
        public List<AspNetUsers> AllUsers { get; set; }
        public AspNetUsers CurrentUser { get; set; }

        public ViewModelFood()
        {
            AllFoods = new List<Food>();
            AllFoodIngredients = new List<FoodIngredient>();
            AllIngredients = new List<Ingredient>();
            AllCategories = new List<SelectListItem>();
            AllOrders = new List<Order>();
            AllFoodOrders = new List<FoodOrder>();
            CartList = new List<Food>();
            AllUsers = new List<AspNetUsers>();
        }
    }
}
