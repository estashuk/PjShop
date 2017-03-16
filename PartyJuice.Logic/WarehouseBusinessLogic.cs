using System;
using PartyJuice.DataAccess;
using PartyJuice.DbEntity;

namespace PartyJuice.Logic
{
    public class WarehouseBusinessLogic : BaseBusinessLogic<Warehouse>
    {
        private readonly WarehouseRepository _warehouseRepository = new WarehouseRepository();

        public override Warehouse GetById(Guid entityId)
        {
            return _warehouseRepository.GetById(entityId);
        }

        public Warehouse GetByName(string name)
        {
            return _warehouseRepository.GetByName(name);
        }
    }
}