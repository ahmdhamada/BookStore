using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCore.Models;
using BookCore.Models.Repostories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookstoreRepostory<Auther> authorrepo;
        // GET: AuthorController

        public AuthorController(IBookstoreRepostory<Auther> authorrepo)
        {
            this.authorrepo = authorrepo;
        }
        public ActionResult Index()
        {
            var authers = authorrepo.List();
            return View(authers);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var authers = authorrepo.Find(id);
            return View(authers);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auther aut)
        {
            try
            {
                authorrepo.Add(aut);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var authers = authorrepo.Find(id);
            return View(authers);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Auther aut)
        {
            try
            {
                authorrepo.Update(id, aut);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var authers = authorrepo.Find(id);
            return View(authers);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Auther aut)
        {
            try
            {
                authorrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
