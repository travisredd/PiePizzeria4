using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PiePizzeria.Data;
using PiePizzeria.Models;
using PiePizzeria.ViewModels;

namespace PiePizzeria.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        // private readonly IPieRepository _pieRepository;
        private readonly PizzaContext _pizzaContext;

        public HomeController(PizzaContext pizzaContext)
        {
            _pizzaContext = pizzaContext;
        }

        public ActionResult Index()
        {
            var pies = _pizzaContext.Pies.OrderBy(a => a.Name);

            var homeViewModel = new HomeViewModel()
            {
                Pies = pies.ToList(),
                Title = "Welcome to the Pie Pizzeria!"
            };

            return View(homeViewModel);
        }

        public ActionResult AddEditPizza(int Id)
        {
            return this.RedirectToAction("AddEditPizza", "Admin", new { id = Id });
        }
    }
}