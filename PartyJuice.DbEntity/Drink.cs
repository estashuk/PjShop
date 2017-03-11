using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public class Drink : NameEntity
    {
        [Required]
        public DrinkType DrinkType { get; set; }
        [Required]
        public Producer Producer { get; set; }
        [Required]
        public double Volume { get; set; }
        [Required]
        public Price Price { get; set; }
    }
}