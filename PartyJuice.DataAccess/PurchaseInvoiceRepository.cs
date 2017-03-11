using System;
using System.Data.Entity;
using System.Linq;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class PurchaseInvoiceRepository : BaseRepository<PurchaseInvoice>
    {
        public override IQueryable<PurchaseInvoice> GetAll()
        {
            return Context.PurchaseInvoices.Include(x => x.Items);
        }

        public override IQueryable<PurchaseInvoice> GetAllNotDeleted()
        {
            return Context.PurchaseInvoices.Where(x => !x.IsDeleted)
                .Include(x => x.Items);
        }

        public override IQueryable<PurchaseInvoice> GetAllDeleted()
        {
            return Context.PurchaseInvoices.Where(x => x.IsDeleted)
                .Include(x => x.Items);
        }

        public override PurchaseInvoice GetById(Guid id)
        {
            return Context.PurchaseInvoices.Include(x => x.Items).FirstOrDefault(x => x.Id == id);
        }
    }
}