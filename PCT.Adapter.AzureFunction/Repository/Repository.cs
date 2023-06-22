using PCT.Adapter.AzureFunction.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace PCT.Adapter.AzureFunction.Repository
{
    public class Repository<T> where T : Entity
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> DbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            DbSet = _dataContext.Set<T>();
        }

        public T Create(T entity)
        {
            DbSet.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
            return entity;
        }

        public T GetById(Guid id)
        {
            return DbSet.SingleOrDefault(x => x.Id == id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataContext.Dispose();
            }
        }
    }
}
