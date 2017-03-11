using System;
using System.Collections.Generic;
using PartyJuice.DataAccess;
using PartyJuice.DbEntity;
using PartyJuice.Logic;

namespace PartyJuice.PJService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlcShopService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlcShopService.svc or AlcShopService.svc.cs at the Solution Explorer and start debugging.
    public class PJService : IPJService
    {
        private readonly BaseBusinessLogic<User> _userLogic = new BaseBusinessLogic<User>(); 
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
    }
}
