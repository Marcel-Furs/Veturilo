using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Veturilo.Infrastructure.Entities;

namespace Veturilo.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : IEntity
    {
        public T? Get(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
        public T? Find(Expression<Func<T, bool>> predicate);

        public T Add(T entity);
        public T Delete(int id);
        public T? Update(T entity);
    }
}
