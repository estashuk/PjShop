using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public class DiscountCard : IdEntity
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public int Discount { get; set; }
    }
}