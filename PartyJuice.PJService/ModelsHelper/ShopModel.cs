using System;

namespace PartyJuice.PJService.ModelsHelper
{
    public class ShopModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}