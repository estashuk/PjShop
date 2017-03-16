using System;
using System.Data.Entity;
using System.Linq;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class WarehouseRepository : BaseRepository<Warehouse>
    {
        public override IQueryable<Warehouse> GetAll()
        {
            return Context.Warehouses.Include(x => x.DrinkElements);
        }

        public override IQueryable<Warehouse> GetAllNotDeleted()
        {
            return Context.Warehouses.Where(x => !x.IsDeleted)
                .Include(x => x.DrinkElements);
        }

        public override IQueryable<Warehouse> GetAllDeleted()
        {
            return Context.Warehouses.Where(x => x.IsDeleted)
                .Include(x => x.DrinkElements);
        }

        public override Warehouse GetById(Guid id)
        {
            return Context.Warehouses.Include(x => x.DrinkElements)
                .FirstOrDefault(x => x.Id == id);
        }

        public Warehouse GetByName(string name)
        {
            return Context.Warehouses.Include(x => x.DrinkElements)
                .FirstOrDefault(x => x.Name == name);
        }
    }
}