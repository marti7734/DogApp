using DogApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp
{
    public class Dogs_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ApplicationDbContext context;

        public Dogs_Controller(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
