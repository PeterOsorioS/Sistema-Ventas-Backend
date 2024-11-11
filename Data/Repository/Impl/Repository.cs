using Data.Context;
using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Impl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public int Count(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Count();
        }


        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char [] {','},StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.AsNoTracking().ToList();
        }

        public T GetById(int Id)
        {
            return dbset.Find(Id);
        }

        public IEnumerable<T> GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }

            return query.AsNoTracking().ToList();
        }
        public void Remove(T Entity)
        {
            _context.Remove(Entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
