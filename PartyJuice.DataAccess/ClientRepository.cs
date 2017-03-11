using System;
using System.Data.Entity;
using System.Linq;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class ClientRepository : BaseRepository<Client>
    {
        public override IQueryable<Client> GetAll()
        {
            return Context.Clients
                .Include(x => x.ClientsPhoneNumbers);
        }

        public override IQueryable<Client> GetAllDeleted()
        {
            return Context.Clients.Where(x => x.IsDeleted)
                .Include(x => x.ClientsPhoneNumbers);
        }

        public override IQueryable<Client> GetAllNotDeleted()
        {
            return Context.Clients.Where(x => !x.IsDeleted)
                .Include(x => x.ClientsPhoneNumbers);
        }

        public override Client GetById(Guid id)
        {
            return Context.Clients.Include(x => x.ClientsPhoneNumbers)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}