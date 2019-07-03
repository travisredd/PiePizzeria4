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

        public AddEditPizzaModel()
        {

        }

        public AddEditPizzaModel(int id)
        {
            Pie = new Pie { Id = id };
        }
    }
}
