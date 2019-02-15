using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Models;
using Online_Shop.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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

        public IActionResult RegisterCustomer(RegisterUser user)
        {
            Customer cust = new Customer();

            cust.Name = user.Name;
            cust.Address = user.Address;
            cust.PostalCode = user.PostalCode;
            cust.City = user.City;
            cust.Username = user.Username;
            cust.Email = user.Email;
            cust.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.Customer.Add(cust);
            _context.SaveChanges();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult AddToCart(int id)
        {
            List<Food> cartList;

            Food newFood = new Food();
            newFood = _context.Food.SingleOrDefault(f => f.FoodId == id);

            if (HttpContext.Session.GetString("cart") == null)
            {
                cartList = new List<Food>();
            }
            else
            {
                var temp = HttpContext.Session.GetString("cart");
                cartList = JsonConvert.DeserializeObject<List<Food>>(temp);
            }

            cartList.Add(newFood);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartList));

            return PartialView("_ShowCart", cartList);
        }

        public IActionResult RemoveFromCart(int id)
        {
            List<Food> cartList;

            var temp = HttpContext.Session.GetString("cart");
            cartList = JsonConvert.DeserializeObject<List<Food>>(temp);

            Food food = cartList.FirstOrDefault(f => f.FoodId == id);

            cartList.Remove(food);

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartList));

            return PartialView("_ShowCart", cartList);
        }
    }
}
