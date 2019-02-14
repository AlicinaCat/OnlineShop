using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Models;
using Online_Shop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Shop.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private TomasosContext _context;

        public HomeController(TomasosContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewModelFood model = new ViewModelFood();
            model.AllFoods = _context.Food.ToList();
            model.AllFoodIngredients = _context.FoodIngredient.ToList();
            model.AllIngredients = _context.Ingredient.ToList();

            foreach (var item in model.AllFoods)
            {
                foreach (var ing in model.AllFoodIngredients.Where(f => f.FoodId == item.FoodId).ToList())
                {
                    item.Ingredients.Add(model.AllIngredients.SingleOrDefault(i => i.IngredientId == ing.IngredientId));
                }
            }

            return View(model);
        }
    }
}
