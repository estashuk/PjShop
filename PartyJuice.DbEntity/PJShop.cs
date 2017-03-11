using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public class PJShop : IdEntity
    {
        [Required]
        public ICollection<Warehouse> Warehouses { get; set; }

        [Required]
        public Address ShopAddress { get; set; }

        [Required]
        public ICollection<PhoneNumber> ShopPhoneNumbers { get; set; } 
    }
}