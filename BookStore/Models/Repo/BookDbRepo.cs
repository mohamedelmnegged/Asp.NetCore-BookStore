using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repo
{
    public class BookDbRepo : IBooksRepo<Book>
    {
        private readonly BookStoreDBContext _db;
        public BookDbRepo(BookStoreDBContext db)
        {
            _db = db;
        }
        public void Add(Book t)
        {
            _db.Books.Add(t);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleted = Find(id);
            _db.Books.Remove(deleted);
            _db.SaveChanges();
        }

        public Book Find(int id)
        {
            var find = _db.Books.Include(a => a.Author).FirstOrDefault(f => f.Id == id);
            return find;
        }

        public IList<Book> list()
        {
            return _db.Books.Include(a => a.Author).ToList();
        }

        public void Update(int id, Book t)
        {
            _db.Books.Update(t);
            _db.SaveChanges();
        }

        public IList<Book> Search(string value)
        {
            var searched = _db.Books.Include(a => a.Author).Where(a => a.Author.Name.Contains(value) || a.Name.Contains(value)   ).ToList();

            return searched; 
        }
    }
}
