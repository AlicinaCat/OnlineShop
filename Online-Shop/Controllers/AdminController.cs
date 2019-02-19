using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Shop.Models;
using Online_Shop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Shop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private TomasosContext _context;

        public AdminController(TomasosContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult ManageMenu()
        {
            var model = GetViewModel();

            return View(model);
        }

        public IActionResult EditMenu(int id)
        {
            var model = GetViewModel();

            model.CurrentFood = model.AllFoods.SingleOrDefault(f => f.FoodId == id);

            return View(model);
        }


        // TODO make this method smaller
        [HttpPost]
        public IActionResult EditMenu(ViewModelFood edited)
        {
            var old = GetViewModel();

            old.CurrentFood = _context.Food.SingleOrDefault(f => f.FoodId == edited.CurrentFood.FoodId);
            edited.CurrentFood.Ingredients = new List<Ingredient>();

            foreach (var item in edited.AllIngredients)
            {
                if (item.Selected == true)
                {
                    if (old.CurrentFood.Ingredients.FirstOrDefault(i => i.IngredientId == item.IngredientId) == null)
                    {
                        FoodIngredient foodIng = new FoodIngredient();
                        foodIng.FoodId = edited.CurrentFood.FoodId;
                        foodIng.IngredientId = item.IngredientId;

                        _context.Add(foodIng);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    if (old.CurrentFood.Ingredients.FirstOrDefault(i => i.IngredientId == item.IngredientId) != null)
                    {
                        var foodIng = _context.FoodIngredient.SingleOrDefault(i => i.IngredientId == item.IngredientId);

                        _context.Remove(foodIng);
                        _context.SaveChanges();
                    }
                }
            }
    

                _context.Entry(old.CurrentFood).CurrentValues.SetValues(edited.CurrentFood);
            _context.SaveChanges();

            return RedirectToAction("ManageMenu");
        }

        public IActionResult ManageOrders()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }

        public ViewModelFood GetViewModel()
        {
            ViewModelFood model = new ViewModelFood();
            model.AllFoods = _context.Food.ToList();
            model.AllFoodIngredients = _context.FoodIngredient.ToList();
            model.AllIngredients = _context.Ingredient.ToList();

            foreach (var item in _context.Category)
            {
                model.AllCategories.Add(new SelectListItem { Text = item.Title, Value = item.CategoryId.ToString() });
            }

            foreach (var item in model.AllFoods)
            {
                foreach (var ing in model.AllFoodIngredients.Where(f => f.FoodId == item.FoodId).ToList())
                {
                    item.Ingredients.Add(model.AllIngredients.SingleOrDefault(i => i.IngredientId == ing.IngredientId));
                }
            }

            return model;
        }
    }
}
