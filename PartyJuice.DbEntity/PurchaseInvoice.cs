using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public class PurchaseInvoice : IdEntity
    {
        [Required, MaxLength(20)]
        public string Number { get; set; }
        [Required]
        public User StoreKeeper { get; set; }
        [Required]
        public ICollection<WarehouseElement> Items { get; set; }
        [Required]
        public Warehouse Warehouse { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}