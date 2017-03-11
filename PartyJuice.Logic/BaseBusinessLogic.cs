using System;
using System.Linq;
using System.Linq.Expressions;
using PartyJuice.DataAccess;
using PartyJuice.DbEntity;

namespace PartyJuice.Logic
{
    public class BaseBusinessLogic<T>  where T : IdEntity
    {
        protected readonly BaseRepository<T> Repository; 

        public BaseBusinessLogic()
        {
            Repository = new BaseRepository<T>();
        }

        public virtual T GetById(Guid entityId)
        {
            return  Repository.GetById(entityId);
        }

        public void Add(T entityObj)
        {
            Repository.Add(entityObj);
        }

        public void Delete(T entityobj)
        {
            Repository.Delete(entityobj);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual IQueryable<T> GetAllNotDeleted()
        {
            return Repository.GetAllNotDeleted();
        }

        public virtual IQueryable<T> GetAllDeleted()
        {
            return Repository.GetAllDeleted();
        }

        public void DeleteById(Guid id)
        {
            Repository.DeleteById(id);
        }

        public void Update(T entityObj)
        {
            Repository.Update(entityObj);
        }

        public void MarkAsDeleted(Guid id)
        {
            Repository.MarkAsDeleted(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return Repository.Get(expression).FirstOrDefault();
        } 
    }
}
