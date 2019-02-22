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


        // TODO - make this method smaller
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
                        var foodIng = _context.FoodIngredient.FirstOrDefault(i => i.IngredientId == item.IngredientId
                                     && i.FoodId == edited.CurrentFood.FoodId);

                        _context.Remove(foodIng);
                        _context.SaveChanges();
                    }
                }
            }
    

                _context.Entry(old.CurrentFood).CurrentValues.SetValues(edited.CurrentFood);
            _context.SaveChanges();

            return RedirectToAction("ManageMenu");
        }

        public IActionResult AddFood()
        {
            var model = GetViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddFood(ViewModelFood model)
        {
            Food food = new Food();
            food.Name = model.CurrentFood.Name;
            food.CategoryId = model.CurrentFood.CategoryId;
            food.Price = model.CurrentFood.Price;

            _context.Food.Add(food);
            _context.SaveChanges();

            foreach (var item in model.AllIngredients)
            {
                if (item.Selected == true)
                {
                        FoodIngredient foodIng = new FoodIngredient();
                        foodIng.FoodId = model.CurrentFood.FoodId;
                        foodIng.IngredientId = item.IngredientId;

                        _context.Add(foodIng);
                        _context.SaveChanges();
                }
            }

            return RedirectToAction("ManageMenu");
        }

        public IActionResult ManageIngredients()
        {
            var model = GetViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult ManageIngredients(ViewModelFood model)
        {
            Ingredient ing = new Ingredient();
            ing.IngredientName = model.CurrentIngredient.IngredientName;

            _context.Ingredient.Add(ing);
            _context.SaveChanges();

            return RedirectToAction("ManageIngredients");
        }

        // TODO - makes sure you can't delete ingredients from other recipes
        public IActionResult RemoveIngredient(int id)
        {
            var ing = _context.Ingredient.SingleOrDefault(i => i.IngredientId == id);

            _context.Remove(ing);
            _context.SaveChanges();

            return RedirectToAction("ManageIngredients");
        }

        [HttpPost]
        public IActionResult EditIngredient(ViewModelFood edited)
        {
            var old = GetViewModel();
            old.CurrentIngredient = _context.Ingredient.SingleOrDefault(i => i.IngredientId == edited.CurrentIngredient.IngredientId);

            _context.Entry(old.CurrentIngredient).CurrentValues.SetValues(edited.CurrentIngredient);
            _context.SaveChanges();

            return RedirectToAction("ManageIngredients");
        }

        public IActionResult ManageOrders()
        {
            var model = GetViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult ChangeOrderState(ViewModelFood model)
        {
            var order = _context.Order.SingleOrDefault(o => o.OrderId == model.CurrentOrder.OrderId);

            _context.Entry(order).CurrentValues.SetValues(model.CurrentOrder);
            _context.SaveChanges();

            return RedirectToAction("ManageOrders");
        }

        public IActionResult RemoveOrder(int id)
        {
            var foodOrders = _context.FoodOrder.Where(f => f.OrderId == id).ToList();

            foreach(var item in foodOrders)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

            var order = _context.Order.SingleOrDefault(o => o.OrderId == id);

            _context.Remove(order);
            _context.SaveChanges();

            return RedirectToAction("ManageOrders");
        }

        public IActionResult ManageUsers()
        {
            var model = GetViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult ChangeMembership(ViewModelFood model)
        {
            if (model.CurrentUser.isPremium)
            {
                AspNetUserRoles role = new AspNetUserRoles();
                role.RoleId = ("F4F4367D-940C-4FD7-A848-137508F418C1");
                role.UserId = model.CurrentUser.Id;

                _context.AspNetUserRoles.Add(role);
                _context.SaveChanges();
            }
            else
            {
                var role = _context.AspNetUserRoles.SingleOrDefault(r => r.UserId == model.CurrentUser.Id && 
                                                            r.RoleId == "F4F4367D-940C-4FD7-A848-137508F418C1");
                _context.Remove(role);
                _context.SaveChanges();
            }

            return RedirectToAction("ManageUsers");
        }

        public IActionResult ChangeAdmin(ViewModelFood model)
        {
            if (model.CurrentUser.isAdmin)
            {
                AspNetUserRoles role = new AspNetUserRoles();
                role.RoleId = ("1F6CE05B-A599-4985-9AB0-87A5BBAE970A");
                role.UserId = model.CurrentUser.Id;

                _context.AspNetUserRoles.Add(role);
                _context.SaveChanges();
            }
            else
            {
                var role = _context.AspNetUserRoles.SingleOrDefault(r => r.UserId == model.CurrentUser.Id &&
                                                            r.RoleId == "1F6CE05B-A599-4985-9AB0-87A5BBAE970A");
                _context.Remove(role);
                _context.SaveChanges();
            }

            return RedirectToAction("ManageUsers");
        }

        public ViewModelFood GetViewModel()
        {
            ViewModelFood model = new ViewModelFood();
            model.AllFoods = _context.Food.ToList();
            model.AllFoodIngredients = _context.FoodIngredient.ToList();
            model.AllIngredients = _context.Ingredient.ToList();
            model.AllFoodOrders = _context.FoodOrder.ToList();
            model.AllOrders = _context.Order.ToList();
            model.AllUsers = _context.AspNetUsers.ToList();

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

            foreach (var item in model.AllOrders)
            {
                item.Customer = _context.Customer.SingleOrDefault(c => c.CustomerId == item.CustomerId);
            }

            foreach (var item in model.AllUsers)
            {
                var roles = _context.AspNetUserRoles.Where(r => r.UserId == item.Id);

                foreach (var role in roles)
                {
                    var userRole = _context.AspNetRoles.Where(ur => ur.Id == role.RoleId).ToList();

                    foreach (var ur in userRole)
                    {
                        if (ur.NormalizedName == "PREMIUM")
                        {
                            item.isPremium = true;
                        }
                        if (ur.NormalizedName == "ADMINISTRATOR")
                        {
                            item.isAdmin = true;
                        }
                    }
                }

            }

            return model;
        }
    }
}
