using System;
using System.Collections.Generic;
using System.ServiceModel;
using PartyJuice.DbEntity;

namespace PartyJuice.PJService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPJService
    {
        [OperationContract]
        List<PJShop> GetShops();
        [OperationContract]
        List<Warehouse> GetWarehouses();
        [OperationContract]
        List<Drink> GetDrinksByWarehouseId(Guid id);
        [OperationContract]
        List<Client> GetClients();
        [OperationContract]
        List<Client> GetClientsWhoHasBirthday(DateTime day);
        [OperationContract]
        List<SaleOrder> GetSaleOrdersByWarehouseId(Guid warehouseId, DateTime dateStart);
        [OperationContract]
        List<SaleOrder> GetSaleOrdersByClientId(Guid clientId);
        [OperationContract]
        List<PurchaseInvoice> GetPurchaseInvoicesByWarehouseId(Guid id, DateTime dateStart);
        [OperationContract]
        List<PurchaseInvoice> GetPurchaseInvoicesByStoreKeeperId(Guid id);
        [OperationContract]
        Client GetClientInfo(Guid clientId);

        [OperationContract]
        bool UserValidation(string login, string password);

    }
}
