using System;
using System.ComponentModel.DataAnnotations;

namespace PartyJuice.DbEntity
{
    public abstract class IdEntity
    {
        [Key]
        public Guid Id { get; protected set; }

        protected IdEntity()
        {
            Id = Guid.NewGuid();
        }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
