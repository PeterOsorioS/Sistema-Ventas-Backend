using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);
        public int Count(Expression<Func<T, bool>>? filter = null);
        public T GetById(int Id);
        public IEnumerable<T> GetAll(Expression<Func<T,bool>>? filter = null,
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null);

        public IEnumerable<T> GetFirstOrDefault(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null);

        public Task Remove(T Entity);
        public void Save();
        public Task SaveAsync();
    }
}
