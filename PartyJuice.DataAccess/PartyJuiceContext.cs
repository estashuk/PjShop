using System.Data.Entity;
using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class PartyJuiceContext : DbContext
    {
        public PartyJuiceContext() : base("PjDbConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkType> DrinkTypes { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PJShop> PjShops { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseElement> WarehouseElements { get; set; }
    }
}
