using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCore.Models;
using BookCore.Models.Repostories;
using BookCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;


namespace BookCore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookstoreRepostory<Book> bokrepo;
        private readonly IBookstoreRepostory<Auther> authrep;
        private readonly IWebHostEnvironment hosting;

        // GET: BookController

        public BookController(IBookstoreRepostory<Book> bokrepo, IBookstoreRepostory<Auther> authrep, IWebHostEnvironment hosting)
        {

            this.bokrepo = bokrepo;
            this.authrep = authrep;
            this.hosting = hosting;
        }
        public ActionResult Index()
        {
            var books = bokrepo.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bokrepo.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                Authors = Fillselectlist()
            };

            return View(model);

        }


        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {
            
                try
                {
                    string FileName = string.Empty;
                    if (model.File != null)
                    {

                        string uploads = Path.Combine(hosting.WebRootPath, "uploads");
                    FileName = model.File.FileName;
                    string fullpath = Path.Combine(uploads, FileName);
                    model.File.CopyTo(new FileStream(fullpath, FileMode.Create));
                }
                    if (model.AutherId == -1)
                    {
                        ViewBag.message = " please select author from list";
                        var vmodel = new BookAuthorViewModel
                        {
                            Authors = Fillselectlist()
                        };
                        return View(vmodel);
                    }
                    var author = authrep.Find(model.AutherId);
                    Book book = new Book
                    {
                        Id = model.BookId,
                        Title = model.Title,
                        Description = model.Descr,
                        Auther = author,
                        ImageUrl = FileName
                    };
                    bokrepo.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                
                catch
            {
                return View();
            }
        } 
        
        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bokrepo.Find(id);
            var autherId = book.Auther == null ? book.Auther.Id = 0 : book.Auther.Id;
           var viewmodel = new BookAuthorViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Descr = book.Description,
                AutherId = autherId,
                Authors = authrep.List().ToList()
            };
            return View(viewmodel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel model)
        {
            try
            {
                var author = authrep.Find(model.AutherId);
                Book book = new Book
                {
                 
                    Title = model.Title,
                    Description = model.Descr,
                    Auther = author
                };
                bokrepo.Update(model.BookId,book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bokrepo.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                bokrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<Auther> Fillselectlist()
        {
            var authors = authrep.List().ToList();
            authors.Insert(0, new Auther { Id = -1, FullName = "please select an author" });
            return authors;
        }
    }
}
