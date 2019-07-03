using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PiePizzeria.Models;

namespace PiePizzeria.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PizzaContext context)
        {
            if (context.Pies.Any()) return;


            var pies = new List<Pie>
            {
                new Pie
                {
                    Name = "Holy Shiitake Pie",
                    Price = 12.95M,
                    ShortDescription = "Our famous thin pie!",
                    LongDescription = "Extra thin crust with a Basil Pesto Sauce, Oven Roasted Chicken Breast, Fresh Shiitake and Champignon Mushrooms, Sicilian Spiced Tomatoes, Whole Roasted Garlic Cloves, Mozzarella Cheese and finished with a light drizzle of Truffle Oil..",
                    //ImageUrl = "https://www.thepie.com/media/k2/items/src/af2ef6a0e2c9c528b09655df79f3b312.jpg",
                    //ImageThumbnailUrl = "https://www.thepie.com/media/mod_zentools2/cache/images/af2ef6a0e2c9c528b09655df79f3b312-392357c340a4c1a1ed379de7343faaa8.jpg",
                    IsPieOfTheWeek = true,
                },
                new Pie
                {
                    Name = "The Wise Guy Pie",
                    Price = 16.95M,
                    ShortDescription = "Say Hello to my Little Friend!",
                    LongDescription = "The Pie's hand tossed dough layered with a creamy mixture of whipped Cream Cheese, Fresh Spinach leaves, Artichoke Hearts, Chicken Breast, Mozzarella Cheese and a touch of tangy Marinara - Baked and topped with diced Tomatoes, fresh-cut Basil and a drizzle of sweet Balsamic reduction.",
                    //ImageUrl = "https://www.thepie.com/media/k2/items/src/feb4274796d93ff716e9650163a77fb8.jpg",
                    //ImageThumbnailUrl = "https://www.thepie.com/media/mod_zentools2/cache/images/feb4274796d93ff716e9650163a77fb8-f28d2aba6e59d34c16c21845a4841c6e.jpg",
                    IsPieOfTheWeek = false,
                },
                new Pie
                {
                    Name = "Chicken Ranch", Price = 18.95M,
                    ShortDescription = "Don't be a Chicken!",
                    LongDescription = "Our special Garlic Ranch Sauce topped with seasoned oven roasted Chicken Breast, Crisp Bacon, Tomatoes, Onions, Sharp Cheddar, and Mozzarella Cheese.",
                    //ImageUrl = "https://www.thepie.com/media/k2/items/src/01f1a05053c6242fcfa23075e5b963c1.jpg",
                    //ImageThumbnailUrl = "https://www.thepie.com/media/mod_zentools2/cache/images/01f1a05053c6242fcfa23075e5b963c1-0de77d9bfa9e0b604627f6fcb9289248.jpg",
                    IsPieOfTheWeek = false,
                },
                new Pie
                {
                    Name = "Thai Pie",
                    Price = 15.95M,
                    ShortDescription = "An Asian classic!",
                    LongDescription = "Looking for something different to eat? A perfect blend of spicy Thai peanut sauce, chicken breast, carrots, red onions, pineapple, fresh basil and chopped cilantro on a thin crust topped with light mozzarella and toasted sesame seeds. You won't regret it...",
                    //ImageUrl = "https://www.thepie.com/media/k2/items/src/867519228d1d5325856fc61d710ded0e.jpg",
                    //ImageThumbnailUrl = "https://www.thepie.com/media/mod_zentools2/cache/images/867519228d1d5325856fc61d710ded0e-cbf6ecc99344c8bc007358fff148ba72.jpg",
                    IsPieOfTheWeek = false,
                },
            };

            foreach (Pie pie in pies)
                context.Pies.Add(pie);

            context.SaveChanges();
        }
    }
}
