using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class BaseRepository<T> where T : IdEntity
    {
        protected readonly PartyJuiceContext Context;

        public BaseRepository()
        {
            Context = new PartyJuiceContext();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }
        public virtual IQueryable<T> GetAllNotDeleted()
        {
            return Context.Set<T>().Where(x => !x.IsDeleted);
        }

        public virtual IQueryable<T> GetAllDeleted()
        {
            return Context.Set<T>().Where(x => x.IsDeleted);
        } 
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }
        public void DeleteById(Guid id)
        {
            var entity = Context.Set<T>().Find(id);
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void MarkAsDeleted(Guid id)
        {
            T entity = Context.Set<T>().Find(id);
            entity.IsDeleted = true;
            Update(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        } 
    }
}