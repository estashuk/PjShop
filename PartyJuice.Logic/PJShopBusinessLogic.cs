using System.Collections.Generic;
using System.Linq;
using PartyJuice.DataAccess;
using PartyJuice.DbEntity;

namespace PartyJuice.Logic
{
    public class PJShopBusinessLogic : BaseBusinessLogic<PJShop>
    {
        private readonly ShopRepository _repository = new ShopRepository();
        private readonly WarehouseBusinessLogic _warehouseBusinessLogic = new WarehouseBusinessLogic();

        public IQueryable<PJShop> GetAllShops()
        {
            return _repository.GetAll();
        }

        public IEnumerable<WarehouseElement> GetWarehouseElements(Warehouse warehouse)
        {
            var warehouseElements = _warehouseBusinessLogic.GetById(warehouse.Id);
            return warehouseElements?.DrinkElements;
        }
    }
}