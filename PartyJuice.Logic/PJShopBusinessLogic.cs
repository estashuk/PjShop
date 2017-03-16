using System;
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
        private readonly WarehouseElementRepository _whelRepository = new WarehouseElementRepository(); 

        public IQueryable<PJShop> GetAllShops()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Warehouse> GetAllWarehousesByShopId(Guid shopId)
        {
            var shop = _repository.GetById(shopId);
            return shop.Warehouses;
        } 

        public IEnumerable<WarehouseElement> GetWarehouseElements(Guid warehouseId)
        {
            var warehouseElements = _warehouseBusinessLogic.GetById(warehouseId)?.DrinkElements;
            return warehouseElements;
        }

        public IEnumerable<WarehouseElement> GetWarehouseElements(string name)
        {
            var warehouseElements = _warehouseBusinessLogic.GetByName(name);
            return warehouseElements?.DrinkElements;
        }

        public WarehouseElement GetWarehouseElement(Guid id)
        {
            return _whelRepository.GetById(id);
        }
    }
}