using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public class SaleOrder : IdEntity
    {
        [Required, MaxLength(20)]
        public string Number { get; set; }
        [Required]
        public User Seller { get; set; }
        [Required]
        public Warehouse Warehouse { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public ICollection<WarehouseElement> Items { get; set; }
        [Required]
        public double TotalCost { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}