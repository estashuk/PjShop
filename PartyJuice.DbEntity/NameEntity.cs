using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public abstract class NameEntity : IdEntity
    {
         [Required]
         [MaxLength(300)]
         public string Name { get; set; }
    }
}