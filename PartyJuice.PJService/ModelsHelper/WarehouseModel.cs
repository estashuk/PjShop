using System;

namespace PartyJuice.PJService.ModelsHelper
{
    public class WarehouseModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}