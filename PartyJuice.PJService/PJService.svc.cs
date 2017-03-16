using System;
using System.Collections.Generic;
using System.Linq;
using PartyJuice.DataAccess;
using PartyJuice.DbEntity;
using PartyJuice.Logic;
using PartyJuice.PJService.ModelsHelper;

namespace PartyJuice.PJService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlcShopService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlcShopService.svc or AlcShopService.svc.cs at the Solution Explorer and start debugging.
    public class PJService : IPJService
    {
        private readonly BaseBusinessLogic<User> _userLogic = new BaseBusinessLogic<User>();
        private readonly PJShopBusinessLogic _shopLogic = new PJShopBusinessLogic();

        public List<ShopModel> GetShops()
        {
            return _shopLogic.GetAllShops()?.Select(x => new ShopModel
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
        }

        public List<WarehouseModel> GetWarehouses(Guid shopId)
        {
            return _shopLogic.GetAllWarehousesByShopId(shopId)?.Select(x => new WarehouseModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<WarehouseElementModel> GetWarehouseElements(Guid warehouseId)
        {
            //return warehouse != null ? _shopLogic.GetWarehouseElements(warehouse.Id)?.ToList() : null;
            return _shopLogic.GetWarehouseElements(warehouseId)?.Select(x=> new WarehouseElementModel
            {
                Count = x.Count,
                DrinkName = "",
                Id = x.Id
            }).ToList();
        }

        public List<Warehouse> GetWarehouses()
        {
            throw new NotImplementedException();
        }

        public List<Drink> GetDrinksByWarehouseId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClientsWhoHasBirthday(DateTime day)
        {
            throw new NotImplementedException();
        }

        public List<SaleOrder> GetSaleOrdersByWarehouseId(Guid warehouseId, DateTime dateStart)
        {
            throw new NotImplementedException();
        }

        public List<SaleOrder> GetSaleOrdersByClientId(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseInvoice> GetPurchaseInvoicesByWarehouseId(Guid id, DateTime dateStart)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseInvoice> GetPurchaseInvoicesByStoreKeeperId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Client GetClientInfo(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public bool UserValidation(string login, string password)
        {
            var user = _userLogic.Get(x => x.Login == login && x.Password == password);
            return user != null;
        }

        public void AddUser(User newUser)
        {
            _userLogic.Add(newUser);
        }

        public List<UserModel> GetAllUsers()
        {
            return _userLogic.GetAll()?.Select(x => new UserModel
            {
                Login = x.Login,
                Password = x.Password,
                Role = x.Role.ToString(),
                Id = x.Id
            }).ToList();
        }

        public void DeleteUser(Guid id)
        {
            _userLogic.DeleteById(id);
        }

        public User GetUser(string login, string password)
        {
            return _userLogic.Get(x => x.Login == login && x.Password == password);
        }

        public bool UserLoginValidation(string login)
        {
            var user = _userLogic.Get(x => x.Login == login);
            return user != null;
        }

        public WarehouseElementModel GetWarehouseElement(Guid elementId)
        {
            var element = _shopLogic.GetWarehouseElement(elementId);
            return new WarehouseElementModel
            {
                Count = element.Count,
                DrinkName = element.Drink.Name,
                Id = element.Id
            };
        }
    }
}
