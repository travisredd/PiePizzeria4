using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiePizzeria.Data;
using PiePizzeria.Models;
using PiePizzeria.ViewModels;

namespace PiePizzeria.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public int Id { get; set; }
        private PizzaContext _pizzaContext;

        public AdminController(PizzaContext pizzaContext) { _pizzaContext = pizzaContext; }


        [HttpGet]
        public ViewResult AddEditPizza(int id)
        {
            this.Id = id;
            var pizza = _pizzaContext.Pies.FirstOrDefault(a => a.Id == Id);
            if (pizza == null)
                return View(new AddEditPizzaModel(Id) { Title = "Add New Pizza" });
            var newPizza = new Pie
            {
                Id = pizza.Id,
                Name = pizza.Name,
                ShortDescription = pizza.ShortDescription,
                LongDescription = pizza.LongDescription,
                Price = pizza.Price,
                //ImageUrl = pizza.ImageUrl,
                //ImageThumbnailUrl = pizza.ImageThumbnailUrl,
                Image = pizza.Image,
                IsPieOfTheWeek = pizza.IsPieOfTheWeek,
            };
            return View(new AddEditPizzaModel()
            {
                Pie = newPizza,
                Title = "Edit " + newPizza.Name,
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddEditPizza(AddEditPizzaModel newPizzaModel)
        {
            var newPizza = newPizzaModel.Pie;
            if (!ModelState.IsValid)
                return View(newPizzaModel);

            var pizza = _pizzaContext.Pies.FirstOrDefault(a => a.Id == newPizza.Id) ?? new Pie();
            if (pizza == null)
                pizza = new Pie();
            pizza.Name = newPizza.Name;
            pizza.ShortDescription = newPizza.ShortDescription ?? "";
            pizza.LongDescription = newPizza.LongDescription ?? "";
            pizza.Price = newPizza.Price;
            pizza.IsPieOfTheWeek = newPizza.IsPieOfTheWeek;
            //pizza.ImageUrl = newPizza.ImageUrl ?? "";
            //pizza.ImageThumbnailUrl = newPizza.ImageThumbnailUrl ?? "";


            if (newPizzaModel.Image != null)
            {
                pizza.SetImage(newPizzaModel.Image);
            }
            else
            {
                if (Id != 0)
                {
                    var tempPizza = _pizzaContext.Pies.FirstOrDefault(a => a.Id == newPizza.Id);
                    pizza.Image = tempPizza.Image;
                    pizza.ImageContentType = tempPizza.ImageContentType;
                }
            }

            _pizzaContext.Entry(pizza).State = pizza.Id == default(long) ? EntityState.Added : EntityState.Modified;
            await _pizzaContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(AddEditPizzaModel pizzaModel)
        {
            if (pizzaModel.Title == "Add New Pizza")
                return RedirectToAction("Index", "Home");
            _pizzaContext.Pies.Remove(new Pie { Id = pizzaModel.Pie.Id });
            await _pizzaContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}