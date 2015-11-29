using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Hotel.Database.Model;

namespace Hotel.Database.Common
{
    public interface IRepository<T>
    {
        T Get(long id);
        IQueryable<T> GetRange();
        IQueryable<T> GetRange(Expression<Func<T, bool>> where);
        void Add(T entity);
        void Update(T entity);
        void AddOrUpdate(T entity);
        void Delete(T entity);
        void SaveChanges();
    }

    public class Repository<T> : IRepository<T>
        where T : IdentityBase
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public T Get(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public IQueryable<T> GetRange()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> GetRange(Expression<Func<T, bool>> @where)
        {
            return Context.Set<T>().Where(where);
        }

        public void Add(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void AddOrUpdate(T entity)
        {
            Context.Entry(entity).State = entity.Id == 0
                ? EntityState.Added
                : EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}