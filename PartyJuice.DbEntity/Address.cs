using System.ComponentModel.DataAnnotations;
using PartyJuice.DbEntity.Enums;

namespace PartyJuice.DbEntity
{
    public class Address : NameEntity
    {
        [Required]
        public Countries Country { get; set; }
        [Required]
        [MinLength(1),MaxLength(100)]
        public string Town { get; set; }
        [Required]
        [MinLength(1), MaxLength(100)]
        private string Street { get; set; }
        [Required]
        [MinLength(1), MaxLength(20)]
        public string Number { get; set; }
    }
}