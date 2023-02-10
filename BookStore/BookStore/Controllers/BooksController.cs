using BookStore.Data;
using BookStore.Domain;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }

        private readonly ApplicationDbContext context;

        public BooksController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]

        public IActionResult Create(BookCreateViewModel binbingModel)
        {
            if(ModelState.IsValid)
            {
                Book bookFromDb = new Book
                {
                    BookName = binbingModel.BookName,
                    Author = binbingModel.Author,
                    Genre=binbingModel.Genre,
                    Picture=binbingModel.Picture,
                    YearOfPublication=binbingModel.YearOfPublication,
                    Price=binbingModel.Price,

                };
                context.Books.Add(bookFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }

        public IActionResult All(string searchStringBreed)
        {
            List<BookAllViewModel> dogs = context.Books
                .Select(bookFromDb => new BookAllViewModel
                {
                    Id = bookFromDb.Id,
                    BookName = bookFromDb.BookName,
                    Author = bookFromDb.Author,
                    Genre = bookFromDb.Genre,
                    Picture = bookFromDb.Picture,
                    YearOfPublication = bookFromDb.YearOfPublication,
                    Price = bookFromDb.Price
                }
                ).ToList();
            
            return View(dogs);



        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book item = context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            BookCreateViewModel book = new BookCreateViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication=item.YearOfPublication,
                Price=item.Price
            };
            return View(book);
        }

        [HttpPost]

        public IActionResult Edit(BookCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book
                {
                    Id = bindingModel.Id,
                    BookName = bindingModel.BookName,
                    Author = bindingModel.Author,
                    Genre= bindingModel.Genre,
                    Picture = bindingModel.Picture,
                    YearOfPublication=bindingModel.YearOfPublication,
                    Price=bindingModel.Price
                };

                context.Books.Update(book);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }

            return View(bindingModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book item = context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            BookCreateViewModel book = new BookCreateViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication=item.YearOfPublication,
                Price=item.Price
            };
            return View(book);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            Book item = context.Books.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            context.Books.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Books");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book item = context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            BookDetailsViewModel book = new BookDetailsViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication=item.YearOfPublication,
                Price=item.Price

            };
            return View(book);
        }

    }
}
