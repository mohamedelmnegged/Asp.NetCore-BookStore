using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repo
{
    public class AuthorDbRepo : IBooksRepo<Author>
    {
        private readonly BookStoreDBContext _db; 
        public AuthorDbRepo(BookStoreDBContext db)
        {
            _db = db; 
        }
        public void Add(Author t)
        {
            _db.Authors.Add(t);
            _db.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var deleted = Find(id);
            _db.Authors.Remove(deleted);
            _db.SaveChanges(); 
        }

        public Author Find(int id)
        {
            var find = _db.Authors.FirstOrDefault(f => f.Id == id);
            return find;
        }

        public IList<Author> list()
        {
            return _db.Authors.ToList();
        }

        public void Update(int id, Author t)
        {
            _db.Authors.Update(t);
            _db.SaveChanges();
        }

        public IList<Author> Search(string value)
        { 
            if(value == null)
            {
                return list(); 
            }
            var searched = _db.Authors.Where(a => a.Name.Contains(value)).ToList();

            return searched;
        }
    }
}
