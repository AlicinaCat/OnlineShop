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

            var cartModel = GetViewModel();

            model.CartList = cartModel.CartList;

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
            cust.Phone = user.Phone;
            cust.City = user.City;
            cust.Username = user.Username;
            cust.Email = user.Email;
            cust.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.Customer.Add(cust);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public IActionResult AddToCart(int id)
        {
            ViewModelFood model = new ViewModelFood();

            Food newFood = new Food();
            newFood = _context.Food.SingleOrDefault(f => f.FoodId == id);

            if (HttpContext.Session.GetString("cart") == null)
            {
                model.CartList = new List<Food>();
            }
            else
            {
                var temp = HttpContext.Session.GetString("cart");
                model.CartList = JsonConvert.DeserializeObject<List<Food>>(temp);
            }

            model.CartList.Add(newFood);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(model.CartList));

            return PartialView("_ShowCart", model);
        }

        public IActionResult RemoveFromCart(int id)
        {
            var model = GetViewModel();

            var temp = HttpContext.Session.GetString("cart");
            model.CartList = JsonConvert.DeserializeObject<List<Food>>(temp);

            Food food = model.CartList.FirstOrDefault(f => f.FoodId == id);

            model.CartList.Remove(food);

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(model.CartList));

            return PartialView("_ShowCart", model);
        }

        public IActionResult ViewProfile()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Customer cust = _context.Customer.SingleOrDefault(c => c.UserId == id);

            var model = GetViewModel();
            model.CurrentCustomer = cust;

            return View(model);
        }

        public IActionResult EditProfile()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Customer cust = _context.Customer.SingleOrDefault(c => c.UserId == id);

            var model = GetViewModel();

            model.RegisterUser = new RegisterUser();

            model.RegisterUser.Name = cust.Name;
            model.RegisterUser.Address = cust.Address;
            model.RegisterUser.PostalCode = cust.PostalCode;
            model.RegisterUser.City = cust.City;
            model.RegisterUser.Username = cust.Username;
            model.RegisterUser.Email = cust.Email;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProfile(ViewModelFood model) 
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Customer cust = new Customer();

            cust.Name = model.RegisterUser.Name;
            cust.Address = model.RegisterUser.Address;
            cust.PostalCode = model.RegisterUser.PostalCode;
            cust.Phone = model.RegisterUser.Phone;
            cust.City = model.RegisterUser.City;
            cust.Username = model.RegisterUser.Username;
            cust.Email = model.RegisterUser.Email;

            var old = _context.Customer.SingleOrDefault(c => c.UserId == id);

            cust.CustomerId = old.CustomerId;
            cust.UserId = old.UserId;

            _context.Entry(old).CurrentValues.SetValues(cust);
            _context.SaveChanges();

            model.CurrentCustomer = cust;

            return View("ViewProfile", model);
        }

        public IActionResult Checkout()
        {
            var model = GetViewModel();

            return View(model);
        }

        public ViewModelFood GetViewModel()
        {
            ViewModelFood model = new ViewModelFood();

            if (HttpContext.Session.GetString("cart") == null)
            {
                model.CartList = new List<Food>();
            }
            else
            {
                var temp = HttpContext.Session.GetString("cart");
                model.CartList = JsonConvert.DeserializeObject<List<Food>>(temp);
            }

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(model.CartList));

            return model;
        }
    }
}
