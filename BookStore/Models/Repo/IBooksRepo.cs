using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repo
{
    public interface IBooksRepo<T>
    {
        void Add(T t);
        IList<T> list();
        T Find(int id);
        void Delete(int id);
        void Update(int id, T t);
        IList<T> Search(string value); 

    }
}
