using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoSite.DataAccess
{
    public interface IRepository<T>
    {
        IEnumerable<T> SelectAll();
        IEnumerable<T> Select(Expression<Func<T, bool>> filter);
        T Insert(T entity);
        bool Update(T entity);
        bool Delete(object id);
    }
}
