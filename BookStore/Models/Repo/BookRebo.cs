using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repo
{
    public class BookRebo : IBooksRepo<Book>
    {
        List<Book> books; 

        public BookRebo()
        {
            books = new List<Book>() { 
                new  Book()
                { Id = 1, Name ="head First", PublishDay = DateTime.Now, Author =  new Author{Id = 1, Name = "mohamed"}, ImageUrl="/images/photo-1510519138101-570d1dca3d66.jpeg"  },
                new  Book()
                { Id = 2, Name ="clean code", PublishDay = DateTime.Now , Author = new Author{Id = 2, Name = "Ahmed" }, ImageUrl="/images/photo-1531771686035-25f47595c87a.jpeg"  },
                new  Book()
                { Id = 3, Name ="data structure", PublishDay = DateTime.Now,  Author = new Author{Id = 4, Name = "ali" }, ImageUrl="/images/photo-1566599236407-5add5e507acc.jpeg"  },
            };
        }
        public void Add(Book t)
        {
            books.Add(t); 
        }

        public void Delete(int id)
        {
            var delete = Find(id);
            books.Remove(delete);
        }

        public Book Find(int id)
        {
            var find = books.FirstOrDefault(f => f.Id == id);

            return find; 
        }

        public IList<Book> list()
        {
            return books;
        }

        public void Update(int id , Book t)
        {
            var update = Find(id);
            update.Id = t.Id;
            update.Name = t.Name;
            update.Author = t.Author;
            update.PublishDay = t.PublishDay;
            update.ImageUrl = t.ImageUrl;
        }

        public IList<Book> Search(string value)
        {
            var searched = books.Where(a => a.Author.Name.Contains(value) || a.Name.Contains(value)).ToList();

            return searched;
        }
    }
}
