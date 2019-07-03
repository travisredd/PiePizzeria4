using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiePizzeria.Models;

namespace PiePizzeria.ViewModels
{
    public class AddEditPizzaModel
    {
        public Pie Pie { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public string Title { get; set; }

        //public int Id { get; set; }
        //[Required(ErrorMessage = "The Name must be specified")]
        //[StringLength(25, ErrorMessage = "Name must be between 5 and 25 characters", MinimumLength = 5)]
        //public string Name { get; set; }
        //[StringLength(50, ErrorMessage = "Short Description cannot be more than 50 characters")]
        //public string ShortDescription { get; set; }
        //[StringLength(1000, ErrorMessage = "Long Description cannot be more than 1000 characters")]
        //public string LongDescription { get; set; }
        //[Required(ErrorMessage = "The Price must be specified")]
        //public decimal Price { get; set; }
        ////public string ImageUrl { get; set; }
        ////public string ImageThumbnailUrl { get; set; }
        //public bool IsPieOfTheWeek { get; set; }

        public AddEditPizzaModel()
        {

        }

        public AddEditPizzaModel(int id)
        {
            Pie = new Pie { Id = id };
        }
    }
}
