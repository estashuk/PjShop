using System;
using System.Data.Entity;
using System.Linq;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class SaleOrderRepository : BaseRepository<SaleOrder>
    {
        public override IQueryable<SaleOrder> GetAll()
        {
            return Context.SaleOrders.Include(x => x.Items);
        }

        public override IQueryable<SaleOrder> GetAllDeleted()
        {
            return Context.SaleOrders.Where(x => x.IsDeleted)
                .Include(x => x.Items);
        }

        public override IQueryable<SaleOrder> GetAllNotDeleted()
        {
            return Context.SaleOrders.Where(x => !x.IsDeleted).
                Include(x => x.Items);
        }

        public override SaleOrder GetById(Guid id)
        {
            return Context.SaleOrders.Include(x => x.Items).FirstOrDefault(x => x.Id == id);
        }
    }
}