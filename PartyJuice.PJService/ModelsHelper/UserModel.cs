using System;
using PartyJuice.DbEntity.Enums;

namespace PartyJuice.PJService.ModelsHelper
{
    public class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Guid Id { get; set; }
    }
}