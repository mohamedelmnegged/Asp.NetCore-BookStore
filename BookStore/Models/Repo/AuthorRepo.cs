using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repo
{
    public class AuthorRepo : IBooksRepo<Author>
    {
        List<Author> authors; 

        public AuthorRepo()
        {
            authors = new List<Author>() {
               new Author(){ Id= 1, Name="mohamed"}, 
               new Author(){ Id= 2, Name="Ahmed"}, 
               new Author(){ Id= 3, Name="Mona"}, 
               new Author(){ Id= 4, Name="ali"}, 
            };
        }
        public void Add(Author t)
        {
            authors.Add(t); 
        }

        public void Delete(int id)
        {
            var deleted = Find(id);
            authors.Remove(deleted); 
        }

        public Author Find(int id)
        {
            var find = authors.FirstOrDefault(f => f.Id == id);
            return find; 
        }

        public IList<Author> list()
        {
            return authors;
        }

        public void Update(int id, Author t)
        {
            var update = Find(id);

            update.Id = t.Id;
            update.Name = t.Name;
        }

        public IList<Author> Search(string value)
        {
            var searched = authors.Where(a => a.Name.Contains(value)).ToList();

            return searched;
        }
    }
}
