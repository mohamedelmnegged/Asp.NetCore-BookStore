using BookStore.Models;
using BookStore.Models.Repo;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksRepo<Book> _book ;
        private  IBooksRepo<Author> _authors;
        private readonly IHostingEnvironment _hosting; 

        public BookController(IBooksRepo<Book> book, IBooksRepo<Author> authors, IHostingEnvironment hosting)
        {
            _book = book;
            _authors = authors;
            _hosting = hosting; 
        }
        // GET: BookController
        public ActionResult  Index()
        {
            var books = _book.list(); 

            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = _book.Find(id); 
            
            return View(book);
        }

        //return model with  id for creating new one 
        public AuthBookViewModel getModelWithId()
        {
            var model = new AuthBookViewModel
            {
               // Id = _book.list().Max(f => f.Id) + 1 == null ? 1 : _book.list().Max(f => f.Id) + 1,
                Authors = FillAuthor(), // get all users to show them in select box 
            };

            return model; 

        }
        // GET: BookController/Create
        public ActionResult Create()
        {
            return View(getModelWithId());
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {   if(model.File == null)
                    {
                        ViewBag.Message = "please Upload Image for the book";
                        return View(getModelWithId());
                    }
                    if (model.AuthorId == -1)
                    {
                        ViewBag.Message = "please Select Author";
                        return View(getModelWithId());
                    }
                    var author = _authors.Find(model.AuthorId);
                    var book = new Book { Id = model.Id, Name = model.Name, PublishDay = model.PublishDay,
                            Author = author, ImageUrl = "/images/" + UploadImage(model) };
                    _book.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(getModelWithId());
                }
            }
            
           
            return View(getModelWithId()); 
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = _book.Find(id);
            if (book == null)
                return RedirectToAction(nameof(Index));
            int authorid = book.Author == null ? -1 : book.Author.Id;
            var model = new AuthBookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                PublishDay = book.PublishDay,
                ImageUrl =  book.ImageUrl,
                AuthorId = authorid ,
                Authors = FillAuthor(),
            }; 
            return View(model); 
            
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit( int id, AuthBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                { 
                    if (model.AuthorId == -1)
                    {
                        ViewBag.Message = "Please Select author";
                        return View(getModelWithId());
                    }
                    var author = _authors.Find(model.AuthorId);
                    //if the user didn't edit the image then get the old and add it 
                    string ImageUrl = string.Empty;
                    if (model.File != null)
                    {
                        //delete the old one and upload the new 
                        DeleteImage(model.ImageUrl);
                        ImageUrl = "/images/" + UploadImage(model);
                       
                    }
                    else
                        ImageUrl = model.ImageUrl; 

                    var book = new Book { Id= model.Id, Name = model.Name,
                        PublishDay = model.PublishDay, Author = author,  ImageUrl = ImageUrl };

                    
                    _book.Update(id, book);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(getModelWithId());
                }
            }

            ModelState.AddModelError("", "Please Follow Instruction in all fileds");
            return View(getModelWithId()); 
            
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = _book.Find(id);
            
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book model)
        {
            try
            {
                //delete book with its images 
                _book.Delete(id);
                DeleteImage(model.ImageUrl);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        } 
        public List<Author> FillAuthor()
        {
            var author = _authors.list().ToList();
            author.Insert(0, new Author { Id = -1, Name = " --- Please Choose the Author ---" });

            return author; 
        } 

        public  string UploadImage(AuthBookViewModel model)
        {
            string fileName = string.Empty;
            //chekc if the image uploaded first
            if (model.File != null)
            {
                string uploads = Path.Combine(_hosting.WebRootPath, "images"); //  get the path to put image 
                fileName = model.File.FileName; // get the name of the image 
                string fullpath = Path.Combine(uploads, fileName); // make the full path for the image  
               // get the image from its fill to our project file 
                using(var stream = new FileStream(fullpath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }
            }

            return fileName; 
        } 

        //delete an image from the dir 
        public void DeleteImage(string ImageName)
        {
            string path = _hosting.WebRootPath + ImageName;
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            
        
        } 

        
        //search for books and return it to index page 
        public ActionResult Search(string value)
        {   

            var searched = _book.Search(value);
            return PartialView("_addBook", searched); 
//            return View("Index", searched); 
        }
    }
}
