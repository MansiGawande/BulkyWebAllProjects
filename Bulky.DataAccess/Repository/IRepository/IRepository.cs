
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; //Expression
using System.Text;
using System.Threading.Tasks;

// Generic interface repository

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository <T>  where T : class // generic class
    {
        //T-Model for crud ? filter is off not req all time
        IEnumerable<T> GetAll (Expression<Func<T, bool>>? filter=null, string? includeProperties = null);
        T Get(Expression<Func<T,bool>> filter, string? includeProperties = null,bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
    