using System.Collections.Generic;

namespace PartyJuice.DbEntity
{
    public class Warehouse : NameEntity
    {
         public ICollection<WarehouseElement> DrinkElements { get; set; } 
    }
}