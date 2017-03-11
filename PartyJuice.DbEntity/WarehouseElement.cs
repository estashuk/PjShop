using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public class WarehouseElement : IdEntity
    {
        [Required]
        public Drink Drink { get; set; }
        [Required]
        public int Count { get; set; }
    }
}