using System;
using System.ComponentModel.DataAnnotations;
using PartyJuice.DbEntity.Enums;

namespace PartyJuice.DbEntity
{
    public class PhoneNumber : IdEntity
    {
        [Required]
        [MaxLength(15)]
        public string Number { get; set; }
        public PhoneNumberKind Kind { get; set; }
    }
}