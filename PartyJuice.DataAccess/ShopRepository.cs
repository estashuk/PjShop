using System;
using System.Data.Entity;
using System.Linq;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class ShopRepository : BaseRepository<PJShop>
    {
        public override IQueryable<PJShop> GetAll()
        {
            return Context.PjShops.Include(x => x.ShopPhoneNumbers).Include(x => x.Warehouses);
        }

        public override IQueryable<PJShop> GetAllNotDeleted()
        {
            return Context.PjShops.Where(x => !x.IsDeleted).Include(x => x.ShopPhoneNumbers).Include(x => x.Warehouses);
        }

        public override IQueryable<PJShop> GetAllDeleted()
        {
            return Context.PjShops.Where(x => x.IsDeleted).Include(x => x.ShopPhoneNumbers).Include(x => x.Warehouses);
        }

        public override PJShop GetById(Guid id)
        {
            return Context.PjShops.Include(x => x.ShopPhoneNumbers).Include(x => x.Warehouses).FirstOrDefault(x => x.Id == id);
        }
    }
}