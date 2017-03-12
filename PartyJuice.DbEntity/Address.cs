using System.ComponentModel.DataAnnotations;
using PartyJuice.DbEntity.Enums;

namespace PartyJuice.DbEntity
{
    public class Address : IdEntity
    {
        [Required]
        public Countries Country { get; set; }
        [Required]
        [MaxLength(100)]
        public string Town { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength(20)]
        public string Number { get; set; }
    }
}