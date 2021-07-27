using BookStore.Models;
using BookStore.Models.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBooksRepo<Author> _author; 
        public AuthorController(IBooksRepo<Author> author)
        {
            _author = author;   

        }
        // GET: AuthorController
        public ActionResult Index()
        {
            var author =  _author.list(); 
            return View(author);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var data = _author.Find(id);

            return  View(data);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        //return author model with id for creating 
        public Author getAuthorWithId()
        {
            var author = new Author
            {
                Id = _author.list().Max(f => f.Id) + 1 == null? 1 : _author.list().Max(f => f.Id) + 1,
            };
            //author.Id = _author.list().Max(f => f.Id) + 1;

            return author; 

        }
        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _author.Add(author);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(author);
                }
            }


            ModelState.AddModelError("", "You should Filled all the required filleds");
            return View("Create", author); 
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = _author.Find(id);
            return View(author);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _author.Update(id, author);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(author);
                }
            }
            ModelState.AddModelError("", "please follow the instruction for all fields ");
            return View(author);
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = _author.Find(id); 
            return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author )
        {
            try
            {

                _author.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(author);
            }
          
        }
    }
}
