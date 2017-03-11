using System;
using System.Data.Entity;
using System.Linq;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class ProducerRepository : BaseRepository<Producer>
    {
        public override IQueryable<Producer> GetAll()
        {
            return Context.Producers.Include(x => x.PhoneNumber);
        }

        public override IQueryable<Producer> GetAllNotDeleted()
        {
            return Context.Producers.Where(x => !x.IsDeleted)
                .Include(x => x.PhoneNumber);
        }

        public override IQueryable<Producer> GetAllDeleted()
        {
            return Context.Producers.Where(x => x.IsDeleted)
                .Include(x => x.PhoneNumber);
        }

        public override Producer GetById(Guid id)
        {
            return Context.Producers.Include(x => x.PhoneNumber).FirstOrDefault(x => x.Id == id);
        }
    }
}