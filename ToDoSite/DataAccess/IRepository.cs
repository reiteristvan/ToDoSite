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
        IEnumerable<T> SelectAll ();
        IEnumerable<T> Select ( Expression<Func<T , bool>> filter );
        void Insert ( T entity );
        void Update ( T entity );
        void Delete ( object id );
    }
}
