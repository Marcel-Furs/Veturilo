using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Veturilo.Infrastructure.Entities;

namespace Veturilo.Infrastructure.Repositories
{
    public class BaseListRepository<T> : IBaseRepository<T> where T : IEntity
    {
        private readonly List<T> list;
        private int counter;

        public BaseListRepository()
        {
            list = new List<T>();
            counter = 0;
        }

        public T Add(T entity)
        {
            entity.Id = ++counter;
            list.Add(entity);
            return entity;
        }

        public T Delete(int id)
        {
            var entity = Get(id);
            list.Remove(entity);
            return entity;
        }

        public T? Find(Expression<Func<T, bool>> predicate)
        {
            return list.FirstOrDefault(predicate.Compile());
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return list.Where(predicate.Compile()).AsEnumerable();
        }

        public T? Get(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return list.AsEnumerable();
        }

        public T? Update(T entity)
        {
            var listObj = Get(entity.Id);
            if(listObj == null)
            {
                return default;
            }
            list.Remove(listObj);
            list.Add(entity);
            return entity;
        }
    }
}
