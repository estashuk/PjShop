using System;
using System.Data.Entity;
using System.Linq;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class UserRepository : BaseRepository<User>
    {
        public override IQueryable<User> GetAll()
        {
            return Context.Users;
        }

        public override IQueryable<User> GetAllDeleted()
        {
            return Context.Users.Where(x => x.IsDeleted);
        }

        public override IQueryable<User> GetAllNotDeleted()
        {
            return Context.Users.Where(x => !x.IsDeleted);
        }

        public override User GetById(Guid id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}