using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PartyJuice.DbEntity.Enums;

namespace PartyJuice.DbEntity
{
    public class Client : IdEntity
    {
        [Required]
        public Sex Sex { get; set; }
        [Required]
        [MinLength(1),MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1), MaxLength(100)]
        public string LastName { get; set; }
        [MinLength(1), MaxLength(100)]
        public string FatherName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public ICollection<PhoneNumber> ClientsPhoneNumbers { get; set; } 
        public DiscountCard Card { get; set; }
    }
}