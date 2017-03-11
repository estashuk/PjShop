using System;
using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public class Price : IdEntity
    {
        [Required]
        public double DrinkPrice { get; set; } 
    }
}