using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IEntityRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        T? Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>>? filter = default, params Expression<Func<T, object>>[] including);
    }
}
