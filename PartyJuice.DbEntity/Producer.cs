using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public class Producer : NameEntity
    {
        [Required]
        public Address Address { get; set; }

        public ICollection<PhoneNumber>  PhoneNumber { get; set; }
    }
}