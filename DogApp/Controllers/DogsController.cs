﻿using DogApp.Abstraction;
using DogApp.Data;
using DogApp.Domain;
using DogApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Controllers
{
    public class DogsController : Controller
    {

        private readonly IDogService _dogService;

        public DogsController(IDogService dogsService)
        {
            this._dogService = dogsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        private readonly ApplicationDbContext context;

        public DogsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]

        public IActionResult Create(DogCreateViewModel binbingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _dogService.Create(binbingModel.Name, binbingModel.Age, binbingModel.Breed, binbingModel.Picture);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();

        }

        public IActionResult Success()
        {
            return this.View();
        }

        public IActionResult All(string searchStringBreed, string searchStringName)
        {
            List<DogAllViewModel> dogs = _dogService.GetDogs()
        
          .Select(dogFromDb => new DogAllViewModel
          { 
               Id = dogFromDb.Id,
               Name = dogFromDb.Name,
               Age = dogFromDb.Age,
               Breed = dogFromDb.Breed,
               Picture = dogFromDb.Picture
        }).ToList();
            if (!string.IsNullOrEmpty(searchStringBreed) && !string.IsNullOrEmpty(searchStringName))
            {

                dogs =dogs.Where(d => d.Breed.Contains(searchStringBreed) && d.Name.Contains(searchStringName)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringName))
            {
                dogs =dogs.Where(d => d.Name.Contains(searchStringName)).ToList();
            }
            return this.View(dogs);


        }
    

            public IActionResult Edit(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if(item == null)
            {
                return NotFound();
            }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        [HttpPost]

        public IActionResult Edit(int id, DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _dogService.UpdateDog(id, bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Picture);
                if (updated)
                {
                    return this.RedirectToAction("All");
                }
            }
            return View(bindingModel);
        }

        public IActionResult Delete(int id)
        {
                Dog item = _dogService.GetDogById(id);
                if (item==null)
                {
                    return NotFound();
                }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        [HttpPost]

        public IActionResult Delete(int id, IFormCollection collection)
        {
                var deleted = _dogService.RemoveByid(id);

                if (deleted)
                {
                    return this.RedirectToAction("All ", "Dogs");
                }
                else
                { 
                return View();
                }

        }
        
        public IActionResult Details(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if(item==null)
            {
                return NotFound();
            }
            DogDetailsViewModel dog = new DogDetailsViewModel()
            {
                Id=item.Id,
                Name=item.Name,
                Age=item.Age,
                Breed=item.Breed,
                Picture=item.Picture

            };
            return View(dog);
        }
    }
}
