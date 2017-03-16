using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class WarehouseElementRepository : BaseRepository<WarehouseElement>
    {

        public override IQueryable<WarehouseElement> GetAll()
        {
            return base.GetAll();
        }

        public override WarehouseElement GetById(Guid id)
        {
            return Context.WarehouseElements.FirstOrDefault(x=>x.Id == id);
        }
    }
}