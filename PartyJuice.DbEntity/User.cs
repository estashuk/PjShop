using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PartyJuice.DbEntity.Enums;

namespace PartyJuice.DbEntity
{
    public class User : IdEntity
    {
        [Required]
        [MinLength(4), MaxLength(20)]
        [Index(IsUnique = true)]
        public string Login { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string Password { get; set; }
        [Required]
        public Roles Role { get; set; }
    }
}